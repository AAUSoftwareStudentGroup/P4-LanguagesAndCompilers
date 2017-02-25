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

		public bool allDerriveEmpty()
		{
			bool allDerriveEmpty = true;
			foreach (var s in symbols)
			{
				if (s.DerivesEmpty() == false || s.IsTerminal())  
				{
					allDerriveEmpty = false;
					break;
				}
			}
			return allDerriveEmpty;
		}

        public bool DerivesEmpty()
        {
            foreach(Symbol s in this.symbols)
            {
				if(s.DerivesEmpty() == true && s.IsTerminal())
                {
					return true;
                }
            }
			return false;
        }

        public Expansion Tail(int index)
        {
            // return everything after the index'th symbol as a new Expansion
            Expansion tail = new Expansion();
                tail.symbols.Add(this.symbols[index+1]);
            return tail;
        }
    }
}