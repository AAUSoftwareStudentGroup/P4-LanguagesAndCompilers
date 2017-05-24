using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class RegisterSimpleOperation : Compiler.Parsing.Data.Node
	{
		public  RegisterSimpleOperation()
		{
			Id = NextId;
		}

		public  RegisterSimpleOperation(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegisterSimpleOperation";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
