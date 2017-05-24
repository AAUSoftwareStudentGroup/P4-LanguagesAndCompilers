using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Generator.Translation.Data
{
	public abstract class Node : List<Node>
	{
		public string Name { get; set; }
		private static int _nextId = 0;
		public static int NextId { get { return _nextId++; } }
		public int Id { get; set; }
		public bool IsPlaceholder { get; set; } = false;
		public abstract T Accept<T>(Generator.Translation.Visitors.TranslatorVisitor<T> visitor);
		public T[] Nodes<T>()where T : class
		{
			return this.Where(c => c is T).Select(c => c as T).ToArray();
		}

		public override string ToString()
		{
			return string.Join(" ", this.Select(child => child.ToString()).Where(str => !string.IsNullOrWhiteSpace(str)));
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public override bool Equals(object obj)
		{
			return obj is Generator.Translation.Data.Node && (obj as Generator.Translation.Data.Node).Id == Id;
		}
	}
}
