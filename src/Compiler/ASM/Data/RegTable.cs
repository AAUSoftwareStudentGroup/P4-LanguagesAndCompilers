using Compiler.ASM.Visitors;
using System.Collections.Generic;

namespace Compiler.ASM.Data
{
	public class RegTable : Compiler.ASM.Data.Node
	{
		public  RegTable()
		{
			Id = NextId;
		}

		public  RegTable(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "RegTable";
		}

		public override T Accept<T>(Compiler.ASM.Visitors.ASMVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
