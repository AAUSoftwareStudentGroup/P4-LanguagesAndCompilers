using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Error
{
    public class RuleError
    {
        public string Rule { get; set; }
        public RuleError Parent { get; set; }
        public List<RuleError> Children { get; set; }
        public List<string> ReturnTypes { get; set; }

        public RuleError()
        {
            Children = new List<RuleError>();
        }
    }

    public class RuleError<T> : RuleError
    {
        public T ErrorData { get; set; }
    }
}
