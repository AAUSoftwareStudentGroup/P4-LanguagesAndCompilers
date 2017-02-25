using System.Collections.Generic;
using System;

namespace P4.Data
{
    public class Symbol
    {
        public string name;

        protected HashSet<Symbol> firstSet = null;
        protected HashSet<Symbol> followSet = null;

        public Symbol() {
            this.name = "";
        }

        public bool IsTerminal() 
        {
            return (this is Production) == false;
        }

        public virtual HashSet<Symbol> FirstSet()
        {
          //  if(firstSet != null)
          //  {
         //       return firstSet;
          //  }

            firstSet = new HashSet<Symbol>();
            if(this.IsTerminal())
            {
            	firstSet.Add(this);
            }
            else
            {
                Production p = this as Production;
                firstSet = p.FirstSet();
            }
            return firstSet;
        }

        public virtual bool DerivesEmpty()
        {

            if(this.IsTerminal() && this.name == "EPSILON" || this.name == "EOF")
            {
				return true;
            }
            else
            {
				return false;
            }
        }

		public override string ToString()
		{
			return name.ToString();
		}
    }
}