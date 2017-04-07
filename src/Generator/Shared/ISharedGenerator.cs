using System.IO;

namespace Generator.Shared
{
    public interface ISharedGenerator
    {
        void LoadBNF(string inputBNFGrammarFile);
    }
}