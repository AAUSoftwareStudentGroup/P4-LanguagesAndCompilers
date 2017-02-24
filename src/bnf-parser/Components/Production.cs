using System.Collections.Generic;
using System;

namespace P4.Data
{
    class Production : Symbol
    {
        public List<Expansion> expansions;
        public Production() {
            expansions = new List<Expansion>();
        }

        public bool DerrivesEmpty()
        {
            throw new NotImplementedException();
        }

        public HashSet<Symbol> FollowSet()
        {
            throw new NotImplementedException();
        }

        public HashSet<Symbol> PredictSet(Expansion e)
        {
            if(expansions.Contains(e) == false)
                throw new Exception("Expansion not in production");
            
            HashSet<Symbol> set = e.FirstSet();
            if(this.DerrivesEmpty())
            {
                set.UnionWith(this.FollowSet());
            }
            
            throw new NotImplementedException();
            return set;
        }
    }
}