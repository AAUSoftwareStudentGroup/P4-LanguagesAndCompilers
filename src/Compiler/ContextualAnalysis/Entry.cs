using Compiler.Data;

namespace Compiler.ContextualAnalysis
{
	public class Entry
	{
        private int _level;
        public Entry(string id, Node node, int level)
        {
            this.Id = id;
			this.Node = node;
            this._level = level;
        }

        public int LevelNumber => _level;
		public string Id
		{
			get;
			set;
		}

        // modify when ast structure is done
        public Node Node
        {
            get;
            set;
        }

		public storageType StorageType
		{
			get;
			set;
		}

		public Type Type
		{
			get;
			set;
		}

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Entry;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

	}

	public enum storageType
	{
		valueType,
		ReferenceType
	}
}