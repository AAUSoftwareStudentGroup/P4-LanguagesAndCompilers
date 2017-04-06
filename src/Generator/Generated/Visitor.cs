namespace Generator.Generated
{
	public abstract class Visitor 
	{
		public abstract void Visit(S node);
		public abstract void Visit(A node);
		public abstract void Visit(B node);
		public abstract void Visit(D node);
		public abstract void Visit(Token node);
	}
}
