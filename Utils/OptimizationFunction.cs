using System;
using System.Collections.Generic;

namespace Project_IA.Utils
{
    public static class OptimizationFunction
    {
        public static double GetOtimizationRosenBrockValue(List<double> values)
        {
            double fitnessResult = 0;
            for (int i = 1; i < values.Count - 1; i++)
            {
                fitnessResult += 100 * Math.Pow((values[i + 1] - Math.Pow(values[i], 2)), 2) + Math.Pow((values[i] - 1), 2);
            }

            return fitnessResult;
        }

        public static double GetOtimizationDixonPriceValue(List<double> values)
        {
            int n = values.Count;
            double fitnessResult = Math.Pow(values[0] - 1, 2);
            for (int i = 1; i < n; i++)
            {
                double xi = values[i];
                fitnessResult += (i + 1) * Math.Pow((2 * xi * xi) - values[i - 1], 2);
            }
            return fitnessResult;
        }

    }

}
