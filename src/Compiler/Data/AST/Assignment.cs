using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Assignment : Node
    {
        public Assignment(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Assignment(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Assignment(this);
        }
    }
}