using System;

namespace P4.Data
{
    public class Token 
    {
        public String Name;
        public String Value;
        
        public override String ToString() {
            return $"({this.Name}: '{this.Value}')";
        }
    }
}