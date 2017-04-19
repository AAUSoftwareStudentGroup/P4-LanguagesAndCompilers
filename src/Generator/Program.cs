//#define GENERATEGENERATOR

using Generator.Parsing;
using Generator.Grammar;
using System.Collections.Generic;
using System;
using Generator.Class;
using System.IO;
using System.Linq;
//using Generator.Converter.Parsing;
using Generator.Translation;
using Generator.Lexing;
using Generator.Translation.Parsing;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            IClassGenerator classGenerator = new ClassGenerator();
            IBNFAnalyzer bnfAnalyzer = new BNFAnalyzer();
            IBNFParser bnfParser = new BNFParser();
            IParserGenerator parserGenerator = new ParserGenerator(bnfAnalyzer);
            ITranslatorGenerator translatorGenerator = new TranslatorGenerator();
#if GENERATEGENERATOR
            Console.WriteLine("Generating generator...");
            BNF bnf = bnfParser.Parse("../../docs/translator.bnf");
            string translatorParserName = "TranslatorParser";
            string translatorVisitorName = "TranslatorVisitor";
            string dataNamespace = "Generator.Translation.Data";
            string parsingNamespace = "Generator.Translation.Parsing";
            string visitorNamespace = "Generator.Translation.Visitors";
            ClassType translatorParser = parserGenerator.GenerateParserClass(bnf, translatorParserName, dataNamespace, parsingNamespace);
            ClassType translatorVisitor = parserGenerator.GenerateVisitorClass(bnf, translatorVisitorName, dataNamespace, visitorNamespace);
            ClassType[] translatorData = parserGenerator.GenerateParseTreeClasses(bnf, translatorVisitorName, dataNamespace, visitorNamespace);
            List<ClassType> classTypes = new List<ClassType>(translatorData) { translatorParser, translatorVisitor };
            foreach (ClassType classType in classTypes)
            {
                string folder = $"../{string.Join("/", classType.NameSpace.Split('.'))}";
                Directory.CreateDirectory(folder);
                classGenerator.Generate(classType, $"{folder}/{classType.Identifier.Split('<')[0]}.cs");
            }
            Console.WriteLine($"...DONE {2 + classTypes.Count} classes generated.");
#else
            Console.WriteLine("Generating compiler...");
            Console.WriteLine("\tGenerating parser...");
            BNF bnf = bnfParser.Parse("../../docs/tang.bnf");
            string programParserName = "ProgramParser";
            string programVisitorName = "ProgramVisitor";
            string dataNamespace = "Compiler.Parsing.Data";
            string parsingNamespace = "Compiler.Parsing";
            string visitorNamespace = "Compiler.Parsing.Visitors";
            ClassType programParser = parserGenerator.GenerateParserClass(bnf, programParserName, dataNamespace, parsingNamespace);
            ClassType programVisitor = parserGenerator.GenerateVisitorClass(bnf, programVisitorName, dataNamespace, visitorNamespace);
            ClassType[] programData = parserGenerator.GenerateParseTreeClasses(bnf, programVisitorName, dataNamespace, visitorNamespace);
            List<ClassType> classTypes = new List<ClassType>(programData) { programParser, programVisitor };
            Console.WriteLine("\tGenerating Program to AST translator...");
            Lexer lexer = new Lexer("../../docs/translator.tokens.json");
            IEnumerator<Translation.Data.Token> tokens = lexer.Analyse(File.ReadAllText("../../docs/tang-ast.translator")).Select(t => new Translation.Data.Token()
            {
                Name = t.Name,
                Value = t.Value,
                Row = t.Row,
                Column = t.Column
            }).GetEnumerator();
            tokens.MoveNext();
            TranslatorParser translatorParser = new TranslatorParser();
            Translation.Data.Translator translator = translatorParser.ParseTranslator(tokens);
            string translatorName = "ProgramToASTTranslator";
            string translatorNamespace = "Compiler.Translation.ProgramToAST";
            string symbolTableDataNamspace = "Compiler.Translation.SymbolTable.Data";
            string symbolTableVisitorNamspace = "Compiler.Translation.SymbolTable.Visitors";
            string symbolTableVisitorName = "SymbolTableVisitor";
            string astDataNamspace = "Compiler.AST.Data";
            string astVisitorNamspace = "Compiler.AST.Visitors";
            string astVisitorName = "ASTVisitor";
            BNF astGrammar = bnfParser.Parse("../../docs/ast.bnf");
            BNF symbolTableGrammar = bnfParser.Parse("../../docs/symboltable.bnf");
            ClassType symbolTableVisitor = parserGenerator.GenerateVisitorClass(symbolTableGrammar, symbolTableVisitorName, symbolTableDataNamspace, symbolTableVisitorNamspace);
            classTypes.Add(symbolTableVisitor);
            foreach (ClassType classType in parserGenerator.GenerateParseTreeClasses(symbolTableGrammar, symbolTableVisitorName, symbolTableDataNamspace, symbolTableVisitorNamspace))
            {
                classTypes.Add(classType);
            }
            ClassType astTableVisitor = parserGenerator.GenerateVisitorClass(astGrammar, astVisitorName, astDataNamspace, astVisitorNamspace);
            classTypes.Add(symbolTableVisitor);
            foreach (ClassType classType in parserGenerator.GenerateParseTreeClasses(astGrammar, astVisitorName, astDataNamspace, astVisitorNamspace))
            {
                classTypes.Add(classType);
            }
            List<(string nameSpace, BNF grammar)> domain = new List<(string nameSpace, BNF grammar)>()
            {
                (dataNamespace, bnf),
                (symbolTableDataNamspace, symbolTableGrammar)
            };
            List<(string nameSpace, BNF grammar)> coDomain = new List<(string nameSpace, BNF grammar)>()
            {
                (astDataNamspace, astGrammar),
                (symbolTableDataNamspace, symbolTableGrammar)
            };
            ClassType toASTTranslator = translatorGenerator.GenerateTranslatorClass(translator, translatorName, domain, coDomain, translatorNamespace);
            classTypes.Add(toASTTranslator);
            foreach (ClassType classType in classTypes)
            {
                string folder = $"../{string.Join("/", classType.NameSpace.Split('.'))}";
                Directory.CreateDirectory(folder);
                classGenerator.Generate(classType, $"{folder}/{classType.Identifier.Split('<')[0]}.cs");
            }
            Console.WriteLine($"...Done {classTypes.Count} classes generated. Thank You.");
#endif
        }
    }
}
