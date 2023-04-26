using Project_IA.Interfaces;
using Project_IA.NQueens;
using Project_IA.OptimizationFunctions;
using System;

namespace Project_IA.Factory
{
    public class RosenbrockIndividualFactory : IIndividualFactory<RosenbrockInd>
    {
        public int Count { get; set; }
        public RosenbrockIndividualFactory(int numberQueens)
        {
            Count = numberQueens;
        }
        public RosenbrockInd GetNewIndividual(double taxMutation)
        {
            var func = new RosenbrockInd(Count, taxMutation);
            Console.WriteLine("[{0}]", string.Join(", ", func.Genes));
            return func;   
        }
    }
}
