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
    }
}
