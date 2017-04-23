using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class ListStructure : Generator.Translation.Data.Node
	{
		public  ListStructure()
		{
		}

		public  ListStructure(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ListStructure";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
