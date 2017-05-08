using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class BooleanArrayInit : Compiler.C.Data.Node
	{
		public  BooleanArrayInit()
		{
		}

		public  BooleanArrayInit(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "BooleanArrayInit";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
