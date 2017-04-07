using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    public class ParameterType
    {
        public ParameterType(string type, string identifier)
        {
            Type = type;
            Identifier = identifier;
        }
        public string Type { get; set; }
        public string Identifier { get; set; }
    }
}
