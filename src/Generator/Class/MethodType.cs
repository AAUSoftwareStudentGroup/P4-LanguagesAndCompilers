using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    public class MethodType
    {
        public MethodType(string modifiers, string type, string identifier)
        {
            Modifiers = modifiers;
            Type = type;
            Identifier = identifier;
            Parameters = new ParameterType[0];
            Body = new string[0];
        }
        public string Type { get; set; }
        public string Modifiers { get; set; }
        public string Identifier { get; set; }
        public ParameterType[] Parameters { get; set; }
        public string[] Body { get; set; }
    }
}
