using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Definition : Node
    {
        public Definition(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Definition(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Definition(this);
        }
    }
}