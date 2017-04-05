using Compiler.Data;

namespace Compiler.Data.AST
{
    public class NODEERROR : Node
    {
        public NODEERROR(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public NODEERROR(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.NODEERROR(this);
        }
    }
}