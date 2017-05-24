using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Token : Generator.Translation.Data.Node
	{
		public string Value { get; set; }
		public string FileName { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public  Token()
		{
			Id = NextId;
		}

		public  Token(bool isPlaceholder)
		{
			Id = NextId;
			IsPlaceholder = isPlaceholder;
			Name = "Token";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
