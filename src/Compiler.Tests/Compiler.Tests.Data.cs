using System.Collections.Generic;
using System.IO;

namespace Compiler.Xunit
{
    public static class CompilerTestsData
    {
        public static IEnumerable<object[]> FilesInTang
        {
            get { 
                List<object[]> data = new List<object[]>();
                var files = Directory.GetFiles("../../../Testfiles/tang/");
                foreach(string file in files) {
                    if(file.EndsWith(".tang"))
                        data.Add(new object[]{file});
                }
                return data;
            }
        }
        public static IEnumerable<object[]> FilesFailingInTang
        {
            get { 
                List<object[]> data = new List<object[]>();
                var files = Directory.GetFiles("../../../Testfiles/Fail/");
                foreach(string file in files) {
                    data.Add(new object[]{file});
                }
                return data;
            }
        }
    }
}