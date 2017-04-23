using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class NewlineGoto : Generator.Translation.Data.Node
	{
		public  NewlineGoto()
		{
		}

		public  NewlineGoto(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "NewlineGoto";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
