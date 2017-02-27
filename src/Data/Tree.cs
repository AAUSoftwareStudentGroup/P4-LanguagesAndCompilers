using System.Collections.Generic;

namespace Compiler.Data
{
    public class Tree<NodeType>
    {
        public NodeType Name { get; set; }
        public List<Tree<NodeType>> Children { get; set; }
        public Tree<NodeType> Parent { get; set; }

        public Tree(NodeType name, Tree<NodeType> parent = null) 
        {
            Parent = parent;
            Name = name;
            Children = new List<Tree<NodeType>>();
        }

        // return the new child
        public Tree<NodeType> AddChild(NodeType name)
        {
            Tree<NodeType> child = new Tree<NodeType>(name, this);
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
            tree += $"{Name}";
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
            s += Name+"\r\n";

            for (int i = 0; i < Children.Count; i++)
                s += Children[i].PrintPretty(indent, i == Children.Count - 1);
            
            return s;
        }
    }
}