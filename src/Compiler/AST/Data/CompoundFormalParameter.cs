using Compiler.AST.Visitors;
using System.Collections.Generic;

namespace Compiler.AST.Data
{
	public class CompoundFormalParameter : Compiler.AST.Data.Node
	{
		public  CompoundFormalParameter()
		{
		}

		public  CompoundFormalParameter(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "CompoundFormalParameter";
		}

		public override T Accept<T>(Compiler.AST.Visitors.ASTVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
