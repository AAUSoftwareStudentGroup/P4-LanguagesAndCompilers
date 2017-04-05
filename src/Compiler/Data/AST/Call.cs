using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Call : Node
    {
        public Call(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Call(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Call(this);
        }
    }
}