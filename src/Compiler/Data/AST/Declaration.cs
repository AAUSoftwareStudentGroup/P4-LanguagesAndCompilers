using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Declaration : Node
    {
        public Declaration(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Declaration(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Declaration(this);
        }
    }
}