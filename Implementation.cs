﻿using Project_IA.Factory;
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
            NQueen bestIndividual;
            int numberItarations = 0;
            do
            {
                double taxMutation = 0.15;
                int numberPopulation = 20;
                int numberElitism = 4;
                int numberGeneration = 1000;
                IIndividualFactory<NQueen> factory = new NQueensIndividualFactory(4);

                Fga<NQueen> fga = new Fga<NQueen>();

                bestIndividual = fga.Execute(factory, numberPopulation, numberElitism, numberGeneration);
                numberItarations++;

            } while(bestIndividual.Avaliation != 0);


                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Melhor Indivíduo:");
                Console.WriteLine("[{0}]", string.Join(", ", bestIndividual.Genes), "Taxa de mutação: ",
                    bestIndividual.TaxMutation, "Avaliação", bestIndividual.Avaliation);
                Console.WriteLine("Taxa de mutação: " + bestIndividual.TaxMutation);
                Console.WriteLine("Avaliação: " + bestIndividual.Avaliation);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Numero de iterações até melhor indivíduo:" + numberItarations);
        }
    }
} 
