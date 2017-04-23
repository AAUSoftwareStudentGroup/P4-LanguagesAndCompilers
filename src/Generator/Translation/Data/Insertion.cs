using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Insertion : Generator.Translation.Data.Node
	{
		public  Insertion()
		{
		}

		public  Insertion(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Insertion";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
