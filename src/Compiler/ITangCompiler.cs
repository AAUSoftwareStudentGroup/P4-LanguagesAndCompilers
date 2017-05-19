using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    interface ITangCompiler
    {
         string Compile(string sourcePath, string tokensJsonPath, int DebugLevel);
         string Compile(string source, string path, string tokensJson, int DebugLevel);
    }
}
