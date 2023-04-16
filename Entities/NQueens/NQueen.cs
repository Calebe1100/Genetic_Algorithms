using Project_IA.Interfaces;
using Project_IA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_IA.NQueens
{
    public class NQueen : IIndividual<NQueen>
    {
        public List<int> Genes { get; set; }
        public int NumberQueens { get; set; }
        public double TaxMutation { get; set; }
        public double Avaliation { get; set; } = -1;

        readonly Random Random;
        public NQueen(int numberQueens, double taxMutation)
        {
            Random = new Random();
            this.Genes = new List<int>(numberQueens);
            for (int i = 0; i < numberQueens; i++)
            {
                this.Genes.Add(RandomUtil.Instance.Next(0, numberQueens));
            }
            this.NumberQueens = numberQueens;
            this.TaxMutation = taxMutation;
        }

        public double Avaliar()
        {
            if (this.Avaliation == -1)
            {

                int numberColision = 0;

                for (int i = 0; i < NumberQueens - 1; i++)
                {
                    for (int j = i + 1; j < NumberQueens; j++)
                    {
                        if (Genes[i] == Genes[j] && i != j)
                        {
                            numberColision++;
                        }
                        if ((Genes[j] - Math.Abs(j - i)) == Genes[i] || (Genes[j] + Math.Abs(j - i)) == Genes[i])
                        {
                            numberColision++;
                        }
                    }

                }
                this.Avaliation = numberColision;
                return numberColision;
            }
            return this.Avaliation;
        }

        NQueen IIndividual<NQueen>.Mutate()
        {
            NQueen mutateQueen = new NQueen(NumberQueens, TaxMutation);

            for (int i = 0; i < this.NumberQueens - 1; i++)
            {
                double generateTaxMutation = Random.NextDouble();
                if (generateTaxMutation < TaxMutation)
                {
                    mutateQueen.Genes[i] = this.Genes[i];
                }
                else
                {
                    mutateQueen.Genes[i] = this.Genes[Random.Next(0, NumberQueens - 1)];
                }
            }
            return mutateQueen;
        }

        public List<NQueen> Recombine(NQueen parent)

        {
            int repartialParentIndice = RandomUtil.Instance.Next(1, NumberQueens - 1);
            List<NQueen> mutateChields = new List<NQueen>();

            if (repartialParentIndice + 3 > NumberQueens)
            {
                repartialParentIndice %= NumberQueens;
            }
            for (int i = 1; i <= NumberQueens / 3; i++)
            {
                this.Genes.Insert(repartialParentIndice, parent.Genes[repartialParentIndice]);
                parent.Genes.Insert(repartialParentIndice, this.Genes[repartialParentIndice + 1]);

                this.Genes.RemoveAt(repartialParentIndice + 1);
                parent.Genes.RemoveAt(repartialParentIndice + 1);

                repartialParentIndice++;
                repartialParentIndice %= NumberQueens;
            }
            mutateChields.Add(parent);
            mutateChields.Add(this);
            return mutateChields;

        }

        public List<NQueen> InvertedAvaliations(List<NQueen> individuals, int numberIndividuals)
        {

            var invertedIndividuals = individuals.Select(ind => { return new NQueen(NumberQueens, TaxMutation) { Genes = ind.Genes, Avaliation = (1 / ind.Avaliation), TaxMutation = ind.TaxMutation }; }).ToList();

            var sumAllAvaliations = invertedIndividuals.Sum(ind => ind.Avaliation);

            var numberRandomAvaliation = Random.NextDouble() * sumAllAvaliations;

            double contSum = 0;
            var individualsCalculated = new List<NQueen>();
            for (int i = 0; i < numberIndividuals; i++)
            {
                foreach (var individual in invertedIndividuals)
                {
                    if (contSum > numberRandomAvaliation)
                    {
                        invertedIndividuals.Remove(individual);
                        individualsCalculated.Add(individual);
                        break;
                    }
                    contSum += individual.Avaliation;
                }

            }
            return individualsCalculated.Select(ind => { return new NQueen(NumberQueens, TaxMutation) { Genes = ind.Genes, Avaliation = (1 / ind.Avaliation), TaxMutation = ind.TaxMutation }; }).ToList();
        }
    }
}

