using System;
using System.Collections.Generic;
using System.Text;

namespace evo
{
    [Serializable]
    class node
    {
        public List<link> inputs;
        public List<link> outputs;



        public double value = 0.0;
        
        public node(double initvalue)
        {
            value = initvalue;
            inputs = new List<link>();
            outputs = new List<link>();
        }
    }
}
