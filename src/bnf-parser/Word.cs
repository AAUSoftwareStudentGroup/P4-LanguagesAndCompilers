using System;

namespace bnf_parser
{
    class Word
    {
        public enum Type {
            NameRead, // Name, but not on left side of Equals. Expecting to read the name from earlier definition
            NameSet, // Name, as above, but on the left side on an Equals. Expecting to set the name.
            String, // Constants
            Or, // |
            GroupStart, // (
            GroupEnd, // )
            Epsilon, // EPSILON constant
            Ignore, // Stuff to ignore, like comments
            Equals // ::=
            };
            public Type type;
            public string word;

            public Word() {
                type = Type.Ignore;
                word = "";
            }
    }
}
