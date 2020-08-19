using System;
using System.Collections.Generic;
using System.Text;

namespace evo
{
    class URandom
    {
        Random r;

        double lastRandom = 0.0;
        double newRandom = 0.0;
        public URandom()
        {
            r = new Random();
            lastRandom = r.NextDouble();
        }

        public double NextDouble()
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
