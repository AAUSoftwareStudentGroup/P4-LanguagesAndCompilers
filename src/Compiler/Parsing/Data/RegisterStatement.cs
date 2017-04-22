using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RegisterStatement : Compiler.Parsing.Data.Node
	{
		public  RegisterStatement()
		{
		}

		public  RegisterStatement(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RegisterStatement";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}