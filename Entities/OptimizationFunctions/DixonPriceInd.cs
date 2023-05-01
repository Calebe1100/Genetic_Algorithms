using Project_IA.Entities.OptimizationFunctions;
using Project_IA.Utils;
using System;
using System.Collections.Generic;

namespace Project_IA.OptimizationFunctions
{
    public class DixonPriceInd : FunctionTemplate
    {
        public DixonPriceInd(int numberGenes, double taxMutation, bool? isCrossover = true) : base(numberGenes, taxMutation, isCrossover)
        {
        }

        public override FunctionTemplate GetParentToRecobination()
        {
            return new DixonPriceInd(NumberGenes, TaxMutation);
        }

        public override FunctionTemplate GetParentToMutation()
        {
            return new DixonPriceInd(NumberGenes, TaxMutation);
        }
        public override double GetSumValueAvaliation(List<double> values)
        {
            return OptimizationFunction.GetOtimizationDixonPriceValue(this.Genes);
        }
    }
}

