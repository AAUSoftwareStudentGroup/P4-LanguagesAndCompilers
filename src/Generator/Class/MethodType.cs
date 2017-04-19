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
            Parameters = new List<ParameterType>();
            Constraints = "";
            Body = new List<string>();
        }
        public string Type { get; set; }
        public string Modifiers { get; set; }
        public string Identifier { get; set; }
        public List<ParameterType> Parameters { get; set; }
        public string Constraints { get; set; }
        public List<string> Body { get; set; }
    }
}
