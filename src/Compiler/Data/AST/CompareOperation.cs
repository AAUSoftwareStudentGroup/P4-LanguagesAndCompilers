using Compiler.Data;

namespace Compiler.Data.AST
{
    public class CompareOperation : Node
    {
        public CompareOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public CompareOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.CompareOperation(this);
        }
    }
}