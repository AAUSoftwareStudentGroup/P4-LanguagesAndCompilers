using Compiler.C.Visitors;
using System.Collections.Generic;

namespace Compiler.C.Data
{
	public class NotExpression : Compiler.C.Data.Node
	{
		public  NotExpression()
		{
		}

		public  NotExpression(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "NotExpression";
		}

		public override T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
