using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Symbol // TODO: This should really be called Terminal. Someone with visual studio should rename this
    {
        protected HashSet<Symbol> _firstSet = null;
        protected HashSet<Symbol> _followSet = null;
        protected bool? _derivesEmpty = null;

        public Symbol() {
            Name = "";
        }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj is Symbol) && (obj as Symbol).Name == this.Name;
        }

        public bool IsTerminal() 
        {
            return (this is Production) == false;
        }

        public virtual HashSet<Symbol> FirstSet()
        {
			if (_firstSet != null)
			{
				return _firstSet;
			}
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
            return false;
        }

		public override string ToString()
		{
			return Name.ToString();
		}
    }
}