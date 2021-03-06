﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNetSPARQL.Nodes;
using System.Collections.Generic;

namespace SPARQLTests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void SELECTObjectVariableNoDistinct()
        {
            var expectedQuery = "SELECT ?uri WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/mayor> ?uri }";

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/mayor"));
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Select(triple, "uri");
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTObjectVariableNoLimit()
        {
            var expectedQuery = "SELECT DISTINCT ?uri WHERE { <http://dbpedia.org/resource/Paris> <http://dbpedia.org/ontology/mayor> ?uri }";

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/mayor"));
            var obj = new VariableNode("uri");
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Select(triple, "uri", true);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTPredicateVariableNoLimit()
        {

            var expectedQuery = "SELECT DISTINCT ?predicate WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate <http://dbpedia.org/resource/Seth_MacFarlane> }";
            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Family_Guy"));
            var predicate = new VariableNode("predicate");
            var obj = new UriNode(new Uri("http://dbpedia.org/resource/Seth_MacFarlane"));
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Select(triple, "predicate", true);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTSubjectVariableNoLimit()
        {
            var expectedQuery = "SELECT DISTINCT ?subject WHERE { ?subject <http://dbpedia.org/ontology/author> <http://dbpedia.org/resource/Seth_MacFarlane> }";

            var subject = new VariableNode("subject");
            var predicate = new UriNode(new Uri("http://dbpedia.org/ontology/author"));
            var obj = new UriNode(new Uri("http://dbpedia.org/resource/Seth_MacFarlane"));
            var triple = new Triple(subject, predicate, obj);

            var query = new dotNetSPARQL.Query.Select(triple, "subject", true);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTSubjectPredicateVariableNoLimit()
        {
            var expectedQuery = "SELECT DISTINCT ?subject, ?predicate WHERE { ?subject ?predicate <http://dbpedia.org/resource/Paris> }";

            var subject = new VariableNode("subject");
            var predicate = new VariableNode("predicate");
            var obj = new UriNode(new Uri("http://dbpedia.org/resource/Paris"));
            var triple = new Triple(subject, predicate, obj);
            var variables = new string[] { "subject", "predicate" };

            var query = new dotNetSPARQL.Query.Select(new List<Triple> { triple }, variables, true);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTPredicateObjectVariableLimit100()
        {
            var expectedQuery = "SELECT DISTINCT ?predicate, ?object WHERE { <http://dbpedia.org/resource/Family_Guy> ?predicate ?object } LIMIT 100";

            var subject = new UriNode(new Uri("http://dbpedia.org/resource/Family_Guy"));
            var predicate = new VariableNode("predicate");
            var obj = new VariableNode("object");
            var triple = new Triple(subject, predicate, obj);
            var variables = new string[] { "predicate", "object" };

            var query = new dotNetSPARQL.Query.Select(new List<Triple> { triple }, variables, true, 100);
            Assert.AreEqual(expectedQuery, query.ToString());
        }

        [TestMethod]
        public void SELECTMultipleTriples()
        {
            var expectedQuery = "SELECT DISTINCT ?object WHERE { <http://dbpedia.org/resource/Family_Guy> <http://dbpedia.org/ontology/author> ?uri . ?uri <http://dbpedia.org/ontology/birthPlace> ?object }";

            var subject = new UriNode("http://dbpedia.org/resource/Family_Guy");
            var predicate = new VariableNode("predicate");
            var obj = new VariableNode("object");
            var firstTriple = new Triple(new UriNode("http://dbpedia.org/resource/Family_Guy"), new UriNode("http://dbpedia.org/ontology/author"), new VariableNode("uri"));
            var secondTriple = new Triple(new VariableNode("uri"), new UriNode("http://dbpedia.org/ontology/birthPlace"), new VariableNode("object"));
            var variables = new string[] { "object" };

            var query = new dotNetSPARQL.Query.Select(new List<Triple> { firstTriple, secondTriple }, variables, true);
            Assert.AreEqual(expectedQuery, query.ToString());
        }
    }
}
