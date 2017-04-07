using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Grammar
{
    public class GrammarInfo
    {
        public bool IsLL1 { get; set; }
        public FirstSetTable FirstSets { get; set; }
        public FollowSetTable FollowSets { get; set; }
        public PredictSetTable PredictsSets { get; set; }
    }
}
