using Project_IA.Entities.OptimizationFunctions;
using Project_IA.OptimizationFunctions;
using System;

namespace Project_IA.Factory
{
    public class DixonPriceIndividualFactory : IIndividualFactory<FunctionTemplate>
    {
        public int Count { get; set; }
        public DixonPriceIndividualFactory(int numberQueens)
        {
            Count = numberQueens;
        }
        public FunctionTemplate GetNewIndividual(double taxMutation)
        {
            var func = new DixonPriceInd(Count, taxMutation);
            Console.WriteLine("[{0}]", string.Join(", ", func.Genes));
            return func;   
        }
    }
}
