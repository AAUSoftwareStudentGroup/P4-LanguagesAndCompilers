using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class TreePattern : Generator.Translation.Data.Node
	{
		public  TreePattern()
		{
			Id = NextId;
		}

		public  TreePattern(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "TreePattern";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
