using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ActualParameter : Compiler.AST.Data.Node
	{
		public  ActualParameter()
		{
		}

		public  ActualParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ActualParameter";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
