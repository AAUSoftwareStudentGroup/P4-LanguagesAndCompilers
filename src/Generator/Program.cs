﻿//#define GENERATEGENERATOR

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
#if GENERATEGENERATOR
            Console.WriteLine("Generating generator...");
            BNF bnf = bnfParser.Parse("../../docs/translator.bnf");
            string translatorParserName = "TranslatorParser";
            string translatorVisitorName = "TranslatorVisitor";
            string dataNamespace = "Generator.Translation.Data";
            string parsingNamespace = "Generator.Translation.Parsing";
            string visitorNamespace = "Generator.Translation.Visitors";
            ClassType[] translatorParser = parserGenerator.GenerateParserClasses(bnf, translatorParserName, dataNamespace, parsingNamespace);
            ClassType[] translatorVisitors = parserGenerator.GenerateVisitorClasses(bnf, translatorVisitorName, dataNamespace, visitorNamespace);
            ClassType[] translatorData = parserGenerator.GenerateSyntaxTreeClasses(bnf, translatorVisitorName, dataNamespace, visitorNamespace);
            var classTypes = translatorData.Union(translatorVisitors).Union(translatorParser);
            foreach (ClassType classType in classTypes)
            {
                string folder = $"../{string.Join("/", classType.NameSpace.Split('.'))}";
                Directory.CreateDirectory(folder);
                classGenerator.Generate(classType, $"{folder}/{classType.Identifier.Split('<')[0]}.cs");
            }
            Console.WriteLine($"...DONE {2 + classTypes.Count()} classes generated.");
