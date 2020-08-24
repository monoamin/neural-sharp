using System;
using System.Collections.Generic;
using System.Text;

namespace evo
{
    static class URandom
    {
        static Random r = new Random();

        static double lastRandom = 0.0;
        static double newRandom = 0.0;

        public static double NextDouble()
        {
            while (newRandom == lastRandom)
            {
                newRandom = r.NextDouble();
            }
            lastRandom = newRandom;
            return newRandom;
        }
    }
}
