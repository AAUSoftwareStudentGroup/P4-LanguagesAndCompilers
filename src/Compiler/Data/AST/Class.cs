using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Class : Node
    {
        public Class(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Class(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Class(this);
        }
    }
}