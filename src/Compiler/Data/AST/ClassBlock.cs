using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ClassBlock : Node
    {
        public ClassBlock(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ClassBlock(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ClassBlock(this);
        }
    }
}