using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class AST : Compiler.AST.Data.Node
	{
		public  AST()
		{
		}

		public  AST(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AST";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
