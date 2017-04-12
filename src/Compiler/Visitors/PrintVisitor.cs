using Compiler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Visitors
{
    public class PrintVisitor : Visitor<string>
    {
        //int _level;
        public override string Visit(Node node)
        {
            //string str = string.Join("", Enumerable.Repeat(" ", _level)) + node.Name + "\n";
            //_level++;

            string str = "";
            if (node is Token && node.Name != "EPSILON")
            {
                str += node.Name + " ";
            }

            foreach (Node child in node.Children)
            {
                str += child.Accept(this);
            }
            //_level--;
            return str;
        }
    }
}
