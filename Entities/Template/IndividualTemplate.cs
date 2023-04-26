using Project_IA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_IA.Entities.Template
{
    abstract class IndividualTemplate<IndividualEntity>
    {
        public List<int> Genes { get; set; }
        public int NumberQueens { get; set; }
        public double TaxMutation { get; set; }
        public double Avaliation { get; set; } = -1;

        readonly Random Random;
        protected IndividualTemplate(int numberQueens, double taxMutation)
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

    }
}
