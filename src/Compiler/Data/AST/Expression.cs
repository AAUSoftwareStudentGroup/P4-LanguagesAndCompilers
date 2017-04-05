using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Expression : Node
    {
        public Expression(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Expression(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Expression(this);
        }
    }
}