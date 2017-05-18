using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class CompoundFormalParameter : Compiler.C.Data.Node
	{
		public  CompoundFormalParameter()
		{
			Id = NextId;
		}

		public  CompoundFormalParameter(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "CompoundFormalParameter";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
