using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Translation.ProgramToAST
{
    public partial class ProgramToASTTranslator
    {
        public AST.Data.Node Translatetype(AST.Data.Token numeral)
        {
            if(numeral.Name == "numeral" && int.TryParse(numeral.Value, out int i))
            {
                if(i <= 127 && i >= -128)
                {
                    return new AST.Data.Token(false) { Name = "int8", Value = "int8" };
                }
                else if(i <= 32767 && i >= -32768)
                {
                    return new AST.Data.Token(false) { Name = "int16", Value = "int16" };
                }
                else if(i <= 2147483647 && i >= -2147483648)
                {
                    return new AST.Data.Token(false) { Name = "int32", Value = "int32" };
                }
            }
            return null;
        }
    }
}
