using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Nodes
{
    public class UriNode : INode
    {
        private Uri _uri;
        public UriNode(Uri uri)
        {
            _uri = uri;
        }

        public UriNode(string uri)
        {
            _uri = new Uri(uri);
        }

        public override string ToString()
        {
            return "<" + _uri.OriginalString + ">";
        }
    }
}
