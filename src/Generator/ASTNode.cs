using Generator.Generated;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class ASTNode : Node
    {
        public override T Accept<T>(Visitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
