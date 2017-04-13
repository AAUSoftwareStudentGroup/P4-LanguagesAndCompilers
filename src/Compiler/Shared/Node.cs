using Compiler.Visitors;
using System.Collections.Generic;

namespace Compiler.Shared
{
	public abstract class Node 
	{
		public string Name = null;
		public List<Node> Children = new List<Node>();
		public abstract T Accept<T>(Visitor<T> visitor);
	}
}
