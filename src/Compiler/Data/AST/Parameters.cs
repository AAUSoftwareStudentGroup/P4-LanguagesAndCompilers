using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Parameters : Node
    {
        public Parameters(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Parameters(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Parameters(this);
        }
    }
}