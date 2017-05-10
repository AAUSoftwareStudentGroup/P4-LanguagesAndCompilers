using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ElseBlock : Compiler.Parsing.Data.Node
	{
		public  ElseBlock()
		{
		}

		public  ElseBlock(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ElseBlock";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
