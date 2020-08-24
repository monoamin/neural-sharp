using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;

namespace evo
{
    class Generation
    {
        public algo[] algos;
        MemoryStream stream;
        public Generation(int childrenCount)
        {
            algos = new algo[childrenCount];
            for (int i = 0; i < childrenCount; i++)
            {
                algos[i] = new algo();
            }
        }
        public Generation(int childrenCount, algo parentAlgo)
        {
            algos = new algo[childrenCount];

            stream = SerializeToStream(parentAlgo);

            for (int i = 0; i < childrenCount; i++)
            {
                algos[i] = (algo)DeserializeFromStream(stream);
            }
        }

        public void Mutate()
        {
            for (int i1 = 0; i1 < algos.Length; i1++)
            {
                for (int i = 0; i < algos[i1].links.Count; i++)
                {
                    double randomMutate = URandom.NextDouble();
                    algos[i1].links[i].weight = ((randomMutate - 0.5) / 5);
                    double weight = algos[i1].links[i].weight;
                }
            }
        }

        public MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }

        public object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return o;
        }
    }
}
