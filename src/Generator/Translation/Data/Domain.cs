using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Domain : Generator.Translation.Data.Node
	{
		public  Domain()
		{
		}

		public  Domain(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Domain";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
