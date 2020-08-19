using System;
using System.Collections.Generic;
using System.Text;

namespace evo
{
    class Generation
    {
        public algo[] algos;
        URandom uRandom;
        public Generation(int childrenCount)
        {
            uRandom = new URandom();
            algos = new algo[childrenCount];
            for (int i = 0; i < childrenCount; i++)
            {
                algos[i] = new algo();
            }
        }
        public Generation(int childrenCount, algo parentAlgo)
        {
            uRandom = new URandom();
            algos = new algo[childrenCount];
            for (int i = 0; i < childrenCount; i++)
            {
                algos[i] = parentAlgo;
            }
        }

        public void Mutate()
        {
            for (int i1 = 0; i1 < algos.Length; i1++)
            {
                for (int i = 0; i < algos[i1].links.Count; i++)
                {
                    double randomMutate = uRandom.NextDouble();
                    algos[i1].links[i].weight = ((randomMutate - 0.5) / 5);
                    double weight = algos[i1].links[i].weight;
                }
            }
        }
    }
}
