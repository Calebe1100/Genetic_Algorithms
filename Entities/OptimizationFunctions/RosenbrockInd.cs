using Project_IA.Entities.OptimizationFunctions;
using Project_IA.Utils;
using System;
using System.Collections.Generic;

namespace Project_IA.OptimizationFunctions
{
    public class RosenbrockInd : FunctionTemplate
    {
        public RosenbrockInd(int numberGenes, double taxMutation, bool? isCrossover = true) : base(numberGenes, taxMutation, isCrossover)
        {
            this.Genes = new List<double>(numberGenes);
            for (int i = 0; i < numberGenes; i++)
            {
                double min = -5;
                double max = 10;
                this.Genes.Add(min + RandomUtil.Instance.NextDouble() * (max - min));
            }
        }

        public override FunctionTemplate GetParentToRecobination()
        {
            return new RosenbrockInd(NumberGenes, TaxMutation);
        }

        public override FunctionTemplate GetParentToMutation()
        {
            return new RosenbrockInd(NumberGenes, TaxMutation);
        }

        public override double GetSumValueAvaliation(List<double> values)
        {
            return OptimizationFunction.GetOtimizationRosenBrockValue(this.Genes);
        }
    }
}

