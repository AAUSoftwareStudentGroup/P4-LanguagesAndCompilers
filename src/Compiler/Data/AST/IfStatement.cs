using Compiler.Data;

namespace Compiler.Data.AST
{
    public class IfStatement : Node
    {
        public IfStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public IfStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.IfStatement(this);
        }
    }
}