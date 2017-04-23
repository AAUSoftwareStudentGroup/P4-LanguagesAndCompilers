using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Conclusion : Generator.Translation.Data.Node
	{
		public  Conclusion()
		{
		}

		public  Conclusion(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Conclusion";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
