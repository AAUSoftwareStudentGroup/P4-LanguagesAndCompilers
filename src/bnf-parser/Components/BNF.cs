using System;
using System.Collections.Generic;

namespace P4.BNF.Components
{
    public class BNF 
    {
        public List<Production> productions;

        public BNF() {
            productions = new List<Production>();
        }
    }
}