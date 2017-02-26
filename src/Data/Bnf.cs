using System.Linq;
using System.Collections.Generic;

namespace Compiler.Data
{
    public class Bnf 
    {
        List<Production> _productions;
        List<Symbol> _terminals;
        List<List<Expansion>> _expansionTable;
        Production _rootProduction;

        public Bnf(Production rootProduction, List<Production> productions, List<Symbol> terminals) {
            _rootProduction = rootProduction;
            _productions = productions;
            _terminals = terminals;
            BuildExpansionTable();
        }

        public IEnumerable<Production> Productions
        {
            get { return _productions; }
        }

        private void BuildExpansionTable()
        {
            _expansionTable = new List<List<Expansion>>();
            foreach(Production p in _productions)
            {
                List<Expansion> expansionRow = new List<Expansion>();
                foreach(Symbol t in _terminals)
                {
                    expansionRow.Add(null);
                }
                _expansionTable.Add(expansionRow);
            }

            for(int i = 0; i < _productions.Count; i++)
            {
                Production p = _productions[i];
                List<Expansion> expansionRow = _expansionTable[i];
                
                foreach(Expansion e in p.Expansions)
                {
                    /* foreach terminal in predict of e */
                    foreach(Symbol s in p.PredictSet(e, this))
                    {
                        /* expansionRow[terminal] = e */
                        int terminalIndex = _terminals.IndexOf(s);
                        expansionRow[terminalIndex] = e;
                    }
                }
            }
        }

        public Tree<string> ParseTokenStream(IEnumerable<Token> tokenList)
        {
            Tree<string> syntaxTree = new Tree<string>("Root", null);
            bool valid = false;
            Stack<Symbol> parseStack = new Stack<Symbol>();
            IEnumerator<Token> tokenStream = tokenList.GetEnumerator();
            // Define end of branch symbol
            Symbol eob = new Symbol() {Name = "EOB"};

            // start enumerator by moving to first element in list
            if(tokenStream.Current == null)
                tokenStream.MoveNext();
            parseStack.Push(new Symbol(){Name = "EOF"});
            parseStack.Push(_rootProduction);
            while(!valid)
            {
                if(parseStack.Peek().IsTerminal())
                {
                    if(parseStack.Peek().Name == "EPSILON")
                    {
                        syntaxTree.AddChild(parseStack.Peek().Name);
                        // syntaxTree = syntaxTree.parent;
                        parseStack.Pop();
                    }
                    else if(parseStack.Peek() == eob)
                    {
                        syntaxTree = syntaxTree.Parent;
                        parseStack.Pop();
                    }
                    else if(parseStack.Peek().Name == tokenStream.Current.Name) {
                        syntaxTree = syntaxTree.AddChild(parseStack.Pop().Name);
                        syntaxTree.AddChild(tokenStream.Current.Value);
                        syntaxTree = syntaxTree.Parent;
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
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.Value}' of type '{tokenStream.Current.Name}', does not match the expected symbol '{parseStack.Peek().Name}' ");
                        syntaxTree.AddChild("ERROR!");
                        System.Console.WriteLine("ParseStack:");
                        while(parseStack.Count > 0)
                        {
                            System.Console.Write(parseStack.Pop().Name+" ");
                        }
                        System.Console.WriteLine();
                        break;
                    }
                }
                else
                {
                    int terminalIndex = _terminals.IndexOf(_terminals.FirstOrDefault((t) => t.Name == tokenStream.Current.Name));
                    int ProductionIndex = _productions.IndexOf(parseStack.Peek() as Production);
                    if(terminalIndex == -1)
                    {
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.Value}' of type '{tokenStream.Current.Name}', does not exsist in the BNF");
                        break;
                    }
                    Expansion e = _expansionTable[ProductionIndex][terminalIndex];
                    if(e == null)
                    {
                        // ERROR: Token not in first set, expected FIRST(parseStack.Peek())
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.Value}' of type '{tokenStream.Current.Name}', not in predict set of '({parseStack.Peek().Name})'");
                        syntaxTree.AddChild("ERROR!");
                        System.Console.WriteLine("ParseStack:");
                        while(parseStack.Count > 0)
                        {
                            System.Console.Write(parseStack.Pop().Name+" ");
                        }
                        System.Console.WriteLine();
                        break;
                    }
                    else 
                    {
                        syntaxTree = syntaxTree.AddChild(parseStack.Peek().Name);
                        parseStack.Pop();
                        
                        // END OF BRANCH
                        parseStack.Push(eob);
                        
                        for(int i = e.Symbols.Count-1; i >= 0; i--)
                        {
                            parseStack.Push(e.Symbols[i]);
                        }
                    }
                }
                
                if( parseStack.Peek().Name == "EOF")
                {
                    valid = true;
                }
            }

            while(syntaxTree.Parent != null)
                syntaxTree = syntaxTree.Parent;
            return syntaxTree;
        }

    }
}