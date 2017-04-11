using System;
using System.Collections.Generic;
using Compiler.Data;

namespace Compiler.ContextualAnalysis
{
    public class SymbolTable
    {
        // TODO not sure if this is needed
        public static Dictionary<string, Entry> globalHashTable = new Dictionary<string, Entry>();

        Stack<Dictionary<string, Entry>> tableList = new Stack<Dictionary<string, Entry>>();

        private static int _nestingLevel;
        //List<Dictionary<string, Entry>> tableList = new List<Dictionary<string, Entry>>();

        public SymbolTable()
        {
            _nestingLevel = 0;
        }

        // Creates a new symbol table under the parentscope
        public void OpenScope()
        {
            _nestingLevel++;
            tableList.Push(new Dictionary<string, Entry>());
        }

        public Dictionary<string, Entry> getCurrentScope() {

            return tableList.Peek();
        }

        public void CloseScope() {
            var hashTable = getCurrentScope();
			foreach (var item in hashTable)
            {
                if (item.Value.LevelNumber == _nestingLevel)
                {
					hashTable.Remove(item.Key);
                }
            }
			if (hashTable.Count == 0)
            {
                tableList.Pop();
                _nestingLevel--;
            }
        }

        public void Enter(string id, Node node) {
            // 
            if (node == null)
            {
                throw  new ArgumentNullException("construct to a table must be initialised");
            }
            var currentTable = getCurrentScope();
            if (currentTable.ContainsKey(id))
            {
				throw new ArgumentException("Identifier already declared in this scope");
            }

			currentTable.Add(id, new Entry(id, node, _nestingLevel));
        }

        // Try to retrive element from table
        public Entry Retrieve(string id) {

            foreach (var currentTable in tableList)
            {

				if (currentTable.ContainsKey(id))
				{
					return currentTable[id];
				}
			}

			if (globalHashTable.ContainsKey(id))
			{
				return globalHashTable[id];
			}
			throw new ArgumentException("Undeclared variable");
		}


        public Entry RetriveLocally(string id) {
            var hashTable = getCurrentScope();
            if (hashTable.ContainsKey(id))
            {
                return hashTable[id];
            }
            return null;

        }

        public int NestingLevel => _nestingLevel;

    }
}
