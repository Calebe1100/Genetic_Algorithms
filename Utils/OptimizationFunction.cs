using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_IA.Utils
{
    public static class OptimizationFunction
    {
        public static double GetOtimizationValue(List<double> values)
        {
            double fitnessResult = 0;
            for (int i = 0; i < values.Count - 1; i++)
            {
                fitnessResult += 100 * Math.Pow((values[i + 1] - Math.Pow(values[i], 2)), 2) + Math.Pow((values[i] - 1), 2);
            }

            return fitnessResult;
        }
    }

}
