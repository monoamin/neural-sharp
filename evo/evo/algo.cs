using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;

namespace evo
{
    [Serializable]
    class algo
    {
        public node[] inputLayer = new node[2];
        public node[] hiddenLayer = new node[2];
        public node[] outputLayer = new node[1];
        public List<link> links;

        public algo()
        {
            links = new List<link>();

            inputLayer[0] = new node(0);
            inputLayer[1] = new node(0);
            hiddenLayer[0] = new node(0);
            hiddenLayer[1] = new node(0);
            outputLayer[0] = new node(0);

            foreach (node m in inputLayer)
            {
                foreach (node n in hiddenLayer)
                {
                    link l = new link(m, n);
                    m.outputs.Add(l);
                    n.inputs.Add(l);
                    links.Add(l);
                }
            }

            foreach (node m in hiddenLayer)
            {
                foreach (node n in outputLayer)
                {
                    link l = new link(m, n);
                    m.outputs.Add(l);
                    n.inputs.Add(l);
                    links.Add(l);
                }
            }

            

        }

        public double Run(double a, double b)
        {
            double result = 0.0d;
            inputLayer[0].value = a;
            inputLayer[1].value = b;
            
            foreach (node n in hiddenLayer)
            {
                double value = 0.0d;
                foreach (link j in n.inputs)
                {
                    value += j.inNode.value * j.weight;
                }
                n.value = LogSigmoid(value);
            }

            foreach (node n in outputLayer)
            {
                double value = 0.0d;
                foreach (link j in n.inputs)
                {
                    value += j.inNode.value * j.weight;
                }
                n.value = LogSigmoid(value);
                result =  value;
            }
            return result;
        }

        public double LogSigmoid(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;
            else return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}
