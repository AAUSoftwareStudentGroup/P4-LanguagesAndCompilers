using System;
using System.Collections.Generic;

namespace P4.BNF.Components
{
    public class Production : Symbol
    {
        public List<Expansion> expansions;
        public Production() {
            expansions = new List<Expansion>();
        }
    }
}