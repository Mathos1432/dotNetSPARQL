using dotNetSPARQL.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Query
{
    public class Count : BaseQuery
    {
        private VariableNode _resultName;
        private VariableNode _variableToCount;
        private Select _selectQuery;

        public Count(List<Triple> triples, string variableToCount, string resultName = "count")
        {
            _selectQuery = new Select(triples, new string[0]);
            _variableToCount = new VariableNode(variableToCount);
            _resultName = new VariableNode(resultName);
        }

        public override string ToString()
        {
            var select = _selectQuery.ToString();
            var countQuery = select.Insert(select.IndexOf(" WHERE "),
                string.Format(" (COUNT({0}) as {1})", _variableToCount, _resultName));
            return countQuery;
        }
    }
}
