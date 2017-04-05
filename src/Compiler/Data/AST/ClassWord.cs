using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ClassWord : Node
    {
        public ClassWord(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ClassWord(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ClassWord(this);
        }
    }
}