using System;

namespace ParserGeneratorGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
        	string template = System.IO.File.ReadAllText("class.cs.template");
        	String[] inputWords = System.IO.File.ReadAllText("input.txt").Split('\n');
            
            foreach(String word in inputWords){
                System.IO.File.WriteAllText(@"../Compiler/Data/AST/" + word + ".cs", template.Replace(@"<NAME>", word));
            }
        }
    }
}
