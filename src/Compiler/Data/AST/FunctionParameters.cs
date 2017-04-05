using Compiler.Data;

namespace Compiler.Data.AST
{
    public class FunctionParameters : Node
    {
        public FunctionParameters(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public FunctionParameters(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.FunctionParameters(this);
        }
    }
}