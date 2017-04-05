using Compiler.Data;

namespace Compiler.Data.AST
{
    public class DelOperation : Node
    {
        public DelOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public DelOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.DelOperation(this);
        }
    }
}