using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Translator : Generator.Translation.Data.Node
	{
		public  Translator()
		{
		}

		public  Translator(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Translator";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
