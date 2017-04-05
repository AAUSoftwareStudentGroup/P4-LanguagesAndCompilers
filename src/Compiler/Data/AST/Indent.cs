using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Indent : Node
    {
        public Indent(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Indent(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Indent(this);
        }
    }
}