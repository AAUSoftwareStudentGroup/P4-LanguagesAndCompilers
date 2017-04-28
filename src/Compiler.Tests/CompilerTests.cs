using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Compiler.LexicalAnalysis;
using Compiler;


namespace Compiler.Tests
{
    [TestClass]
    public class CompilerTests
    {
        // Write .tang program, examine if output C-code is correct. This tests the entire compiler. After testing .tang programs that should work, functionality such as functions, which is not yet implemented should be tested. If errors are found when pattern matching the expected C-code outcome, try to eliminate white space and newlines.
        // Use c.bnf in docs to understand how the corresponding C-program should look like.
        // Begin with very small tests 

        // When translating to .c there will always be a main method as so: void main ( void )\n{\n}
        // If a variable is declared seperately from its assignment, the declaration is done in global scope before main, while the assignment is done inside main

        // As whitespace appears at random (or with no reason in certain places), whitespace is removed from expected and actual output before being compared

        [TestMethod]
        // Test that variable declarations are compiled correctly - this does not work yet
        public void VariableDeclCorrectCompiledError()
        {
            // int16 a = 27 (tang) should be long int a = 27; (C)

            // Should work, but does not right now since have not implemented declaration and assignment in same line.
            string tang = "int16 a = 27";
            string c = "long long int a = 27;\nvoid main ( void )\n{\n}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        public void VariableDeclVariableAss()
        {
            /*
             * int16 a
             * a = 27 (.tang)
             * should be
             * long long int a;
             * void main ( void )
             * {
             *     a = 27;
             * } (.c)
             */

            string tang = "int16 a\na = 27";
            string c = "long long int a;\nvoid main ( void )\n{\n    a = 27;\n}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = c.Replace(" ", String.Empty);
            cOutput = cOutput.Replace(" ", String.Empty);

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // All expressions are put inside parentheses
        // This test fails until we've made equality test '==' in .tang instead of '='.
        public void IfStmTest()
        {
            /*
             * int16 a
             * int16 b
             * a = 20
             * b = 40
             * if ( a == b )
             *     a = a + 1 (.tang)
             * 
             * long long int a;
             * long long int b;
             * void main ( void ) 
             * {
             *     a = 20;
             *     b = 40;
             *     if ( (a == b) )
             *     {
             *         a = (a + 1);
             *     }
             * }
             */

            string tang = "int16 a\nint16 b\na = 20\nb = 40\nif ( a == b )\n    a = a + 1\n";
            string c = "long long int a;\nlong long int b;\nvoid main ( void )\n{\n    a = 20;\n    b = 40;\n    if ( (a == b) )\n    {\n        a = (a + 1);\n    }\n}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = c.Replace(" ", String.Empty);
            cOutput = cOutput.Replace(" ", String.Empty);

            Assert.AreEqual(c, cOutput);
        }
    }
}
