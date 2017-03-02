namespace Compiler.Data
{
    public class Visitor<T>
    {
        public Visitor() 
        {
            // Nothing
        }
        public void Visit(Tree<T> ast)
        {
            if(ast.Node is string) {
                VisitChildren(ast);
                if((ast.Children.Count == 0 && IsTerminal(ast)) || ast.Node.ToString() == "EPSILON")
                    RemoveSelfFromParent(ast);
            }
        }
        private void VisitChildren(Tree<T> ast) {
            for(int i = ast.Children.Count-1; i >= 0; i--) {
                ast.Children[i].Accept( this );
            }
        }

        private void RemoveSelfFromParent(Tree<T> ast) {
            ast.Parent.Children.Remove(ast);
        }

        private bool IsTerminal(Tree<T> node) {
            return false;
        }
    }
}