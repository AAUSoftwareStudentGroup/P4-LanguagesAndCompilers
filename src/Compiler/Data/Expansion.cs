using System.Collections.Generic;

namespace Compiler.Data
{
    public class Expansion
    {
        public Expansion() {
            Symbols = new List<Symbol>();
        }

        public List<Symbol> Symbols { get; set; }

        public HashSet<Symbol> FirstSet()
        {
            HashSet<Symbol> firstSet = new HashSet<Symbol>();
            bool allDeriveEmpty = true;
            foreach(Symbol s in Symbols)
            {
                firstSet.UnionWith(s.FirstSet());
                if(s.DerivesEmpty() == false)
                {
                    allDeriveEmpty = false;
                    break;
                }
            }
            if(!allDeriveEmpty)
                firstSet.RemoveWhere(s => s.Name == "EPSILON");
            return firstSet;
        }

        public bool DerivesEmpty()
        {
            foreach(Symbol s in Symbols)
            {
				if(s.DerivesEmpty() == false)
                {
					return false;
                }
            }
			return true;
        }

        public Expansion Tail(int index)
        {
            // return everything after the index'th symbol as a new Expansion
            Expansion tail = new Expansion();
            for (; index < Symbols.Count - 1; index++)
            {
                tail.Symbols.Add(this.Symbols[index + 1]);
            }
            return tail;
        }

        public override string ToString() {
            return string.Join(" ", Symbols);
        }
    }
}