using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
    }

    public class Lexer
    {
        public static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if(System.IO.File.Exists(arg)) {
                    // read File
                    String source = arg;
                    Analyse(System.IO.File.ReadAllText(arg));
                }
            }
        }

        public static void Analyse(String source)
        {
            List<TokenRule> rules = new List<TokenRule> {
                new TokenRule {
                    Name = "LineComment",
                    Pattern = new Regex(@"//.*")
                },
                new TokenRule {
                    Name = "BlockComment",
                    Pattern = new Regex(@"/\*.*\*/", RegexOptions.Singleline)
                },
                new TokenRule {
                    Name = "Whitespace",
                    Pattern = new Regex(@"[\t ]+")
                },
                new TokenRule {
                    Name = "Indent",
                    Pattern = new Regex(@"\n\r?[\t ]*")
                },
                new TokenRule {
                    Name = "typeInteger",
                    Pattern = new Regex(@"u?int(8|16|32)")
                },
                new TokenRule {
                    Name = "typeNothing",
                    Pattern = new Regex(@"nothing")
                },
                new TokenRule {
                    Name = "TypeDecimal",
                    Pattern = new Regex(@"decimal")
                },
                new TokenRule {
                    Name = "Keyword",
                    Pattern = new Regex(@"(if)|(while)|(for)")
                },
                new TokenRule {
                    Name = "Decimal",
                    Pattern = new Regex(@"[+-]?(0|([1-9][0-9]*))\.[0-9]+")
                },
                new TokenRule {
                    Name = "Integer",
                    Pattern = new Regex(@"[+-]?(0|([1-9][0-9]*))")
                },
                new TokenRule {
                    Name = "Operator",
                    Pattern = new Regex(@"(==)|=|/|\*|\+|-")
                },
                new TokenRule {
                    Name = "ComponentSelector",
                    Pattern = new Regex(@"\.")
                },
                new TokenRule {
                    Name = "CommaSeperator",
                    Pattern = new Regex(@",")
                },
                new TokenRule {
                    Name = "OpenParenthesis",
                    Pattern = new Regex(@"\(")
                },
                new TokenRule {
                    Name = "CloseParenthesis",
                    Pattern = new Regex(@"\)")
                },
                new TokenRule {
                    Name = "OpenCurlybrace",
                    Pattern = new Regex(@"\{")
                },
                new TokenRule {
                    Name = "CloseCurlybrace",
                    Pattern = new Regex(@"\}")
                },
                new TokenRule {
                    Name = "Identifier",
                    Pattern = new Regex(@"_*[a-zA-Z][a-zA-Z_0-9]*")
                },
            };
            List<Token> tokens = new List<Token>();

            int currentIndex = 0;
            while(currentIndex < source.Length) 
            {
                Token token = null;

                foreach (TokenRule rule in rules)
                {
                    Match match = rule.Pattern.Match(source, currentIndex);
                    if(match.Success && match.Index - currentIndex == 0)
                    {
                        token = new Token {
                            Type = rule.Name,
                            Value = match.Value
                        };
                        currentIndex += token.Value.Length;
                        Console.WriteLine(token);
                        break;
                    }
                }

                if(token == null)
                {
                    return;
                }

            }
        }
    }
}
