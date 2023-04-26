using System;
using System.Threading;

namespace Project_IA.Utils
{
    public static class RandomUtil
    {
        private static int seed = Environment.TickCount;
        private static readonly Random random = new Random(Interlocked.Increment(ref seed));

        private static readonly ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
            (() => random);

        public static Random Instance { get { return threadLocal.Value; } }
    }
}

