using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Return : Node
    {
        public Return(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Return(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Return(this);
        }
    }
}