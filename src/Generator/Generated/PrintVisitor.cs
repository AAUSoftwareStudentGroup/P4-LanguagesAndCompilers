using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generator.Generated
{
    public class PrintVisitor : Visitor
    {
        protected int Level { get; private set; } = 0;

        void PrintNode(string root, List<Node> children)
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Level)) + root);
            Level++;
            foreach (var child in children)
            {
                child.Accept(this);
            }
            Level--;
        }

        public override void Visit(S node)
        {
            PrintNode("S", node.Children);

        }

        public override void Visit(A node)
        {
            PrintNode("A", node.Children);

        }

        public override void Visit(B node)
        {
            PrintNode("B", node.Children);

        }

        public override void Visit(D node)
        {
            PrintNode("D", node.Children);

        }

        public override void Visit(Token node)
        {
            Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Level)) + node.Name);
        }
    }
}
