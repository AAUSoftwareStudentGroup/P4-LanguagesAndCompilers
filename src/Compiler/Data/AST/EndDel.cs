using Compiler.Data;

namespace Compiler.Data.AST
{
    public class EndDel : Node
    {
        public EndDel(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public EndDel(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.EndDel(this);
        }
    }
}