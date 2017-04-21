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

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/wikiPageExternalLink"));
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

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/wikiPageExternalLink"));
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
    }
}
