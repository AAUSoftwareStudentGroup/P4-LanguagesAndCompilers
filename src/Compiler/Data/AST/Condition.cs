using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Condition : Node
    {
        public Condition(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Condition(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Condition(this);
        }
    }
}