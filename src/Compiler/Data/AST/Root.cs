using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Root : Node
    {
        public Root(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Root(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Root(this);
        }
    }
}