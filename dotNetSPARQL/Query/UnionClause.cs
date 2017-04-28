using dotNetSPARQL.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Query
{
    public class UnionClause : BaseClause
    {
        private List<Triple> _triples;

        public UnionClause(List<Triple> triples)
        {
            _triples = triples;
        }

        public override string ToString()
        {
            var unionClause = "{" + _triples.First().ToString() + "}";
            for (int i = 1; i < _triples.Count(); i++)
            {
                unionClause += " UNION {" + _triples[i].ToString() + "}";
            }
            return unionClause;
        }
    }
}
