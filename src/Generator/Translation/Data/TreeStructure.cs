using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class TreeStructure : Generator.Translation.Data.Node
	{
		public  TreeStructure()
		{
		}

		public  TreeStructure(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "TreeStructure";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
