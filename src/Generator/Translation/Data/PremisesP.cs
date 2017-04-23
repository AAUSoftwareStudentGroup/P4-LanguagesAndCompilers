using Generator.Translation.Visitors;
using System.Collections.Generic;

namespace Generator.Translation.Data
{
	public class PremisesP : Generator.Translation.Data.Node
	{
		public  PremisesP()
		{
		}

		public  PremisesP(bool isPlaceholder)
		{
			IsPlaceholder = isPlaceholder;
			Name = "PremisesP";
		}

		public override T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
