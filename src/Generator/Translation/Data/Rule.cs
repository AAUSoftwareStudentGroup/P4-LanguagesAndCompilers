using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Rule : Generator.Translation.Data.Node
	{
		public  Rule()
		{
		}

		public  Rule(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Rule";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
