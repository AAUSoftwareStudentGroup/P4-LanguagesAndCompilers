using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypedParametersP : Node
    {
        public TypedParametersP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypedParametersP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypedParametersP(this);
        }
    }
}