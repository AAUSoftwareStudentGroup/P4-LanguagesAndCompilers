using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class FormalParameter : Compiler.AST.Data.Node
	{
		public  FormalParameter()
		{
		}

		public  FormalParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "FormalParameter";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
