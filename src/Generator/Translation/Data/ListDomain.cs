using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class ListDomain : Generator.Translation.Data.Node
	{
		public  ListDomain()
		{
		}

		public  ListDomain(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "ListDomain";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
