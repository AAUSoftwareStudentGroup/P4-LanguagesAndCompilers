using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleStatementsP : Node
    {
        public SimpleStatementsP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleStatementsP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleStatementsP(this);
        }
    }
}