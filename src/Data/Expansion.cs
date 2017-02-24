using System.Collections.Generic;
using System;

namespace P4.Data
{
    public class Expansion
    {
        public List<Symbol> symbols;
        protected HashSet<Symbol> firstSet = null;

        public Expansion() {
            symbols = new List<Symbol>();
        }


        public HashSet<Symbol> FirstSet()
        {
            if(firstSet != null)
            {
                return firstSet;
            }

            firstSet = new HashSet<Symbol>();
            foreach(Symbol s in this.symbols)
            {
                firstSet.UnionWith(s.FirstSet());
                if(s.DerivesEmpty() == false)
                {
                    break;
                }
            }
            return firstSet;
        }

        public bool DerivesEmpty()
        {
            bool allDeriveEmpty = true;
            foreach(Symbol s in this.symbols)
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
            for(;index < symbols.Count-1; index++)
            {
                tail.symbols.Add(this.symbols[index+1]);
            }
            return tail;
        }
    }
}