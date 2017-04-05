using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ReturnStatement : Node
    {
        public ReturnStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ReturnStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ReturnStatement(this);
        }
    }
}