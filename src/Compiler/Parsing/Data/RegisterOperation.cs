using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RegisterOperation : Compiler.Parsing.Data.Node
	{
		public  RegisterOperation()
		{
		}

		public  RegisterOperation(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
