using Project_IA.Interfaces;
using System;
using System.Collections.Generic;

namespace Project_IA.NQueens
{
    public class NQueen : IIndividual<NQueen>
    {
        public List<int> Genes { get; set; }
        public int NumberQueens { get; set; }
        public double TaxMutation { get; set; } = 0.15;
        public double Avaliation { get; set; } = -1;

        readonly Random Random = new Random();

        public NQueen(int numberQueens)
        {

            this.Genes = new List<int>(numberQueens);
            for (int i = 0; i < numberQueens; i++)
            {
                this.Genes.Add(Random.Next(0, numberQueens));
                Console.WriteLine(this.Genes[i]);
            }
            this.NumberQueens = numberQueens;
        }

        public double Avaliar()
        {
            throw new NotImplementedException();
        }

        NQueen IIndividual<NQueen>.Mutate()
        {
            NQueen mutateQueen = new NQueen(NumberQueens);

            for (int i = 0; i < this.NumberQueens; i++)
            {
                double generateTaxMutation = Random.NextDouble();
                if (generateTaxMutation > TaxMutation)
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
            int repartialParentIndice = Random.Next(parent.Genes.Count);

            if(repartialParentIndice + 3 > NumberQueens - 1)
            {
                repartialParentIndice %= NumberQueens - 1;
            }
            for (int i = 1; i < NumberQueens / 3; i++)
            {
                this.Genes.RemoveAt(repartialParentIndice);
                this.Genes.Add(parent.Genes[repartialParentIndice]);

                parent.Genes.Add(this.Genes[repartialParentIndice]);

                repartialParentIndice++;
                repartialParentIndice %= NumberQueens - 1;
            }
            return new List<NQueen>();

        }
    }
}

