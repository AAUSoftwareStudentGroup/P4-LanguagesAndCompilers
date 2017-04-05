using Compiler.Data;

namespace Compiler.Data.AST
{
    public class EPSILON : Node
    {
        public EPSILON(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public EPSILON(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.EPSILON(this);
        }
    }
}