using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Lexing
{
    public class LexicalException : Exception
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string FileName { get; set; }
        public string Symbol { get; set; }

        public LexicalException(string symbol, string fileName, int row, int column)
        {
            Symbol = symbol;
            FileName = fileName;
            Row = row;
            Column = column;
        }
    }
}
