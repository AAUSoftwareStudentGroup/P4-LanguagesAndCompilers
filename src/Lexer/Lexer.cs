using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using P4.Data;

namespace P4.LexicalAnalysis
{
    public class Lexer
    {
        private List<LexerRule> rules;

        public Lexer(string configPath = "Tokens.cfg.json")
        {
            string TokenCfg = System.IO.File.ReadAllText(configPath);
            rules = JsonConvert.DeserializeObject<List<LexerRule>>(TokenCfg);
            foreach (LexerRule r in rules) 
            {
                var options = RegexOptions.None;
                if (r.SingleLine) options |= RegexOptions.Singleline;
                
                r.Pattern = new Regex(r.PatternString, options);
            }
        }

        public IEnumerable<Token> Analyse(String source)
        {
            Token token = null;
            Match match = null;
            int currentIndex = 0;

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
                        
                        token = new Token {
                            name = "NewLine",
                            value = match.Value
                        };
                        yield return token;
                        if(indentSize > indentationLevel.Peek())
                        {
                            token = new Token {
                                name = "Indent",
                                value = match.Value
                            };
                            indentationLevel.Push(indentSize);
                            yield return token;
                        }
                        while(indentSize < indentationLevel.Peek())
                        {
                            indentationLevel.Pop();
                            token = new Token {
                                name = "Dedent",
                                value = match.Value
                            };
                            yield return token;

                            token = new Token {
                                name = "NewLine",
                                value = match.Value
                            };
                            yield return token;
                        }
                    }
                    continue;
                }

                foreach (LexerRule rule in rules)
                {
                    match = rule.Pattern.Match(source, currentIndex);
                    if(match.Success && match.Index == currentIndex)
                    {
                        currentIndex += match.Value.Length;
                        token = new Token {
                            name = rule.Name,
                            value = match.Value
                        };
                        if(!rule.Ignore) {
                            yield return token;
                        }
                        break;
                    }
                }

                if(token == null)
                {
                    Console.WriteLine("Error before: ..."+source.Substring(currentIndex, 10));
                    break;
                }
            }
        }
    }
}
