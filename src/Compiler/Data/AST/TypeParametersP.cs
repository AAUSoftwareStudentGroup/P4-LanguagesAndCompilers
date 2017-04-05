using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypeParametersP : Node
    {
        public TypeParametersP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypeParametersP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypeParametersP(this);
        }
    }
}