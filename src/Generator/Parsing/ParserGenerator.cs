using Generator.AST;
using Generator.Grammar;
using System.IO;
using System;
using System.Collections.Generic;
using Generator.Class;
using System.Linq;

namespace Generator.Parsing
{
    public class ParserGenerator : IParserGenerator
    {
        IBNFAnalyzer _bnfAnalyzer;

        public ParserGenerator(IBNFAnalyzer bnfAnalyzer)
        {
            _bnfAnalyzer = bnfAnalyzer;
        }

        private bool IsTerminal(string symbol, BNF bnf)
        {
            return !bnf.ContainsKey(symbol);
        }

        public ClassType GenerateParserClass(BNF bnf, string targetNamespace)
        {
            GrammarInfo grammerInfo = _bnfAnalyzer.Analyze(bnf);

            ClassType parserClass = new ClassType(targetNamespace, "public", "Parser", null)
            {
                Usings = new string[]
                {
                    "using System;",
                    "using System.Collections.Generic;"
                }
            };

            List<MethodType> parseMethods = new List<MethodType>();

            MethodType parseTerminalMethod = new MethodType("public", "Token", "ParseTerminal")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("IEnumerator<Token>", "tokens"),
                    new ParameterType("string", "expected")
                },
                Body = new string[]
                {
                    "if(expected == \"EPSILON\")",
                    "{",
                    "\treturn new Token() { Name = \"EPSILON\" };",
                    "}",
                    "Token token = tokens.Current;",
                    "if(token.Name == expected)",
                    "{",
                        "\ttokens.MoveNext();",
                        "\treturn token;",
                    "}",
                    "else",
                    "{",
                        "\tthrow new Exception();",
                    "}"
                }
            };

            parseMethods.Add(parseTerminalMethod);

            foreach (var production in bnf)
            {
                MethodType parseMethod = new MethodType("public", production.Key, $"Parse{production.Key}")
                {
                    Parameters = new ParameterType[]
                    {
                        new ParameterType("IEnumerator<Token>", "tokens")
                    }
                };

                List<string> methodStatements = new List<string>();

                methodStatements.Add($"{production.Key} node = new {production.Key}(){{ Name = \"{production.Key}\", Children = new List<Node>() }};");

                methodStatements.Add("switch(tokens.Current.Name)");
                methodStatements.Add("{");

                for(int expansionIndex = 0; expansionIndex < production.Value.Count; expansionIndex++)
                {
                    foreach (var predictSymbol in grammerInfo.PredictsSets[(production.Key, expansionIndex)])
                    {
                        methodStatements.Add($"\tcase \"{predictSymbol}\":");
                    }

                    foreach (var expansionSymbol in bnf[production.Key][expansionIndex])
                    {
                        if(IsTerminal(expansionSymbol, bnf))
                        {
                            methodStatements.Add($"\t\tnode.Children.Add(ParseTerminal(tokens, \"{expansionSymbol}\"));");
                        }
                        else
                        {
                            methodStatements.Add($"\t\tnode.Children.Add(Parse{expansionSymbol}(tokens));");
                        }
                    }

                    methodStatements.Add($"\t\treturn node;");
                    
                }

                methodStatements.Add($"\tdefault:");
                methodStatements.Add($"\t\tthrow new Exception();");

                methodStatements.Add("}");

                parseMethod.Body = methodStatements.ToArray();

                parseMethods.Add(parseMethod);
            }

            parserClass.Methods = parseMethods.ToArray();

            return parserClass;
        }

        public ClassType[] GenerateParseTreeClasses(BNF bnf, string targetNamespace)
        {
            List<ClassType> classes = new List<ClassType>();

            ClassType nodeClass = CreateNodeClass(targetNamespace);
            MethodType acceptMethod = CreateAcceptMethod();
            ClassType tokenClass = CreateTokenClass(targetNamespace);
            ClassType visitorClass = new ClassType(targetNamespace, "public abstract", "Visitor<T>", null);
            List<MethodType> visitMethods = new List<MethodType>();

            foreach (var production in bnf)
            {
                MethodType visitMethod = CreateVisitMethod(production);
                visitMethods.Add(visitMethod);

                ClassType classType = CreateParseTreeClass(targetNamespace, production);
                classes.Add(classType);
            }

            MethodType visitTokenMethod = CreateVisitTokenMethod();
            MethodType visitNodeMethod = CreateVisitNodeMethod();

            visitMethods.Add(visitTokenMethod);
            visitMethods.Add(visitNodeMethod);

            visitorClass.Methods = visitMethods.ToArray();

            classes.Add(visitorClass);
            classes.Add(nodeClass);
            classes.Add(tokenClass);

            return classes.ToArray();
        }

        private static MethodType CreateVisitNodeMethod()
        {
            return new MethodType("public abstract", "T", "Visit")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Node", "node")
                }
            };
        }

        private static MethodType CreateVisitTokenMethod()
        {
            return new MethodType("public virtual", "T", "Visit")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Token", "node")
                },
                Body = new string[]
                {
                    "return Visit((Node)node);"
                }
            };
        }

        private static ClassType CreateParseTreeClass(string targetNamespace, KeyValuePair<string, List<List<string>>> production)
        {
            return new ClassType(targetNamespace, "public", production.Key, "Node")
            {
                Usings = new string[]
                {
                    "using System.Collections.Generic;"
                },
                Methods = new MethodType[]
                {
                    CreateAcceptMethod()
                }
            };
        }

        private static MethodType CreateVisitMethod(KeyValuePair<string, List<List<string>>> production)
        {
            return new MethodType("public virtual", "T", "Visit")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType(production.Key, "node")
                },
                Body = new string[]
                {
                    "return Visit((Node)node);"
                }
            };
        }

        private static ClassType CreateTokenClass(string targetNamespace)
        {
            return new ClassType(targetNamespace, "public", "Token", "Node")
            {
                Fields = new FieldType[]
                {
                    new FieldType("public", "string", "Value")
                    {
                        Expression = "{ get; set; }"
                    },
                    new FieldType("public", "int", "Line")
                    {
                        Expression = "{ get; set; }"
                    },
                    new FieldType("public", "int", "Column")
                    {
                        Expression = "{ get; set; }"
                    }
                },
                Methods = new MethodType[]
                {
                    CreateAcceptMethod()
                }
            };
        }

        private static MethodType CreateAcceptMethod()
        {
            return new MethodType("public override", "T", "Accept<T>")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Visitor<T>", "visitor")
                },
                Body = new string[]
                {
                    "return visitor.Visit(this);"
                }
            };
        }

        private static ClassType CreateNodeClass(string targetNamespace)
        {
            return new ClassType(targetNamespace, "public abstract", "Node", null)
            {
                Usings = new string[]
                {
                    "using System.Collections.Generic;"
                },
                Fields = new FieldType[]
                {
                    new FieldType("public", "string", "Name")
                    {
                        Expression = "= null;"
                    },
                    new FieldType("public", "List<Node>", "Children")
                    {
                        Expression = "= new List<Node>();"
                    }
                },
                Methods = new MethodType[]
                {
                    new MethodType("public abstract", "T", "Accept<T>")
                    {
                        Parameters = new ParameterType[]
                        {
                            new ParameterType("Visitor<T>", "visitor")
                        }
                    }
                }
            };
        }
    }
}
