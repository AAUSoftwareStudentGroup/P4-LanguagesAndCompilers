using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Token : Generator.Translation.Data.Node
	{
		public string Value { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}