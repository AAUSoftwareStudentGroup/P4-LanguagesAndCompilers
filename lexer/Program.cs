using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace P4.Lexer
{
    public class Token 
    {
        public String Type;
        public String Value;
        
        public override String ToString() {
            return $"({this.Type}: '{this.Value}')";
        }
    }

    public class TokenRule
    {
        public String Name;
        public Regex Pattern;
        public String PatternString;
        public bool SingleLine = false;
        public bool Ignore = false;
    }

    public class Lexer
    {
        public static void Main(string[] args)
        {
            List<TokenRule> rules;
            string TokenCfg = System.IO.File.ReadAllText("Token.cfg.json");
            rules = JsonConvert.DeserializeObject<List<TokenRule>>(TokenCfg);
            foreach (TokenRule r in rules) 
            {
                var options = RegexOptions.None;
                if (r.SingleLine) options |= RegexOptions.Singleline;
                
                r.Pattern = new Regex(r.PatternString, options);
                // Console.WriteLine(r.PatternString);
            }

            foreach (string arg in args)
            {
                if(System.IO.File.Exists(arg)) {
                    // read File
                    String source = arg;
                    List<Token> tokens = Analyse(System.IO.File.ReadAllText(arg), rules);
                    foreach( Token t in tokens)
                    {
                        Console.WriteLine($"({t.Type}: {t.Value})");
                    }
                }
            }
        }

        public static List<Token> Analyse(String source, List<TokenRule> rules)
        {
            List<Token> tokens = new List<Token>();
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
                            tokens.Add(token);
                            indentationLevel.Push(indentSize);
                        }
                        while(indentSize < indentationLevel.Peek())
                        {
                            indentationLevel.Pop();
                            token = new Token {
                                Type = "Dedent",
                                Value = match.Value
                            };
                            tokens.Add(token);
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
                            tokens.Add(token);
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
            return tokens;
        }
    }
}
