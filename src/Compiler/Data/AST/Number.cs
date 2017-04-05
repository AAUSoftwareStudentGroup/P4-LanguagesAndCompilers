using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Number : Node
    {
        public Number(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Number(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Number(this);
        }
    }
}