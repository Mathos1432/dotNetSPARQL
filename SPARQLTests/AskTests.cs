using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL;
using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace SPARQLTests
{
    [TestClass]
    public class AskTests
    {
        [TestMethod]
        public void ASKNoVariable()
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
        public void ASKSubjectVariable()
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
        public void ASKPredicateVariable()
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
        public void ASKObjectVariable()
        {
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> ?uri }";
            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new UriNode("http://dbpedia.org/ontology/author");
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Ask(triple);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void ASKChainedQuery()
        {
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> ?uri . ?uri <http://dbpedia.org/ontology/birthPlace> ?obj }";
            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new UriNode("http://dbpedia.org/ontology/author");
            var obj = new VariableNode("uri");
            var firstTriple = new Triple(subject, predicate, obj);
            var secondTriple = new Triple(obj, new UriNode("http://dbpedia.org/ontology/birthPlace"), new VariableNode("obj"));

            var query = new dotNetSPARQL.Query.Ask(new List<Triple>() { firstTriple, secondTriple });
            Assert.AreEqual(expectedQuery, query.ToString());
        }
    }
}