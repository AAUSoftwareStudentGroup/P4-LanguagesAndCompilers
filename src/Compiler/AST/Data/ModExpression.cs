using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ModExpression : Compiler.AST.Data.Node
	{
		public  ModExpression()
		{
		}

		public  ModExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ModExpression";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
