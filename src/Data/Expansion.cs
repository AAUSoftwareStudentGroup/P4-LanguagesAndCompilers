using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Expansion
    {
        public List<Symbol> Symbols { get; set; }
        protected HashSet<Symbol> _firstSet = null;

        public Expansion() {
            Symbols = new List<Symbol>();
        }


        public HashSet<Symbol> FirstSet()
        {
            _firstSet = new HashSet<Symbol>();
            foreach(Symbol s in Symbols)
            {
                _firstSet.UnionWith(s.FirstSet());
                if(s.DerivesEmpty() == false)
                {
                    break;
                }
            }
            return _firstSet;
        }

		public bool AllDerriveEmpty()
		{
			bool allDerriveEmpty = true;
			foreach (var s in Symbols)
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
            foreach(Symbol s in Symbols)
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
                tail.Symbols.Add(Symbols[index+1]);
            return tail;
        }
    }
}