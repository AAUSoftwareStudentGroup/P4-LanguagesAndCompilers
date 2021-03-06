﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Linq;

namespace Generator.Lexing
{
    public class Lexer
    {
        List<LexerRule> _rules;

        public Lexer(string configPath)
        {
            //Read json file with regular expressions
            string TokenCfg = System.IO.File.ReadAllText(configPath);
            //Convert to a list of LexerRules
            _rules = JsonConvert.DeserializeObject<List<LexerRule>>(TokenCfg);
            foreach (LexerRule r in _rules) 
            {
                //Initialise options to be nothing
                var options = RegexOptions.None;
                //If the rule can cover multiple lines (e.g. block comments) activate single line: this ignores newline
                if (r.SingleLine) options |= RegexOptions.Singleline;
                
                r.Pattern = new Regex(r.PatternString, options);
            }
        }

        public IEnumerable<Token> Analyse(String source, string fileName)
        {
            Token token = null;
            Match match = null;
            int currentIndex = 0;

            //Variables to keep track of where we are in the file
            //line = amount of newlines since beginning of file, column = amount of characters since last newline
            //lines and columns are 0-indexed and count spaces
            int row = 0;
            int column = 0;

            Regex BeforeIndent = new Regex(@"[\t ]*[\n\r]+", RegexOptions.Singleline);
            Regex Indentation = new Regex(@" *");
            Stack<int> indentationLevel = new Stack<int>();
            indentationLevel.Push(0);

            while(currentIndex < source.Length) 
            {
                token = null;
                // Generate indentation to
                match = BeforeIndent.Match(source, currentIndex);
                if(match.Success && match.Index == currentIndex)
                {
                    currentIndex += match.Value.Length;
                    UpdateCounters(match, ref row, ref column);
                    match = Indentation.Match(source, currentIndex);
                    if (match.Success && match.Index == currentIndex)
                    {
                        int indentSize = match.Value.Length;
                        currentIndex += indentSize;
                        UpdateCounters(match, ref row, ref column);
                        if (indentSize > indentationLevel.Peek())
                        {
                            token = new Token
                            {
                                Name = "indent",
                                Value = match.Value,
                                Row = row,
                                Column = column
                            };
                            indentationLevel.Push(indentSize);
                            yield return token;
                        }
                        else
                        {
                            token = new Token
                            {
                                Name = "newline",
                                Value = match.Value,
                                Row = row,
                                Column = column
                            };
                            yield return token;
                        }
                        while (indentSize < indentationLevel.Peek())
                        {
                            indentationLevel.Pop();
                            token = new Token
                            {
                                Name = "dedent",
                                Value = match.Value,
                                Row = row,
                                Column = column
                            };
                            yield return token;

                            token = new Token
                            {
                                Name = "newline",
                                Value = match.Value,
                                Row = row,
                                Column = column
                            };
                            yield return token;
                        }
                    }
                    continue;
                }

                foreach (LexerRule rule in _rules){
                    match = rule.Pattern.Match(source, currentIndex);
                    if(match.Success && match.Index == currentIndex){
                        currentIndex += match.Value.Length;
                        UpdateCounters(match, ref row, ref column);
                        token = new Token {
                            Name = rule.Name,
                            Value = match.Value,
                            Row = row,
                            Column = column
                        };
                        if (!rule.Ignore) {
                            yield return token;
                        }
                        break;
                    }
                }

                if(token == null)
                {
                    throw new LexicalException(source.Substring(currentIndex, Math.Min(source.Length - currentIndex, 10)).Split(' ')[0] + "...", fileName, row, column);
                }
            }
            while(indentationLevel.Peek() > 0)
            {
                indentationLevel.Pop();
                token = new Token {
                    Name = "dedent",
                    Value = match.Value,
                    Row = row,
                    Column = column
                };
                yield return token;

                token = new Token {
                    Name = "newline",
                    Value = match.Value,
                    Row = row,
                    Column = column
                };
                yield return token;
            }
            yield return new Token {Name = "eof", Value = "", Row = row, Column = column};
        }

        private static void UpdateCounters(Match match, ref int row, ref int column)
        {
            int newLines = match.Value.Where(c => c == '\n').Count();
            if (newLines > 0)
            {
                row += newLines;
                column = 0;
            }
            else
            {
                column += match.Value.Length;
            }
        }
    }
}
