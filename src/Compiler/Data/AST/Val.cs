using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Val : Node
    {
        public Val(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Val(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Val(this);
        }
    }
}