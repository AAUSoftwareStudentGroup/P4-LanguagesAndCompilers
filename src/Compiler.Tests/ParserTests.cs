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

            Lexer lexer = new Lexer("../docs/tang.tokens.json");

            var tokens = lexer.Analyse(File.ReadAllText("../docs/samples/Alias.tang"));

            System.Diagnostics.Debug.WriteLine(string.Join(" ", tokens.Select(t => t.Name)));

            string[] testtokens = { "intType", "identifier", "newline", "identifier", "=", "intLiteral", "newline", "intType", "identifier", "newline", "identifier", "=", "identifier", "eof" };

            var list = testtokens.Select(t => new Parsing.Data.Token() { Name = t});

            var tokenlist = list.GetEnumerator();
            tokenlist.MoveNext();
            System.Diagnostics.Debug.WriteLine("test string \n and another");

            var parseTreeTest = new Parsing.Data.Program(true) {
                new Parsing.Data.GlobalStatements(true){
                    new Parsing.Data.GlobalStatement(true){
                        new Parsing.Data.Statement(true){
                            new Parsing.Data.IdentifierDeclaration(true){
                                new Parsing.Data.Token(){Name = "intType"},
                                new Parsing.Data.Token(){Name = "identifier"},
                            }
                        }
                    },
                    new Parsing.Data.GlobalStatementsP(true){
                        new Parsing.Data.Token(){ Name = "newline" },
                        new Parsing.Data.GlobalStatement(true){
                            new Parsing.Data.Statement(true){
                                new Parsing.Data.Assignment(true){
                                    new Parsing.Data.Token(){ Name = "identifier" },
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
                                                                new Parsing.Data.PrimaryExpression(true){
                                                                    new Parsing.Data.Token(){ Name = "intLiteral" }
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
                                    }
                                }
                            }
                        },
                        new Parsing.Data.GlobalStatementsP(true){
                            new Parsing.Data.Token(){ Name = "newline" },
                            new Parsing.Data.GlobalStatement(true){
                                new Parsing.Data.Statement(true){
                                    new Parsing.Data.IdentifierDeclaration(true){
                                        new Parsing.Data.Token(){ Name = "intType" },
                                        new Parsing.Data.Token(){ Name = "identifier" }
                                    }
                                }
                            },
                            new Parsing.Data.GlobalStatementsP(true){
                                new Parsing.Data.Token(){ Name = "newline" },
                                new Parsing.Data.GlobalStatement(true){
                                    new Parsing.Data.Statement(true){
                                        new Parsing.Data.Assignment(true){
                                            new Parsing.Data.Token(){ Name = "identifier" },
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
                                                                        new Parsing.Data.PrimaryExpression(true){
                                                                            new Parsing.Data.Token(){ Name = "identifier" },
                                                                            new Parsing.Data.BitSelector(true){
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
                                            }
                                        }
                                    }
                                },
                                new Parsing.Data.GlobalStatementsP(true){
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

                //var parseTreeLines = parseTree.Accept(new Parsing.Visitors.TreePrintVisitor());
                //foreach(var line in parseTreeLines)
                //{
                //    System.Diagnostics.Debug.WriteLine(line);
                //}

                //var parseTreeLinesTest = parseTreeTest.Accept(new Parsing.Visitors.TreePrintVisitor());
                //foreach (var line in parseTreeLinesTest)
                //{
                //    System.Diagnostics.Debug.WriteLine(line);
                //}


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
                Assert.AreEqual(nodeChildren, nodeChildrenTest);
                for (int i = 0;i < nodeChildren.Length; i++)
                {
                    TreeAsserter(nodeChildren[i], nodeChildrenTest[i]);
                }
            }
          
            

        }
    }
}
