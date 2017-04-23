using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class RulesP : Generator.Translation.Data.Node
	{
		public  RulesP()
		{
		}

		public  RulesP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "RulesP";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
