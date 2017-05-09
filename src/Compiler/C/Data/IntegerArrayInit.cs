using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class IntegerArrayInit : Compiler.C.Data.Node
	{
		public  IntegerArrayInit()
		{
		}

		public  IntegerArrayInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "IntegerArrayInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
