using Compiler.Data;

namespace Compiler.Data.AST
{
    public class AddSubOpp : Node
    {
        public AddSubOpp(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public AddSubOpp(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.AddSubOpp(this);
        }
    }
}