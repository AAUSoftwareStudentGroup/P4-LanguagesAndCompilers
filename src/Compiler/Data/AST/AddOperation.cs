using Compiler.Data;

namespace Compiler.Data.AST
{
    public class AddOperation : Node
    {
        public AddOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public AddOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.AddOperation(this);
        }
    }
}