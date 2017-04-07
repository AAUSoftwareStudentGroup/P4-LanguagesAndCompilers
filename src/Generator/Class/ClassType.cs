using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    class ClassType
    {
        public string AccessModifier { get; set; }
        public string Identifier { get; set; }
        public string BaseClass { get; set; }
        public FieldType[] Fields { get; set; }
        public FieldType[] Methods { get; set; }
    }
}
