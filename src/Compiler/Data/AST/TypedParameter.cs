using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypedParameter : Node
    {
        public TypedParameter(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypedParameter(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypedParameter(this);
        }
    }
}