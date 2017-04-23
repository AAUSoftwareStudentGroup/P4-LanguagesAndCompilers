using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class System : Generator.Translation.Data.Node
	{
		public  System()
		{
		}

		public  System(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "System";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
