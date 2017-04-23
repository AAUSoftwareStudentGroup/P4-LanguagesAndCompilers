using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Rules : Generator.Translation.Data.Node
	{
		public  Rules()
		{
		}

		public  Rules(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Rules";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
