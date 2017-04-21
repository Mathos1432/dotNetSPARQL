using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL.Nodes;

namespace SPARQLTests
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void ValidCount()
        {
            var expectedQuery = "SELECT (COUNT(?uri) as ?count) WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/location> ?uri }";

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/location"));
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);

            var countQuery = new dotNetSPARQL.Query.Count(new List<Triple>() { triple }, "uri");
            Assert.AreEqual(expectedQuery, countQuery.ToString());
        }
    }
}
