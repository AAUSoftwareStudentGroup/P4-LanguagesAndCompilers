using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Production : Symbol
    {
        public Production() {
            Expansions = new List<Expansion>();
        }
        public List<Expansion> Expansions { get; set; }

        public override bool DerivesEmpty()
        {
            foreach(Expansion e in Expansions)
            {
                foreach(Symbol s in e.Symbols)
                {
					if (s.IsTerminal() && s.DerivesEmpty())
					{
						return true;
					}
                }
            }
            return false;
        }

        public HashSet<Symbol> FollowSet(Bnf bnf)
        {
            if(_followSet != null)
            {
                return _followSet;
            }

            _followSet = new HashSet<Symbol>();
            // foreach occurence of `this` in any expansion in BNF
            foreach(Production p in bnf.Productions)
            {
                foreach(Expansion e in p.Expansions)
                {
                    for(int i = 0; i < e.Symbols.Count; i++)
                    {
                        Symbol s = e.Symbols[i];
                        if(s == this)
                        {
                            if(i < e.Symbols.Count-1)
                            {
                                Expansion tail = e.Tail(i);
                                _followSet.UnionWith(tail.FirstSet());
								if(tail.AllDerriveEmpty())
                                {
                                    _followSet.UnionWith(p.FollowSet(bnf));
                                }
                            }
                            else
                            {
                                _followSet.UnionWith(p.FollowSet(bnf));
                            }
                        }
                    }
                }
            }
            return _followSet;
        }

        public override HashSet<Symbol> FirstSet()
        {
            _firstSet = new HashSet<Symbol>();
        
            foreach(Expansion e in Expansions)
            {
                foreach(Symbol s in e.Symbols)
                {
                    _firstSet.UnionWith(s.FirstSet());
                    if(s.DerivesEmpty() == false)
                    {
                        break;
                    }
                }
            }

            return _firstSet;
        }

        public HashSet<Symbol> PredictSet(Expansion e, Bnf bnf)
        {
            if(Expansions.Contains(e) == false)
                throw new Exception("Expansion not in production");
            
            HashSet<Symbol> set = e.FirstSet();
            if(DerivesEmpty())
            {
                set.UnionWith(FollowSet(bnf));
            }
            
            return set;
        }
    }
}