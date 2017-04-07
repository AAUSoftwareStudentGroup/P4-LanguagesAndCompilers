using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Grammar
{
    public class FirstSetTable
    {
        public FirstSetTable()
        {
            SymbolSets = new Dictionary<string, HashSet<string>>();
            ExpansionSets = new Dictionary<(string production, int expansion), HashSet<string>>();
        }

        public Dictionary<string, HashSet<string>> SymbolSets { get; set; }
        public Dictionary<(string production, int expansion), HashSet<string>> ExpansionSets { get; set; }
    }
}
