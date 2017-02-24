using System.Collections.Generic;
using System;

namespace P4.Data
{
    public class Symbol
    {
        public string name;

        protected HashSet<Symbol> firstSet = null;
        protected HashSet<Symbol> followSet = null;
        protected bool? derivesEmpty = null;

        public Symbol() {
            this.name = "";
        }

        public bool IsTerminal() 
        {
            return (this is Production) == false;
        }

        public virtual HashSet<Symbol> FirstSet()
        {
            if(firstSet != null)
            {
                return firstSet;
            }

            firstSet = new HashSet<Symbol>();
            if(this.IsTerminal())
            {
                if(this.name != "EPSILON" && this.name != "EOF")
                {
                    firstSet.Add(this);
                }
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
            if(this.derivesEmpty != null)
                return this.derivesEmpty.Value;

            if(this.IsTerminal())
            {
                this.derivesEmpty = (this.name == "EPSILON" || this.name == "EOF");
            }
            else
            {
                Production p = this as Production;
                this.derivesEmpty = p.DerivesEmpty();
            }
            return this.derivesEmpty.Value;
        }
    }
}