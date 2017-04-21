using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Nodes
{
    public class VariableNode : INode
    {
        private string _variableName;

        public VariableNode(string variableName)
        {
            _variableName = variableName;
        }

        public override string ToString()
        {
            return "?" + _variableName;
        }
    }
}
