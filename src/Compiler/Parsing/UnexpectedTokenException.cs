using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Data;


namespace Compiler.Parsing
{
    class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(Token t)
        {
            Token = t;
        }

        public Token Token { get; set; }

    }
}
