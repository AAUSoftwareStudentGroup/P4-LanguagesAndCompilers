using System.Reflection;

namespace Compiler.Data
{
    public class Visitor
    {
        public Visitor() 
        {
            // Nothing to initiate
        }
        public void EPSILON(AST.EPSILON ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void Root(AST.Root ast) 
        {
            // Do nothing
        }
        public void SimpleStatement(AST.SimpleStatement ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void SimpleStatements(AST.SimpleStatements ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void Statement(AST.Statement ast) 
        {
            PutChildrenOntoParentAndRemoveSelf(ast);
        }
        public void NewLine(AST.NewLine ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void CompareOperation(AST.CompareOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void OrOperation(AST.OrOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void AndOperation(AST.AndOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void AddOperation(AST.AddOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void MultOperation(AST.MultOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
        }
        public void DelOperation(AST.DelOperation ast) 
        {
            CompareOrAndAddMultDel(ast);
            // If contain 1 identifier and 1 FunctionParameters, rename to FunctionCall
            if(ast.Children.Count == 2) {
                if(ast.Children[0].name == "Identifier" &&
                   ast.Children[1].name == "FunctionParameters") 
                {
                    ast.name = "FunctionCall";
                }
            }
                
        }
        public void Expression(AST.Expression ast) 
        {
            // If only contain 1 child, replace with child
            if(ast.Children.Count == 1) {
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
            }
        }
        public void FunctionParameters(AST.FunctionParameters ast) 
        {
            // FunctionParameters only have 1 child
            // Eat child and acquire grandchildren except StartDel and EndDel
            ast.Children.AddRange(ast.Children[0].Children);
            RemoveDelimiters(ast);
            ast.Children.RemoveAt(0);
        }
        public void TypeParameters(AST.TypeParameters ast) 
        {
            // Remove delimiters
            RemoveDelimiters(ast);
        }
        public void TypedParameters(AST.TypedParameters ast) 
        {
            // Remove start and end delimiter
            RemoveDelimiters(ast);

            // Split up into blocks of 2 of type and identifier
            for(int i = 0; i < ast.Children.Count; i++) {
                // Take i and i+1 and group together
                ast.Children.Insert(i, new AST.TypedParameter("TypedParameter", false, ast));
                ast.Children[i].Children.Add(ast.Children[i+1]);
                ast.Children[i].Children.Add(ast.Children[i+2]);
                ast.Children.RemoveAt(i+1);
                ast.Children.RemoveAt(i+1);
            }
        }

        public void TypedParameter(AST.TypedParameter ast) 
        {
            // Nothing
        }
        public void EndDel(AST.EndDel ast) 
        {
            // Nothing
        }
        public void StartDel(AST.StartDel ast) 
        {
            // Nothing
        }
        public void LeftSide(AST.LeftSide ast) 
        {
            // Nothing
        }
        public void NODEERROR(AST.NODEERROR ast) 
        {
            // YOU DON FUCKED UP
        }
        public void Statements(AST.Statements ast) 
        {
            // Nothing
        }
        public void Compare(AST.Compare ast) 
        {
            // Nothing
        }
        public void ClassStatement(AST.ClassStatement ast) 
        {
            // Nothing
        }
        public void And(AST.And ast) 
        {
            // Nothing
        }
        public void Assignment(AST.Assignment ast) 
        {
            // Nothing
        }
        public void AddOperationP(AST.AddOperationP ast) 
        {
            // Nothing
        }
        public void AndOperationP(AST.AndOperationP ast) 
        {
            // Nothing
        }
        public void While(AST.While ast) 
        {
            // Nothing
        }
        public void Val(AST.Val ast) 
        {
            // Nothing
        }
        public void TypedParametersPP(AST.TypedParametersPP ast) 
        {
            // Nothing
        }
        public void TypedParametersP(AST.TypedParametersP ast) 
        {
            // Nothing
        }
        public void TypeParametersPP(AST.TypeParametersPP ast) 
        {
            // Nothing
        }
        public void TypeParametersP(AST.TypeParametersP ast) 
        {
            // Nothing
        }
        public void ClassStatements(AST.ClassStatements ast) 
        {
            // Nothing
        }
        public void Class(AST.Class ast) 
        {
            // Nothing
        }
        public void Condition(AST.Condition ast) 
        {
            // Nothing
        }
        public void ClassBlock(AST.ClassBlock ast) 
        {
            // Nothing
        }
        public void ClassStatementsP(AST.ClassStatementsP ast) 
        {
            // Nothing
        }
        public void Call(AST.Call ast) 
        {
            // Nothing
        }
        public void Dedent(AST.Dedent ast) 
        {
            // Nothing
        }
        public void Indent(AST.Indent ast) 
        {
            // Nothing
        }
        public void Definition(AST.Definition ast) 
        {
            // Nothing
        }
        public void Del(AST.Del ast) 
        {
            // Nothing
        }
        public void EOF(AST.EOF ast) 
        {
            // Nothing
        }
        public void ClassWord(AST.ClassWord ast) 
        {
            // Nothing
        }
        public void Identifier(AST.Identifier ast) 
        {
            // Nothing
        }
        public void IdentifierOperation(AST.IdentifierOperation ast) 
        {
            // Nothing
        }
        public void IfStatement(AST.IfStatement ast) 
        {
            // Nothing
        }
        public void If(AST.If ast) 
        {
            // Nothing
        }
        public void MulDivOpp(AST.MulDivOpp ast) 
        {
            // Nothing
        }
        public void Number(AST.Number ast) 
        {
            // Nothing
        }
        public void Or(AST.Or ast) 
        {
            // Nothing
        }
        public void CompareOperationP(AST.CompareOperationP ast) 
        {
            // Nothing
        }
        public void MultOperationP(AST.MultOperationP ast) 
        {
            // Nothing
        }
        public void OrOperationP(AST.OrOperationP ast) 
        {
            // Nothing
        }
        public void Parameters(AST.Parameters ast) 
        {
            // Nothing
        }
        public void ParametersP(AST.ParametersP ast) 
        {
            // Nothing
        }
        public void ParametersPP(AST.ParametersPP ast) 
        {
            // Nothing
        }
        public void Return(AST.Return ast) 
        {
            // Nothing
        }
        public void ReturnStatement(AST.ReturnStatement ast) 
        {
            // Nothing
        }
        public void SimpleDeclaration(AST.SimpleDeclaration ast) 
        {
            // Nothing
        }
        public void SimpleType(AST.SimpleType ast) 
        {
            // Nothing
        }
        public void StatementsP(AST.StatementsP ast) 
        {
            // Nothing
        }
        public void WhileStatement(AST.WhileStatement ast) 
        {
            // Nothing
        }
        public void SimpleStatementsP(AST.SimpleStatementsP ast) 
        {
            // Nothing
        }
        public void SimpleBlock(AST.SimpleBlock ast) 
        {
            // Remove all indent and dedent
            ast.Children.RemoveAll(x => x.name == "Indent" || x.name == "Dedent");
        }
        public void Type(AST.Type ast) {
            // If contains TypeParameters, is a functionPointer?
            if(ast.Children.Count == 1) 
            {
                // Replace with child
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
                return;
            }
            if(ast.Children.Find(x => x.name == "TypeParameters") != null) 
            {
                ast.name =  "FunctionPointer";
                RemoveDelimiters(ast);
                // SimpleType is now ReturnType
                ast.Children.Find(x => x.name == "SimpleType").name = "ReturnType";
            }
        }
        public void RemoveDelimiters(AST.Node ast) {
            ast.Children.RemoveAll(x => x is AST.StartDel || x is AST.EndDel);
        }
        public void SepOp(AST.SepOp ast) 
        {
            RemoveSelfFromParent(ast);
        }
        public void Assign(AST.Assign ast) {
            RemoveSelfFromParent(ast);
        }
        public void FunctionDefinition(AST.FunctionDefinition ast) {
            // Replace parent
            ast.Parent.Parent.Children.Add(ast);
            ast.Parent.Parent.Children.Remove(ast.Parent);
        }
        public void CompareOrAndAddMultDel(AST.Node ast) 
        {
            if((ast.Children.Count == 2 &&
                ast.Children[1].name == ast.name + "P") ||
                ast.Children.Count == 1)
            {
                // Put child onto parent and remove self
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), ast.Children[0]);
                RemoveSelfFromParent(ast);
            }
        }
        public void PutChildrenOntoParentAndRemoveSelf(AST.Node ast) {
            // Put all children onto parent and remove self
            if(ast.Children.Count > 0)
                ast.Parent.Children.InsertRange(ast.Parent.Children.IndexOf(ast), ast.Children);
            RemoveSelfFromParent(ast);
        }

        public void AddSubOpp(AST.AddSubOpp ast) {
            RemoveSelfFromParent(ast);
        }
        public void Declaration(AST.Declaration ast) {
            // If contains functionDefinition, put simpleType into functionDefiniton->LeftSide->simpleType
            AST.FunctionDefinition functionDefinition = (AST.FunctionDefinition)ast.Children.Find(x => x is AST.FunctionDefinition );
            if(functionDefinition != null) 
            {
                functionDefinition.Children.Insert(0, ast.Children[0]);
                functionDefinition.Children[0].name = "ReturnType";
                functionDefinition.Children.Insert(1, ast.Children[1]);
                ast.Children.RemoveAll(x => x.name != "FunctionDefinition");
            }
        }
        // SimpleType -> ReturnType i FunctionCall/Definition
        public void IdentifierStatement(AST.IdentifierStatement ast) 
        {
            // if child 1 contains Assignment, replace self with Assignment and add identifier to Assignment -> LeftSide -> Identifier
            AST.Node idop = ast.Children.Find(x => x.name == "IdentifierOperation");
            if(idop != null) {
                ast.Parent.Children.Insert(ast.Parent.Children.IndexOf(ast), idop.Children[0]);
                idop.Children[0].Children.Insert(0, new AST.LeftSide("LeftSide", false, idop.Children[0]));
                idop.Children[0].Children[0].Children.Insert(0, ast.Children[0]);
                RemoveSelfFromParent(ast);
            }  
        }

        public bool GeneralCleanUp(AST.Node ast){
            if( ast.Parent != null && 
              (ast.name == ast.Parent.name + "P" ||
               ast.name == ast.Parent.name))
            {
                // Put child onto parent and remove self
                ast.Parent.Children.InsertRange(ast.Parent.Children.IndexOf(ast), ast.Children);
                RemoveSelfFromParent(ast);
                return false;
            }
            // Empty productions must be sacrificed
            if(!ast.isTerminal && ast.Children.Count == 0) {
                RemoveSelfFromParent(ast);
                return false;
            }
            return true;
        }
        public void Visit(AST.Node ast)
        {
            //Visit bottom-up
            VisitChildren(ast);
            // Remove recursive names and empty productions
            if(!GeneralCleanUp(ast)) return;

            //Get the method information using the method info class
            ast.Accept(this);
        }
        private void VisitChildren(AST.Node ast) {
            for(int i = ast.Children.Count-1; i >= 0; i--) {
                ast.Children[i].Accept( this );
            }
        }

        private void RemoveSelfFromParent(AST.Node ast) {
            ast.Parent.Children.Remove(ast);
        }

        private bool IsTerminal(AST.Node ast) {
            return ast.isTerminal;
        }
    }
}