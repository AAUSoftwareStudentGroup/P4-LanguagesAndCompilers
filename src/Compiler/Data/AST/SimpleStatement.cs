using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleStatement : Node
    {
        public SimpleStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleStatement(this);
        }
    }
}