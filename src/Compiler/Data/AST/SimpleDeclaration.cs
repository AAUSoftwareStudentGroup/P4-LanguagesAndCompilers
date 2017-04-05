using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleDeclaration : Node
    {
        public SimpleDeclaration(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleDeclaration(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleDeclaration(this);
        }
    }
}