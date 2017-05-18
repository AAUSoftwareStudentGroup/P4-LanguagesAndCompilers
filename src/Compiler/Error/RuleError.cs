using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Error
{
    public class RuleError
    {
        public bool IsError { get; set; }
        public bool IsPatternError { get; set; }
        public string Rule { get; set; }
        public RuleError Parent { get; set; }
        public List<RuleError> Children { get; set; }
        public List<string> ReturnTypes { get; set; }
        public List<string> PatternTypes { get; set; }

        public RuleError()
        {
            Children = new List<RuleError>();
            PatternTypes = new List<string>();
        }
    }

    public class RuleError<TFrom, TTo> : RuleError
    {
        public TFrom From { get; set; }
        public TTo To { get; set; }
    }
}
