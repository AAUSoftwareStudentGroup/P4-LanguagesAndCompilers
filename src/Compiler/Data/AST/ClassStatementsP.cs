using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ClassStatementsP : Node
    {
        public ClassStatementsP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ClassStatementsP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ClassStatementsP(this);
        }
    }
}