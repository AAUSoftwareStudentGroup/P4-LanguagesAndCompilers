using Compiler.Data;

namespace Compiler.Data.AST
{
    public class And : Node
    {
        public And(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public And(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.And(this);
        }
    }
}