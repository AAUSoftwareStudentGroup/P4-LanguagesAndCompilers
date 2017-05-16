using System;
using System.IO;
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
        public void CompileTypesCorrectly()
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
        public void CompileOperatorsCorrectly()
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
        public void CompileDeclAndAssOneLineCorrectly()
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
        public void CompileDeclAndAssTwoLinesCorrectly()
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
        public void CompileNestedForLoopCorrectly()
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
        public void Should_ThrowException_When_ReservedKeywordIsUsed()
        {
            string tang = @"uint32 return = 42";
            string cOutput;

            TangCompiler tc = new TangCompiler();

            // An exception should be thrown when using a reserved keyword as an identifier. 
            //This will be caught by the generic exception and if it is caught, then the test passes. 
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }
        
        [TestMethod]
        public void CompileDirectBitAssCorrectly()
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
        public void CompileIfCorrectly()
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

        [TestMethod]
        // Tests that a function in tang, gives a proper function in c, when compiled.
        public void CompileFunctionCorrectly()
        {
            string tang = @"int8 foo()
    return 8

int8 a = foo()";
            string c = @"signed char foo ( ) ;
signed char a ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    return 8 ;
}
void main ( )
{
    a = foo ( ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Tests that the scope of a program in tang, gives a proper function in c, when compiled.
        public void CompileScopeCorrectly()
        {
            string tang = @"int8 foo()
    if(true)
        return 2
    return 4

int8 a = foo()";
            string c = @"signed char foo ( ) ;
signed char a ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    if ( 1 )
    {
        return 2 ;
    }
    return 4 ;
}
void main ( )
{
    a = foo ( ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Tests that a function in tang, gives a proper function in c, when compiled.
        public void Should_ThrowEception_When_ReturnTypeDiffer()
        {
            string tang = @"int8 foo()
    return 8

bool a = foo()";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            //Should throw exception, as the return type is different from the assign type.
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }

        [TestMethod]
        // Tests that a function in tang, gives a proper function in c, when compiled.
        public void Should_ThrowEception_When_ScopeIsOutOfReach()
        {
            string tang = @"nothing foo()
    int8 a = 5

a = 7";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            //Should throw exception, as the return type is different from the assign type.
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }

        [TestMethod]
        // Tests that a function in tang, gives a proper function in c, when compiled.
        public void CorrectConversionOfIntType()
        {
            string tang = @"int8 a = 10
int16 b = 20
int8 c = a + b";

            string c = @"signed char foo ( ) ;
signed char a ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    if ( 1 )
    {
        return 2 ;
    }
    return 4 ;
}
void main ( )
{
    a = foo ( ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            System.Diagnostics.Debug.WriteLine(cOutput);

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        public void Should_ThrowException_When_SameVariableDefinedInScope() 
        {
            string tang = @"int8 a = 2
if (true)
    int8 a = 5";
            string cOutput;
            TangCompiler tc = new TangCompiler();

            //Should throw exception, when variable already defined in scope.
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }

        [TestMethod]
        public void Should_ThrowException_When_AssigningIntToBool()
        {   
            string tang = @"int8 a
a = true";
            string cOutput;
            TangCompiler tc = new TangCompiler();
            
            //Should throw exception, when two different types are used in an assignment.
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }

        [TestMethod]
        public void Should_ThrowException_When_TypesDifferInArithmetic()
        {
            string tang = @"int8 i = 5
char c = '4'
i = i + c";
            string cOutput;
            TangCompiler tc = new TangCompiler();

            //should throw exception when two different types are used in arithmetic statements
            Assert.ThrowsException<Exception>(() => cOutput = tc.Compile(tang));
        }

        [TestMethod]
        public void AddExpressionSpecialTestCompiler()
        {
            /* tang:
             * int8 a = 1 + 2 + 3
             * c:
             * signed char a ;
             * void main ( ) ;
             * void main ( ) 
             * {
             *     a = 1 + 2 + 3 ;
             * }
             */ 
            string tang = System.IO.File.ReadAllText("TestFiles\\AddExpression.tang");

            string c = @"signed char a ;
void main ( ) ;
void ( )
{
	a = ( ( 1 + 2 ) + 3 ) ;
}";

            TangCompiler tc = new TangCompiler();

            string cOutput = tc.Compile(tang);

            c = new System.Text.RegularExpressions.Regex("[\r]").Replace(c, "");
            cOutput = new System.Text.RegularExpressions.Regex("[\r]").Replace(cOutput, "");

            Assert.AreEqual(c, cOutput);
        }

        [TestMethod]
        // Method to test that all programs compile correctly in Succes folder
        public void ProgramsCompileCorrectly()
        {
            string path = "Succes";
            string[] files = Directory.GetFiles(path);
            foreach(string file in files) {
                Console.WriteLine("Testing " + file + " for errors");
                string tang = File.ReadAllText(file);
                TangCompiler tc = new TangCompiler();                
                Assert.IsNotNull(tc.Compile(tang));
            }
        }

        [TestMethod]
        // Method to test that all programs does not compile correctly in Fail folder
        public void ProgramsDoesntCompileCorrectly()
        {
            string path = "Fail";
            string[] files = Directory.GetFiles(path);
            foreach(string file in files) {
                Console.WriteLine("Testing " + file + " for errors");
                string tang = File.ReadAllText(file);
                TangCompiler tc = new TangCompiler();                
                Assert.IsNull(tc.Compile(tang));
            }
        }
    }
}
