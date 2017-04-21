using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Nodes
{
    public class LiteralNode : INode
    {
        private string _value;
        public LiteralNode(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
