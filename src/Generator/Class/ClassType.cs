using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    public class ClassType
    {
        public ClassType(string nameSpace, string classModifiers, string identifier, string baseClass)
        {
            NameSpace = nameSpace;
            ClassModifiers = classModifiers;
            Identifier = identifier;
            BaseClass = baseClass;
            Usings = new List<string>();
            Fields = new List<FieldType>();
            Methods = new List<MethodType>();
        }

        public string NameSpace { get; set; }
        public string ClassModifiers { get; set; }
        public string Identifier { get; set; }
        public string BaseClass { get; set; }
        public List<FieldType> Fields { get; set; }
        public List<MethodType> Methods { get; set; }
        public List<string> Usings { get; set; }
    }
}
