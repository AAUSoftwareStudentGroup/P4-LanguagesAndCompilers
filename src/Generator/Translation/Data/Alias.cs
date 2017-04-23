using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Alias : Generator.Translation.Data.Node
	{
		public  Alias()
		{
		}

		public  Alias(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Alias";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
