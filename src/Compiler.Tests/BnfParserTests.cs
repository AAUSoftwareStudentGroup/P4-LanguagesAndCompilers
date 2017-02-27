using Compiler.Data;
using Compiler.Parsing.BnfParsing;
using System;
using Xunit;

namespace Compiler.Tests
{
    public class BnfParserTests
    {
        [Fact]
        public void Parse()
        {
            BnfParser bnfParser = new BnfParser();
            Bnf bnf = BnfParser.Parse("TestFiles/Grammar.bnf");
            Assert.NotNull(bnf);
            Assert.Equal(49, bnf.Productions.Count);
            Assert.Equal(2, bnf.Productions[48].Expansions.Count);
        }
    }
}
