using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Statements : Node
    {
        public Statements(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Statements(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Statements(this);
        }
    }
}