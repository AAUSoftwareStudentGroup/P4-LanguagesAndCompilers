using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Grammar
{
    public class PredictSetTable : Dictionary<(string production, int expansion), HashSet<string>>
    {
    }
}
