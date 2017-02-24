using System;
using System.Linq;
using System.Collections.Generic;

public class AST 
{
    public string name;
    public List<AST> children;
    public AST parent;

    public AST(string name, AST parent) 
    {
        this.parent = parent;
        this.name = name;
        this.children = new List<AST>();
    }

    // return the new child
    public AST AddChild(string name)
    {
        AST child = new AST(name, this);
        this.children.Add(child);
        return child;
    }
}

namespace P4.Data
{
    class BNF 
    {
        public List<Production> productions;
        public List<Symbol> terminals;
        public List<List<Expansion>> expansionTable;
        public Production rootProduction;

        public BNF() {
            productions = new List<Production>();
            terminals = new List<Symbol>();
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
                        /* expansionRow[terminal] = e */
                }

                for(int j = 0; j < terminals.Count; j++)
                {
                    Symbol t = terminals[j];
                    Expansion e = null;

                    expansionRow.Add(e);
                }
            }
        }

        public AST ParseTokenStream(IEnumerable<Token> tokenList)
        {
            AST syntaxTree = new AST("Root", null);
            bool valid = false;
            Stack<Symbol> parseStack = new Stack<Symbol>();
            IEnumerator<Token> tokenStream = tokenList.GetEnumerator();
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
                    }
                }
                else
                {
                    int terminalIndex = terminals.IndexOf(terminals.FirstOrDefault((t) => t.name == tokenStream.Current.name));
                    int ProductionIndex = productions.IndexOf(parseStack.Peek() as Production);
                    Expansion e = expansionTable[ProductionIndex][terminalIndex];
                    if(e == null)
                    {
                        // ERROR: Token not in first set, expected FIRST(parseStack.Peek())
                    }
                    else 
                    {
                        parseStack.Pop();
                        for(int i = e.symbols.Count-1; i >= 0; i++)
                        {
                            parseStack.Push(e.symbols[i]);
                        }
                    }
                }
            }


            return syntaxTree;
        }

    }
}