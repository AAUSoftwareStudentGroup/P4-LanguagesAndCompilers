using Compiler.Data;

namespace Compiler.Data.AST
{
    public class MulDivOpp : Node
    {
        public MulDivOpp(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public MulDivOpp(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.MulDivOpp(this);
        }
    }
}