using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ClassStatements : Node
    {
        public ClassStatements(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ClassStatements(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ClassStatements(this);
        }
    }
}