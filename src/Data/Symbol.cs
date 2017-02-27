using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Symbol
    {
        protected HashSet<Symbol> _firstSet = null;
        protected HashSet<Symbol> _followSet = null;

        public Symbol() {
            Name = "";
        }

        public string Name { get; set; }

        public bool IsTerminal() 
        {
            return (this is Production) == false;
        }

        public virtual HashSet<Symbol> FirstSet()
        {
            _firstSet = new HashSet<Symbol>();
            if(IsTerminal())
            {
            	_firstSet.Add(this);
            }
            else
            {
                Production p = this as Production;
                _firstSet = p.FirstSet();
            }
            return _firstSet;
        }

        public virtual bool DerivesEmpty()
        {
            if(IsTerminal() && (Name == "EPSILON" || Name == "EOF"))
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
			return Name.ToString();
		}
    }
}