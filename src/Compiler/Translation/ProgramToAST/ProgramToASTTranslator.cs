namespace Compiler.Translation.ProgramToAST
{
	public class ProgramToASTTranslator 
	{
		public int Translatep__program = 0;
		public int Translates__identifier_symbolTable = 0;
		public int Translates___return_declarations = 0;
		public int Translatef__program_symbolTable = 0;
		public int Translatef__globalStatements_symbolTable = 0;
		public int Translatef__globalStatement_symbolTable = 0;
		public int Translatef__interrupt_symbolTable = 0;
		public int Translatef__statements_symbolTable = 0;
		public int Translatef__statement_symbolTable = 0;
		public int Translatef__identifierDeclaration_symbolTable = 0;
		public int Translateq__formalParameters = 0;
		public int Translateq__formalParametersP = 0;
		public int Translateq__formalParameter = 0;
		public int Translateq__type = 0;
		public int Translatef__registerStatement_symbolTable = 0;
		public int Translate__program_symbolTable = 0;
		public int Translate__globalStatements_symbolTable = 0;
		public int Translate__globalStatement_symbolTable = 0;
		public int Translate__interrupt_symbolTable = 0;
		public int Translate__statements_symbolTable = 0;
		public int Translate__statement_symbolTable = 0;
		public int Translate__returnStatement_symbolTable = 0;
		public int Translate__identifierDeclaration_symbolTable = 0;
		public int Translate__formalParameters_symbolTable = 0;
		public int Translate__formalParametersP_symbolTable = 0;
		public int Translate__formalParameter_symbolTable = 0;
		public int Translatep__type = 0;
		public int Translatep__intType = 0;
		public int Translateq__intType = 0;
		public int Translate__registerStatement_symbolTable = 0;
		public int Translatep__registerType = 0;
		public int Translateq__registerType = 0;
		public int Translatep__booleanType = 0;
		public int Translateq__booleanType = 0;
		public int Translate__identifierStatement_symbolTable = 0;
		public int Translate__ifStatement_symbolTable = 0;
		public int Translate__whileStatement_symbolTable = 0;
		public int Translate__forStatement_symbolTable = 0;
		public int Translate__expression_symbolTable = 0;
		public int Translate__orExpression_symbolTable = 0;
		public int Translate__orExpressionP_symbolTable = 0;
		public int Translate__andExpression_symbolTable = 0;
		public int Translate__andExpressionP_symbolTable = 0;
		public int Translate__eqExpression_symbolTable = 0;
		public int Translate__eqExpressionP_symbolTable = 0;
		public int Translate__relationalExpression_symbolTable = 0;
		public int Translate__relationalExpressionP_symbolTable = 0;
		public int Translate__addSubExpression_symbolTable = 0;
		public int Translate__addSubExpressionP_symbolTable = 0;
		public int Translate__mulDivExpression_symbolTable = 0;
		public int Translate__mulDivExpressionP_symbolTable = 0;
		public int Translate__powExpression_symbolTable = 0;
		public int Translate__powExpressionP_symbolTable = 0;
		public int Translate__primaryExpression_symbolTable = 0;
		public int Translatet__expressionList_parameters_symbolTable = 0;
		public int Translatet__expressionListP_parametersP_symbolTable = 0;
		public int Translatet__expression_parameter_symbolTable = 0;
		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Program program)
		{
			Translatep__program++;
			if(program != null && program.Name == "Program")
			{
				Compiler.Translation.SymbolTable.Data.Node s = Translatef(program as Compiler.Parsing.Data.Program, new Compiler.Translation.SymbolTable.Data.SymbolTable(false) { new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } });
				if(s != null && s.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node ast, Compiler.Translation.SymbolTable.Data.Node symbolTable) = Translate(program as Compiler.Parsing.Data.Program, s as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(ast != null && ast.Name == "AST" && symbolTable != null && symbolTable.Name == "SymbolTable")
					{
						return ast as Compiler.AST.Data.AST;
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translates__identifier_symbolTable++;
			if(identifier != null && identifier.Name == "identifier" && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declarations"))
			{
				Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Declarations);
				if(dcl != null && dcl.Name == "Declaration")
				{
					return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			Compiler.Parsing.Data.Token _return = identifier;
			if(_return != null && _return.Name == "return" && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declarations"))
			{
				Compiler.Translation.SymbolTable.Data.Node dcl = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Declarations);
				if(dcl != null && dcl.Name == "Declaration")
				{
					return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token _return, Compiler.Translation.SymbolTable.Data.Declarations declarations)
		{
			Translates___return_declarations++;
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 1 && declarations[0] != null && declarations[0].Name == "EPSILON"))
			{
				return new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			Compiler.Parsing.Data.Token identifier = _return;
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 1 && declarations[0] != null && declarations[0].Name == "EPSILON"))
			{
				return new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				if(AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					return declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				if(!AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
					if(dcl != null && dcl.Name == "Declaration")
					{
						return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
					}
				}
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "return")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
				if(dcl != null && dcl.Name == "Declaration")
				{
					return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				if(AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					return declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				if(!AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
					if(dcl != null && dcl.Name == "Declaration")
					{
						return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
					}
				}
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "return")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				return declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				Compiler.Translation.SymbolTable.Data.Node dcl = Translates(_return as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
				if(dcl != null && dcl.Name == "Declaration")
				{
					return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
				Compiler.Translation.SymbolTable.Data.Node dcl = Translates(_return as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
				if(dcl != null && dcl.Name == "Declaration")
				{
					return dcl as Compiler.Translation.SymbolTable.Data.Declaration;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__program_symbolTable++;
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON") && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__globalStatements_symbolTable++;
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements" && (globalStatements[1].Count == 1 && globalStatements[1][0] != null && globalStatements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					Compiler.Translation.SymbolTable.Data.Node s2 = Translatef(globalStatements[1] as Compiler.Parsing.Data.GlobalStatements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(s2 != null && s2.Name == "SymbolTable")
					{
						return s2 as Compiler.Translation.SymbolTable.Data.SymbolTable;
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__globalStatement_symbolTable++;
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__interrupt_symbolTable++;
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && interrupt[1] != null && interrupt[1].Name == "(" && interrupt[2] != null && interrupt[2].Name == "numeral" && interrupt[3] != null && interrupt[3].Name == ")" && interrupt[4] != null && interrupt[4].Name == "indent" && interrupt[5] != null && interrupt[5].Name == "Statements" && interrupt[6] != null && interrupt[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__statements_symbolTable++;
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					Compiler.Translation.SymbolTable.Data.Node s2 = Translatef(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(s2 != null && s2.Name == "SymbolTable")
					{
						return s2 as Compiler.Translation.SymbolTable.Data.SymbolTable;
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__statement_symbolTable++;
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ReturnStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statement[0] as Compiler.Parsing.Data.RegisterStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(s1 != null && s1.Name == "SymbolTable")
				{
					return s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__identifierDeclaration_symbolTable++;
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
				{
					Compiler.Translation.SymbolTable.Data.Node it = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(it != null && it.Name == "IntType")
					{
						Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters);
							if(p != null && p.Name == "Parameters")
							{
								return Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { it as Compiler.Translation.SymbolTable.Data.IntType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
				{
					Compiler.Translation.SymbolTable.Data.Node t = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t != null && t.Name == "BooleanType")
					{
						Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters);
							if(p != null && p.Name == "Parameters")
							{
								return Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t as Compiler.Translation.SymbolTable.Data.BooleanType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 8 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "nothing" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "(" && identifierDeclaration[3] != null && identifierDeclaration[3].Name == "FormalParameters" && identifierDeclaration[4] != null && identifierDeclaration[4].Name == ")" && identifierDeclaration[5] != null && identifierDeclaration[5].Name == "indent" && identifierDeclaration[6] != null && identifierDeclaration[6].Name == "Statements" && identifierDeclaration[7] != null && identifierDeclaration[7].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
				{
					Compiler.Translation.SymbolTable.Data.Node t = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
					if(t != null && t.Name == "nothing")
					{
						Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[3] as Compiler.Parsing.Data.FormalParameters);
							if(p != null && p.Name == "Parameters")
							{
								return Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { t as Compiler.Translation.SymbolTable.Data.Token }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
							}
						}
					}
				}
			}
			throw new System.Exception(identifierDeclaration.Name);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParameters formalParameters)
		{
			Translateq__formalParameters++;
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON"))
			{
				return new Compiler.Translation.SymbolTable.Data.Parameters(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP"))
			{
				Compiler.Translation.SymbolTable.Data.Node p3 = Translateq(formalParameters[0] as Compiler.Parsing.Data.FormalParameter);
				if(p3 != null && p3.Name == "Parameter")
				{
					Compiler.Translation.SymbolTable.Data.Node p4 = Translateq(formalParameters[1] as Compiler.Parsing.Data.FormalParametersP);
					if(p4 != null && p4.Name == "ParametersP")
					{
						return new Compiler.Translation.SymbolTable.Data.Parameters(false) { p3 as Compiler.Translation.SymbolTable.Data.Parameter, p4 as Compiler.Translation.SymbolTable.Data.ParametersP };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParametersP formalParametersP)
		{
			Translateq__formalParametersP++;
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 1 && formalParametersP[0] != null && formalParametersP[0].Name == "EPSILON"))
			{
				return new Compiler.Translation.SymbolTable.Data.ParametersP(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP"))
			{
				Compiler.Translation.SymbolTable.Data.Node p3 = Translateq(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter);
				if(p3 != null && p3.Name == "Parameter")
				{
					Compiler.Translation.SymbolTable.Data.Node p4 = Translateq(formalParametersP[2] as Compiler.Parsing.Data.FormalParametersP);
					if(p4 != null && p4.Name == "ParametersP")
					{
						return new Compiler.Translation.SymbolTable.Data.ParametersP(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = ",", Value = "," }, p3 as Compiler.Translation.SymbolTable.Data.Parameter, p4 as Compiler.Translation.SymbolTable.Data.ParametersP };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParameter formalParameter)
		{
			Translateq__formalParameter++;
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && formalParameter[1] != null && formalParameter[1].Name == "identifier"))
			{
				Compiler.Translation.SymbolTable.Data.Node t = Translateq(formalParameter[0] as Compiler.Parsing.Data.Type);
				if(t != null && t.Name == "Type")
				{
					Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(formalParameter[1] as Compiler.Parsing.Data.Token);
					if(id1 != null && id1.Name == "identifier")
					{
						return new Compiler.Translation.SymbolTable.Data.Parameter(false) { t as Compiler.Translation.SymbolTable.Data.Type, id1 as Compiler.Translation.SymbolTable.Data.Token };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.Type type)
		{
			Translateq__type++;
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType"))
			{
				Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					return new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.IntType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType"))
			{
				Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType")
				{
					return new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.BooleanType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType"))
			{
				Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					return new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.RegisterType };
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatef__registerStatement_symbolTable++;
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 9 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && registerStatement[1][8] != null && registerStatement[1][8].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 1 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 6 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "(" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "FormalParameters" && registerStatement[1][1][2] != null && registerStatement[1][1][2].Name == ")" && registerStatement[1][1][3] != null && registerStatement[1][1][3].Name == "indent" && registerStatement[1][1][4] != null && registerStatement[1][1][4].Name == "Statements" && registerStatement[1][1][5] != null && registerStatement[1][1][5].Name == "dedent"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
				{
					Compiler.Translation.SymbolTable.Data.Node t = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
					if(t != null && t.Name == "RegisterType")
					{
						Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node p = Translateq(registerStatement[1][1][1] as Compiler.Parsing.Data.FormalParameters);
							if(p != null && p.Name == "Parameters")
							{
								return Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t as Compiler.Translation.SymbolTable.Data.RegisterType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__program_symbolTable++;
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON") && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return (new Compiler.AST.Data.AST(false) { new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm != null && stm.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.AST(false) { stm as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__globalStatements_symbolTable++;
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements" && (globalStatements[1].Count == 1 && globalStatements[1][0] != null && globalStatements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (stm1 as Compiler.AST.Data.GlobalStatement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatements[1] as Compiler.Parsing.Data.GlobalStatements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { stm1 as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.GlobalStatement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__globalStatement_symbolTable++;
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node inter1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Interrupt, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(inter1 != null && inter1.Name == "Interrupt" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { inter1 as Compiler.AST.Data.Interrupt }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { stm1 as Compiler.AST.Data.Statement }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (stm1 as Compiler.AST.Data.GlobalStatement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__interrupt_symbolTable++;
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && interrupt[1] != null && interrupt[1].Name == "(" && interrupt[2] != null && interrupt[2].Name == "numeral" && interrupt[3] != null && interrupt[3].Name == ")" && interrupt[4] != null && interrupt[4].Name == "indent" && interrupt[5] != null && interrupt[5].Name == "Statements" && interrupt[6] != null && interrupt[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node i1 = Translatep(interrupt[2] as Compiler.Parsing.Data.Token);
				if(i1 != null && i1.Name == "numeral")
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(interrupt[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.Interrupt(false) { new Compiler.AST.Data.Token() { Name = "interrupt", Value = "interrupt" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, i1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__statements_symbolTable++;
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (stm1 as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.Statement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, new Compiler.AST.Data.GlobalStatement(false) { stm2 as Compiler.AST.Data.Statement } } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.GlobalStatement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__statement_symbolTable++;
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == "IntegerDeclaration" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.IntegerDeclaration }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == "IntegerDeclarationInit" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.IntegerDeclarationInit }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == "BooleanDeclaration" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.BooleanDeclaration }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == "BooleanDeclarationInit" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.BooleanDeclarationInit }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node f, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(f != null && f.Name == "Function" && s1 != null && s1.Name == "SymbolTable")
				{
					return (f as Compiler.AST.Data.Function, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node idStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(idStm1 != null && idStm1.Name == idStm1.Name && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { idStm1 as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node ifStm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(statement[0] as Compiler.Parsing.Data.IfStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(ifStm1 != null && ifStm1.Name == ifStm1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { ifStm1 as Compiler.AST.Data.Node }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node whileStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.WhileStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(whileStm1 != null && whileStm1.Name == "WhileStatement" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { whileStm1 as Compiler.AST.Data.WhileStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node forStm1, Compiler.Translation.SymbolTable.Data.Node s) = Translate(statement[0] as Compiler.Parsing.Data.ForStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(forStm1 != null && forStm1.Name == "ForStatement" && s != null && s.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { forStm1 as Compiler.AST.Data.ForStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node regStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.RegisterStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(regStm1 != null && regStm1.Name == regStm1.Name && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { regStm1 as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ReturnStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node retStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.ReturnStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(retStm != null && retStm.Name == retStm.Name && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.Statement(false) { retStm as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.ReturnStatement returnStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__returnStatement_symbolTable++;
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "Expression" && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "return")))
				{
					(Compiler.AST.Data.Node iret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(iret != null && iret.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.IntegerReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, iret as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "Expression" && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "return")))
				{
					(Compiler.AST.Data.Node bret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(bret != null && bret.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.BooleanReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, bret as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "Expression" && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "return")))
				{
					(Compiler.AST.Data.Node rret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(rret != null && rret.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.RegisterReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, rret as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__identifierDeclaration_symbolTable++;
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
								{
									return (new Compiler.AST.Data.IntegerDeclaration(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							(Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(p != null && p.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable")
							{
								(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][4] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									return (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.IntType }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameter, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								(Compiler.AST.Data.Node iexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(iexpr != null && iexpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
									{
										return (new Compiler.AST.Data.IntegerDeclarationInit(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, iexpr as Compiler.AST.Data.IntegerExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 8 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "nothing" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "(" && identifierDeclaration[3] != null && identifierDeclaration[3].Name == "FormalParameters" && identifierDeclaration[4] != null && identifierDeclaration[4].Name == ")" && identifierDeclaration[5] != null && identifierDeclaration[5].Name == "indent" && identifierDeclaration[6] != null && identifierDeclaration[6].Name == "Statements" && identifierDeclaration[7] != null && identifierDeclaration[7].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "nothing")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
					if(t2 != null && t2.Name == "nothing")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							(Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[3] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(p != null && p.Name == "FormalParameters" && s1 != null && s1.Name == "SymbolTable")
							{
								(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[6] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									return (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.Token }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameters, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t2 != null && t2.Name == "BooleanType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
								{
									return (new Compiler.AST.Data.BooleanDeclaration(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t2 != null && t2.Name == "BooleanType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								(Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(p != null && p.Name == "FormalParameters" && s1 != null && s1.Name == "SymbolTable")
								{
									(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][4] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
									{
										return (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.BooleanType }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameters, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t2 != null && t2.Name == "BooleanType")
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								(Compiler.AST.Data.Node bexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(bexpr != null && bexpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
									{
										return (new Compiler.AST.Data.BooleanDeclarationInit(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, bexpr as Compiler.AST.Data.BooleanExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParameters formalParameters, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__formalParameters_symbolTable++;
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return (new Compiler.AST.Data.FormalParameters(false) { new Compiler.AST.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP" && (formalParameters[1].Count == 1 && formalParameters[1][0] != null && formalParameters[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParameters[0] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.FormalParameters(false) { p1 as Compiler.AST.Data.FormalParameter }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParameters[0] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node p2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(formalParameters[1] as Compiler.Parsing.Data.FormalParametersP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(p2 != null && p2.Name == "FormalParameter" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.FormalParameters(false) { new Compiler.AST.Data.FormalParameter(false) { new Compiler.AST.Data.CompoundFormalParameter(false) { p1 as Compiler.AST.Data.FormalParameter, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p2 as Compiler.AST.Data.FormalParameter } } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParametersP formalParametersP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__formalParametersP_symbolTable++;
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP" && (formalParametersP[2].Count == 1 && formalParametersP[2][0] != null && formalParametersP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable")
				{
					return (p1 as Compiler.AST.Data.FormalParameter, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node p2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(formalParametersP[2] as Compiler.Parsing.Data.FormalParametersP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(p2 != null && p2.Name == "FormalParameter" && s2 != null && s2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.FormalParameter(false) { new Compiler.AST.Data.CompoundFormalParameter(false) { p1 as Compiler.AST.Data.FormalParameter, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p2 as Compiler.AST.Data.FormalParameter } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParameter formalParameter, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__formalParameter_symbolTable++;
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && formalParameter[1] != null && formalParameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t = Translatep(formalParameter[0] as Compiler.Parsing.Data.Type);
				if(t != null && t.Name == "Type")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(formalParameter[0] as Compiler.Parsing.Data.Type);
					if(t2 != null && t2.Name == "Type")
					{
						Compiler.AST.Data.Node id1 = Translatep(formalParameter[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(formalParameter[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								return (new Compiler.AST.Data.FormalParameter(false) { t as Compiler.AST.Data.Type, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { t2 as Compiler.Translation.SymbolTable.Data.Type, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Type type)
		{
			Translatep__type++;
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType"))
			{
				Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					return new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.IntType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType"))
			{
				Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType")
				{
					return new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.BooleanType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType"))
			{
				Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					return new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.RegisterType };
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.IntType intType)
		{
			Translatep__intType++;
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint8", Value = "uint8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint16", Value = "uint16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint32", Value = "uint32" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int8", Value = "int8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int16", Value = "int16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32"))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int32", Value = "int32" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.IntType intType)
		{
			Translateq__intType++;
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint8", Value = "uint8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint16", Value = "uint16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint32", Value = "uint32" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int8", Value = "int8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int16", Value = "int16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32"))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int32", Value = "int32" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__registerStatement_symbolTable++;
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 1 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
					if(t2 != null && t2.Name == "RegisterType")
					{
						Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
								{
									return (new Compiler.AST.Data.RegisterDeclaration(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
					if(t2 != null && t2.Name == "RegisterType")
					{
						Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								(Compiler.AST.Data.Node rexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(registerStatement[1][1][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(rexpr != null && rexpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON"))
									{
										return (new Compiler.AST.Data.RegisterDeclarationInit(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, rexpr as Compiler.AST.Data.RegisterExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 9 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && registerStatement[1][8] != null && registerStatement[1][8].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node regType = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(regType != null && regType.Name == "RegisterType")
				{
					(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(registerStatement[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable")
					{
						(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(registerStatement[1][4] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && s2 != null && s2.Name == "SymbolTable")
						{
							(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s3) = Translate(registerStatement[1][7] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(boolExpr != null && boolExpr.Name == "BooleanExpression" && s3 != null && s3.Name == "SymbolTable")
							{
								return (new Compiler.AST.Data.DirectBitAssignment(false) { regType as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.RegisterType registerType)
		{
			Translatep__registerType++;
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8"))
			{
				return new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register8", Value = "register8" } };
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16"))
			{
				return new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register16", Value = "register16" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.RegisterType registerType)
		{
			Translateq__registerType++;
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8"))
			{
				return new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register8", Value = "register8" } };
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16"))
			{
				return new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register16", Value = "register16" } };
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.BooleanType booleanType)
		{
			Translatep__booleanType++;
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool"))
			{
				return new Compiler.AST.Data.BooleanType(false) { new Compiler.AST.Data.Token() { Name = "bool", Value = "bool" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.BooleanType booleanType)
		{
			Translateq__booleanType++;
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool"))
			{
				return new Compiler.Translation.SymbolTable.Data.BooleanType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "bool", Value = "bool" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierStatement identifierStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__identifierStatement_symbolTable++;
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 3 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "{" && identifierStatement[1][0][1] != null && identifierStatement[1][0][1].Name == "Expression" && identifierStatement[1][0][2] != null && identifierStatement[1][0][2].Name == "}") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierStatement[1][0][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable")
						{
							(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(boolExpr != null && boolExpr.Name == "BooleanExpression" && s2 != null && s2.Name == "SymbolTable")
							{
								return (new Compiler.AST.Data.IndirectBitAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							}
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.IntegerAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, intExpr as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						(Compiler.AST.Data.Node registerExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(registerExpr != null && registerExpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.RegisterAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, registerExpr as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.BooleanAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "IntType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "BooleanType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "RegisterType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "nothing") && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IfStatement ifStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__ifStatement_symbolTable++;
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 8 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "Expression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statements" && ifStatement[6] != null && ifStatement[6].Name == "dedent" && ifStatement[7] != null && ifStatement[7].Name == "ElseStatement" && (ifStatement[7].Count == 1 && ifStatement[7][0] != null && ifStatement[7][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.IfStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 8 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "Expression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statements" && ifStatement[6] != null && ifStatement[6].Name == "dedent" && ifStatement[7] != null && ifStatement[7].Name == "ElseStatement" && (ifStatement[7].Count == 4 && ifStatement[7][0] != null && ifStatement[7][0].Name == "else" && ifStatement[7][1] != null && ifStatement[7][1].Name == "indent" && ifStatement[7][2] != null && ifStatement[7][2].Name == "Statements" && ifStatement[7][3] != null && ifStatement[7][3].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(ifStatement[7][2] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(stm1 != null && stm1.Name == "Statement" && symbolTable3 != null && symbolTable3.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.IfElseStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" }, new Compiler.AST.Data.Token() { Name = "else", Value = "else" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.WhileStatement whileStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__whileStatement_symbolTable++;
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && whileStatement[1] != null && whileStatement[1].Name == "(" && whileStatement[2] != null && whileStatement[2].Name == "Expression" && whileStatement[3] != null && whileStatement[3].Name == ")" && whileStatement[4] != null && whileStatement[4].Name == "indent" && whileStatement[5] != null && whileStatement[5].Name == "Statements" && whileStatement[6] != null && whileStatement[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(whileStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(whileStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.WhileStatement(false) { new Compiler.AST.Data.Token() { Name = "while", Value = "while" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.ForStatement forStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__forStatement_symbolTable++;
			if(forStatement != null && forStatement.Name == "ForStatement" && (forStatement.Count == 12 && forStatement[0] != null && forStatement[0].Name == "for" && forStatement[1] != null && forStatement[1].Name == "(" && forStatement[2] != null && forStatement[2].Name == "IntType" && forStatement[3] != null && forStatement[3].Name == "identifier" && forStatement[4] != null && forStatement[4].Name == "from" && forStatement[5] != null && forStatement[5].Name == "Expression" && forStatement[6] != null && forStatement[6].Name == "to" && forStatement[7] != null && forStatement[7].Name == "Expression" && forStatement[8] != null && forStatement[8].Name == ")" && forStatement[9] != null && forStatement[9].Name == "indent" && forStatement[10] != null && forStatement[10].Name == "Statements" && forStatement[11] != null && forStatement[11].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(forStatement[2] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType")
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(forStatement[2] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType")
					{
						Compiler.AST.Data.Node id1 = Translatep(forStatement[3] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier")
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(forStatement[3] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier")
							{
								(Compiler.AST.Data.Node iexpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(forStatement[5] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
								{
									(Compiler.AST.Data.Node iexpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(forStatement[7] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(iexpr2 != null && iexpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
									{
										(Compiler.AST.Data.Node stms1, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(forStatement[10] as Compiler.Parsing.Data.Statements, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
										if(stms1 != null && stms1.Name == "Statement" && symbolTable3 != null && symbolTable3.Name == "SymbolTable")
										{
											return (new Compiler.AST.Data.ForStatement(false) { new Compiler.AST.Data.Token() { Name = "for", Value = "for" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "from", Value = "from" }, iexpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "to", Value = "to" }, iexpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stms1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
										}
									}
								}
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__expression_symbolTable++;
			if(expression != null && expression.Name == "Expression" && (expression.Count == 1 && expression[0] != null && expression[0].Name == "OrExpression") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression[0] as Compiler.Parsing.Data.OrExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpression orExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__orExpression_symbolTable++;
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 1 && orExpression[1][0] != null && orExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && orExpression[1] != null && orExpression[1].Name == "OrExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpression[1] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpressionP orExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__orExpressionP_symbolTable++;
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 1 && orExpressionP[2][0] != null && orExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpressionP[2] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpression andExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__andExpression_symbolTable++;
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 1 && andExpression[1][0] != null && andExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && andExpression[1] != null && andExpression[1].Name == "AndExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpression[1] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpressionP andExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__andExpressionP_symbolTable++;
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 1 && andExpressionP[2][0] != null && andExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpressionP[2] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpression eqExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__eqExpression_symbolTable++;
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 1 && eqExpression[1][0] != null && eqExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, boolExpr as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpressionP eqExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__eqExpressionP_symbolTable++;
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanNotEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanNotEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpression relationalExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__relationalExpression_symbolTable++;
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 1 && relationalExpression[1][0] != null && relationalExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpression[1] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpressionP relationalExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__relationalExpressionP_symbolTable++;
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">=", Value = ">=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">=", Value = ">=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpression addSubExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__addSubExpression_symbolTable++;
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 1 && addSubExpression[1][0] != null && addSubExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpression[1] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpressionP addSubExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__addSubExpressionP_symbolTable++;
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpression mulDivExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__mulDivExpression_symbolTable++;
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 1 && mulDivExpression[1][0] != null && mulDivExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpression[1] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpressionP mulDivExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__mulDivExpressionP_symbolTable++;
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.ModExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "%", Value = "%" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.ModExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "%", Value = "%" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PowExpression powExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__powExpression_symbolTable++;
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && powExpression[1] != null && powExpression[1].Name == "PowExpressionP" && (powExpression[1].Count == 1 && powExpression[1][0] != null && powExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && powExpression[1] != null && powExpression[1].Name == "PowExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpression[1] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PowExpressionP powExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__powExpressionP_symbolTable++;
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP" && (powExpressionP[2].Count == 1 && powExpressionP[2][0] != null && powExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.PowExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "^", Value = "^" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpressionP[2] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.PowExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "^", Value = "^" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PrimaryExpression primaryExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__primaryExpression_symbolTable++;
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "numeral") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node i1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(i1 != null && i1.Name == "numeral")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { i1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						return (new Compiler.AST.Data.IntegerExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						return (new Compiler.AST.Data.BooleanExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "IntType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "BooleanType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "RegisterType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters")))
					{
						Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(p2 != null && p2.Name == "ExpressionList")
						{
							return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 3 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "{" && primaryExpression[1][0][1] != null && primaryExpression[1][0][1].Name == "Expression" && primaryExpression[1][0][2] != null && primaryExpression[1][0][2].Name == "}"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier")
				{
					Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier")))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1][0][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IndirectBitValue(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && primaryExpression[2] != null && primaryExpression[2].Name == ")") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.IntegerParenthesisExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && primaryExpression[2] != null && primaryExpression[2].Name == ")") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanParenthesisExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "!" && primaryExpression[1] != null && primaryExpression[1].Name == "PrimaryExpression") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.NotExpression(false) { new Compiler.AST.Data.Token() { Name = "!", Value = "!" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && primaryExpression[1] != null && primaryExpression[1].Name == "(" && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && primaryExpression[3] != null && primaryExpression[3].Name == ")" && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 1 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterLiteral(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && primaryExpression[1] != null && primaryExpression[1].Name == "(" && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && primaryExpression[3] != null && primaryExpression[3].Name == ")" && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 3 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "{" && primaryExpression[4][1] != null && primaryExpression[4][1].Name == "Expression" && primaryExpression[4][2] != null && primaryExpression[4][2].Name == "}")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType")
				{
					(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
					{
						(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(primaryExpression[4][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable")
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.DirectBitValue(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "true") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "true")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { t1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "false") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node f1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(f1 != null && f1.Name == "false")
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { f1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.ExpressionList expressionList, Compiler.Translation.SymbolTable.Data.Parameters parameters, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatet__expressionList_parameters_symbolTable++;
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "EPSILON") && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 1 && parameters[0] != null && parameters[0].Name == "EPSILON") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				return new Compiler.AST.Data.ExpressionList(false) { new Compiler.AST.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 2 && expressionList[0] != null && expressionList[0].Name == "Expression" && expressionList[1] != null && expressionList[1].Name == "ExpressionListP" && (expressionList[1].Count == 1 && expressionList[1][0] != null && expressionList[1][0].Name == "EPSILON")) && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 2 && parameters[0] != null && parameters[0].Name == "Parameter" && parameters[1] != null && parameters[1].Name == "ParametersP" && (parameters[1].Count == 1 && parameters[1][0] != null && parameters[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node p5 = Translatet(expressionList[0] as Compiler.Parsing.Data.Expression, parameters[0] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p5 != null && p5.Name == "ExpressionListArgs")
				{
					return new Compiler.AST.Data.ExpressionList(false) { p5 as Compiler.AST.Data.ExpressionListArgs };
				}
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 2 && expressionList[0] != null && expressionList[0].Name == "Expression" && expressionList[1] != null && expressionList[1].Name == "ExpressionListP") && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 2 && parameters[0] != null && parameters[0].Name == "Parameter" && parameters[1] != null && parameters[1].Name == "ParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node p5 = Translatet(expressionList[0] as Compiler.Parsing.Data.Expression, parameters[0] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p5 != null && p5.Name == "ExpressionListArgs")
				{
					Compiler.AST.Data.Node p6 = Translatet(expressionList[1] as Compiler.Parsing.Data.ExpressionListP, parameters[1] as Compiler.Translation.SymbolTable.Data.ParametersP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(p6 != null && p6.Name == "ExpressionListArgs")
					{
						return new Compiler.AST.Data.ExpressionListArgs(false) { new Compiler.AST.Data.CompoundArgs(false) { p5 as Compiler.AST.Data.ExpressionListArgs, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p6 as Compiler.AST.Data.ExpressionListArgs } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.ExpressionListP expressionListP, Compiler.Translation.SymbolTable.Data.ParametersP parametersP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatet__expressionListP_parametersP_symbolTable++;
			if(expressionListP != null && expressionListP.Name == "ExpressionListP" && (expressionListP.Count == 3 && expressionListP[0] != null && expressionListP[0].Name == "," && expressionListP[1] != null && expressionListP[1].Name == "Expression" && expressionListP[2] != null && expressionListP[2].Name == "ExpressionListP") && parametersP != null && parametersP.Name == "ParametersP" && (parametersP.Count == 3 && parametersP[0] != null && parametersP[0].Name == "," && parametersP[1] != null && parametersP[1].Name == "Parameter" && parametersP[2] != null && parametersP[2].Name == "ParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node p5 = Translatet(expressionListP[1] as Compiler.Parsing.Data.Expression, parametersP[1] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p5 != null && p5.Name == "ExpressionListArgs")
				{
					Compiler.AST.Data.Node p6 = Translatet(expressionListP[2] as Compiler.Parsing.Data.ExpressionListP, parametersP[2] as Compiler.Translation.SymbolTable.Data.ParametersP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(p6 != null && p6.Name == "ExpressionListArgs")
					{
						return new Compiler.AST.Data.ExpressionListArgs(false) { new Compiler.AST.Data.CompoundArgs(false) { p5 as Compiler.AST.Data.ExpressionListArgs, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p6 as Compiler.AST.Data.ExpressionListArgs } };
					}
				}
			}
			if(expressionListP != null && expressionListP.Name == "ExpressionListP" && (expressionListP.Count == 3 && expressionListP[0] != null && expressionListP[0].Name == "," && expressionListP[1] != null && expressionListP[1].Name == "Expression" && expressionListP[2] != null && expressionListP[2].Name == "ExpressionListP" && (expressionListP[2].Count == 1 && expressionListP[2][0] != null && expressionListP[2][0].Name == "EPSILON")) && parametersP != null && parametersP.Name == "ParametersP" && (parametersP.Count == 3 && parametersP[0] != null && parametersP[0].Name == "," && parametersP[1] != null && parametersP[1].Name == "Parameter" && parametersP[2] != null && parametersP[2].Name == "ParametersP" && (parametersP[2].Count == 1 && parametersP[2][0] != null && parametersP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				Compiler.AST.Data.Node p5 = Translatet(expressionListP[1] as Compiler.Parsing.Data.Expression, parametersP[1] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(p5 != null && p5.Name == "ExpressionListArgs")
				{
					return new Compiler.AST.Data.ExpressionList(false) { p5 as Compiler.AST.Data.ExpressionListArgs };
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.Parameter parameter, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translatet__expression_parameter_symbolTable++;
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "IntType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node iexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(iexpr != null && iexpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return new Compiler.AST.Data.ExpressionListArgs(false) { iexpr as Compiler.AST.Data.IntegerExpression };
				}
			}
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "BooleanType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node bexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(bexpr != null && bexpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return new Compiler.AST.Data.ExpressionListArgs(false) { bexpr as Compiler.AST.Data.BooleanExpression };
				}
			}
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "RegisterType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
				(Compiler.AST.Data.Node rexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(rexpr != null && rexpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable")
				{
					return new Compiler.AST.Data.ExpressionListArgs(false) { rexpr as Compiler.AST.Data.RegisterExpression };
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Token Translatep(Compiler.Parsing.Data.Token token)
		{
			return new Compiler.AST.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
		}

		public Compiler.Translation.SymbolTable.Data.Token Translateq(Compiler.Parsing.Data.Token token)
		{
			return new Compiler.Translation.SymbolTable.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
		}

		public Compiler.Parsing.Data.Token Translatew(Compiler.Parsing.Data.Token token)
		{
			return new Compiler.Parsing.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
		}

		public bool AreEqual(Compiler.Parsing.Data.Node left, Compiler.Translation.SymbolTable.Data.Node right)
		{
			if (left.Count != right.Count || left.Name != right.Name)
			{
			    return false;
			}
			if (left is Compiler.Parsing.Data.Token || right is Compiler.Translation.SymbolTable.Data.Token)
			{
			    if (left is Compiler.Parsing.Data.Token leftToken && right is Compiler.Translation.SymbolTable.Data.Token rightToken && leftToken.Value == rightToken.Value)
			    {
			        return true;
			    }
			    return false;
			}
			for (int index = 0; index < left.Count; index++)
			{
			    if (!AreEqual(left[index], right[index]))
			    {
			        return false;
			    }
			}
			return true;
		}

		public Compiler.Parsing.Data.Node Insert(Compiler.Parsing.Data.Node left, Compiler.Parsing.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name) {
			    return right.Accept(new Compiler.Parsing.Visitors.CloneVisitor());
			}
			var leftClone = left.Accept(new Compiler.Parsing.Visitors.CloneVisitor());
			Compiler.Parsing.Data.Node Insertion = InsertAux(leftClone, right);
			return (Insertion == null ? null : leftClone);
		}

		public Compiler.Parsing.Data.Node InsertAux(Compiler.Parsing.Data.Node left, Compiler.Parsing.Data.Node right)
		{
			for (int i = 0; i < left.Count;  i++)
			{
			    if(left[i].IsPlaceholder && left[i].Name == right.Name) {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else {
			        Compiler.Parsing.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null) {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}

		public Compiler.AST.Data.Node Insert(Compiler.AST.Data.Node left, Compiler.AST.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name) {
			    return right.Accept(new Compiler.AST.Visitors.CloneVisitor());
			}
			var leftClone = left.Accept(new Compiler.AST.Visitors.CloneVisitor());
			Compiler.AST.Data.Node Insertion = InsertAux(leftClone, right);
			return (Insertion == null ? null : leftClone);
		}

		public Compiler.AST.Data.Node InsertAux(Compiler.AST.Data.Node left, Compiler.AST.Data.Node right)
		{
			for (int i = 0; i < left.Count;  i++)
			{
			    if(left[i].IsPlaceholder && left[i].Name == right.Name) {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else {
			        Compiler.AST.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null) {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}

		public Compiler.Translation.SymbolTable.Data.Node Insert(Compiler.Translation.SymbolTable.Data.Node left, Compiler.Translation.SymbolTable.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name) {
			    return right.Accept(new Compiler.Translation.SymbolTable.Visitors.CloneVisitor());
			}
			var leftClone = left.Accept(new Compiler.Translation.SymbolTable.Visitors.CloneVisitor());
			Compiler.Translation.SymbolTable.Data.Node Insertion = InsertAux(leftClone, right);
			return (Insertion == null ? null : leftClone);
		}

		public Compiler.Translation.SymbolTable.Data.Node InsertAux(Compiler.Translation.SymbolTable.Data.Node left, Compiler.Translation.SymbolTable.Data.Node right)
		{
			for (int i = 0; i < left.Count;  i++)
			{
			    if(left[i].IsPlaceholder && left[i].Name == right.Name) {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else {
			        Compiler.Translation.SymbolTable.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null) {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}

		public void printCounts()
		{
			System.Console.WriteLine("___Translation methods calls___");
			System.Console.WriteLine("Translatep__program: "+Translatep__program);
			System.Console.WriteLine("Translates__identifier_symbolTable: "+Translates__identifier_symbolTable);
			System.Console.WriteLine("Translates___return_declarations: "+Translates___return_declarations);
			System.Console.WriteLine("Translatef__program_symbolTable: "+Translatef__program_symbolTable);
			System.Console.WriteLine("Translatef__globalStatements_symbolTable: "+Translatef__globalStatements_symbolTable);
			System.Console.WriteLine("Translatef__globalStatement_symbolTable: "+Translatef__globalStatement_symbolTable);
			System.Console.WriteLine("Translatef__interrupt_symbolTable: "+Translatef__interrupt_symbolTable);
			System.Console.WriteLine("Translatef__statements_symbolTable: "+Translatef__statements_symbolTable);
			System.Console.WriteLine("Translatef__statement_symbolTable: "+Translatef__statement_symbolTable);
			System.Console.WriteLine("Translatef__identifierDeclaration_symbolTable: "+Translatef__identifierDeclaration_symbolTable);
			System.Console.WriteLine("Translateq__formalParameters: "+Translateq__formalParameters);
			System.Console.WriteLine("Translateq__formalParametersP: "+Translateq__formalParametersP);
			System.Console.WriteLine("Translateq__formalParameter: "+Translateq__formalParameter);
			System.Console.WriteLine("Translateq__type: "+Translateq__type);
			System.Console.WriteLine("Translatef__registerStatement_symbolTable: "+Translatef__registerStatement_symbolTable);
			System.Console.WriteLine("Translate__program_symbolTable: "+Translate__program_symbolTable);
			System.Console.WriteLine("Translate__globalStatements_symbolTable: "+Translate__globalStatements_symbolTable);
			System.Console.WriteLine("Translate__globalStatement_symbolTable: "+Translate__globalStatement_symbolTable);
			System.Console.WriteLine("Translate__interrupt_symbolTable: "+Translate__interrupt_symbolTable);
			System.Console.WriteLine("Translate__statements_symbolTable: "+Translate__statements_symbolTable);
			System.Console.WriteLine("Translate__statement_symbolTable: "+Translate__statement_symbolTable);
			System.Console.WriteLine("Translate__returnStatement_symbolTable: "+Translate__returnStatement_symbolTable);
			System.Console.WriteLine("Translate__identifierDeclaration_symbolTable: "+Translate__identifierDeclaration_symbolTable);
			System.Console.WriteLine("Translate__formalParameters_symbolTable: "+Translate__formalParameters_symbolTable);
			System.Console.WriteLine("Translate__formalParametersP_symbolTable: "+Translate__formalParametersP_symbolTable);
			System.Console.WriteLine("Translate__formalParameter_symbolTable: "+Translate__formalParameter_symbolTable);
			System.Console.WriteLine("Translatep__type: "+Translatep__type);
			System.Console.WriteLine("Translatep__intType: "+Translatep__intType);
			System.Console.WriteLine("Translateq__intType: "+Translateq__intType);
			System.Console.WriteLine("Translate__registerStatement_symbolTable: "+Translate__registerStatement_symbolTable);
			System.Console.WriteLine("Translatep__registerType: "+Translatep__registerType);
			System.Console.WriteLine("Translateq__registerType: "+Translateq__registerType);
			System.Console.WriteLine("Translatep__booleanType: "+Translatep__booleanType);
			System.Console.WriteLine("Translateq__booleanType: "+Translateq__booleanType);
			System.Console.WriteLine("Translate__identifierStatement_symbolTable: "+Translate__identifierStatement_symbolTable);
			System.Console.WriteLine("Translate__ifStatement_symbolTable: "+Translate__ifStatement_symbolTable);
			System.Console.WriteLine("Translate__whileStatement_symbolTable: "+Translate__whileStatement_symbolTable);
			System.Console.WriteLine("Translate__forStatement_symbolTable: "+Translate__forStatement_symbolTable);
			System.Console.WriteLine("Translate__expression_symbolTable: "+Translate__expression_symbolTable);
			System.Console.WriteLine("Translate__orExpression_symbolTable: "+Translate__orExpression_symbolTable);
			System.Console.WriteLine("Translate__orExpressionP_symbolTable: "+Translate__orExpressionP_symbolTable);
			System.Console.WriteLine("Translate__andExpression_symbolTable: "+Translate__andExpression_symbolTable);
			System.Console.WriteLine("Translate__andExpressionP_symbolTable: "+Translate__andExpressionP_symbolTable);
			System.Console.WriteLine("Translate__eqExpression_symbolTable: "+Translate__eqExpression_symbolTable);
			System.Console.WriteLine("Translate__eqExpressionP_symbolTable: "+Translate__eqExpressionP_symbolTable);
			System.Console.WriteLine("Translate__relationalExpression_symbolTable: "+Translate__relationalExpression_symbolTable);
			System.Console.WriteLine("Translate__relationalExpressionP_symbolTable: "+Translate__relationalExpressionP_symbolTable);
			System.Console.WriteLine("Translate__addSubExpression_symbolTable: "+Translate__addSubExpression_symbolTable);
			System.Console.WriteLine("Translate__addSubExpressionP_symbolTable: "+Translate__addSubExpressionP_symbolTable);
			System.Console.WriteLine("Translate__mulDivExpression_symbolTable: "+Translate__mulDivExpression_symbolTable);
			System.Console.WriteLine("Translate__mulDivExpressionP_symbolTable: "+Translate__mulDivExpressionP_symbolTable);
			System.Console.WriteLine("Translate__powExpression_symbolTable: "+Translate__powExpression_symbolTable);
			System.Console.WriteLine("Translate__powExpressionP_symbolTable: "+Translate__powExpressionP_symbolTable);
			System.Console.WriteLine("Translate__primaryExpression_symbolTable: "+Translate__primaryExpression_symbolTable);
			System.Console.WriteLine("Translatet__expressionList_parameters_symbolTable: "+Translatet__expressionList_parameters_symbolTable);
			System.Console.WriteLine("Translatet__expressionListP_parametersP_symbolTable: "+Translatet__expressionListP_parametersP_symbolTable);
			System.Console.WriteLine("Translatet__expression_parameter_symbolTable: "+Translatet__expression_parameter_symbolTable);
		}
	}
}
