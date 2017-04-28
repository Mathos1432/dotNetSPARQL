using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL.Nodes;

namespace SPARQLTests
{
    [TestClass]
    public class ClauseTests
    {
        [TestMethod]
        public void COUNTClause()
        {
            var expectedClause = "(COUNT(?uri) as ?count)";
            var countClause = new dotNetSPARQL.Query.CountClause("uri");
            Assert.AreEqual(expectedClause, countClause.ToString());
        }

        [TestMethod]
        public void ORDERBYDescClause()
        {
            var expectedClause = "ORDER BY DESC(?uri)";
            var orderByClause = new dotNetSPARQL.Query.OrderByClause("uri", true);
            Assert.AreEqual(expectedClause, orderByClause.ToString());
        }

        [TestMethod]
        public void ORDERBYAscClause()
        {
            var expectedClause = "ORDER BY ASC(?uri)";
            var orderByClause = new dotNetSPARQL.Query.OrderByClause("uri", false);
            Assert.AreEqual(expectedClause, orderByClause.ToString());
        }

        [TestMethod]
        public void COUNTQuery()
        {
            var expectedQuery = "SELECT (COUNT(?uri) as ?count) WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/wikiPageExternalLink> ?uri }";

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/wikiPageExternalLink"));
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);
            var countClause = new dotNetSPARQL.Query.CountClause("uri");

            var clauses = new dotNetSPARQL.Query.BaseClause[] { countClause };
            var triples = new List<Triple> { triple };
            var selectCountQuery = new dotNetSPARQL.Query.Select(
                triples, clauses, new string[0]);

            Assert.AreEqual(expectedQuery, selectCountQuery.ToString());
        }

        [TestMethod]
        public void ORDERBYQuery()
        {
            var expectedQuery = "SELECT WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/wikiPageExternalLink> ?uri } ORDER BY DESC(?uri)";

            var subject = new UriNode("http://dbpedia.org/resource/Paris");
            var predicate = new UriNode("http://dbpedia.org/ontology/wikiPageExternalLink");
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);
            var orderByClause = new dotNetSPARQL.Query.OrderByClause("uri", true);

            var clauses = new dotNetSPARQL.Query.BaseClause[] { orderByClause };
            var triples = new List<Triple> { triple };
            var selectCountQuery = new dotNetSPARQL.Query.Select(
                triples, clauses, new string[0]);

            Assert.AreEqual(expectedQuery, selectCountQuery.ToString());
        }

        [TestMethod]
        public void ORDERBYCountQuery()
        {
            var expectedQuery = "SELECT (COUNT(?uri) as ?count) WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/wikiPageExternalLink> ?uri } ORDER BY DESC(?count)";

            var subject = new UriNode("http://dbpedia.org/resource/Paris");
            var predicate = new UriNode("http://dbpedia.org/ontology/wikiPageExternalLink");
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);
            var orderByClause = new dotNetSPARQL.Query.OrderByClause("count", true);
            var countClause = new dotNetSPARQL.Query.CountClause("uri");

            var clauses = new dotNetSPARQL.Query.BaseClause[] { orderByClause, countClause };
            var triples = new List<Triple> { triple };
            var selectCountQuery = new dotNetSPARQL.Query.Select(
                triples, clauses, new string[0]);

            Assert.AreEqual(expectedQuery, selectCountQuery.ToString());
        }

        [TestMethod]
        public void UNIONClause()
        {
            var expectedQuery = "{<http://dbpedia.org/resource/Paris> <http://www.w3.org/2000/01/rdf-schema#label> ?label} UNION {<http://dbpedia.org/resource/Montreal> <http://www.w3.org/2000/01/rdf-schema#label> ?label}";

            var subject = new UriNode("http://dbpedia.org/resource/Paris");
            var predicate = new UriNode("http://www.w3.org/2000/01/rdf-schema#label");
            var obj = new VariableNode("label");
            var triple = new Triple(subject, predicate, obj);
            var triples = new List<Triple> { triple };
            subject = new UriNode("http://dbpedia.org/resource/Montreal");
            triple = new Triple(subject, predicate, obj);
            triples.Add(triple);
            var unionClause = new dotNetSPARQL.Query.UnionClause(triples);
            Assert.AreEqual(expectedQuery, unionClause.ToString());
        }

        [TestMethod]
        public void SELECTUnionClause()
        {
            var expectedQuery = "SELECT ?uri, ?label WHERE {{ ?uri <http://www.w3.org/2000/01/rdf-schema#label> ?label } {<http://dbpedia.org/resource/Paris> <http://www.w3.org/2000/01/rdf-schema#label> ?label} UNION {<http://dbpedia.org/resource/Montreal> <http://www.w3.org/2000/01/rdf-schema#label> ?label}}";

            var subject = new UriNode("http://dbpedia.org/resource/Paris");
            var predicate = new UriNode("http://www.w3.org/2000/01/rdf-schema#label");
            var obj = new VariableNode("label");
            var triple = new Triple(subject, predicate, obj);
            var triples = new List<Triple> { triple };
            subject = new UriNode("http://dbpedia.org/resource/Montreal");
            triple = new Triple(subject, predicate, obj);
            triples.Add(triple);
            var unionClause = new dotNetSPARQL.Query.UnionClause(triples);
            triple = new Triple(
                new VariableNode("uri"),
                new UriNode("http://www.w3.org/2000/01/rdf-schema#label"),
                new VariableNode("label"));
            var select = new dotNetSPARQL.Query.Select(new List<Triple>() { triple }, new dotNetSPARQL.Query.BaseClause[] { unionClause }, new string[] { "uri", "label" });
            Assert.AreEqual(expectedQuery, select.ToString());
        }

        [TestMethod]
        public void SELECTUnionOrderByClauses()
        {
            var expectedQuery = "SELECT ?uri, ?label WHERE {{ ?uri <http://www.w3.org/2000/01/rdf-schema#label> ?label } {<http://dbpedia.org/resource/Paris> <http://www.w3.org/2000/01/rdf-schema#label> ?label} UNION {<http://dbpedia.org/resource/Montreal> <http://www.w3.org/2000/01/rdf-schema#label> ?label}} ORDER BY ASC(?label)";
            var subject = new UriNode("http://dbpedia.org/resource/Paris");
            var predicate = new UriNode("http://www.w3.org/2000/01/rdf-schema#label");
            var obj = new VariableNode("label");
            var triple = new Triple(subject, predicate, obj);
            var triples = new List<Triple> { triple };
            subject = new UriNode("http://dbpedia.org/resource/Montreal");
            triple = new Triple(subject, predicate, obj);
            triples.Add(triple);
            var unionClause = new dotNetSPARQL.Query.UnionClause(triples);
            triple = new Triple(
                new VariableNode("uri"),
                new UriNode("http://www.w3.org/2000/01/rdf-schema#label"),
                new VariableNode("label"));
            var orderByClause = new dotNetSPARQL.Query.OrderByClause("label");
            var select = new dotNetSPARQL.Query.Select(new List<Triple>() { triple }, new dotNetSPARQL.Query.BaseClause[] { orderByClause, unionClause }, new string[] { "uri", "label" });
            Assert.AreEqual(expectedQuery, select.ToString());
        }
    }
}
