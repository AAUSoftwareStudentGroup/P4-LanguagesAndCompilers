using System.Linq;
using System.Collections.Generic;

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
                        parseStack.Pop();
                    }
                    else if(parseStack.Peek().name == tokenStream.Current.name) {
                        syntaxTree = syntaxTree.AddChild(tokenStream.Current.name);
                        syntaxTree.AddChild(tokenStream.Current.value);
                        syntaxTree = syntaxTree.parent;
                        tokenStream.MoveNext();
                        // If parse stack is empty
                        if( parseStack.Pop().name == "EOF")
                        {
                            valid = true;
                        }
                    }
                    else
                    {
                        // ERROR: Token '{tokenStream.Current.value}' does not match the expected token '{FIRST(parseStack.Peek())}' 
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.value}' does not match the expected token 'FIRST({parseStack.Peek().name})' ");
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
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.name}' not in first set, expected 'FIRST({parseStack.Peek().name})'");
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
                        for(int i = e.symbols.Count-1; i >= 0; i--)
                        {
                            parseStack.Push(e.symbols[i]);
                        }
                    }
                }
            }

            while(syntaxTree.parent != null)
                syntaxTree = syntaxTree.parent;
            return syntaxTree;
        }

    }
}