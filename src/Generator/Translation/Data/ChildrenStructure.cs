using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class ChildrenStructure : Generator.Translation.Data.Node
	{
		public  ChildrenStructure()
		{
			Id = NextId;
		}

		public  ChildrenStructure(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "ChildrenStructure";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
