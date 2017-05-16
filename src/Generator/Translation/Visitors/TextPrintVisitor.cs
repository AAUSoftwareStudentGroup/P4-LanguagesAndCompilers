using System;
using System.Collections.Generic;
using System.Text;
using Generator.Translation.Data;
using System.Linq;

namespace Generator.Translation.Visitors
{
    class TextPrintVisitor : TranslatorVisitor<string>
    {
        public override string Visit(Node node)
        {
            return string.Join(" ", node.Select(child => child.Accept(this)).Where(str => !string.IsNullOrWhiteSpace(str)));
        }

        public override string Visit(Token node)
        {
            return node.Value;
        }
    }
}
