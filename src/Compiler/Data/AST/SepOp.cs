using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SepOp : Node
    {
        public SepOp(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SepOp(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SepOp(this);
        }
    }
}