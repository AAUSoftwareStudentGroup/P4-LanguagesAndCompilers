using System;

namespace P4.Data
{
    public class Token 
    {
        public String name;
        public String value;
        
        public override String ToString() {
            return $"({this.name}: '{this.value}')";
        }
    }
}