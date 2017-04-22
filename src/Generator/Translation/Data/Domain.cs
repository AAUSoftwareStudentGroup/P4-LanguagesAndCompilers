using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Domain : Generator.Translation.Data.Node
	{
		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}