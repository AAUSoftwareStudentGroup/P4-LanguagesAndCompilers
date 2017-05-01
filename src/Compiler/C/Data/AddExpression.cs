using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class AddExpression : Compiler.C.Data.Node
	{
		public  AddExpression()
		{
		}

		public  AddExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "AddExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
