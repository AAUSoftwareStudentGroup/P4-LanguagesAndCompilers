using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Symbol
    {
        protected HashSet<Symbol> _firstSet = null;
        protected HashSet<Symbol> _followSet = null;
        protected bool? _derivesEmpty = null;

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
            if (_firstSet != null)
            {
                return _firstSet;
            }

            _firstSet = new HashSet<Symbol>();
            if (IsTerminal())
            {
                if (Name != "EPSILON" && Name != "EOF")
                {
                    _firstSet.Add(this);
                }
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
            if (_derivesEmpty != null)
                return _derivesEmpty.Value;

            if (IsTerminal())
            {
                _derivesEmpty = (Name == "EPSILON" || Name == "EOF");
            }
            else
            {
                Production p = this as Production;
                _derivesEmpty = p.DerivesEmpty();
            }
            return _derivesEmpty.Value;
        }
    }
}