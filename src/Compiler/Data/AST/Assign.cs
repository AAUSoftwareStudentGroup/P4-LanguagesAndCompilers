using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Assign : Node
    {
        public Assign(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Assign(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Assign(this);
        }
    }
}