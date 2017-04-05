using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Type : Node
    {
        public Type(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Type(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Type(this);
        }
    }
}