#else
            ITranslatorGenerator translatorGenerator = new TranslatorGenerator();
            Console.WriteLine("Generating compiler...");
            Console.WriteLine("\tGenerating parser...");
            BNF bnf = bnfParser.Parse("../../docs/tang.bnf");
            string programParserName = "ProgramParser";
            string programVisitorName = "ProgramVisitor";
            string dataNamespace = "Compiler.Parsing.Data";
            string parsingNamespace = "Compiler.Parsing";
            string visitorNamespace = "Compiler.Parsing.Visitors";
            ClassType[] programParserClasses = parserGenerator.GenerateParserClasses(bnf, programParserName, dataNamespace, parsingNamespace);
            ClassType[] programVisitors = parserGenerator.GenerateVisitorClasses(bnf, programVisitorName, dataNamespace, visitorNamespace);
            ClassType[] programData = parserGenerator.GenerateSyntaxTreeClasses(bnf, programVisitorName, dataNamespace, visitorNamespace);
            IEnumerable<ClassType> classesToGenerate = programData.Union(programVisitors).Union(programParserClasses);
            Console.WriteLine("\tGenerating Translators...");
            Lexer lexer = new Lexer("../../docs/translator.tokens.json");

            try
            {

                IEnumerator<Translation.Data.Token> tokens = lexer.Analyse(File.ReadAllText("../../docs/tang-ast.translator"), "ast-c.translator").Select(t => new Translation.Data.Token()
                {
                    FileName = "tang-ast.translator",
                    Name = t.Name,
                    Value = t.Value,
                    Row = t.Row,
                    Column = t.Column
                }).GetEnumerator();
                tokens.MoveNext();

                IEnumerator<Translation.Data.Token> toCTranslatorTokens = lexer.Analyse(File.ReadAllText("../../docs/ast-c.translator"), "ast-c.translator").Select(t => new Translation.Data.Token()
                {
                    FileName = "ast-c.translator",
                    Name = t.Name,
                    Value = t.Value,
                    Row = t.Row,
                    Column = t.Column
                }).GetEnumerator();
                toCTranslatorTokens.MoveNext();

                TranslatorParser translatorParser = new TranslatorParser();

                Translation.Data.Translator astTranslator = translatorParser.ParseTranslator(tokens);

                Translation.Data.Translator cTranslator = translatorParser.ParseTranslator(toCTranslatorTokens);

                string translatorName = "ProgramToASTTranslator";
                string translatorNamespace = "Compiler.Translation.ProgramToAST";
                string cTranslatorName = "ASTToCTranslator";
                string cTranslatorNamespace = "Compiler.Translation.ASTToC";
                string symbolTableDataNamspace = "Compiler.Translation.SymbolTable.Data";
                string symbolTableVisitorNamspace = "Compiler.Translation.SymbolTable.Visitors";
                string symbolTableVisitorName = "SymbolTableVisitor";
                string astDataNamspace = "Compiler.AST.Data";
                string astVisitorNamespace = "Compiler.AST.Visitors";
                string astVisitorName = "ASTVisitor";
                string cDataNamspace = "Compiler.C.Data";
                string cVisitorNamespace = "Compiler.C.Visitors";
                string cVisitorName = "CVisitor";

                BNF cGrammar = bnfParser.Parse("../../docs/c.bnf");
                BNF astGrammar = bnfParser.Parse("../../docs/ast.bnf");
                BNF symbolTableGrammar = bnfParser.Parse("../../docs/symboltable.bnf");

                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateVisitorClasses(symbolTableGrammar, symbolTableVisitorName, symbolTableDataNamspace, symbolTableVisitorNamspace));
                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateSyntaxTreeClasses(symbolTableGrammar, symbolTableVisitorName, symbolTableDataNamspace, symbolTableVisitorNamspace));
                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateVisitorClasses(astGrammar, astVisitorName, astDataNamspace, astVisitorNamespace));
                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateSyntaxTreeClasses(astGrammar, astVisitorName, astDataNamspace, astVisitorNamespace));
                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateVisitorClasses(cGrammar, cVisitorName, cDataNamspace, cVisitorNamespace));
                classesToGenerate = classesToGenerate.Union(parserGenerator.GenerateSyntaxTreeClasses(cGrammar, cVisitorName, cDataNamspace, cVisitorNamespace));

                List<RelationDomain> relationDomains = new List<RelationDomain>()
                {
                    new RelationDomain(){ Identifier = "Program", Grammar = bnf, DataNamespace = dataNamespace, VisitorNamespace = visitorNamespace },
                    new RelationDomain(){ Identifier = "AST", Grammar = astGrammar, DataNamespace = astDataNamspace, VisitorNamespace = astVisitorNamespace },
                    new RelationDomain(){ Identifier = "SymbolTable", Grammar = symbolTableGrammar, DataNamespace = symbolTableDataNamspace, VisitorNamespace = symbolTableVisitorNamspace },
                };

                ClassType toASTTranslator = translatorGenerator.GenerateTranslatorClass(astTranslator, translatorName, relationDomains, translatorNamespace);

                classesToGenerate = classesToGenerate.Append(toASTTranslator);

                List<RelationDomain> cRelationDomains = new List<RelationDomain>()
                {
                    new RelationDomain(){ Identifier = "AST", Grammar = astGrammar, DataNamespace = astDataNamspace, VisitorNamespace = astVisitorNamespace },
                    new RelationDomain(){ Identifier = "C", Grammar = cGrammar, DataNamespace = cDataNamspace, VisitorNamespace = cVisitorNamespace },
                };

                ClassType toCTranslator = translatorGenerator.GenerateTranslatorClass(cTranslator, cTranslatorName, cRelationDomains, cTranslatorNamespace);

                classesToGenerate = classesToGenerate.Append(toCTranslator);

                foreach (ClassType classType in classesToGenerate)
                {
                    string folder = $"../{string.Join("/", classType.NameSpace.Split('.'))}";
                    Directory.CreateDirectory(folder);
                    classGenerator.Generate(classType, $"{folder}/{classType.Identifier.Split('<')[0]}.cs");
                }
                Console.WriteLine($"...Done {classesToGenerate.Count()} classes generated. Approximately {classesToGenerate.Sum(c => c.Methods.Sum(m => m.Body.Count + 3) + c.Usings.Count + c.Fields.Count)} lines of code. Thank You.");
            }
            catch (LexicalException exception)
            {
                Console.WriteLine($"Unexpected symbol near {exception.Symbol} in {exception.FileName} line {exception.Row + 1} column {exception.Column + 1}.");
            }
            catch (UnexpectedTokenException exception)
            {
                if (exception.Token.Name == exception.Token.Value)
                {
                    if (exception.Token.FileName != null)
                    {
                        Console.WriteLine($"Unexpected '{exception.Token.Name}' in {exception.Token.FileName} line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected '{exception.Token.Name}' at line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Unexpected {exception.Token.Name} '{exception.Token.Value}' in {exception.Token.FileName} line {exception.Token.Row + 1} column {exception.Token.Column + 1}.");
                }
            }
#endif
        }
    }
}
