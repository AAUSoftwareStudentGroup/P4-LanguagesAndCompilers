using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ExpressionListP : Compiler.Parsing.Data.Node
	{
		public  ExpressionListP()
		{
		}

		public  ExpressionListP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ExpressionListP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
