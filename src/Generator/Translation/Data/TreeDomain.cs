using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class TreeDomain : Generator.Translation.Data.Node
	{
		public  TreeDomain()
		{
		}

		public  TreeDomain(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "TreeDomain";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
