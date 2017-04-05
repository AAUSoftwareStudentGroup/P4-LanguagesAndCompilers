using Compiler.Data;

namespace Compiler.Data.AST
{
    public class LeftSide : Node
    {
        public LeftSide(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public LeftSide(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.LeftSide(this);
        }
    }
}