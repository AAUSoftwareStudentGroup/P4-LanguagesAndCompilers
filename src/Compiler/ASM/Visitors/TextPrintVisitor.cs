using System;
using System.Collections.Generic;
using System.Text;
using Compiler.ASM.Data;
using System.Linq;

namespace Compiler.ASM.Visitors
{
    class TextPrintVisitor : ASMVisitor<IEnumerable<string>>
    {
        public override IEnumerable<string> Visit(Node node)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> Visit(Data.ASM node)
        {
            if(node.Nodes<ASM.Data.ASM>().Length == 2)
            {
                foreach (var line in node.Nodes<ASM.Data.ASM>()[0].Accept(this))
                {
                    yield return line;
                }
                foreach (var line in node.Nodes<ASM.Data.ASM>()[1].Accept(this))
                {
                    yield return line;
                }
            }
            else
            {
                yield return string.Join(" ", node.Select(c => (c as ASM.Data.Token).Value));
            }
        }
    }
}
