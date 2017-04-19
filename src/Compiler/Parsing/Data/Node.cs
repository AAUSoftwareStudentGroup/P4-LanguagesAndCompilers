using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Compiler.Parsing.Data
{
	public abstract class Node : List<Node>
	{
		public string Name { get; set; }
		public abstract T Accept<T>(Compiler.Parsing.Visitors.ProgramVisitor<T> visitor);
		public T[] Nodes<T>()where T : class
		{
			return this.Where(c => c is T).Select(c => c as T).ToArray();
		}
	}
}
