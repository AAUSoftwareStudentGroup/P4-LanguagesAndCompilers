using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundArgs : Compiler.C.Data.Node
	{
		public  CompoundArgs()
		{
			Id = NextId;
		}

		public  CompoundArgs(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "CompoundArgs";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
