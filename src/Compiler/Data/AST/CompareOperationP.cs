using Compiler.Data;

namespace Compiler.Data.AST
{
    public class CompareOperationP : Node
    {
        public CompareOperationP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public CompareOperationP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.CompareOperationP(this);
        }
    }
}