using Generator.Class;
using Generator.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Generator.Tests
{
    [TestClass]
    public class ParserGeneratorTests
    {
        BNF ll1Grammar => new BNF()
        {
            { "S", new List<List<string>>(){ new List<string>(){ "A", "a" } } },
            { "A", new List<List<string>>(){ new List<string>(){ "B", "D" } } },
            { "B", new List<List<string>>(){ new List<string>(){ "b" },
                                                new List<string>(){ "EPSILON" } } },
            { "D", new List<List<string>>(){ new List<string>(){ "d" },
                                                new List<string>(){ "EPSILON" } } }
        };
    }
}
