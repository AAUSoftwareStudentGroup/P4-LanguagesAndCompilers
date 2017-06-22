using Compiler.ASM.Visitors;
using System.Collections.Generic;

namespace Compiler.ASM.Data
{
	public class ASM : Compiler.ASM.Data.Node
	{
		public  ASM()
		{
			Id = NextId;
		}

		public  ASM(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ASM";
		}

		public override T Accept<T>(Compiler.ASM.Visitors.ASMVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
