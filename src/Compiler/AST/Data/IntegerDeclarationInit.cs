using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerDeclarationInit : Compiler.AST.Data.Node
	{
		public  IntegerDeclarationInit()
		{
			Id = NextId;
		}

		public  IntegerDeclarationInit(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IntegerDeclarationInit";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
