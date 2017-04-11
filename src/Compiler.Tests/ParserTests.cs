using Compiler.Data;
using Compiler.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseProgram() {
            //List<Token> tokenList = new List<Token>();

            string[] tokens = { "simpleType", "identifier", "assign", "intLiteral", "eof" };

            //foreach (string s in tokens)
            //{
            //    tokenList.Add(new Token { Name = s, Value = s });
            //}

            var tokenlist = tokens.Select(t => new Token() { Name = t }).GetEnumerator();

            Parser parser = new Parser();
            tokenlist.MoveNext();

            try
            {
                parser.ParseProgramNode(tokenlist);
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }
    }
}
