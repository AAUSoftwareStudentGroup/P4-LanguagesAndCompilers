//using Compiler.Parsing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace Compiler.Tests
//{
//    [TestClass]
//    public class ParserTests
//    {
//        [TestMethod]
//        public void ParseProgram() {
//            //List<Token> tokenList = new List<Token>();

//            string[] tokens = { "simpleType", "identifier", "assign", "intLiteral", "eof" };

//            var list = tokens.Select(t => new Token() { Name = t });

//            int i = 0;
//            foreach(Token t in list)
//            {
//                Assert.AreEqual(t.Name, tokens[i]);
//                i++;
//            }

//            var tokenlist = list.GetEnumerator();
//            Parser parser = new Parser();
//            tokenlist.MoveNext();

//            PrintVisitor visitor = new PrintVisitor();

//            try
//            {
//                Node n = parser.ParseProgramNode(tokenlist);

//                string parserS = n.Accept(visitor);
//                System.Diagnostics.Debug.WriteLine(parserS);

//                string inputS = "";
//                foreach (string str in tokens)
//                {
//                    inputS += str + " ";
//                }

//                Assert.AreEqual(parserS, inputS);

//            }
//            catch (Exception e)
//            {
//                Assert.Fail("Expected no exception, but got: " + e.Message);
//            }

            
//        }
//    }
//}
