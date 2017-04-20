using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL
{
    public class SPARQL
    {
        const int DEFAULT_LIMIT = 100;

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the object location.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="predicate"></param>
        /// <param name="variableName"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(Uri subject, Uri predicate, string variableName, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + variableName + " WHERE { ";
            requestString += FormatUri(subject) + " " + FormatUri(predicate) + " ?" + variableName;
            requestString += " }";
            return requestString;
        }

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the predicate location.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="predicate"></param>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(Uri subject, string variableName, Uri obj, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + variableName + " WHERE { ";
            requestString += FormatUri(subject) + " ?" + variableName + " " + FormatUri(obj);
            requestString += " }";
            return requestString;
        }

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the subject location.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="predicate"></param>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(string variableName, Uri predicate, Uri obj, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + variableName + " WHERE { ";
            requestString += "?" + variableName + " " + FormatUri(predicate) + " " + FormatUri(obj);
            requestString += " }";
            return requestString;
        }

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the subject location.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="predicate"></param>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(string subjectVariable, Uri predicate, string objectVariable, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + subjectVariable + ", ?" + objectVariable + " WHERE { ";
            requestString += "?" + subjectVariable + " " + FormatUri(predicate) + " ?" + objectVariable;
            requestString += " }";
            return requestString;
        }

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the subject location.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="predicate"></param>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(Uri subject, string predicateVariable, string objectVariable, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + predicateVariable + ", ?" + objectVariable + " WHERE { ";
            requestString += FormatUri(subject) + " ?" + predicateVariable + " ?" + objectVariable;
            requestString += " }";
            return requestString;
        }

        /// <summary>
        /// Returns a Sparql SELECT query with the variable in the subject location.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="predicate"></param>
        /// <param name="obj"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string SELECT(string subjectVariable, string predicateVariable, Uri obj, int limit = DEFAULT_LIMIT)
        {
            var requestString = "SELECT DISTINCT ?" + subjectVariable + ", ?" + predicateVariable + " WHERE { ";
            requestString += "?" + subjectVariable + " ?" + predicateVariable + " " + FormatUri(obj);
            requestString += " }";
            return requestString;
        }

        private string FormatUri(Uri uri)
        {
            return "<" + uri.OriginalString + ">";
        }
    }
}
