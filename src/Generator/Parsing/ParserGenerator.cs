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

                methodStatements.Add($"{production.Key} node = new {production.Key}(){{ Children = new List<Node>() }};");

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

            ClassType nodeClass = new ClassType(targetNamespace, "public abstract", "Node",  null)
            {
                Usings = new string[]
                {
                    "using System.Collections.Generic;"
                },
                Fields = new FieldType[]
                {
                    new FieldType("public", "List<Node>", "Children")
                    {
                        Expression = "= new List<Node>();"
                    }
                },
                Methods = new MethodType[]
                {
                    new MethodType("public abstract", "void", "Accept")
                    {
                        Parameters = new ParameterType[]
                        {
                            new ParameterType("Visitor", "visitor")
                        }
                    }
                }
            };

            classes.Add(nodeClass);

            MethodType acceptMethod = new MethodType("public override", "void", "Accept")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Visitor", "visitor")
                },
                Body = new string[]
                {
                    "visitor.Visit(this);"
                }
            };

            ClassType tokenClass = new ClassType(targetNamespace, "public", "Token", "Node")
            {
                Fields = new FieldType[]
                {
                    new FieldType("public", "string", "Name")
                    {
                        Expression = "{ get; set; }"
                    },
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
                    acceptMethod
                }
            };

            classes.Add(tokenClass);

            ClassType visitorClass = new ClassType(targetNamespace, "public abstract", "Visitor", null);

            List<MethodType> visitMethods = new List<MethodType>();

            foreach (var production in bnf)
            {
                MethodType visitMethod = new MethodType("public virtual", "void", "Visit")
                {
                    Parameters = new ParameterType[]
                    {
                        new ParameterType(production.Key, "node")
                    },
                    Body = new string[]
                    {
                        "Visit((Node)node);"
                    }
                };

                visitMethods.Add(visitMethod);

                ClassType classType = new ClassType(targetNamespace, "public", production.Key, "Node")
                {
                    Usings = new string[]
                    {
                        "using System.Collections.Generic;"
                    },
                    Methods = new MethodType[]
                    {
                        acceptMethod
                    }
                };

                classes.Add(classType);
            }

            MethodType visitTokenMethod = new MethodType("public virtual", "void", "Visit")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Token", "node")
                },
                Body = new string[]
                {
                    "Visit((Node)node);"
                }
            };

            visitMethods.Add(visitTokenMethod);

            MethodType visitNodeMethod = new MethodType("public virtual", "void", "Visit")
            {
                Parameters = new ParameterType[]
                {
                    new ParameterType("Node", "node")
                },
                Body = new string[]
                {
                    "foreach (Node child in node.Children)",
                    "{",
                        "\tchild.Accept(this);",
                    "}"
                }
            };

            visitMethods.Add(visitNodeMethod);

            visitorClass.Methods = visitMethods.ToArray();

            classes.Add(visitorClass);

            return classes.ToArray();
        }


    }
}
