using Generator.Grammar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Translation
{
    public class RelationDomain
    {
        public string Identifier { get; set; }
        public string Namespace { get; set; }
        public BNF Grammar { get; set; }
    }
}
