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

        public GenericIndividual Execute(IIndividualFactory<GenericIndividual> factory, int numberGenericIndividuals, int numberElitism, int numberGeration)
        {
            List<GenericIndividual> initGenericIndividuals = new List<GenericIndividual>(numberGenericIndividuals);

            for (int i = 1; i < numberGenericIndividuals; i++)
            {
                initGenericIndividuals.Add(factory.GetNewIndividual());
            }

            for (int i = 0; i < numberGeration; i++)
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
                bestGenericIndividuals.AddRange(this.GenerateElectism(joinInitRecombindeMutant, numberGenericIndividuals));
                //bestGenericIndividuals.AddRange(this.SpinRoullete(joinInitRecombindeMutant, numberGenericIndividuals - numberElitism));

                initGenericIndividuals = bestGenericIndividuals;
                if(bestGenericIndividuals.Any(bgi => bgi.Avaliar() < 3))
                {
                    Console.WriteLine("Best Individual:" + bestGenericIndividuals.Find(bgi => bgi.Avaliar() < 3));
                }
            }

            return factory.GetNewIndividual();

        }
        private List<GenericIndividual> GenerateRecombineByTwoParent(List<GenericIndividual> initGenericIndividuals)
        {
            List<GenericIndividual> chields = new List<GenericIndividual>(initGenericIndividuals.Count);
            List<GenericIndividual> aux = new List<GenericIndividual>(initGenericIndividuals.Count);

            aux.AddRange(initGenericIndividuals);

            for (int i = 0; i < aux.Count; i++)
            {
                int randomIndiceOne = Random.Next(1, aux.Count);
                int randomIndiceTwo = Random.Next(1, aux.Count);

                GenericIndividual parentOne = aux[randomIndiceOne];
                GenericIndividual parentTwo = aux[randomIndiceTwo];

                initGenericIndividuals.Remove(aux[randomIndiceOne]);
                initGenericIndividuals.Remove(aux[randomIndiceTwo]);

                chields.AddRange(parentOne.Recombine(parentTwo));

            }
            return chields;
        }

        //private IEnumerable<GenericIndividual> SpinRoullete(List<GenericIndividual> joinInitRecombindeMutant, int numberElitism)
        //{
        //    throw new NotImplementedException();
        //}

        private IEnumerable<GenericIndividual> GenerateElectism(List<GenericIndividual> joinInitRecombindeMutant, int numberGenericIndividuals)
        {
            return joinInitRecombindeMutant.OrderBy(el => el.Avaliar()).ToList().GetRange(0, numberGenericIndividuals);
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

