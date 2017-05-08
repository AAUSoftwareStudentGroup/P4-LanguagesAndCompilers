using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class FormalParameters : Compiler.AST.Data.Node
	{
		public  FormalParameters()
		{
		}

		public  FormalParameters(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameters";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
