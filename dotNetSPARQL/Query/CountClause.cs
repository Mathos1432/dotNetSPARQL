using dotNetSPARQL.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Query
{
    public class CountClause : BaseClause
    {
        private VariableNode _resultName;
        private VariableNode _variableToCount;

        public CountClause(string variableToCount, string resultName = "count")
        {
            _variableToCount = new VariableNode(variableToCount);
            _resultName = new VariableNode(resultName);
        }

        public override string ToString()
        {
            return string.Format("(COUNT({0}) as {1})", _variableToCount, _resultName);
        }
    }
}
