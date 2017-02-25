using System.Collections.Generic;
using System;

namespace P4.Data
{
    public class Production : Symbol
    {
        public List<Expansion> expansions;
        public Production() {
            expansions = new List<Expansion>();
        }

        public override bool DerivesEmpty()
        {
            if(this.derivesEmpty != null)
                return this.derivesEmpty.Value;

            this.derivesEmpty = false;
            foreach(Expansion e in expansions)
            {
                foreach(Symbol s in e.symbols)
                {
                    if(s.DerivesEmpty()){
                        this.derivesEmpty = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public HashSet<Symbol> FollowSet(BNF bnf)
        {
            if(this.followSet != null)
            {
                return this.followSet;
            }

            this.followSet = new HashSet<Symbol>();
            // foreach occurence of `this` in any expansion in BNF
            foreach(Production p in bnf.productions)
            {
                foreach(Expansion e in p.expansions)
                {
                    for(int i = 0; i < e.symbols.Count; i++)
                    {
                        Symbol s = e.symbols[i];
                        if(s == this)
                        {
                            if(i < e.symbols.Count-1)
                            {
                                Expansion tail = e.Tail(i);
                                followSet.UnionWith(tail.FirstSet());
                                if(tail.DerivesEmpty())
                                {
                                    followSet.UnionWith(p.FollowSet(bnf));
                                }
                            }
                            else
                            {
                                followSet.UnionWith(p.FollowSet(bnf));
                            }
                        }
                    }
                }
            }
            return followSet;
        }

        public override HashSet<Symbol> FirstSet()
        {
            if(firstSet != null)
            {
                return firstSet;
            }

            firstSet = new HashSet<Symbol>();
        
            foreach(Expansion e in expansions)
            {
                foreach(Symbol s in e.symbols)
                {
                    firstSet.UnionWith(s.FirstSet());
                    if(s.DerivesEmpty() == false)
                    {
                        break;
                    }
                }
            }

            return firstSet;
        }

        public HashSet<Symbol> PredictSet(Expansion e, BNF bnf)
        {
            if(expansions.Contains(e) == false)
                throw new Exception("Expansion not in production");
            
            HashSet<Symbol> set = e.FirstSet();
            if(this.DerivesEmpty())
            {
                set.UnionWith(this.FollowSet(bnf));
            }
            
            return set;
        }
    }
}