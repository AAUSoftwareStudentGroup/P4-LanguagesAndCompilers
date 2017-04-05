using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleBlock : Node
    {
        public SimpleBlock(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleBlock(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleBlock(this);
        }
    }
}