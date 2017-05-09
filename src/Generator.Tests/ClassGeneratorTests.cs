using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Generator.Grammar;
using System.Linq;
using Generator.Class;

namespace Generator.Tests
{
    [TestClass]
    public class ClassGeneratorTests
    {
        ClassGenerator classGen;
        [TestInitialize]
        public void Setup() 
        {
            classGen = new ClassGenerator();
        }

        [TestMethod]
        public void Test()
        {
            ClassType classDef = new ClassType("namespaceTest","classModifiersTest", "identifierTest", "baseClassTest");
            classGen.GetClassTextLines(classDef);
        }
    }
}
