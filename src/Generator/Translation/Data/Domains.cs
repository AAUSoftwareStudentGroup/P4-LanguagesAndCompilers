using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class Domains : Generator.Translation.Data.Node
	{
		public  Domains()
		{
		}

		public  Domains(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "Domains";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
