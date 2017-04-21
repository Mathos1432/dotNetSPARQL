using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Nodes
{
    public class LiteralNode : INode
    {
        private string _value;
        private string _language;
        public LiteralNode(string value, string language = "")
        {
            _value = value;
            _language = language;
        }

        public override string ToString()
        {
            return "\"" + _value + "\"" + (string.IsNullOrWhiteSpace(_language) ? "" : "@" + _language);
        }
    }
}
