using System.Collections.Generic;

namespace Compiler.Data
{
    public class Tree<T> 
    {
        public Tree(T node, Tree<T> parent = null) 
        {
            Parent = parent;
            Node = node;
            Children = new List<Tree<T>>();
        }

        public T Node { get; set; }
        public List<Tree<T>> Children { get; set; }
        public Tree<T> Parent { get; set; }

        // return the new child
        public Tree<T> AddChild(T node)
        {
            Tree<T> child = new Tree<T>(node, this);
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
                tree += string.Join(",", Children);
                tree += ")";
            }
            tree += $"{Node}";
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
    }
}