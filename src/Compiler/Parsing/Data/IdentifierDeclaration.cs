using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierDeclaration : Compiler.Parsing.Data.Node
	{
		public  IdentifierDeclaration()
		{
		}

		public  IdentifierDeclaration(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierDeclaration";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
