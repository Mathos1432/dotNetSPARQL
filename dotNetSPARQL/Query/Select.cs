using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace dotNetSPARQL.Query
{
    public class Select : BaseQuery
    {
        const int DEFAULT_LIMIT = 100;

        private List<Triple> _triples;
        private string[] _variables;
        private int _limit;
        private bool _distinct;

        public Select(string[] variables, List<Triple> triples, bool distinct = false, int limit = DEFAULT_LIMIT)
        {
            _triples = triples;
            _variables = variables;
            _limit = limit;
            _distinct = distinct;
        }

        public Select(string variable, Triple triple, bool distinct = false, int limit = DEFAULT_LIMIT)
        {
            _triples = new List<Triple> { triple };
            _variables = new string[] { variable };
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
