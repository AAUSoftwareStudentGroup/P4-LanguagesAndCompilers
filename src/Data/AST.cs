using System.Collections.Generic;

namespace P4.Data
{
    public class AST 
    {
        public string name;
        public List<AST> children;
        public AST parent;

        public AST(string name, AST parent = null) 
        {
            this.parent = parent;
            this.name = name;
            this.children = new List<AST>();
        }

        // return the new child
        public AST AddChild(string name)
        {
            AST child = new AST(name, this);
            this.children.Add(child);
            return child;
        }

        public override string ToString()
        {
            string tree = "";
            if(this.children.Count > 0)
            {
                tree += "(";
                tree += string.Join(",", children);
                tree += ")";
            }
            tree += $"{this.name}";
            if(parent == null)
            {
                tree += ";";
            }
            return tree;
        }
    }
}