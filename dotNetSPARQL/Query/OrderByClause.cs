using dotNetSPARQL.Nodes;

namespace dotNetSPARQL.Query
{
    public class OrderByClause : BaseClause
    {
        private VariableNode _sortVariable;
        private bool _desc;

        public OrderByClause(string sortVariable, bool desc = false)
        {
            _desc = desc;
            _sortVariable = new VariableNode(sortVariable);
        }

        public override string ToString()
        {
            return string.Format("ORDER BY {0}({1})",
                (_desc? "DESC" : "ASC"), _sortVariable);
        }
    }
}
