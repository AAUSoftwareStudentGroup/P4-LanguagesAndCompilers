using System;

namespace P4.Lexer
{
    public class Token 
    {
        public String Type;
        public String Value;
        
        public override String ToString() {
            return $"({this.Type}: '{this.Value}')";
        }
    }
}