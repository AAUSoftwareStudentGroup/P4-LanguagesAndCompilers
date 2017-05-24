using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Systems : Generator.Translation.Data.Node
	{
		public  Systems()
		{
			Id = NextId;
		}

		public  Systems(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "Systems";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
