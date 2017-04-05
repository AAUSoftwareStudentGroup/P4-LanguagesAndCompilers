using Compiler.Data;

namespace Compiler.Data.AST
{
    public class AddOperationP : Node
    {
        public AddOperationP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public AddOperationP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.AddOperationP(this);
        }
    }
}