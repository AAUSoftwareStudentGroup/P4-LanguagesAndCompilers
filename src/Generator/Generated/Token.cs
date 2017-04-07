namespace Generator.Generated
{
	public class Token : Node
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public int Line { get; set; }
		public int Column { get; set; }
		public override void Accept(Visitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
