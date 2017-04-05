using Compiler.Data;

namespace Compiler.Data.AST
{
    public class IdentifierStatement : Node
    {
        public IdentifierStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public IdentifierStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.IdentifierStatement(this);
        }
    }
}