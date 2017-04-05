using Compiler.Data;

namespace Compiler.Data.AST
{
    public class WhileStatement : Node
    {
        public WhileStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public WhileStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.WhileStatement(this);
        }
    }
}