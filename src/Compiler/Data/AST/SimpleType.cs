using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleType : Node
    {
        public SimpleType(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleType(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleType(this);
        }
    }
}