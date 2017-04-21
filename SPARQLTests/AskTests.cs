using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL;

namespace SPARQLTests
{
    [TestClass]
    public class AskTests
    {
        [TestMethod]
        public void ValidASKNoVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Family_Guy");
            var predicate = new Uri("http://dbpedia.org/ontology/author");
            var obj = new Uri("http://dbpedia.org/resource/Seth_MacFarlane");
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.ASK(subject, predicate, obj);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidASKSubjectVariable()
        {
            var subjectVariable = "uri";
            var predicate = new Uri("http://dbpedia.org/ontology/author");
            var obj = new Uri("http://dbpedia.org/resource/Seth_MacFarlane");
            var expectedQuery = "ASK WHERE { ?uri <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.ASK(subjectVariable, predicate, obj);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidASKPredicateVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Family_Guy");
            var predicateVariable = "predicate";
            var obj = new Uri("http://dbpedia.org/resource/Seth_MacFarlane");
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.ASK(subject, predicateVariable, obj);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidASKObjectVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Family_Guy");
            var predicate = new Uri("http://dbpedia.org/ontology/author");
            var objVariable = "uri";
            var expectedQuery = "ASK WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> ?uri }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.ASK(subject, predicate, objVariable);
            Assert.AreEqual(expectedQuery, query);
        }
    }
}