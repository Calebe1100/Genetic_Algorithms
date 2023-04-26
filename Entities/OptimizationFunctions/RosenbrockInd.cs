using Project_IA.Interfaces;
using Project_IA.Utils;
using System;
using System.Collections.Generic;

namespace Project_IA.OptimizationFunctions
{
    public class RosenbrockInd : IIndividual<RosenbrockInd>
    {
        public List<double> Genes { get; set; }
        public int NumberGenes { get; set; }
        public bool IsCrossover { get; set; }
        public double TaxMutation { get; set; }
        public double Avaliation { get; set; } = -1;

        readonly Random Random;
        readonly GaussianRandom GaussianRandom;
        public RosenbrockInd(int numberQueens, double taxMutation, bool? isCrossover = true)
        {
            Random = new Random();
            GaussianRandom = new GaussianRandom();
            this.Genes = new List<double>(numberQueens);
            for (double i = 0; i < numberQueens; i++)
            {
                this.Genes.Add(RandomUtil.Instance.Next(0, numberQueens));
            }
            this.NumberGenes = numberQueens;
            this.TaxMutation = taxMutation;
            IsCrossover = isCrossover.Value;
        }

        public double Avaliar()
        {
            this.Avaliation = OptimizationFunction.GetOtimizationValue(this.Genes);
            return this.Avaliation;
        }

        RosenbrockInd IIndividual<RosenbrockInd>.Mutate()
        {
            RosenbrockInd mutateQueen = new RosenbrockInd(NumberGenes, TaxMutation);


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

        public List<RosenbrockInd> Recombine(RosenbrockInd parent)
        {
            List<RosenbrockInd> parentRecombined = new List<RosenbrockInd>();

            RosenbrockInd parentOne = new RosenbrockInd(parent.NumberGenes, parent.TaxMutation);
            RosenbrockInd parentTwo = new RosenbrockInd(parent.NumberGenes, parent.TaxMutation);

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

        public List<RosenbrockInd> InvertedAvaliations(List<RosenbrockInd> individuals, int numberIndividuals)
        {
            return individuals.GetRange(0, numberIndividuals);
        }

        public double GetNoise()
        {
            return 0.1 * GaussianRandom.NextGaussian();
        }

    }
}

