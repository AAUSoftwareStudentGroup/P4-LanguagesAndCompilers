using Compiler.Data;

namespace Compiler.Data.AST
{
    public class AndOperation : Node
    {
        public AndOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public AndOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.AndOperation(this);
        }
    }
}