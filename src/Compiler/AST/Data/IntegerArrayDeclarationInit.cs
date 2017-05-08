using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerArrayDeclarationInit : Compiler.AST.Data.Node
	{
		public  IntegerArrayDeclarationInit()
		{
		}

		public  IntegerArrayDeclarationInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerArrayDeclarationInit";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
