using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Compiler.LexicalAnalysis;
using Compiler;

namespace Compiler.Tests
{
    [TestClass]
    public class CompilerTests
    {
        // Notes: when translating to C, there will always be a main method void main ()\n{\n} 
        // This main method will be initialised as a prototype in the beginning of the file: void main ();
        // If a variable is declared seperately from its assignment, the declaration is done in global scope before main, while the assignment is done inside main
        // All expressions are put inside parentheses, e.g. a = a + 1 -> a = (a + 1)
        // Assume a space between each token

        [[Fact]]
        // Method to test that all programs does not compile correctly in Fail folder
        public void ProgramsCompileCorrectly()
        {
            string path = "../../../Testfiles/tang";
            string[] files = Directory.GetFiles(path, "*.tang");
            foreach(string file in files) {
                TangCompiler tc = new TangCompiler();
                string actual = "";
                string expected = File.ReadAllText(file + ".c");
                try
                {
                    actual = actual = tc.Compile(file, "../../../../../docs/tang.tokens.json");
                } 
                catch(Exception e) 
                {
                    Console.WriteLine("ERROR IN FILE: " + file);
                    throw e;
                }
                Assert.Equal(expected, actual);
            }
        }
        [[Fact]]
        // Method to test that all programs does not compile correctly in Fail folder
        public void ProgramsDoesntCompileCorrectly()
        {
            string path = "../../../Testfiles/Fail";
            string[] files = Directory.GetFiles(path);
            foreach(string file in files) {
                Console.WriteLine("Testing " + file + " for errors");
                TangCompiler tc = new TangCompiler();   
                Assert.Throws(typeof(Exception), () => tc.Compile(file, "../../../../../docs/tang.tokens.json"));
                Console.WriteLine("Done with " + file);
            }
        }
    }
}

