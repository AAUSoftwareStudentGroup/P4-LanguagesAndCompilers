using Compiler.Data;

namespace Compiler.Data.AST
{
    public class FunctionDefinition : Node
    {
        public FunctionDefinition(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public FunctionDefinition(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.FunctionDefinition(this);
        }
    }
}