using Compiler.Parsing;
namespace Compiler.Data
{
	public class Token : Node
	{
		public string Value { get; set; }
		public int Line { get; set; }
		public int Column { get; set; }
		public override T Accept<T>(Visitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
