using Compiler.Data;

namespace Compiler.Data.AST
{
    public class ParametersP : Node
    {
        public ParametersP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public ParametersP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.ParametersP(this);
        }
    }
}