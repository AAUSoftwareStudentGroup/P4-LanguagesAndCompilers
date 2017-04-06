using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Class
{
    interface IClassGenerator
    {
        void Generate(ClassType classType, string outputFilePath);
    }
}
