using System;
using System.Collections.Generic;
using System.Text;

namespace evo
{
    [Serializable]
    class link
    {
        public double weight;
        public node outNode;
        public node inNode;

        public link(double weight)
        {
            this.weight = weight;
        }

        public link(node from, node to)
        {
            this.weight = 1.0d;
            this.outNode = to;
            this.inNode = from;
        }


    }
}
