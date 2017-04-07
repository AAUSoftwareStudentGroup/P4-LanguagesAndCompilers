using Generator.Generated;
using System;
using System.Linq;


namespace Generator
{
    public class PrintVisitor : Visitor<string>
    {
        int _level;
        public override string Visit(Node node)
        {
            string str = string.Join("", Enumerable.Repeat(" ", _level)) + node.Name + "\n";
            _level++;
            foreach (Node child in node.Children)
            {
                str += child.Accept(this);
            }
            _level--;
            return str;
        }
    }
}