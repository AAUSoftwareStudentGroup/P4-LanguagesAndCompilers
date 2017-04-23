using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class ListPattern : Generator.Translation.Data.Node
	{
		public  ListPattern()
		{
		}

		public  ListPattern(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ListPattern";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
