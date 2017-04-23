using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Patterns : Generator.Translation.Data.Node
	{
		public  Patterns()
		{
		}

		public  Patterns(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Patterns";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
