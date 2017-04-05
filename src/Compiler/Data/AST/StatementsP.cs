using Compiler.Data;

namespace Compiler.Data.AST
{
    public class StatementsP : Node
    {
        public StatementsP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public StatementsP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.StatementsP(this);
        }
    }
}