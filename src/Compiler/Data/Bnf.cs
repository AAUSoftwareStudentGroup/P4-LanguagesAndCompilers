using System.Linq;
using System.Collections.Generic;
using System;

namespace Compiler.Data
{
    public class Bnf 
    {
        public List<Production> Productions { get; set; }
        public List<Symbol> Terminals { get; set; }
        public List<List<Expansion>> ExpansionTable { get; set; }
        public Production RootProduction { get; set; }

        public Bnf(Production rootProduction, List<Production> productions, List<Symbol> terminals) {
            RootProduction = rootProduction;
            Productions = productions;
            Terminals = terminals;
            BuildExpansionTable();
        }

        private void BuildExpansionTable()
        {
            ExpansionTable = new List<List<Expansion>>();
            foreach(Production p in Productions)
            {
                List<Expansion> expansionRow = new List<Expansion>();
                foreach(Symbol t in Terminals)
                {
                    expansionRow.Add(null);
                }
                ExpansionTable.Add(expansionRow);
            }

            for(int i = 0; i < Productions.Count; i++)
            {
                Production p = Productions[i];
                List<Expansion> expansionRow = ExpansionTable[i];
                
                foreach(Expansion e in p.Expansions)
                {
                    /* foreach terminal in predict of e */
                    foreach(Symbol s in p.PredictSet(e, this))
                    {
                        /* expansionRow[terminal] = e */
                        int terminalIndex = Terminals.IndexOf(s);
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
            parseStack.Push(RootProduction);
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
                    else if(parseStack.Peek().Equals(eob))
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
                    int terminalIndex = Terminals.IndexOf(Terminals.FirstOrDefault((t) => t.Name == tokenStream.Current.Name));
                    int ProductionIndex = Productions.IndexOf(parseStack.Peek() as Production);
                    if(terminalIndex == -1)
                    {
                        System.Console.WriteLine($"ERROR: Token '{tokenStream.Current.Value}' of type '{tokenStream.Current.Name}', does not exsist in the BNF");
                        break;
                    }
                    Expansion e = ExpansionTable[ProductionIndex][terminalIndex];
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

		// If condition 1 and 2 is true then the bnf is ll1
        public bool IsLL1()
        {
            return Ll1Condition1() && Ll1Condition2();
        }

		// Checks if the Firstset of a production only contains distincs elements 
        public bool Ll1Condition1()
        {
            foreach (Production p in Productions)
            {
                HashSet<Symbol> union = new HashSet<Symbol>();
                foreach (var e in p.Expansions)
                {
                    if (union.Intersect(e.FirstSet()).Count() > 0)
                    {
                        return false;
                    }
                    union.UnionWith(e.FirstSet());
                }
            }
            return true;
        }

		// Checks if the set of first and followset of a production only contains distinct elements
        public bool Ll1Condition2()
        {
            foreach (var p in Productions)
            {
                if (p.DerivesEmpty() && p.FirstSet().Intersect(p.FollowSet(this)).Count() > 0)
                {

                    return false;
                }
            }
            return true;
        }

    }
}