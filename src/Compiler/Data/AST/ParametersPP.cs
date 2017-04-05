using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ParametersPP : Node
    {
        public ParametersPP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ParametersPP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ParametersPP(this);
        }
    }
}