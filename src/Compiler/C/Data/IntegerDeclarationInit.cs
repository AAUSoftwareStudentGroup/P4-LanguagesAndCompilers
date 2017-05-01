using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerDeclarationInit : Compiler.C.Data.Node
	{
		public  IntegerDeclarationInit()
		{
		}

		public  IntegerDeclarationInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerDeclarationInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
