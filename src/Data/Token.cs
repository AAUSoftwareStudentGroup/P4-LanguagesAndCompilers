using System;

namespace Compiler.Data
{
    public class Token 
    {
        public String Name { get; set; }
        public String Value { get; set; }
        
        public override String ToString() {
            return $"({Name}: '{Value}')";
        }
    }
}