using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL;
using dotNetSPARQL.Nodes;

namespace SPARQLTests
{
    [TestClass]
    public class AskTests
    {
        [TestMethod]
        public void ValidASKNoVariable()
        {

            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";

            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new UriNode("http://dbpedia.org/ontology/author");
            var obj = new UriNode("http://dbpedia.org/resource/Seth_MacFarlane");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Ask(triple);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void ValidASKSubjectVariable()
        {
            var expectedQuery = "ASK WHERE { ?uri <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";

            var subject = new VariableNode("uri");
            var predicate = new UriNode("http://dbpedia.org/ontology/author");
            var obj = new UriNode("http://dbpedia.org/resource/Seth_MacFarlane");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Ask(triple);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void ValidASKPredicateVariable()
        {
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new VariableNode("predicate");
            var obj = new UriNode("http://dbpedia.org/resource/Seth_MacFarlane");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Ask(triple);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void ValidASKObjectVariable()
        {
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> ?uri }";
            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new UriNode("http://dbpedia.org/ontology/author");
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Ask(triple);
            Assert.AreEqual(expectedQuery, query.ToString());
        }
    }
}