using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypedParametersPP : Node
    {
        public TypedParametersPP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypedParametersPP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypedParametersPP(this);
        }
    }
}