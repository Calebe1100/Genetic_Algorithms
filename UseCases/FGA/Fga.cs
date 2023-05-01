using Project_IA.Factory;
using Project_IA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_IA.FGA
{
    public class Fga<GenericIndividual> where GenericIndividual : IIndividual<GenericIndividual>
    {
        public readonly Random Random = new Random();

        public GenericIndividual Execute(IIndividualFactory<GenericIndividual> factory, int numberGenericIndividuals, int numberElitism, int numberGeration, double taxMutation)
        {
            List<GenericIndividual> initGenericIndividuals = new List<GenericIndividual>(numberGenericIndividuals);

            for (int i = 1; i <= numberGenericIndividuals; i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Indivíduo: " + i);
                var individual = factory.GetNewIndividual(taxMutation);
                initGenericIndividuals.Add(individual);
            }

            for (int i = 1; i <= numberGeration; i++)
            {

                // Recombine
                var chieldsRecombined = this.GenerateRecombineByTwoParent(initGenericIndividuals);

                // Mutate
                var chieldsMutated = this.GenerateMutant(initGenericIndividuals);

                // Join
                List<GenericIndividual> joinInitRecombindeMutant = new List<GenericIndividual>(numberGenericIndividuals);
                joinInitRecombindeMutant.AddRange(initGenericIndividuals);
                joinInitRecombindeMutant.AddRange(chieldsRecombined);
                joinInitRecombindeMutant.AddRange(chieldsMutated);

                //Generate bests
                List<GenericIndividual> bestGenericIndividuals = new List<GenericIndividual>(numberGenericIndividuals);
                bestGenericIndividuals.AddRange(this.GenerateElectism(joinInitRecombindeMutant, numberElitism));
                bestGenericIndividuals.AddRange(this.SpinRoullete(joinInitRecombindeMutant, numberGenericIndividuals - numberElitism));

                initGenericIndividuals = bestGenericIndividuals;

                Console.WriteLine("Geração: " + i);
                Console.WriteLine("-------------------");
                Console.WriteLine("Avaliação: " + initGenericIndividuals[0].Avaliar());
            }

            return initGenericIndividuals[0];

        }
        private List<GenericIndividual> GenerateRecombineByTwoParent(List<GenericIndividual> initGenericIndividuals)
        {
            List<GenericIndividual> chields = new List<GenericIndividual>(initGenericIndividuals.Count);
            List<GenericIndividual> aux = new List<GenericIndividual>(initGenericIndividuals.Count);

            aux.AddRange(initGenericIndividuals);

            for (int i = 0; i < initGenericIndividuals.Count / 2; i++)
            {
                int randomIndiceOne = Random.Next(0, aux.Count - 1);
                int randomIndiceTwo = Random.Next(0, aux.Count - 1);

                GenericIndividual parentOne = aux[randomIndiceOne];
                GenericIndividual parentTwo = aux[randomIndiceTwo];

                aux.Remove(aux[randomIndiceOne]);
                aux.Remove(aux[randomIndiceTwo]);

                chields.AddRange(parentOne.Recombine(parentTwo));

            }
            return chields;
        }

        private IEnumerable<GenericIndividual> SpinRoullete(List<GenericIndividual> joinInitRecombindeMutant, int numberIndividuals)
        {
            var invertedIndividuals = joinInitRecombindeMutant.FirstOrDefault().InvertedAvaliations(joinInitRecombindeMutant, numberIndividuals);

            return invertedIndividuals;
        }

        private IEnumerable<GenericIndividual> GenerateElectism(List<GenericIndividual> joinInitRecombindeMutant, int numberElitism)
        {
            joinInitRecombindeMutant.ForEach(el => el.Avaliar());

            var orderAvaliators = joinInitRecombindeMutant.OrderBy(el => el.Avaliar()).ToList();
            orderAvaliators = orderAvaliators.GetRange(0, numberElitism);
            return orderAvaliators;
        }

        private List<GenericIndividual> GenerateMutant(List<GenericIndividual> initGenericIndividuals)
        {
            List<GenericIndividual> mutants = new List<GenericIndividual>();

            for (int i = 0; i < initGenericIndividuals.Count; i++)
            {
                GenericIndividual genericIndividual = initGenericIndividuals[i].Mutate();

                mutants.Add(genericIndividual);
            }
            return mutants;
        }


    }
}

