using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetSPARQL.Nodes
{
    public class Triple
    {
        public INode Subject { get; private set; }
        public INode Predicate { get; private set; }
        public INode Object { get; private set; }

        public Triple(INode subject, INode predicate, INode obj)
        {
            Subject = subject;
            Predicate = predicate;
            Object = obj;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Subject, Predicate, Object);
        }
    }
}
