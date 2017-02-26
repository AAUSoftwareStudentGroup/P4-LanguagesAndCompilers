namespace Compiler.Parsing.BnfParsing
{
    public class Word
    {
        public WordType Type { get; set; }
        public string Content { get; set; }

        public Word()
        {
            Type = WordType.Ignore;
            Content = "";
        }
    }
}
