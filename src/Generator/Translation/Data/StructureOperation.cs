using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class StructureOperation : Generator.Translation.Data.Node
	{
		public  StructureOperation()
		{
		}

		public  StructureOperation(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "StructureOperation";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
