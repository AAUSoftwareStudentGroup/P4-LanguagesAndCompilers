using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Compiler.LexicalAnalysis;
using System.Linq;
using System.Diagnostics;
using Compiler.Parsing;

namespace Compiler.Tests
{
    [TestClass]
    public class ProgramToASTTranslatorTests
    {
        [TestMethod]
        public void ConvertToASTCorrectly()
        {
            /* Alias.tang file:
             * uint8 a
             * a = 2
             * uint8 b
             * b = a
             * tokens:
             * uint8 identifier newline
             * identifier = numeral newline
             * uint8 identifier newline
             * identifier = identifier newline eof
             */

            // When running the method ParseProgram on an enumerator of these tokens, the result is a big parse tree
            // The goal of the ProgramToASTTranslator is to take this parse tree as input and output an AST
            // The AST output is written by hand from the .tang file, and then it is asserted if the output is equivalent to the expected output

            string source = System.IO.File.ReadAllText(AppContext.BaseDirectory + "\\TestFiles\\Alias.tang");

            // File path relative to where the debug file is located which is in a land far, far away
            Lexer l = new Lexer(AppContext.BaseDirectory + "..\\..\\..\\..\\..\\..\\docs\\tang.tokens.json");

            var tokens = l.Analyse(source);
            ProgramParser parser = new ProgramParser();
            var tokenEnumerator = tokens.Select(t => new Parsing.Data.Token() { Name = t.Name, Value = t.Value }).GetEnumerator();
            tokenEnumerator.MoveNext();
            var parseTree = parser.ParseProgram(tokenEnumerator);

            // Create a new instance of the ProgramToASTTranslator class
            var astTranslator = new Translation.ProgramToAST.ProgramToASTTranslator();
            // Use the ProgramToASTTranslator with parseTree as parameter to get the AST
            AST.Data.AST ast = astTranslator.Translatep(parseTree) as AST.Data.AST;

            // Below is a hardcoded tree of how the AST is expected to look
            var astExpected = new AST.Data.AST(true)
            {
                new AST.Data.GlobalStatement(true)
                {
                    new AST.Data.CompoundGlobalStatement(true)
                    {
                        new AST.Data.GlobalStatement(true)
                        {
                            new AST.Data.Statement(true)
                            {
                                new AST.Data.IntegerDeclaration(true)
                                {
                                    new AST.Data.IntType(true)
                                    {
                                        new AST.Data.Token(){ Name = "uint8" }
                                    },
                                    new AST.Data.Token(){ Name = "identifier" }
                                }
                            }
                        },
                        new AST.Data.Token(){ Name = "newline" },
                        new AST.Data.GlobalStatement(true)
                        {
                            new AST.Data.CompoundGlobalStatement(true)
                            {
                                new AST.Data.GlobalStatement(true)
                                {
                                    new AST.Data.Statement(true)
                                    {
                                        new AST.Data.IntegerAssignment(true)
                                        {
                                            new AST.Data.Token(){ Name = "identifier" },
                                            new AST.Data.Token(){ Name = "=" },
                                            new AST.Data.IntegerExpression(true)
                                            {
                                                new AST.Data.Token(){ Name = "numeral" }
                                            }
                                        }
                                    }
                                },
                                new AST.Data.Token(){ Name = "newline" },
                                new AST.Data.GlobalStatement(true)
                                {
                                    new AST.Data.CompoundGlobalStatement(true)
                                    {
                                        new AST.Data.GlobalStatement(true)
                                        {
                                            new AST.Data.Statement(true)
                                            {
                                                new AST.Data.IntegerDeclaration(true)
                                                {
                                                    new AST.Data.IntType(true)
                                                    {
                                                        new AST.Data.Token(){ Name = "uint8" }
                                                    },
                                                    new AST.Data.Token(){ Name = "identifier" }
                                                }
                                            }
                                        },
                                        new AST.Data.Token(){ Name = "newline" },
                                        new AST.Data.GlobalStatement(true)
                                        {
                                            new AST.Data.Statement(true)
                                            {
                                                new AST.Data.IntegerAssignment(true)
                                                {
                                                    new AST.Data.Token(){ Name = "identifier" },
                                                    new AST.Data.Token(){ Name = "=" },
                                                    new AST.Data.IntegerExpression(true)
                                                    {
                                                        new AST.Data.Token(){ Name = "identifier" }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                },
                new AST.Data.Token(){ Name = "eof" }
            };

            // Call a method to walk the tree's nodes and test if their names are equal
            TreeAsserter(ast, astExpected);
        }

        public void TreeAsserter(AST.Data.Node node, AST.Data.Node nodeTest)
        {
            Assert.AreEqual(node.Name, nodeTest.Name);

            if (node is AST.Data.Token) { }
            else
            {
                AST.Data.Node[] nodeChildren = node.Nodes<AST.Data.Node>();
                AST.Data.Node[] nodeChildrenTest = nodeTest.Nodes<AST.Data.Node>();
                for (int i = 0; i < nodeChildren.Length; i++)
                {
                    TreeAsserter(nodeChildren[i], nodeChildrenTest[i]);
                }
            }
        }

    }
}
