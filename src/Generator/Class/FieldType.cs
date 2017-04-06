using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    public class FieldType
    {
        public FieldType(string modifiers, string type, string identifier)
        {
            Modifiers = modifiers;
            Type = type;
            Identifier = identifier;
        }
        public string Modifiers { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public string Expression { get; set; }
    }
}
