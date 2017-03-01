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
            if (_derivesEmpty != null)
                return _derivesEmpty.Value;

            foreach(Expansion e in Expansions)
            {
                if (e.DerivesEmpty())
                {
                    _derivesEmpty = true;
                    return true;
                }
            }
            _derivesEmpty = false;
            return false;
        }

        public HashSet<Symbol> FollowSet(Bnf bnf)
        {
            if(_followSet != null)
            {
                return _followSet;
            }

            _followSet = new HashSet<Symbol>();
            foreach (var production in bnf.Productions)
            {
                foreach (var expansion in production.Expansions)
                {
                    for (int i = 0; i < expansion.Symbols.Count; i++)
                    {
                        Symbol b = expansion.Symbols[i];
                        if(b.Equals(this))
                        {
                            if(i < expansion.Symbols.Count - 1)
                            {
                                var tailFirstSet = expansion.Symbols[i + 1].FirstSet();

                                bool tailFirstSetContainsEpsilon = false;

                                foreach (var symbol in tailFirstSet)
                                {
                                    if (symbol.Name == "EPSILON")
                                    {
                                        tailFirstSetContainsEpsilon = true;
                                        break;
                                    }
                                }

                                tailFirstSet.RemoveWhere(s => s.Name == "EPSILON");
                                
                                _followSet.UnionWith(tailFirstSet);
                                if (tailFirstSetContainsEpsilon)
                                {
                                    _followSet.UnionWith(production.FollowSet(bnf));
                                }
                            }
                            else
                            {
                                _followSet.UnionWith(production.FollowSet(bnf));
                            }
                        }
                    }
                }
            }

            return _followSet;
        }

        public override HashSet<Symbol> FirstSet()
        {
            if (_firstSet != null)
                return _firstSet;

            _firstSet = new HashSet<Symbol>();
            foreach (Expansion e in Expansions)
            {
                _firstSet.UnionWith(e.FirstSet());
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