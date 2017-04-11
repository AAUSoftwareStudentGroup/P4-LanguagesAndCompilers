using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Compiler.Data;

namespace Compiler.LexicalAnalysis
{
    public class Lexer
    {
        List<LexerRule> _rules;

        public Lexer(string configPath = "Tokens.cfg.json")
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

        public IEnumerable<Token> Analyse(String source)
        {
            Token token = null;
            Match match = null;
            int currentIndex = 0;

            //Variables to keep track of where we are in the file
            //line = amount of newlines since beginning of file, column = amount of characters since last newline
            //lines and columns are 0-indexed
            int row = 0;
            int column = 0;

            Regex BeforeIndent = new Regex(@"[\\t ]*[\n\r]+", RegexOptions.Singleline);
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
                    match = Indentation.Match(source, currentIndex);
                    if(match.Success && match.Index == currentIndex) {
                        int indentSize = match.Value.Length;
                        currentIndex += indentSize;
                        
                        if(indentSize > indentationLevel.Peek())
                        {
                            token = new Token {
                                Name = "Indent",
                                Value = match.Value,
                                Line = row,
                                Column = column
                            };
                            column += token.Value.Length;
                            indentationLevel.Push(indentSize);
                            yield return token;
                        }
                        else
                        {
                            token = new Token
                            {
                                Name = "NewLine",
                                Value = match.Value,
                                Line = row,
                                Column = column
                            };
                            row++;
                            column = 0;
                            yield return token;
                        }
                        while(indentSize < indentationLevel.Peek())
                        {
                            indentationLevel.Pop();
                            token = new Token {
                                Name = "Dedent",
                                Value = match.Value,
                                Line = row,
                                Column = column
                            };
                            column += token.Value.Length;
                            yield return token;

                            token = new Token {
                                Name = "NewLine",
                                Value = match.Value,
                                Line = row,
                                Column = column
                            };
                            row++;
                            column = 0;
                            yield return token;
                        }
                    }
                    continue;
                }

                foreach (LexerRule rule in _rules){
                    match = rule.Pattern.Match(source, currentIndex);
                    if(match.Success && match.Index == currentIndex){
                        currentIndex += match.Value.Length;
                        token = new Token {
                            Name = rule.Name,
                            Value = match.Value,
                            Line = row,
                            Column = column
                        };
                        column += token.Value.Length;
                        if (!rule.Ignore) {
                            yield return token;
                        }
                        break;
                    }
                }

                if(token == null)
                {
                    Console.WriteLine("Error before: ..."+source.Substring(currentIndex, 10));
                    throw new Exception("Error before: ..."+source.Substring(currentIndex, 10));
                }
            }
            while(indentationLevel.Peek() > 0)
            {
                indentationLevel.Pop();
                token = new Token {
                    Name = "Dedent",
                    Value = match.Value,
                    Line = row,
                    Column = column
                };
                column += token.Value.Length;
                yield return token;

                token = new Token {
                    Name = "NewLine",
                    Value = match.Value,
                    Line = row,
                    Column = column
                };
                row++;
                column = 0;
                yield return token;
            }
            yield return new Token {Name = "eof", Value = "", Line = row, Column = column};
        }
    }
}
