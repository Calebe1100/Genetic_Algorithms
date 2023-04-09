using Project_IA.Factory;
using Project_IA.FGA;
using Project_IA.NQueens;
using System;

namespace Project_IA
{
    public class Implementation
    {
        protected Implementation()
        {

        }
        public static void Main(string[] args)
        {
            double taxMutation = 0.15;
            int numberPopulation = 20;
            int numberElitism = 4;
            int numberGeneration = 1000;
            IIndividualFactory<NQueen> factory = new NQueensIndividualFactory(9);

            Fga<NQueen> fga = new Fga<NQueen>();

            NQueen bestIndividual = fga.Execute(factory, numberPopulation, numberElitism, numberGeneration);

            Console.WriteLine(bestIndividual.ToString());
            var obj = new NQueen(20);

        }
    }
} 
