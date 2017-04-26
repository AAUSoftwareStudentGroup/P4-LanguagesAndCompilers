using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Symbol : Generator.Translation.Data.Node
	{
		public  Symbol()
		{
		}

		public  Symbol(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Symbol";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
