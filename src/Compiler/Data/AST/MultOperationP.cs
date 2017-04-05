using Compiler.Data;

namespace Compiler.Data.AST
{
    public class MultOperationP : Node
    {
        public MultOperationP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public MultOperationP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.MultOperationP(this);
        }
    }
}