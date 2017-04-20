using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class CompoundGlobalStatement : Compiler.AST.Data.Node
	{
		public  CompoundGlobalStatement()
		{
		}

		public  CompoundGlobalStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
