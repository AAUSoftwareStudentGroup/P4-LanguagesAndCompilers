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

        public ClassType GenerateParserClass(BNF bnf, string parserName, string dataNamespace, string parserNamespace)
        {
            GrammarInfo grammerInfo = _bnfAnalyzer.Analyze(bnf);

            ClassType parserClass = new ClassType(parserNamespace, "public", parserName, null)
            {
                Usings = new List<string>()
                {
                    "using System;",
                    "using System.Collections.Generic;"
                }
            };

            parserClass.Methods = new List<MethodType>();

            MethodType parseTerminalMethod = new MethodType("public", $"{dataNamespace}.Token", "ParseTerminal")
            {
                Parameters = new List<ParameterType>()
                {
                    new ParameterType($"IEnumerator<{dataNamespace}.Token>", "tokens"),
                    new ParameterType("string", "expected")
                },
                Body = new List<string>()
                {
                    "if(expected == \"EPSILON\")",
                    "{",
                    $"\treturn new {dataNamespace}.Token() {{ Name = \"EPSILON\" }};",
                    "}",
                    $"{dataNamespace}.Token token = tokens.Current;",
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

            parserClass.Methods.Add(parseTerminalMethod);

            foreach (var production in bnf)
            {
                MethodType parseMethod = new MethodType("public", $"{dataNamespace}.{production.Key}", $"Parse{production.Key}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType($"IEnumerator<{dataNamespace}.Token>", "tokens")
                    }
                };

                List<string> methodStatements = new List<string>();

                methodStatements.Add($"{dataNamespace}.{production.Key} node = new {dataNamespace}.{production.Key}(){{ Name = \"{production.Key}\" }};");

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
                            methodStatements.Add($"\t\tnode.Add(ParseTerminal(tokens, \"{expansionSymbol}\"));");
                        }
                        else
                        {
                            methodStatements.Add($"\t\tnode.Add(Parse{expansionSymbol}(tokens));");
                        }
                    }

                    methodStatements.Add($"\t\treturn node;");
                    
                }

                methodStatements.Add($"\tdefault:");
                methodStatements.Add($"\t\tthrow new Exception();");

                methodStatements.Add("}");

                parseMethod.Body = methodStatements;

                parserClass.Methods.Add(parseMethod);
            }

            return parserClass;
        }

        public ClassType GenerateVisitorClass(BNF bnf, string visitorName, string dataNamespace, string visitorNamespace)
        {
            ClassType visitorClass = new ClassType(visitorNamespace, "public abstract", $"{visitorName}<T>", null);

            visitorClass.Methods = new List<MethodType>();

            foreach (var production in bnf)
            {
                MethodType visitMethod = CreateVisitMethod(production.Key, dataNamespace);
                visitorClass.Methods.Add(visitMethod);
            }

            MethodType visitToken = CreateVisitMethod($"Token", dataNamespace);

            visitorClass.Methods.Add(visitToken);

            MethodType visitNode = new MethodType("public abstract", "T", "Visit")
            {
                Parameters = new List<ParameterType>()
                {
                    new ParameterType($"{dataNamespace}.Node", "node")
                }
            };

            visitorClass.Methods.Add(visitNode);

            return visitorClass;
        }

        public ClassType[] GenerateParseTreeClasses(BNF bnf, string visitorName, string dataNamespace, string visitorNamespace)
        {
            List<ClassType> classes = new List<ClassType>();

            foreach (var production in bnf)
            {
                ClassType classType = CreateParseTreeClass(dataNamespace, visitorNamespace, visitorName, $"{production.Key}");
                classes.Add(classType);
            }

            ClassType nodeClass = new ClassType(dataNamespace, "public abstract", "Node", "List<Node>")
            {
                Usings = new List<string>()
                {
                    "using System.Collections.Generic;",
                    "using System.Collections;",
                    "using System.Linq;",
                },
                Fields = new List<FieldType>()
                {
                    new FieldType("public", "string", "Name") { Expression = "{ get; set; }"}
                },
                Methods = new List<MethodType>()
                {
                    new MethodType("public abstract", "T", "Accept<T>")
                    {
                        Parameters = new List<ParameterType>()
                        {
                            new ParameterType($"{visitorNamespace}.{visitorName}<T>", "visitor")
                        }
                    },
                    new MethodType("public", "T[]", "Nodes<T>")
                    {
                        Constraints = "where T : class",
                        Body = new List<string>()
                        {
                            "return this.Where(c => c is T).Select(c => c as T).ToArray();"
                        }
                    }
                }
            };

            classes.Add(nodeClass);

            ClassType tokenClass = CreateParseTreeClass(dataNamespace, visitorNamespace, visitorName, "Token");
            tokenClass.Fields.Add(new FieldType("public", "string", "Value") { Expression = "{ get; set; }" });
            tokenClass.Fields.Add(new FieldType("public", "int", "Row") { Expression = "{ get; set; }" });
            tokenClass.Fields.Add(new FieldType("public", "int", "Column") { Expression = "{ get; set; }" });

            classes.Add(tokenClass);

            classes.Add(CreateParseTreeClass(dataNamespace, visitorNamespace, visitorName, "ListNode"));

            return classes.ToArray();
        }

        private static ClassType CreateParseTreeClass(string dataNamespace, string visitorNamespace, string visitorName, string name)
        {
            return new ClassType(dataNamespace, "public", $"{name}", $"{dataNamespace}.Node")
            {
                Usings = new List<string>()
                {
                    "using System.Collections.Generic;",
                },
                Methods = new List<MethodType>()
                {
                    CreateAcceptMethod(visitorNamespace, visitorName)
                }
            };
        }

        private static MethodType CreateVisitMethod(string parameterType, string dataNamespace)
        {
            return new MethodType("public virtual", "T", "Visit")
            {
                Parameters = new List<ParameterType>()
                {
                    new ParameterType($"{dataNamespace}.{parameterType}", "node")
                },
                Body = new List<string>()
                {
                    $"return Visit(({dataNamespace}.Node)node);"
                }
            };
        }

        private static MethodType CreateAcceptMethod(string visitorNamespace, string visitorName)
        {
            return new MethodType("public override", "T", "Accept<T>")
            {
                Parameters = new List<ParameterType>()
                {
                    new ParameterType($"{visitorNamespace}.{visitorName}<T>", "visitor")
                },
                Body = new List<string>()
                {
                    "return visitor.Visit(this);"
                }
            };
        }
    }
}
