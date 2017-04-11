//using Generator.Generated;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace Generator
//{
//    class BuildASTVisitor : Visitor<ASTNode>
//    {
//        public override ASTNode Visit(Node node)
//        {
//            ASTNode ast = new ASTNode() { Name = node.Name };
//            foreach (var child in node.Children)
//            {
//                ast.Children.Add(child.Accept(this));
//            }
//            if(ast.Children.Any(c => c.Name != "EPSILON"))
//            {
//                ast.Children.RemoveAll(c => c.Name == "EPSILON");
//            }
//            else if(ast.Children.Count > 0)
//            {
//                ast.Children = new List<Node>();
//                ast.Name = "EPSILON";
//            }
            
//            return ast;
//        }
//    }
//}
