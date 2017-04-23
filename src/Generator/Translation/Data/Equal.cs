using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Equal : Generator.Translation.Data.Node
	{
		public  Equal()
		{
		}

		public  Equal(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Equal";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
