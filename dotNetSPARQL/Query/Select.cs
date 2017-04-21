using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace dotNetSPARQL.Query
{
    public class Select : BaseQuery
    {
        private List<Triple> _triples;
        private string[] _variables;
        private int _limit;
        private bool _distinct;

        public Select(List<Triple> triples, string[] variables, bool distinct = false, int limit = -1)
        {
            _triples = triples;
            _variables = variables;
            _limit = limit;
            _distinct = distinct;
        }

        public Select(Triple triple, string variable = "", bool distinct = false, int limit = -1)
        {
            _triples = new List<Triple> { triple };
            if (!string.IsNullOrWhiteSpace(variable))
            {
                _variables = new string[] { variable };
            }
            else
            {
                _variables = new string[0];
            }
            _limit = limit;
            _distinct = distinct;
        }

        public override string ToString()
        {
            var query = "SELECT " + (_distinct ? "DISTINCT " : "");
            for (int i = 0; i < _variables.Length; i++)
            {
                query += "?" + _variables[i];
                if (i < _variables.Length - 1)
                {
                    query += ", ";
                }
                else
                {
                    query += " ";
                }
            }
            query += "WHERE { ";
            query += CombineTriples(_triples);
            query += " }" + (_limit >= 0 ? " LIMIT " + _limit : "");
            return query;
        }
    }
}
