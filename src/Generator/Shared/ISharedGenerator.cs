using System.IO;

namespace Generator.Shared
{
    public interface ISharedGenerator
    {
        BNF LoadBNF(string inputBNFGrammarFile);
    }
}
