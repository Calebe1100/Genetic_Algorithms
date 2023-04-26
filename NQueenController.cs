using Project_IA.Factory;
using Project_IA.FGA;
using Project_IA.NQueens;
using System;

namespace Project_IA
{
    public static class NQueenController
    {
        public static void Main()
        {
            var func = new FunctionsController();
            func.Execute();
            //var inputConsole = "";
            //do
            //{
            //    try
            //    {
            //    Console.WriteLine("---------------Algoritmo Genético--------------------");
            //    Console.WriteLine("Digite o número de rainhas: Ex: 4");
            //    int numberQueens = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Digite a taxa de mutação (0 a 1) Ex 0.15:");
            //    double taxMutation = double.Parse(Console.ReadLine());
            //    Console.WriteLine("Digite o número da população: Ex: 20");
            //    int numberPopulation = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Digite o número de elitismo: Ex: 4");
            //    int numberElitism = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Digite o número de gerações: Ex: 1000");
            //    int numberGeneration = int.Parse(Console.ReadLine());
            //    IIndividualFactory<NQueen> factory = new NQueensIndividualFactory(numberQueens);

            //    Fga<NQueen> fga = new Fga<NQueen>();

            //    NQueen bestIndividual = fga.Execute(factory, numberPopulation, numberElitism, numberGeneration, taxMutation);

            //    Console.WriteLine("-----------------------------------");
            //    Console.WriteLine("Melhor Indivíduo do cíclo:");
            //    Console.WriteLine("[{0}]", string.Join(", ", bestIndividual.Genes));
            //    Console.WriteLine("Taxa de mutação: " + bestIndividual.TaxMutation);
            //    Console.WriteLine("Avaliação: " + bestIndividual.Avaliation);
            //    } catch(Exception e)
            //    {
            //        Console.WriteLine("Error: " + e.Message);
            //    }
            //    Console.WriteLine("Pressione y para rodar novamente ou qualquer outra tecla pra sair para sair... ");
            //    inputConsole = Console.ReadLine();
            //} while (inputConsole == "y");
        }
    }
}
