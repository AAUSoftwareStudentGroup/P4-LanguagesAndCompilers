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

        public ClassType[] GenerateParserClasses(BNF bnf, string dataNameSpace, string targetNamespace)
        {
            List<ClassType> classes = new List<ClassType>();

            GrammarInfo grammerInfo = _bnfAnalyzer.Analyze(bnf);

            ClassType parserClass = new ClassType(targetNamespace, "public", "Parser", null)
            {
                Usings = new string[]
                {
                    "using System;",
                    "using System.Collections.Generic;",
                    $"using {dataNameSpace};"
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
                MethodType parseMethod = new MethodType("public", $"{production.Key}Node", $"Parse{production.Key}Node")
                {
                    Parameters = new ParameterType[]
                    {
                        new ParameterType("IEnumerator<Token>", "tokens")
                    }
                };

                List<string> methodStatements = new List<string>();

                methodStatements.Add($"{production.Key}Node node = new {production.Key}Node(){{ Name = \"{production.Key}\", Children = new List<Node>() }};");

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
                            methodStatements.Add($"\t\tnode.Children.Add(Parse{expansionSymbol}Node(tokens));");
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

            ClassType visitorClass = new ClassType(targetNamespace, "public abstract partial", "Visitor<T>", null)
            {
                Usings = new string[]
                {
                    $"using {dataNameSpace};"
                }
            };

            List<MethodType> visitMethods = new List<MethodType>();

            foreach (var production in bnf)
            {
                MethodType visitMethod = CreateVisitMethod(production);
                visitMethods.Add(visitMethod);
            }

            visitorClass.Methods = visitMethods.ToArray();

            classes.Add(parserClass);

            classes.Add(visitorClass);

            return classes.ToArray();
        }

        public ClassType[] GenerateParseTreeClasses(BNF bnf, string parserNameSpace, string targetNamespace)
        {
            List<ClassType> classes = new List<ClassType>();

            foreach (var production in bnf)
            {
                ClassType classType = CreateParseTreeClass(parserNameSpace, targetNamespace, production);
                classes.Add(classType);
            }

            return classes.ToArray();
        }

        private static ClassType CreateParseTreeClass(string parserNameSpace, string targetNamespace, KeyValuePair<string, List<List<string>>> production)
        {
            return new ClassType(targetNamespace, "public", $"{production.Key}Node", "Node")
            {
                Usings = new string[]
                {
                    "using System.Collections.Generic;",
                    $"using {parserNameSpace};"
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
                    new ParameterType($"{production.Key}Node", "node")
                },
                Body = new string[]
                {
                    "return Visit((Node)node);"
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
    }
}
