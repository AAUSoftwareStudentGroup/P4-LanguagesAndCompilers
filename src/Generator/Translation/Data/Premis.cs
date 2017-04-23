using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Premis : Generator.Translation.Data.Node
	{
		public  Premis()
		{
		}

		public  Premis(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Premis";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
