using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Premises : Generator.Translation.Data.Node
	{
		public  Premises()
		{
		}

		public  Premises(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Premises";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
