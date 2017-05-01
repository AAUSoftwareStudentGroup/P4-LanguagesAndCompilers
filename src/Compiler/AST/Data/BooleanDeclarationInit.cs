using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class BooleanDeclarationInit : Compiler.AST.Data.Node
	{
		public  BooleanDeclarationInit()
		{
		}

		public  BooleanDeclarationInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanDeclarationInit";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
