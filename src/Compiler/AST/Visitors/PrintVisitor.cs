using System;
using System.Collections.Generic;
using System.Text;
using Compiler.AST.Data;
using System.Linq;

namespace Compiler.AST.Visitors
{
    public class PrintVisitor : ASTVisitor<IEnumerable<string>>
    {
        public override IEnumerable<string> Visit(Node node)
        {
            yield return node.Name;
            int childIndex = 0;
            foreach (var child in node)
            {
                if(childIndex < node.Count - 1)
                {
                    yield return $"|-{child.Accept(this).First()}";
                }
                else
                {
                    yield return $"'-{child.Accept(this).First()}";
                }

                foreach (var line in child.Accept(this).Skip(1))
                {
                    if (childIndex < node.Count - 1)
                    {
                        yield return $"| {line}";
                    }
                    else
                    {
                        yield return $"  {line}";
                    }
                }
                childIndex++;
            }
        }

        public override IEnumerable<string> Visit(Token node)
        {
            yield return $"{node.Name}";
        }
    }
}

