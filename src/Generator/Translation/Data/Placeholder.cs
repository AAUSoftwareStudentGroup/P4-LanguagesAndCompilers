using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Placeholder : Generator.Translation.Data.Node
	{
		public  Placeholder()
		{
		}

		public  Placeholder(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Placeholder";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
