using System.IO;
using Compiler.LexicalAnalysis;
using System;
using System.Collections.Generic;

namespace Compiler.Preprocessing
{
	public class Preprocessor 
	{
		private List<string> imports = new List<String>();
        public  List<Token> Process(Lexer lexer, string path, IEnumerable<Token> tokens) {
			bool onlyImportsYet = true;
			List<Token> newList = new List<Token>();
			foreach(Token token in tokens) {
				if(onlyImportsYet && token.Name == "import" && !imports.Contains(token.Value)) {
					var newTokens = Process(lexer,path,lexer.Analyse(File.ReadAllText(path + token.Value.Replace("import ", "") + ".tang")));
					if(newTokens == null)
						throw new Exception("Import not found");
					foreach(var newToken in newTokens)
						if(newToken.Name != "eof")
							newList.Add(newToken);
						else
							newList.RemoveAt(newList.Count - 1); // To remove last inserted newline
					imports.Add(token.Value);
				}
				else if(token.Name == "newline") {
					// Yield but dont set onlyImportsYet
					newList.Add(token);
				} else if(onlyImportsYet == false && token.Name == "import") {
					throw new Exception("Imports must be at start of file");
				} else if(token.Name == "import" && imports.Contains(token.Value)) {
					// Do exactly nothing. We already imported this
				} else {
					onlyImportsYet = false;
					newList.Add(token);
				}
			}
			return newList;
		}
    }
}