using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Identifier : Node
    {
        public Identifier(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Identifier(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Identifier(this);
        }
    }
}