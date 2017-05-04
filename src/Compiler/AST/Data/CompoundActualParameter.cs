using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class CompoundActualParameter : Compiler.AST.Data.Node
	{
		public  CompoundActualParameter()
		{
		}

		public  CompoundActualParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundActualParameter";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
