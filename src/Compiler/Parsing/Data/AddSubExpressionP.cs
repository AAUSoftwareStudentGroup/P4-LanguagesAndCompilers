using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class AddSubExpressionP : Compiler.Parsing.Data.Node
	{
		public  AddSubExpressionP()
		{
		}

		public  AddSubExpressionP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AddSubExpressionP";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
