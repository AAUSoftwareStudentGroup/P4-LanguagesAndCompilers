using Compiler.Parsing;
using Compiler.LexicalAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.IO;

namespace Compiler.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseProgram()
        {
            //Lexer lexer = new Lexer("C:/Users/Steffan/Desktop/P4-LanguagesAndCompilers/docs/tang.tokens.json");

            //string file = "C:/Users/Steffan/Desktop/P4-LanguagesAndCompilers/docs/samples/Alias.tang";

            //var tokens = lexer.Analyse(File.ReadAllText(file));
            
            //foreach(Token s in tokens)
            //{
                
            //    System.Diagnostics.Debug.WriteLine(s.Name);
            //}

            string[] testTokens = {
                "uint8",
                "identifier",
                "newline",
                "identifier",
                "=",
                "numeral",
                "newline",
                "uint8",
                "identifier",
                "newline",
                "identifier",
                "=",
                "identifier",
                "newline",
                "eof"
            };

            var list = testTokens.Select(t => new Parsing.Data.Token() { Name = t});

            var tokenlist = list.GetEnumerator();
            tokenlist.MoveNext();

            var parseTreeTest = new Parsing.Data.Program(true) {
                new Parsing.Data.GlobalStatements(true){
                    new Parsing.Data.GlobalStatement(true){
                        new Parsing.Data.Statement(true){
                            new Parsing.Data.IdentifierDeclaration(true){
                                new Parsing.Data.IntType(true){
                                    new Parsing.Data.Token(){ Name = "uint8" }
                                },
                                new Parsing.Data.Token(){Name = "identifier"},
                                new Parsing.Data.Definition(true){
                                    new Parsing.Data.Token(){ Name = "newline"}
                                }
                            }
                        }
                    },
                    new Parsing.Data.GlobalStatements(true){
                        new Parsing.Data.GlobalStatement(true){
                            new Parsing.Data.Statement(true){
                                new Parsing.Data.IdentifierStatement(true){
                                    new Parsing.Data.Token(){ Name = "identifier" },
                                    new Parsing.Data.IdentifierStatementP(true){
                                        new Parsing.Data.BitSelector(true){
                                            new Parsing.Data.Token(){ Name = "EPSILON" }
                                        },  
                                        new Parsing.Data.Token(){ Name = "=" },
                                        new Parsing.Data.Expression(true){
                                            new Parsing.Data.OrExpression(true){
                                                new Parsing.Data.AndExpression(true){
                                                    new Parsing.Data.EqExpression(true){
                                                        new Parsing.Data.RelationalExpression(true){
                                                            new Parsing.Data.AddSubExpression(true){
                                                                new Parsing.Data.MulDivExpression(true){
                                                                    new Parsing.Data.PowExpression(true){
                                                                        new Parsing.Data.PrimaryExpression(true){
                                                                            new Parsing.Data.Token(){ Name = "numeral" }
                                                                        },
                                                                        new Parsing.Data.PowExpressionP(true){
                                                                            new Parsing.Data.Token(){ Name = "EPSILON"}
                                                                        }
                                                                    },
                                                                    new Parsing.Data.MulDivExpressionP(true){
                                                                        new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                    }
                                                                },
                                                                new Parsing.Data.AddSubExpressionP(true){
                                                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                }
                                                            },
                                                            new Parsing.Data.RelationalExpressionP(true){
                                                                new Parsing.Data.Token(){ Name = "EPSILON" }
                                                            }
                                                        },
                                                        new Parsing.Data.EqExpressionP(true){
                                                            new Parsing.Data.Token(){ Name = "EPSILON" }
                                                        }
                                                    },
                                                    new Parsing.Data.AndExpressionP(true){
                                                        new Parsing.Data.Token(){ Name = "EPSILON" }
                                                    }
                                                },
                                                new Parsing.Data.OrExpressionP(true){
                                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                                }
                                            }
                                        },
                                        new Parsing.Data.Token(){ Name = "newline" }
                                    }
                                }
                            }
                        },
                        new Parsing.Data.GlobalStatements(true){
                            new Parsing.Data.GlobalStatement(true){
                                new Parsing.Data.Statement(true){
                                    new Parsing.Data.IdentifierDeclaration(true){
                                        new Parsing.Data.IntType(true){
                                            new Parsing.Data.Token(){ Name = "uint8" }
                                        },
                                        new Parsing.Data.Token(){ Name = "identifier" },
                                        new Parsing.Data.Definition(true){
                                            new Parsing.Data.Token(){ Name = "newline" }
                                        }
                                    }
                                }
                            },
                            new Parsing.Data.GlobalStatements(true){
                                new Parsing.Data.GlobalStatement(true){
                                    new Parsing.Data.Statement(true){
                                        new Parsing.Data.IdentifierStatement(true){
                                            new Parsing.Data.Token(){ Name = "identifier" },
                                            new Parsing.Data.IdentifierStatementP(true) {
                                                new Parsing.Data.BitSelector(true){
                                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                                },
                                                new Parsing.Data.Token(){ Name = "=" },
                                                new Parsing.Data.Expression(true){
                                                    new Parsing.Data.OrExpression(true){
                                                        new Parsing.Data.AndExpression(true){
                                                            new Parsing.Data.EqExpression(true){
                                                                new Parsing.Data.RelationalExpression(true){
                                                                    new Parsing.Data.AddSubExpression(true){
                                                                        new Parsing.Data.MulDivExpression(true){
                                                                            new Parsing.Data.PowExpression(true){
                                                                                new Parsing.Data.PrimaryExpression(true){
                                                                                    new Parsing.Data.Token(){ Name = "identifier" },
                                                                                    new Parsing.Data.IdentifierOperation(true){
                                                                                        new Parsing.Data.BitSelector(true){
                                                                                            new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                                        }
                                                                                    }
                                                                                },
                                                                                new Parsing.Data.PowExpressionP(true){
                                                                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                                }
                                                                            },
                                                                            new Parsing.Data.MulDivExpressionP(true){
                                                                                new Parsing.Data.Token(){ Name = "EPSILON"}
                                                                            }
                                                                        },
                                                                        new Parsing.Data.AddSubExpressionP(true){
                                                                            new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                        }
                                                                    },
                                                                    new Parsing.Data.RelationalExpressionP(true){
                                                                        new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                    }
                                                                },
                                                                new Parsing.Data.EqExpressionP(true){
                                                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                                                }
                                                            },
                                                            new Parsing.Data.AndExpressionP(true){
                                                                new Parsing.Data.Token(){Name = "EPSILON" }
                                                            }
                                                        },
                                                        new Parsing.Data.OrExpressionP(true){
                                                            new Parsing.Data.Token(){ Name = "EPSILON" }
                                                        }
                                                    }
                                                },
                                                new Parsing.Data.Token(){ Name = "newline" }
                                            }   
                                        }

                                    }
                                },
                                new Parsing.Data.GlobalStatements(true){
                                    new Parsing.Data.Token(){ Name = "EPSILON" }
                                }
                            }
                        }
                    }
                },
                new Parsing.Data.Token(){ Name = "eof" }
            };

            try
            {
                ProgramParser parser = new ProgramParser();

                var parseTree = parser.ParseProgram(tokenlist);

                var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
                foreach (var line in parseTreeLines)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                }

                System.Diagnostics.Debug.WriteLine("\n < ParserTree \n TestTree> \n");

                var parseTreeLinesTest = parseTreeTest.Accept(new Parsing.Visitors.TreePrintVisitor());
                foreach (var line in parseTreeLinesTest)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                }


                TreeAsserter(parseTree, parseTreeTest);

                //var parseTreeLine = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());


                //foreach (var line in tokens)
                //{
                //    System.Diagnostics.Debug.WriteLine(line);
                //}

            }
            catch (Exception e)
            {
               Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

        public void TreeAsserter(Parsing.Data.Node node, Parsing.Data.Node nodeTest)
        {
            Assert.AreEqual(node.Name, nodeTest.Name);

            if(node is Parsing.Data.Token){}
            else
            {
                Parsing.Data.Node[] nodeChildren = node.Nodes<Parsing.Data.Node>();
                Parsing.Data.Node[] nodeChildrenTest = nodeTest.Nodes<Parsing.Data.Node>();
                for (int i = 0;i < nodeChildren.Length; i++)
                {
                    TreeAsserter(nodeChildren[i], nodeChildrenTest[i]);
                }
            }
        }
    }
}
