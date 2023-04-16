using Project_IA.Interfaces;
using Project_IA.NQueens;
using System;

namespace Project_IA.Factory
{
    public class NQueensIndividualFactory : IIndividualFactory<NQueen>
    {
        public int Count { get; set; }
        public NQueensIndividualFactory(int numberQueens)
        {
            Count = numberQueens;
        }
        public NQueen GetNewIndividual(double taxMutation)
        {
            var nQuee = new NQueen(Count, taxMutation);
            Console.WriteLine("[{0}]", string.Join(", ", nQuee.Genes));
            return nQuee;   
        }

    }
}
