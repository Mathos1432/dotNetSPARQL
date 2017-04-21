using dotNetSPARQL.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Query
{
    public class Ask
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
            for (int i = 0; i < _triples.Count; i++)
            {
                query += _triples[i].ToString();
                if (i < _triples.Count - 1)
                {
                    query += " . ";
                }
            }
            query += " }";
            return query;
        }
    }
}
