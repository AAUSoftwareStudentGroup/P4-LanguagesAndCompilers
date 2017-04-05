using Compiler.Data;

namespace Compiler.Data.AST
{
    public class TypeParametersPP : Node
    {
        public TypeParametersPP(string name, bool isTerminal, Node parent) : base(name, isTerminal, parent)
        {

        }

        public TypeParametersPP(Symbol symbol, Node parent) : base(symbol, parent)
        {

        }

        override public void Accept(Visitor visitor) {
            visitor.TypeParametersPP(this);
        }
    }
}