using System;
//using System.Linq;
////using Generator.Generated;


//namespace Generator
//{
//    public class PrintVisitor : Visitor
//    {
//        int _level;
//        void Print(Node node)
//        {
//            System.Console.WriteLine(string.Join("", Enumerable.Repeat(" ", _level)) + node.GetType().Name);
//            foreach(Node child in node.Children)
//            {
//                child.Accept(this);
//            }
//        }
//        public override void Visit(Statements node) => Print(node);

//        public override void Visit(StatementsP node) => Print(node);

//        public override void Visit(Statement node) => Print(node);

//        public override void Visit(Generated.Class node) => Print(node);

//        public override void Visit(ClassBlock node) => Print(node);

//        public override void Visit(ClassStatements node) => Print(node);

//        public override void Visit(ClassStatementsP node) => Print(node);

//        public override void Visit(ClassStatement node) => Print(node);

//        public override void Visit(Declaration node) => Print(node);

//        public override void Visit(IdentifierStatement node) => Print(node);

//        public override void Visit(IdentifierOperation node) => Print(node);

//        public override void Visit(Assignment node) => Print(node);

//        public override void Visit(Call node) => Print(node);

//        public override void Visit(IfStatement node) => Print(node);

//        public override void Visit(WhileStatement node) => Print(node);

//        public override void Visit(Condition node) => Print(node);

//        public override void Visit(Definition node) => Print(node);

//        public override void Visit(FunctionDefinition node) => Print(node);

//        public override void Visit(SimpleBlock node) => Print(node);

//        public override void Visit(TypedParameters node) => Print(node);

//        public override void Visit(TypedParametersP node) => Print(node);

//        public override void Visit(TypedParametersPP node) => Print(node);

//        public override void Visit(Generated.Type node) => Print(node);

//        public override void Visit(TypeParameters node) => Print(node);

//        public override void Visit(TypeParametersP node) => Print(node);

//        public override void Visit(TypeParametersPP node) => Print(node);

//        public override void Visit(SimpleStatements node) => Print(node);

//        public override void Visit(SimpleStatementsP node) => Print(node);

//        public override void Visit(SimpleStatement node) => Print(node);

//        public override void Visit(ReturnStatement node) => Print(node);

//        public override void Visit(SimpleDeclaration node) => Print(node);

//        public override void Visit(Expression node) => Print(node);

//        public override void Visit(CompareOperation node) => Print(node);

//        public override void Visit(CompareOperationP node) => Print(node);

//        public override void Visit(OrOperation node) => Print(node);

//        public override void Visit(OrOperationP node) => Print(node);

//        public override void Visit(AndOperation node) => Print(node);

//        public override void Visit(AndOperationP node) => Print(node);

//        public override void Visit(AddOperation node) => Print(node);

//        public override void Visit(AddOperationP node) => Print(node);

//        public override void Visit(MultOperation node) => Print(node);

//        public override void Visit(MultOperationP node) => Print(node);

//        public override void Visit(DelOperation node) => Print(node);

//        public override void Visit(Del node) => Print(node);

//        public override void Visit(FunctionParameters node) => Print(node);

//        public override void Visit(Parameters node) => Print(node);

//        public override void Visit(ParametersP node) => Print(node);

//        public override void Visit(ParametersPP node) => Print(node);

//        public override void Visit(Val node) => Print(node);

//        public override void Visit(Token node) => Print(node);
//    }
//}