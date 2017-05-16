using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Translation
{
    class TranslationException : Exception
    {
        public Error.RuleError Error { get; set; }

        public TranslationException(Error.RuleError error)
        {
            Error = error;
        }
    }
}
