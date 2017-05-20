using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Compiler.LexicalAnalysis;
using Compiler;

namespace Compiler.Xunit
{
    public class CompilerTests
    {
        // Notes: when translating to C, there will always be a main method void main ()\n{\n} 
        // This main method will be initialised as a prototype in the beginning of the file: void main ();
        // If a variable is declared seperately from its assignment, the declaration is done in global scope before main, while the assignment is done inside main
        // All expressions are put inside parentheses, e.g. a = a + 1 -> a = (a + 1)
        // Assume a space between each token

        [Theory]
        [MemberData("FilesInTang", MemberType = typeof(CompilerTestsData))]
        // Method to test that all programs does not compile correctly in Fail folder
        public void ProgramsCompileCorrectly(string file)
        {
            TangCompiler tc = new TangCompiler();
            string expected = File.ReadAllText(file + ".c").Replace("\r","");
            string actual = tc.Compile(file, "../../../../../docs/tang.tokens.json").Replace("\r", "");
            Assert.Equal(expected, actual);
        }
        [Theory]
        [MemberData("FilesFailingInTang", MemberType = typeof(CompilerTestsData))]
        // Method to test that all programs does not compile correctly in Fail folder
        public void ProgramsDoesntCompileCorrectly(string file)
        {
            TangCompiler tc = new TangCompiler();   
            Assert.ThrowsAny<Exception>(() => tc.Compile(file, "../../../../../docs/tang.tokens.json"));
        }
    }
}
