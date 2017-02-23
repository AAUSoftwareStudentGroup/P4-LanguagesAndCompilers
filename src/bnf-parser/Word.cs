using System;

namespace bnf_parser
{
    class Word
    {
        public enum Type {
            NameRead, // Name,, but not on left side of Equals. Expecting to read the name
            NameSet, // Name, as above, but on the left side on an Equals. Expecting to set the name
            String, // Strings in quotes
            Or, // |
            GroupStart, // (
            GroupEnd, // )
            Epsilon, // EPSILON constant
            Ignore, // Other stuff to ignore, like \ and comments
            Equals // ::=
            };
    }
}
