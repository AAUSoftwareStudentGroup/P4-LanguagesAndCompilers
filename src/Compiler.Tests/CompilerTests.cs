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
        // Notes: when translating to C, there will always be a main method void main ()\n{\n} 
        // This main method will be initialised as a prototype in the beginning of the file: void main ();
        // If a variable is declared seperately from its assignment, the declaration is done in global scope before main, while the assignment is done inside main
        // All expressions are put inside parentheses, e.g. a = a + 1 -> a = (a + 1)
        // Assume a space between each token

        [TestMethod]
        // Method to test that each type is correctly translated from .tang to .c
        // bool in tang = unsigned char in c
        public void Types()
        {
            string tang = @"bool on = true
int8 sc = 127
int16 si = 32767
int32 sl = 9223372036854775807
uint8 uc = 255
uint16 ui = 65535
uint32 ul = 4294967295";
            string c = @"unsigned char on ;
signed char sc ;
signed int si ;
signed long sl ;
unsigned char uc ;
unsigned int ui ;
unsigned long ul ;
void main ( ) ;
void main ( )
{
    on = 1 ;
    sc = 127 ;
    si = 32767 ;
    sl = 9223372036854775807 ;
    uc = 255 ;
    ui = 65535 ;
    ul = 4294967295 ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Does not work yet, since pow is not yet implemented
        public void Operators()
        {
            string tang = @"bool off = (true or false) and !true
bool on = ((43-1) == 42)
int16 zero = ((42+18) * (10/2)) % 5
int16 hunna = 10^2
bool falseStatements = (hunna <= 101) and (hunna >= 99)";
            string c = @"unsigned char off ;
unsigned char on ;
signed int zero ;
signed int hunna ;
unsigned char falseStatements ;
void main ( ) ;
void main ( )
{
    off = ( ( ( 1 || 0 ) ) && ( ! 1 ) ) ;
    on = ( ( ( ( 43 - 1 ) ) == 42 ) ) ;
    zero = ( ( ( ( ( 42 + 18 ) ) * ( ( 10 / 2 ) ) ) ) % 5 ) ;
    hunna = ( pow ( 2 , 2 ) );
    falseStatements = ( ( ( hunna <= 101 ) ) && ( ( hunna >= 99 ) ) ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Test that a variable declared and assigned in same line is compiled correctly
        public void VarDeclAndAssInOneLine()
        {
            /* 
             * int16 a = 27 (.tang)
             * ///should be///
             * signed int a;
             * void main ( ) ;
             * void main ( )
             * {
             *     a = 27 ;
             * }
             */

            string tang = @"int16 a = 27";
            string c = @"signed int a ;
void main ( ) ;
void main ( )
{
    a = 27 ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

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
             * signed int a ;
             * void main ( ) ; 
             * void main ( )
             * {
             *     a = 27 ;
             * } (.c)
             */

            string tang = @"int16 a
a = 27";
            string c = @"signed int a ;
void main ( ) ;
void main ( )
{
    a = 27 ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

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
            string c = @"unsigned long sum ;
void main ( ) ;
void main ( )
{
    sum = 0 ;
    for ( signed char x = 0 ; x <= 10 ; x ++ )
    {
        for ( signed char y = 0 ; y <= x ; y ++ )
        {
            sum = ( sum + ( x * y ) ) ;
        }
    }
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

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
            string c = @"void main ( ) ;
void main ( )
{
    ( * ( volatile unsigned char * ) ( 36 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 36 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 36 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
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
             * signed long a ;
             * signed long b ;
             * void main ( ) ;
             * void main ( void ) 
             * {
             *     a = 20 ;
             *     b = 40 ;
             *     if ( ( a == b ) )
             *     {
             *         a = ( a + 1 ) ;
             *     }
             * } (.c)
             */

            string tang = @"int32 a
int32 b
a = 20
b = 40
if ( a == b )
    a = a + 1";
            string c = @"signed long a ;
signed long b ;
void main ( ) ;
void main ( )
{
    a = 20 ;
    b = 40 ;
    if ( ( a == b ) )
    {
        a = ( a + 1 ) ;
    }
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }
    }
}
