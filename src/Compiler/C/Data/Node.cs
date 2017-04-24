using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Compiler.C.Data
{
	public abstract class Node : List<Node>
	{
		public string Name { get; set; }
		public bool IsPlaceholder { get; set; } = false;
		public abstract T Accept<T>(Compiler.C.Visitors.CVisitor<T> visitor);
		public T[] Nodes<T>()where T : class
		{
			return this.Where(c => c is T).Select(c => c as T).ToArray();
		}
	}
}
