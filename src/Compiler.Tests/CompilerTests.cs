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
        // Notes: when translating to C, there will always be a main method void main ( void )\n{\n} 
        // This main method will be initialised as a prototype in the beginning of the file: void main ( void );
        // If a variable is declared seperately from its assignment, the declaration is done in global scope before main, while the assignment is done inside main
        // All expressions are put inside parentheses, e.g. a = a + 1 -> a = (a + 1)

        // As whitespace currently appears at random (or with no reason in certain places), whitespace is removed from expected and actual output before being compared. This will probably be fixed later.

        [TestMethod]
        // Test that a variable declared and assigned in same line is compiled correctly
        public void VarDeclAndAssInOneLine()
        {
            /* 
             * int16 a = 27 (.tang)
             * ///should be///
             * void main ( void );
             * signed int a;
             * void main ( void )
             * {
             *     a = 27;
             * }
             */ 

            string tang = @"int16 a = 27";
            string c = @"void main ( void );
signed int a;
void main ( void )
{
    a = 27;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Much like the test above, this tests if a variable declared first then assigned in another line is compiled correctly
        public void VarDeclAndAssInTwoLines()
        {
            /*
             * int16 a
             * a = 27 (.tang)
             * ///should be///
             * void main ( void ); 
             * signed int a;
             * void main ( void )
             * {
             *     a = 27;
             * } (.c)
             */

            string tang = @"int16 a
a = 27";
            string c = @"void main ( void );
signed int a;
void main ( void )
{
    a = 27;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Test (nested) for
        public void ForStmTest()
        {
            string tang = @"uint32 sum
sum = 0
for(int8 x from 0 to 10)
    for(int8 y from 0 to x)
        sum = sum + x * y";
            string c = @"void main (void);
unsigned long sum;
void main (void)
{
    sum = 0 ;
    for ( signed char x = 0 ; x <= 10 ; x++ )
    {
        for ( signed char y = 0 ; y <= x ; y++ )
        {
            sum = (sum + (x * y)) ;
        }
    }
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        public void ReservedKeywordIdentifier()
        {
            string tang = @"uint32 return = 42";
            string cOutput;

            TangCompiler tc = new TangCompiler();

            // An exception should be thrown when using a reserved keyword as an identifier. This will be caught by the generic exception and if it is caught, then the test passes. If it is not caught, we make use of Assert.Fail to indicate that the test failed.
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }
        
        [TestMethod]
        public void DirectBitAss()
        {
            string tang = @"register8(36){5} = true";
            string c = @"void main ( void );
void main ( void )
{
    ( * ( volatile unsigned char * ) ( 36 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 36 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 36 ) ) & ~ ( 1 << ( 5 ) ) ) );
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[ \t\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        
        [TestMethod]
        // Fails because it initialises b before a when translating to C, this is low priority but will be fixed.
        public void IfStmTest()
        {
            /*
             * int32 a
             * int32 b
             * a = 20
             * b = 40
             * if ( a == b )
             *     a = a + 1 (.tang)
             * 
             * signed long a;
             * signed long b;
             * void main ( void ) 
             * {
             *     a = 20;
             *     b = 40;
             *     if ( (a == b) )
             *     {
             *         a = (a + 1);
             *     }
             * } (.c)
             */

            string tang = "int32 a\nint32 b\na = 20\nb = 40\nif ( a == b )\n    a = a + 1\n";
            string c = "void main ( void ) ;signed long a;\nsigned long b;\nvoid main ( void )\n{\n    a = 20;\n    b = 40;\n    if ( (a == b) )\n    {\n        a = (a + 1);\n    }\n}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = c.Replace(" ", String.Empty);
            cOutput = cOutput.Replace(" ", String.Empty);

            Assert.AreEqual(c, cOutput);
        }
    }
}
