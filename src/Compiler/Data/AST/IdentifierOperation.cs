using Compiler.Data;

namespace Compiler.Data.AST
{
    public class IdentifierOperation : Node
    {
        public IdentifierOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public IdentifierOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.IdentifierOperation(this);
        }
    }
}