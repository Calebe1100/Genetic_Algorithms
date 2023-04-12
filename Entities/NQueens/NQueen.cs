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
        public double TaxMutation { get; set; } = 0.15;
        public double Avaliation { get; set; } = -1;

        Random Random = new Random();
        public NQueen(int numberQueens)
        {
            this.Genes = new List<int>(numberQueens);
            for (int i = 0; i < numberQueens; i++)
            {
                this.Genes.Add(RandomUtil.Instance.Next(0, numberQueens));
            }
            Console.WriteLine("[{0}]", string.Join(", ", this.Genes));
            this.NumberQueens = numberQueens;
        }

        public double Avaliar()
        {
            int numberColision = 0;

            for (int i = 0; i < NumberQueens - 1; i++)
            {
                for (int j =  i + 1; j < NumberQueens; j++)
                {
                    if (Genes[i] == Genes[j] && i != j)
                    {
                        numberColision++;
                    }
                    if((Genes[j] - Math.Abs(j - i)) == Genes[i] || (Genes[j] + Math.Abs(j - i)) == Genes[i])
                    {
                        numberColision++;
                    }
                }

            }
            this.Avaliation = numberColision;
            return numberColision;
        }

        NQueen IIndividual<NQueen>.Mutate()
        {
            NQueen mutateQueen = new NQueen(NumberQueens);

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
            int repartialParentIndice = Random.Next(parent.Genes.Count);
            List<NQueen> mutateChields = new List<NQueen>();

            if(repartialParentIndice + 3 > NumberQueens - 1)
            {
                repartialParentIndice %= NumberQueens - 1;
            }
            for (int i = 1; i < NumberQueens / 3; i++)
            {
                this.Genes.Insert(repartialParentIndice, parent.Genes[repartialParentIndice]);
                parent.Genes.Insert(repartialParentIndice, this.Genes[repartialParentIndice + 1]);

                this.Genes.RemoveAt(repartialParentIndice + 1);
                parent.Genes.RemoveAt(repartialParentIndice + 1);

                repartialParentIndice++;
                repartialParentIndice %= NumberQueens - 1;
            }
            mutateChields.Add(parent);
            mutateChields.Add(this);
            return mutateChields;

        }
    }
}

