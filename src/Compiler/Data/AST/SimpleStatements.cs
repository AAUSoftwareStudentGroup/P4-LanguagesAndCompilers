using Compiler.Data;

namespace Compiler.Data.AST
{
    public class SimpleStatements : Node
    {
        public SimpleStatements(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public SimpleStatements(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.SimpleStatements(this);
        }
    }
}