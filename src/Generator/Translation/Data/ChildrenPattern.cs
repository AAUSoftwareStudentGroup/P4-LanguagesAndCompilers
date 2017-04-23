using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class ChildrenPattern : Generator.Translation.Data.Node
	{
		public  ChildrenPattern()
		{
		}

		public  ChildrenPattern(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ChildrenPattern";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
