using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class ActualParameters : Compiler.AST.Data.Node
	{
		public  ActualParameters()
		{
		}

		public  ActualParameters(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ActualParameters";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
