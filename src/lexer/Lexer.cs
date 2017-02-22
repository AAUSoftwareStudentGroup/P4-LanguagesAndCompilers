using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace P4.Lexer
{
    public class Lexer
    {
        private List<TokenRule> rules;

        public Lexer(string configPath = "Token.cfg.json")
        {
            string TokenCfg = System.IO.File.ReadAllText(configPath);
            rules = JsonConvert.DeserializeObject<List<TokenRule>>(TokenCfg);
            foreach (TokenRule r in rules) 
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
                                Type = "Indent",
                                Value = match.Value
                            };
                            indentationLevel.Push(indentSize);
                            yield return token;
                        }
                        while(indentSize < indentationLevel.Peek())
                        {
                            indentationLevel.Pop();
                            token = new Token {
                                Type = "Dedent",
                                Value = match.Value
                            };
                            yield return token;
                        }
                    }
                    continue;
                }

                foreach (TokenRule rule in rules)
                {
                    match = rule.Pattern.Match(source, currentIndex);
                    if(match.Success && match.Index == currentIndex)
                    {
                        currentIndex += match.Value.Length;
                        token = new Token {
                            Type = rule.Name,
                            Value = match.Value
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
            yield break;
        }
    }
}
