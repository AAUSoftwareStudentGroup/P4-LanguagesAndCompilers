using Compiler.Data;

namespace Compiler.Data.AST
{
    public class OrOperationP : Node
    {
        public OrOperationP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public OrOperationP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.OrOperationP(this);
        }
    }
}