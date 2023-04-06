using Project_IA.NQueens;

namespace Project_IA.Factory
{
    public class NQueensIndividualFactory : IIndividualFactory<NQueen>
    {
        public int Count { get; set; }
        public NQueensIndividualFactory(int numberQueens)
        {
            Count = numberQueens;
        }
        public NQueen GetNewIndividual()
        {
            return new NQueen(Count);
        }

    }
}
