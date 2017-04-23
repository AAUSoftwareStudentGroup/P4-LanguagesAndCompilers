using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Translation
{
    class Relation
    {
        public string Operator { get; set; }
        public List<RelationDomain> LeftDomains { get; set; }
        public List<RelationDomain> RightDomains { get; set; }
    }
}
