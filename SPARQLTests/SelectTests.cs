using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL;

namespace SPARQLTests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void ValidSELECTObjectVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Paris");
            var predicate = new Uri("http://dbpedia.org/ontology/mayor");
            var objVariable = "uri";
            var expectedQuery = "SELECT DISTINCT ?uri WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/mayor> ?uri }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subject, predicate, objVariable, -1);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidSELECTPredicateVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Family_Guy");
            var predicateVariable = "predicate";
            var obj = new Uri("http://dbpedia.org/resource/Seth_MacFarlane");
            var expectedQuery = "SELECT DISTINCT ?predicate WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subject, predicateVariable, obj, -1);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidSELECTSubjectVariable()
        {
            var subjectVariable = "subject";
            var predicate = new Uri("http://dbpedia.org/ontology/author");
            var obj = new Uri("http://dbpedia.org/resource/Seth_MacFarlane");
            var expectedQuery = "SELECT DISTINCT ?subject WHERE { ?subject <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subjectVariable, predicate, obj, -1);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidSELECTSubjectPredicateVariable()
        {
            var subjectVariable = "uri";
            var predicateVarible = "predicate";
            var obj = new Uri("http://dbpedia.org/resource/Paris");
            var expectedQuery = "SELECT DISTINCT ?uri, ?predicate WHERE { ?uri ?predicate <http://dbpedia.org/resource/Paris> }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subjectVariable, predicateVarible, obj, -1);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidSELECTPredicateObjectVariable()
        {
            var subject = new Uri("http://dbpedia.org/resource/Family_Guy");
            var predicateVariable = "predicate";
            var objectVariable = "obj";
            var expectedQuery = "SELECT DISTINCT ?predicate, ?obj WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate ?obj }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subject, predicateVariable, objectVariable, -1);
            Assert.AreEqual(expectedQuery, query);
        }

        [TestMethod]
        public void ValidSELECTSubjectObjectVariable()
        {
            var subjectVariable = "subject";
            var predicate = new Uri("http://dbpedia.org/ontology/author");
            var objectVariable = "obj";
            var expectedQuery = "SELECT DISTINCT ?subject, ?obj WHERE { ?subject <http://dbpedia.org/ontology/author> ?obj }";
            var queryBuilder = new SPARQL();
            var query = queryBuilder.SELECT(subjectVariable, predicate, objectVariable, -1);
            Assert.AreEqual(expectedQuery, query);
        }
    }
}
