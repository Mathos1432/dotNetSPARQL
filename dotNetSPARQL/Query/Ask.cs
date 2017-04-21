using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace dotNetSPARQL.Query
{
    public class Ask : BaseQuery
    {
        const int DEFAULT_LIMIT = 100;

        private List<Triple> _triples;

        public Ask(List<Triple> triples)
        {
            _triples = triples;
        }

        public Ask(Triple triple)
        {
            _triples = new List<Triple> { triple };
        }

        public override string ToString()
        {
            var query = "ASK WHERE { ";
            query += CombineTriples(_triples);
            query += " }";
            return query;
        }
    }
}
