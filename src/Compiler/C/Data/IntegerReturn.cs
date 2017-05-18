using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerReturn : Compiler.C.Data.Node
	{
		public  IntegerReturn()
		{
			Id = NextId;
		}

		public  IntegerReturn(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "IntegerReturn";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
