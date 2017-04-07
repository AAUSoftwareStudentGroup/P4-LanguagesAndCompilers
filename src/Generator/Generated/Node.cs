using System.Collections.Generic;

namespace Generator.Generated
{
	public abstract class Node 
	{
		public string Name = null;
		public List<Node> Children = new List<Node>();
		public abstract T Accept<T>(Visitor<T> visitor);
	}
}
