using System;
using System.Collections.Generic;

namespace P4.BNF
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.BNF_Parser parser = new Parser.BNF_Parser();
            List<BNF.Components.Production> parsedFile = parser.ParseFile(args[0]); // first program argument is filename to read
            Console.WriteLine("Program finished");
        }
    }
}
