using System.Collections.Generic;
using System.Linq;

namespace Compiler.Data
{
    public class Tree
    {
        public Tree(AST_Node name, Tree parent = null) 
        {
            Parent = parent;
            Node = name;
            Children = new List<Tree>();
        }

        public AST_Node Node { get; set; }
        public List<Tree> Children { get; set; }
        public Tree Parent { get; set; }

        // return the new child
        public Tree AddChild(AST_Node name)
        {
            Tree child = new Tree(name, this);
            Children.Add(child);
            return child;
        }

        public override string ToString()
        {
            return PrintPretty();
        }

        public string ToNewickString()
        {
            string tree = "";
            if(Children.Count > 0)
            {
                tree += "(";
                tree += string.Join(",", (Children.Select(t => t.ToNewickString())));
                tree += ")";
                tree += $"{Node}";
            }
            else {
                tree += $"\"{Node}\"";
            }
            if(Parent == null)
            {
                tree += ";";
            }
            return tree;
        }
        
        public string PrintPretty(string indent = "", bool last = true)
        {
            string s = indent;
            if (last)
            {
                s += "\\-";
                indent += "  ";
            }
            else
            {
                s += "|-";
                indent += "| ";
            }
            s += Node+"\r\n";

            for (int i = 0; i < Children.Count; i++)
                s += Children[i].PrintPretty(indent, i == Children.Count - 1);
            
            return s;
        }

        public void Accept( Visitor v) 
        {
            v.Visit( this );
        }
    }
}