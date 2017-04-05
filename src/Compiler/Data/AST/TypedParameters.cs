using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypedParameters : Node
    {
        public TypedParameters(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypedParameters(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypedParameters(this);
        }
    }
}