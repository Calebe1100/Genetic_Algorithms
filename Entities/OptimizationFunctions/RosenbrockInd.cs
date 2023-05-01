﻿using Project_IA.Entities.OptimizationFunctions;
using Project_IA.Utils;
using System;
using System.Collections.Generic;

namespace Project_IA.OptimizationFunctions
{
    public class RosenbrockInd : FunctionTemplate
    {
        public RosenbrockInd(int numberGenes, double taxMutation, bool? isCrossover = true) : base(numberGenes, taxMutation, isCrossover)
        {
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

