using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypeParameters : Node
    {
        public TypeParameters(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypeParameters(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypeParameters(this);
        }
    }
}