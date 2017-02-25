using System.Linq;
using System.Collections.Generic;
using System;

namespace P4.Data
{
    public class BNF 
    {
        public List<Production> productions;
        public List<Symbol> terminals;
        public List<List<Expansion>> expansionTable;
        public Production rootProduction;

        public BNF(Production rootProduction, List<Production> productions, List<Symbol> terminals) {
            this.rootProduction = rootProduction;
            this.productions = productions;
            this.terminals = terminals;
            BuildExpansionTable();
        }

        private void BuildExpansionTable()
        {
            expansionTable = new List<List<Expansion>>();
            foreach(Production p in productions)
            {
                List<Expansion> expansionRow = new List<Expansion>();
                foreach(Symbol t in terminals)
                {
                    expansionRow.Add(null);
                }
                expansionTable.Add(expansionRow);
            }

            for(int i = 0; i < productions.Count; i++)
            {
                Production p = productions[i];
                List<Expansion> expansionRow = expansionTable[i];
                
                foreach(Expansion e in p.expansions)
                {
                    /* foreach terminal in predict of e */
                    foreach(Symbol s in p.PredictSet(e, this))
                    {
                        /* expansionRow[terminal] = e */
                        int terminalIndex = terminals.IndexOf(s);
                        expansionRow[terminalIndex] = e;
                    }
                }
            }
        }

        public AST ParseTokenStream(IEnumerable<Token> tokenList)
        {
            AST syntaxTree = new AST("Root", null);
            bool valid = false;
            Stack<Symbol> parseStack = new Stack<Symbol>();
            IEnumerator<Token> tokenStream = tokenList.GetEnumerator();
            // Define end of branch symbol
            Symbol eob = new Symbol() {name = "EOB"};

            // start enumerator by moving to first element in list
            if(tokenStream.Current == null)
                tokenStream.MoveNext();
            parseStack.Push(new Symbol(){name = "EOF"});
            parseStack.Push(rootProduction);
            while(!valid)
            {
                if(parseStack.Peek().IsTerminal())
                {
                    if(parseStack.Peek().name == "EPSILON")
                    {
                        syntaxTree.AddChild(parseStack.Peek().name);
                        // syntaxTree = syntaxTree.parent;
                        parseStack.Pop();
                    }
                    else if(parseStack.Peek() == eob)
                    {
                        syntaxTree = syntaxTree.parent;
                        parseStack.Pop();
                    }
                    else if(parseStack.Peek().name == tokenStream.Current.name) {
                        syntaxTree = syntaxTree.AddChild(parseStack.Pop().name);
                        syntaxTree.AddChild(tokenStream.Current.value);
                        syntaxTree = syntaxTree.parent;
                        if(tokenStream.MoveNext() == false)
                        {
                            System.Console.WriteLine("ERROR: No more tokens in input stream");
                            break;
                        }
                        // If parse stack is empty
                    }
                    else
                    {
                        // ERROR: Token '{tokenStream.Current.value}' does not match the expected token '{FIRST(parseStack.Peek())}' 
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.value}' of type '{tokenStream.Current.name}', does not match the expected symbol '{parseStack.Peek().name}' ");
                        syntaxTree.AddChild("ERROR!");
                        System.Console.WriteLine("ParseStack:");
                        while(parseStack.Count > 0)
                        {
                            System.Console.Write(parseStack.Pop().name+" ");
                        }
                        System.Console.WriteLine();
                        break;
                    }
                }
                else
                {
                    int terminalIndex = terminals.IndexOf(terminals.FirstOrDefault((t) => t.name == tokenStream.Current.name));
                    int ProductionIndex = productions.IndexOf(parseStack.Peek() as Production);
                    if(terminalIndex == -1)
                    {
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.value}' of type '{tokenStream.Current.name}', does not exsist in the BNF");
                        break;
                    }
                    Expansion e = expansionTable[ProductionIndex][terminalIndex];
                    if(e == null)
                    {
                        // ERROR: Token not in first set, expected FIRST(parseStack.Peek())
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.value}' of type '{tokenStream.Current.name}', not in predict set of '({parseStack.Peek().name})'");
                        syntaxTree.AddChild("ERROR!");
                        System.Console.WriteLine("ParseStack:");
                        while(parseStack.Count > 0)
                        {
                            System.Console.Write(parseStack.Pop().name+" ");
                        }
                        System.Console.WriteLine();
                        break;
                    }
                    else 
                    {
                        syntaxTree = syntaxTree.AddChild(parseStack.Peek().name);
                        parseStack.Pop();
                        
                        // END OF BRANCH
                        parseStack.Push(eob);
                        
                        for(int i = e.symbols.Count-1; i >= 0; i--)
                        {
                            parseStack.Push(e.symbols[i]);
                        }
                    }
                }
                
                if( parseStack.Peek().name == "EOF")
                {
                    valid = true;
                }
            }

            while(syntaxTree.parent != null)
                syntaxTree = syntaxTree.parent;
            return syntaxTree;
        }

		public bool IsLL1()
		{
			foreach (Production A in this.productions.Skip(3))
			{
				HashSet<Symbol> predictSet = new HashSet<Symbol>();
				foreach (var expansion in A.expansions)
				{
					var s = A.PredictSet(expansion, this);
					var intersection = s.Intersect(predictSet).ToList();
					if (intersection.Count != 0)
					{
						A.PredictSet(expansion, this);
						A.FollowSet(this);
						return false;
					}
					predictSet.UnionWith(s);

				}
				predictSet = null;
			}
			return true;
		}

    }
}