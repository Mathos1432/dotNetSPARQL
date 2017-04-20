﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL
{
    public class SPARQL
    {
        const int DEFAULT_LIMIT = 100;
        const string VARIABLE_FORMAT = "?{0}";
        const string URI_FORMAT = "<{0}>";
        const string PREFIX_FORMAT = "PREFIX {0}:<{1}>";

        const string SELECT_DISTINCT = "SELECT DISTINCT ?{0} WHERE ";
        const string SELECT_DISTINCT_TWO_VARIABLES = "SELECT DISTINCT ?{0}, ?{1} WHERE ";

        const string ASK_WHERE = "ASK WHERE ";

        #region SELECT
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
            var requestString = string.Format(SELECT_DISTINCT, variableName) + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += "}";
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
            var requestString = string.Format(SELECT_DISTINCT, variableName) + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += "}";
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
            var requestString = string.Format(SELECT_DISTINCT, variableName) + "{ ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += "}";
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
            var requestString = string.Format(SELECT_DISTINCT_TWO_VARIABLES, subjectVariable, objectVariable) + "{ ";
            requestString += string.Format(VARIABLE_FORMAT, subjectVariable) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(VARIABLE_FORMAT, objectVariable) + " ";
            requestString += "}";
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
            var requestString = string.Format(SELECT_DISTINCT_TWO_VARIABLES, predicateVariable, objectVariable) + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(VARIABLE_FORMAT, predicateVariable) + " ";
            requestString += string.Format(VARIABLE_FORMAT, objectVariable) + " ";
            requestString += "}";
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
            var requestString = string.Format(SELECT_DISTINCT_TWO_VARIABLES, subjectVariable, predicateVariable) + "{ ";
            requestString += string.Format(VARIABLE_FORMAT, subjectVariable) + " ";
            requestString += string.Format(VARIABLE_FORMAT, predicateVariable) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += " }";
            return requestString;
        }
        #endregion SELECT
        #region ASK
        public string ASK(Uri subject, Uri predicate, Uri obj)
        {
            var requestString = ASK_WHERE + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += "}";
            return requestString;
        }

        public string ASK(Uri subject, Uri predicate, string variableName)
        {
            var requestString = ASK_WHERE + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += "}";
            return requestString;
        }

        public string ASK(Uri subject, string variableName, Uri obj)
        {
            var requestString = ASK_WHERE + "{ ";
            requestString += string.Format(URI_FORMAT, subject) + " ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += "}";
            return requestString;
        }

        public string ASK(string variableName, Uri predicate, Uri obj)
        {
            var requestString = ASK_WHERE + "{ ";
            requestString += string.Format(VARIABLE_FORMAT, variableName) + " ";
            requestString += string.Format(URI_FORMAT, predicate) + " ";
            requestString += string.Format(URI_FORMAT, obj) + " ";
            requestString += "}";
            return requestString;
        }
        #endregion ASK
    }
}