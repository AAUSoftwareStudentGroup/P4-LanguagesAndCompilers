using Compiler.Data;

namespace Compiler.Data.AST
{
    public class StartDel : Node
    {
        public StartDel(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public StartDel(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.StartDel(this);
        }
    }
}