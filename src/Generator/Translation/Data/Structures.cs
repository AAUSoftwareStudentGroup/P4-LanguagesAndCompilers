using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Structures : Generator.Translation.Data.Node
	{
		public  Structures()
		{
		}

		public  Structures(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Structures";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
