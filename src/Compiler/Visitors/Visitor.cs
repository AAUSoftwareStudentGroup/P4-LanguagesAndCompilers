﻿using Compiler.Shared;

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
