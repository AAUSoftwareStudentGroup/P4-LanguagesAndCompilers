using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerArrayDeclarationEmptyInit : Compiler.AST.Data.Node
	{
		public  IntegerArrayDeclarationEmptyInit()
		{
		}

		public  IntegerArrayDeclarationEmptyInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerArrayDeclarationEmptyInit";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
