using Generator.Generated;
using System;
using System.Linq;


namespace Generator
{
    public class PrintVisitor : Visitor
    {
        int _level;
        public override void Visit(Node node)
        {
            System.Console.WriteLine(string.Join("", Enumerable.Repeat(" ", _level)) + node.GetType().Name);
            _level++;
            foreach (Node child in node.Children)
            {
                child.Accept(this);
            }
            _level--;
        }

        public override void Visit(Token node)
        {
            System.Console.WriteLine(string.Join("", Enumerable.Repeat(" ", _level)) + node.Name);
        }
    }
}