using System;
using System.Collections.Generic;

namespace P4.BNF.Parser
{
    class Production : Symbol
    {
        public List<Expansion> expansions;
        public Production() {
            expansions = new List<Expansion>();
        }
    }
}