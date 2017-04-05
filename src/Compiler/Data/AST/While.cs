using Compiler.Data;

namespace Compiler.Data.AST
{
    public class While : Node
    {
        public While(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public While(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.While(this);
        }
    }
}