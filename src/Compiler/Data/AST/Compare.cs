using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Compare : Node
    {
        public Compare(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Compare(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Compare(this);
        }
    }
}