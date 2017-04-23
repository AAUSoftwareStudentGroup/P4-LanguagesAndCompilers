using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Name : Generator.Translation.Data.Node
	{
		public  Name()
		{
		}

		public  Name(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Name";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
