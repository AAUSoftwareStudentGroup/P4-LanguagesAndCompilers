using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Generator.Translation.Data
{
	public abstract class Node : List<Node>
	{
		public string Name { get; set; }
		public bool IsPlaceholder { get; set; } = false;
		public abstract T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor);
		public T[] Nodes<T>()where T : class
		{
			return this.Where(c => c is T).Select(c => c as T).ToArray();
		}
	}
}
