namespace Compiler.Data
{
    public class AST_Node
    {
        public string name;
        public bool isTerminal;
        public AST_Node(string name, bool isTerminal)
        {
            this.name = name;
            this.isTerminal = isTerminal;
        }

        public AST_Node(Symbol symbol) {
            this.name = symbol.Name;
            this.isTerminal = symbol.IsTerminal();
        }

        public override string ToString() {
            return name;
        }
    }
}