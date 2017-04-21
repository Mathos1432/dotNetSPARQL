using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace dotNetSPARQL.Query
{
    /// <summary>
    /// Base class for a query. Provides methods that can be shared for all 
    /// types of queries and forces overriding of the ToString() operator.
    /// </summary>
    public abstract class BaseQuery
    {
        protected string CombineTriples(List<Triple> triples)
        {
            var query = "";
            for (int i = 0; i < triples.Count; i++)
            {
                query += triples[i].ToString();
                if (i < triples.Count - 1)
                {
                    query += " . ";
                }
            }
            return query;
        }

        /// <summary>
        /// Converts the query object to a SPARQL query string.
        /// </summary>
        /// <returns>A valid SPARQL query.</returns>
        public abstract override string ToString();
    }
}
