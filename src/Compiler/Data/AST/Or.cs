using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Or : Node
    {
        public Or(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Or(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Or(this);
        }
    }
}