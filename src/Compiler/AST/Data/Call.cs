using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class Call : Compiler.AST.Data.Node
	{
		public  Call()
		{
		}

		public  Call(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Call";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
