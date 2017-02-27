using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Parsing.BnfParsing
{
    public enum WordType
    {
        NameRead, // Name, but not on left side of Equals. Expecting to read the name from earlier definition
        NameSet, // Name, as above, but on the left side on an Equals. Expecting to set the name.
        Or, // |
        Ignore, // Stuff to ignore, like comments
        Epsilon,
        Equals // ::=
    };
}
