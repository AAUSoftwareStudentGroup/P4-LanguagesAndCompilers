using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class CompoundGlobalStatement : Compiler.AST.Data.Node
	{
		public  CompoundGlobalStatement()
		{
			Id = NextId;
		}

		public  CompoundGlobalStatement(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "CompoundGlobalStatement";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
