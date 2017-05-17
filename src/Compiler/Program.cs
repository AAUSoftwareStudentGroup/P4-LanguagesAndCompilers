using System.IO;
using System;
using Compiler.Parsing;
using Compiler.Preprocessing;
using Compiler.LexicalAnalysis;
using System.Linq;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string tokensPath = "../../docs/tang.tokens.json";
            string sourcePath = "../../docs/samples/test.tang";
            string outputPath = sourcePath + ".c";
            int debugLevel = 0;
            TangCompiler tangCompiler = new TangCompiler();
            if(args.Count() > 0) {
                // First arg is sourcefile.
                sourcePath = args[0];
                if(args[0] == "-h" || args[0] == "--help")
                    Console.WriteLine("Usage: " + args[0] + " [SOURCEFILE] [OUTPUTFILE] [TOKENSFILE]");
            }
            if (args.Count() > 1) {
                // Second arg is output name
                outputPath = args[1];
            }
            if (args.Count() > 2) {
                tokensPath = args[2];
            }
            if (args.Count() > 3) {
                debugLevel = Int32.Parse(args[3]);
            }
            if (args.Count() > 4) {
                throw new ArgumentException("Too many arguments");
            }
            File.WriteAllText(outputPath, tangCompiler.Compile(sourcePath, tokensPath, debugLevel));
        }
    }

}
