using Generator.Grammar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Translation
{
    public class RelationDomain
    {
        public string Identifier { get; set; }
        public string DataNamespace { get; set; }
        public string VisitorNamespace { get; set; }
        public BNF Grammar { get; set; }
    }
}
