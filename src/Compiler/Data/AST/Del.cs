using Compiler.Data;

namespace Compiler.Data.AST
{
    public class Del : Node
    {
        public Del(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public Del(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.Del(this);
        }
    }
}