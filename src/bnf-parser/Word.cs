using System;

namespace P4.BNF.Parser
{
    class Word
    {
        public enum Type {
            NameRead, // Name, but not on left side of Equals. Expecting to read the name from earlier definition
            NameSet, // Name, as above, but on the left side on an Equals. Expecting to set the name.
            Or, // |
            Ignore, // Stuff to ignore, like comments
            Epsilon,
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
