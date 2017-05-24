using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Pattern : Generator.Translation.Data.Node
	{
		public  Pattern()
		{
			Id = NextId;
		}

		public  Pattern(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "Pattern";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
