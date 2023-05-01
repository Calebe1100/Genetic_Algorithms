using Project_IA.Entities.OptimizationFunctions;
using Project_IA.Factory;
using Project_IA.FGA;
using Project_IA.NQueens;
using Project_IA.OptimizationFunctions;
using System;

namespace Project_IA
{
    public class FunctionsController
    {
        public void Execute()
        {
            var inputConsole = "";
            do
            {
                try
                {
                    int numberQueens = 10;
                    double taxMutation = 0.15;
                    int numberPopulation = 20;
                    int numberElitism = 2;
                    int numberGeneration = 2000;
                    IIndividualFactory<FunctionTemplate> factory = new DixonPriceIndividualFactory(numberQueens);

                    Fga<FunctionTemplate> fga = new Fga<FunctionTemplate>();

                    FunctionTemplate bestIndividual = fga.Execute(factory, numberPopulation, numberElitism, numberGeneration, taxMutation);

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Melhor Indivíduo do cíclo:");
                    Console.WriteLine("[{0}]", string.Join(", ", bestIndividual.Genes));
                    Console.WriteLine("Taxa de mutação: " + bestIndividual.TaxMutation);
                    Console.WriteLine("Avaliação: " + bestIndividual.Avaliation);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                Console.WriteLine("Pressione y para rodar novamente ou qualquer outra tecla pra sair para sair... ");
                inputConsole = Console.ReadLine();
            } while (inputConsole == "y");
        }
    }
}
