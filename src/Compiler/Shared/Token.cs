using Compiler.Data;
using Compiler.Visitors;

namespace Compiler.Shared
{
	public class Token : Node
	{
		public string Value { get; set; }
		public int Row { get; set; }
		public int Column { get; set; }
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
