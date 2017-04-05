using Compiler.Data;

namespace Compiler.Data.AST
{
    public class MultOperation : Node
    {
        public MultOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public MultOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.MultOperation(this);
        }
    }
}