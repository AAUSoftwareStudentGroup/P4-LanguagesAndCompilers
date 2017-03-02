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
            VisitChildren(ast);

            if((ast.Children.Count == 0 && !IsTerminal(ast)) || ((ast.Node as AST_Node).name == "EPSILON")) 
            {
                RemoveSelfFromParent(ast);
            } 
            // If statementP's parent is statementP, put self into parent.parent.children
            else if(ast.Parent != null && (
                        (ast.Node as AST_Node).name == (ast.Parent.Node as AST_Node).name 
                        || 
                        (ast.Node as AST_Node).name == (ast.Parent.Node as AST_Node).name + "P"
                   ))
            {                
                for(int i = 0; i < ast.Children.Count; i++) 
                {
                    ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[i]);
                }
                RemoveSelfFromParent(ast);
            }
            else if(ast.Children.Count == 1 && 
                !IsTerminal(ast.Children[0]) &&  
                ast.Children[0].Children.Count == 1 && 
                ast.Parent != null) 
            {
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
            }
            else if((ast.Node as AST_Node).name == "NewLine") {
                RemoveSelfFromParent(ast);
            }
            else if(ast.Children.Count > 0 &&
                    (ast.Children[0].Node as AST_Node).name == "StartDel" 
                    &&  
                    (ast.Children[ast.Children.Count-1].Node as AST_Node).name == "EndDel"
                ) {
                ast.Children.RemoveAt(0);
                ast.Children.RemoveAt(ast.Children.Count-1);
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
            return (node.Node as AST_Node).isTerminal;
        }
    }
}