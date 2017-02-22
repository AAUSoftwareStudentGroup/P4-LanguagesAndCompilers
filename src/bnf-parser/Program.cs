using System;

namespace bnf_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            BNF_Parser parser = new BNF_Parser();
            parser.Parse(args[0]); // first program argument is filename to read
        }
    }
}
