
using Compiler.Shared;
using Compiler.Visitors;

namespace Compiler
{
    public class TypeDenoter : Node
    {
        public TypeDenoter()
        {
        }

        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
