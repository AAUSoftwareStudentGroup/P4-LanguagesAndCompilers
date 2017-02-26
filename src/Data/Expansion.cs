using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Expansion
    {
        HashSet<Symbol> _firstSet = null;
        public Expansion() {
            Symbols = new List<Symbol>();
        }

        public List<Symbol> Symbols { get; set; }

        public HashSet<Symbol> FirstSet()
        {
            if (_firstSet != null)
            {
                return _firstSet;
            }

            _firstSet = new HashSet<Symbol>();
            foreach (Symbol s in Symbols)
            {
                _firstSet.UnionWith(s.FirstSet());
                if (s.DerivesEmpty() == false)
                {
                    break;
                }
            }
            return _firstSet;
        }

        public bool DerivesEmpty()
        {
            bool allDeriveEmpty = true;
            foreach(Symbol s in Symbols)
            {
                if(s.DerivesEmpty() == false)
                {
                    allDeriveEmpty = false;
                    break;
                }
            }
            return allDeriveEmpty;
        }

        public Expansion Tail(int index)
        {
            // return everything after the index'th symbol as a new Expansion
            Expansion tail = new Expansion();
            for(;index < Symbols.Count-1; index++)
            {
                tail.Symbols.Add(Symbols[index+1]);
            }
            return tail;
        }
    }
}