using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Dedent : Node
    {
        public Dedent(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Dedent(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Dedent(this);
        }
    }
}