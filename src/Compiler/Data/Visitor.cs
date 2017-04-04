using System.Reflection;

namespace Compiler.Data
{
    public class Visitor
    {
        public Visitor() 
        {
            // Nothing
        }
        public void NameEPSILON(Tree ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void NameRoot(Tree ast) 
        {
            // Do nothing
        }
        public void NameSimpleStatement(Tree ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void NameSimpleStatements(Tree ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void NameStatement(Tree ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void NameNewLine(Tree ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void NameCompareOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void NameOrOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void NameAndOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void NameAddOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void NameMultOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void NameDelOperation(Tree ast) 
        {
            CompareOrAndAddMultDel(ast);
            // If contain 1 identifier and 1 FunctionParameters, rename to FunctionCall
            if(ast.Children.Count == 2) {
                if(ast.Children[0].Node.name == "Identifier" &&
                   ast.Children[1].Node.name == "FunctionParameters") 
                {
                    ast.Node.name = "FunctionCall";
                }
            }
                
        }
        public void NameParameters(Tree ast) 
        {
            // Remove start and end delimiter and put onto parent
        }        
        public void NameExpression(Tree ast) 
        {
            // If only contain 1 child, replace with child
            if(ast.Children.Count == 1) {
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
            }
        }
        public void NameFunctionParameters(Tree ast) 
        {
            // FunctionParameters only have 1 child
            // Eat child and acquire grandchildren except StartDel and EndDel
            ast.Children.AddRange(ast.Children[0].Children);
            RemoveDelimiters(ast);
            ast.Children.RemoveAt(0);
        }
        public void NameTypeParameters(Tree ast) 
        {
            // Remove delimiters
            RemoveDelimiters(ast);
        }
        public void NameTypedParameters(Tree ast) 
        {
            // Remove start and end delimiter
            ast.Children.RemoveAll(x => x.Node.name == "StartDel" || x.Node.name == "EndDel");
            // Split up into blocks of 2 of type and identifier
            for(int i = 0; i < ast.Children.Count; i++) {
                // Take i and i+1 and group together
                ast.Children.Insert(i, new Tree(new AST_Node("TypedParameter", false),ast));
                ast.Children[i].Children.Add(ast.Children[i+1]);
                ast.Children[i].Children.Add(ast.Children[i+2]);
                ast.Children.RemoveAt(i+1);
                ast.Children.RemoveAt(i+1);
            }
        }
        public void NameSimpleBlock(Tree ast) 
        {
            // Remove all indent and dedent
            ast.Children.RemoveAll(x => x.Node.name == "Indent" || x.Node.name == "Dedent");
        }
        public void NameType(Tree ast) {
            // If contains TypeParameters, is a functionPointer?
            if(ast.Children.Count == 1) 
            {
                // Replace with child
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
                return;
            }
            if(ast.Children.Find(x => x.Node.name == "TypeParameters") != null) 
            {
                ast.Node.name =  "FunctionPointer";
                RemoveDelimiters(ast);
                // SimpleType is now ReturnType
                ast.Children.Find(x => x.Node.name == "SimpleType").Node.name = "ReturnType";
            }
        }
        public void RemoveDelimiters(Tree ast) {
            ast.Children.RemoveAll(x => x.Node.name == "StartDel" || x.Node.name == "EndDel");
        }
        public void NameSepOp(Tree ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void NameAssign(Tree ast) {
            RemoveSelfFromParent(ast);
        }
        public void NameFunctionDefinition(Tree ast) {
            // Replace parent
            ast.Parent.Parent.Children.Add(ast);
            ast.Parent.Parent.Children.Remove(ast.Parent);
        }
        public void CompareOrAndAddMultDel(Tree ast) 
        {
            if((ast.Children.Count == 2 &&
                ast.Children[1].Node.name == ast.Node.name + "P") ||
                ast.Children.Count == 1)
            {
                // Put child onto parent and remove self
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
            }
        }
        public void PutChildrenOntoParentAndRemoveSelf(Tree ast) {
            // Put all children onto parent and remove self
            if(ast.Children.Count > 0)
                ast.Parent.Children.InsertRange(ast.Parent.Children.IndexOf(ast), ast.Children);
            RemoveSelfFromParent(ast);
        }

        public void NameAddSubOpp(Tree ast) {
            RemoveSelfFromParent(ast);
        }
        public void NameDeclaration(Tree ast) {
            // If contains functionDefinition, put simpleType into functionDefiniton->LeftSide->simpleType
            Tree functionDefinition = ast.Children.Find(x => x.Node.name == "FunctionDefinition");
            if(functionDefinition != null) 
            {
                functionDefinition.Children.Insert(0, ast.Children[0]);
                functionDefinition.Children[0].Node.name = "ReturnType";
                functionDefinition.Children.Insert(1, ast.Children[1]);
                ast.Children.RemoveAll(x => x.Node.name != "FunctionDefinition");
            }
        }
        // SimpleType -> ReturnType i FunctionCall/Definition
        public void NameIdentifierStatement(Tree ast) 
        {
            // if child 1 contains Assignment, replace self with Assignment and add identifier to Assignment -> LeftSide -> Identifier
            Tree idop = ast.Children.Find(x => x.Node.name == "IdentifierOperation");
            if(idop != null) {
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), idop.Children[0]);
                idop.Children[0].Children.Insert(0, new Tree(new AST_Node("LeftSide", false), idop.Children[0]));
                idop.Children[0].Children[0].Children.Insert(0, ast.Children[0]);
                RemoveSelfFromParent(ast);
            }  
        }

        public bool GeneralCleanUp(Tree ast){
            if( ast.Parent != null && 
              (ast.Node.name == ast.Parent.Node.name + "P" ||
               ast.Node.name == ast.Parent.Node.name))
            {
                // Put child onto parent and remove self
                ast.Parent.Children.InsertRange(ast.Parent.Children.IndexOf(ast), ast.Children);
                RemoveSelfFromParent(ast);
                return false;
            }
            // Empty productions must be sacrificed
            if(!ast.Node.isTerminal && ast.Children.Count == 0) {
                RemoveSelfFromParent(ast);
                return false;
            }
            return true;
        }
        public void Visit(Tree ast)
        {
            //Visit bottom-up
            VisitChildren(ast);
            // Remove recursive names and empty productions
            if(!GeneralCleanUp(ast)) return;

            //Get the method information using the method info class
            MethodInfo mi = this.GetType().GetMethod("Name" + ast.Node.name);
            if(mi != null) {
                mi.Invoke(this, new object[]{ast});
            }

        }
        private void VisitChildren(Tree ast) {
            for(int i = ast.Children.Count-1; i >= 0; i--) {
                ast.Children[i].Accept( this );
            }
        }

        private void RemoveSelfFromParent(Tree ast) {
            ast.Parent.Children.Remove(ast);
        }

        private bool IsTerminal(Tree ast) {
            return ast.Node.isTerminal;
        }
    }
}