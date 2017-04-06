using System.Collections.Generic;

namespace Generator.Generated
{
	public abstract class Node 
	{
		public List<Node> Children = new List<Node>();
		public abstract void Accept(Visitor visitor);
	}
}
