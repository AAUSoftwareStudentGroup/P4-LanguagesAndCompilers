using Compiler.Data;

namespace Compiler.Data.AST
{
    public class NewLine : Node
    {
        public NewLine(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public NewLine(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.NewLine(this);
        }
    }
}