using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    class MethodType
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
        public ParameterType[] Parameters { get; set; }
        public StatementType[] Body { get; set; }
    }
}
