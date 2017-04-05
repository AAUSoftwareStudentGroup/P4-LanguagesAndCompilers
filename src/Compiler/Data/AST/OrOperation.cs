using Compiler.Data;

namespace Compiler.Data.AST
{
    public class OrOperation : Node
    {
        public OrOperation(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public OrOperation(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.OrOperation(this);
        }
    }
}