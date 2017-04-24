using System;
using System.Collections.Generic;
using System.Text;
using Compiler.C.Data;

namespace Compiler.C.Visitors
{
    class TextPrintVisitor : CVisitor<IEnumerable<string>>
    {
        public override IEnumerable<string> Visit(Node node)
        {
            foreach (var child in node)
            {
                foreach (var str in child.Accept(this))
                {
                    yield return str;
                }
            }
        }

        public override IEnumerable<string> Visit(Token node)
        {
            yield return node.Value;
        }
    }
}
