using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    public class ClassType
    {
        public ClassType(string nameSpace, string modifiers, string identifier, string baseClass)
        {
            NameSpace = nameSpace;
            Modifiers = modifiers;
            Identifier = identifier;
            BaseClass = baseClass;
            Usings = new string[0];
            Fields = new FieldType[0];
            Methods = new MethodType[0];
        }

        public string NameSpace { get; set; }
        public string Modifiers { get; set; }
        public string Identifier { get; set; }
        public string BaseClass { get; set; }
        public FieldType[] Fields { get; set; }
        public MethodType[] Methods { get; set; }
        public string[] Usings { get; set; }
    }
}
