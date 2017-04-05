using Compiler.Data;

namespace Compiler.Data.AST
{
    public class If : Node
    {
        public If(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public If(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.If(this);
        }
    }
}