using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Structure : Generator.Translation.Data.Node
	{
		public  Structure()
		{
		}

		public  Structure(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Structure";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
