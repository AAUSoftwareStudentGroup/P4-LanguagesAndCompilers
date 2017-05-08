using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class IntegerCompoundArgs : Compiler.AST.Data.Node
	{
		public  IntegerCompoundArgs()
		{
		}

		public  IntegerCompoundArgs(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerCompoundArgs";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
