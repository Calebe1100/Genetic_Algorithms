using Project_IA.Interfaces;
using Project_IA.OptimizationFunctions;
using Project_IA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_IA.Entities.OptimizationFunctions
{
    public abstract class FunctionTemplate : IIndividual<FunctionTemplate>
    {
        public List<double> Genes { get; set; }
        public int NumberGenes { get; set; }
        public bool IsCrossover { get; set; }
        public double TaxMutation { get; set; }
        public double Avaliation { get; set; }
        public bool IsAvaliated { get; set; } = false;

        readonly Random Random;
        readonly GaussianRandom GaussianRandom;
        protected FunctionTemplate(int numberGenes, double taxMutation, bool? isCrossover = true)
        {
            Random = new Random();
            GaussianRandom = new GaussianRandom();
            this.Genes = new List<double>(numberGenes);
            for (double i = 0; i < numberGenes; i++)
            {
                this.Genes.Add(RandomUtil.Instance.Next(0, numberGenes));
            }
            this.NumberGenes = numberGenes;
            this.TaxMutation = taxMutation;
            IsCrossover = isCrossover.Value;
        }

        public abstract FunctionTemplate GetParentToMutation();
        public abstract FunctionTemplate GetParentToRecobination();
        public abstract double GetSumValueAvaliation(List<double> values);

        public double Avaliar()
        {
                this.Avaliation = GetSumValueAvaliation(this.Genes);
                this.IsAvaliated = true;
            return this.Avaliation;
        }

        FunctionTemplate IIndividual<FunctionTemplate>.Mutate()
        {
            FunctionTemplate mutateQueen = GetParentToMutation();


            int numberMutation = 0;
            for (int i = 0; i < this.NumberGenes - 1; i++)
            {
                double generateTaxMutation = Random.NextDouble();
                if (generateTaxMutation < 0.1)
                {
                    mutateQueen.Genes[i] = this.Genes[i] + (GaussianRandom.NextGaussian() * 0.1);
                    numberMutation++;
                }
                else
                {
                    mutateQueen.Genes[i] = this.Genes[Random.Next(0, NumberGenes - 1)];
                }
            }
            if (numberMutation == 0)
            {
                int randomPosition = Random.Next(this.NumberGenes - 1);
                mutateQueen.Genes[randomPosition] = this.Genes[randomPosition] + (GaussianRandom.NextGaussian() * 0.1);
            }
            return mutateQueen;
        }

        public List<FunctionTemplate> Recombine(FunctionTemplate parent)
        {
            List<FunctionTemplate> parentRecombined = new List<FunctionTemplate>();

            FunctionTemplate parentOne = GetParentToRecobination();
            FunctionTemplate parentTwo = GetParentToRecobination();

            if (IsCrossover)
            {
                for (int i = 0; i < parent.NumberGenes; i++)
                {
                    parentOne.Genes[i] = ((this.Genes[i] * 0.67) + (parent.Genes[i] * 0.33));
                    parentTwo.Genes[i] = ((this.Genes[i] * 0.33) + (parent.Genes[i] * 0.67));

                }
            }
            else
            {
                for (int i = 0; i < parent.NumberGenes; i++)
                {
                    double noise = GetNoise();
                    parentOne.Genes[i] = this.Genes[i] + (Math.Abs(noise * (this.Genes[i] - parent.Genes[i])));
                    parentTwo.Genes[i] = this.Genes[i] + (Math.Abs(noise * (this.Genes[i] - parent.Genes[i])));

                }
            }
            parentRecombined.Add(parentOne);
            parentRecombined.Add(parentTwo);

            return parentRecombined;
        }

        public List<FunctionTemplate> InvertedAvaliations(List<FunctionTemplate> individuals, int numberIndividuals)
        {
            return individuals.GetRange(0, numberIndividuals);
        }

        public double GetNoise()
        {
            return 0.1 * GaussianRandom.NextGaussian();
        }

    }
}
