using System;
using Compiler.Shared;

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
