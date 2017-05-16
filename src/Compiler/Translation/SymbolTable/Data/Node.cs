using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Compiler.Translation.SymbolTable.Data
{
	public abstract class Node : List<Node>
	{
		public string Name { get; set; }
		public bool IsPlaceholder { get; set; } = false;
		public abstract T Accept<T>(Compiler.Translation.SymbolTable.Visitors.SymbolTableVisitor<T> visitor);
		public T[] Nodes<T>()where T : class
		{
			return this.Where(c => c is T).Select(c => c as T).ToArray();
		}

		public override string ToString()
		{
			return string.Join(" ", this.Select(child => child.ToString()).Where(str => !string.IsNullOrWhiteSpace(str)));
		}
	}
}
