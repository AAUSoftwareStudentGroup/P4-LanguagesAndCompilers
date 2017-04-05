using Compiler.Data;

namespace Compiler.Data.AST
{
    public class AndOperationP : Node
    {
        public AndOperationP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public AndOperationP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.AndOperationP(this);
        }
    }
}