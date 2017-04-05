using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ClassStatement : Node
    {
        public ClassStatement(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ClassStatement(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ClassStatement(this);
        }
    }
}