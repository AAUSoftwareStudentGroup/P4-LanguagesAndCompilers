using Compiler.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Visitors
{
    public abstract partial class Visitor<T>
	{
        public virtual T Visit(Token node)
        {
            return Visit((Node)node);
        }

        public abstract T Visit(Node node);
    }
}
