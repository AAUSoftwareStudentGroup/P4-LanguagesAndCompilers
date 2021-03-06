using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class ReturnValue : Compiler.Parsing.Data.Node
	{
		public  ReturnValue()
		{
			Id = NextId;
		}

		public  ReturnValue(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ReturnValue";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
