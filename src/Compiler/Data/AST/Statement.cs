using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Statement : Node
    {
        public Statement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Statement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Statement(this);
        }
    }
}