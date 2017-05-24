using Compiler.Parsing.Visitors;
using System.Collections.Generic;

namespace Compiler.Parsing.Data
{
	public class IdentifierSimpleDeclaration : Compiler.Parsing.Data.Node
	{
		public  IdentifierSimpleDeclaration()
		{
			Id = NextId;
		}

		public  IdentifierSimpleDeclaration(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IdentifierSimpleDeclaration";
		}

		public override T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
