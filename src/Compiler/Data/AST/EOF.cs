using Compiler.Data;

namespace Compiler.Data.AST
{
    public class EOF : Node
    {
        public EOF(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public EOF(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.EOF(this);
        }
    }
}