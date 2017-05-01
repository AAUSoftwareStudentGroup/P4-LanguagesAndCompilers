namespace Compiler.Translation.ProgramToAST
{
	public class ProgramToASTTranslator 
	{
		public int Translatep__program = 0;
		public int Translates__identifier_symbolTable = 0;
		public int Translates__identifier_variables = 0;
		public int Translate__program_symbolTable = 0;
		public int Translate__globalStatements_symbolTable = 0;
		public int Translate__globalStatementsP_symbolTable = 0;
		public int Translate__globalStatement_symbolTable = 0;
		public int Translate__interrupt_symbolTable = 0;
		public int Translate__statements_symbolTable = 0;
		public int Translate__statementsP_symbolTable = 0;
		public int Translate__statement_symbolTable = 0;
		public int Translate__identifierDeclaration_symbolTable = 0;
		public int Translatep__intType = 0;
		public int Translateq__intType = 0;
		public int Translate__registerStatement_symbolTable = 0;
		public int Translatep__registerType = 0;
		public int Translateq__registerType = 0;
		public int Translatep__booleanType = 0;
		public int Translateq__booleanType = 0;
		public int Translate__assignment_symbolTable = 0;
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
		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Program program)
		{
			Translatep__program++;
			if(program != null && program.Name == "Program" && true)
			{
				(Compiler.AST.Data.Node ast, Compiler.Translation.SymbolTable.Data.Node symbolTable) = Translate(program as Compiler.Parsing.Data.Program, new Compiler.Translation.SymbolTable.Data.SymbolTable(false) { new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } });
				if(ast != null && ast.Name == "AST" && true && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
				{
					return ast as Compiler.AST.Data.AST;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translates__identifier_symbolTable++;
			if(identifier != null && identifier.Name == "identifier" && true && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Variables" && true))
			{
				Compiler.Translation.SymbolTable.Data.Node var = Translates(identifier as Compiler.Parsing.Data.Token, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Variables);
				if(var != null && var.Name == "Variable" && true)
				{
					return var as Compiler.Translation.SymbolTable.Data.Variable;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.Variables variables)
		{
			Translates__identifier_variables++;
			if(identifier != null && identifier.Name == "identifier" && true && variables != null && variables.Name == "Variables" && (variables.Count == 2 && variables[0] != null && variables[0].Name == "Variable" && (variables[0].Count == 2 && variables[0][0] != null && variables[0][0].Name == "Type" && true && variables[0][1] != null && variables[0][1].Name == "identifier" && true) && variables[1] != null && variables[1].Name == "Variables" && true))
			{
				if(AreEqual((identifier as Compiler.Parsing.Data.Token), (variables[0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					return variables[0] as Compiler.Translation.SymbolTable.Data.Variable;
				}
			}
			if(identifier != null && identifier.Name == "identifier" && true && variables != null && variables.Name == "Variables" && (variables.Count == 2 && variables[0] != null && variables[0].Name == "Variable" && (variables[0].Count == 2 && variables[0][0] != null && variables[0][0].Name == "Type" && true && variables[0][1] != null && variables[0][1].Name == "identifier" && true) && variables[1] != null && variables[1].Name == "Variables" && true))
			{
				if(!AreEqual((identifier as Compiler.Parsing.Data.Token), (variables[0][1] as Compiler.Translation.SymbolTable.Data.Token)))
				{
					Compiler.Translation.SymbolTable.Data.Node var = Translates(identifier as Compiler.Parsing.Data.Token, variables[1] as Compiler.Translation.SymbolTable.Data.Variables);
					if(var != null && var.Name == "Variable" && true)
					{
						return var as Compiler.Translation.SymbolTable.Data.Variable;
					}
				}
			}
			if(identifier != null && identifier.Name == "identifier" && true && variables != null && variables.Name == "Variables" && (variables.Count == 1 && variables[0] != null && variables[0].Name == "EPSILON" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__program_symbolTable++;
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON" && true) && program[1] != null && program[1].Name == "eof" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				return (new Compiler.AST.Data.AST(false) { new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && true && program[1] != null && program[1].Name == "eof" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm != null && stm.Name == "GlobalStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.AST(false) { stm as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__globalStatements_symbolTable++;
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && true && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatementsP" && (globalStatements[1].Count == 1 && globalStatements[1][0] != null && globalStatements[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (stm1 as Compiler.AST.Data.GlobalStatement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && true && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatementsP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatements[1] as Compiler.Parsing.Data.GlobalStatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && true && s2 != null && s2.Name == "SymbolTable" && true)
					{
						return (Insert(stm2 as Compiler.AST.Data.GlobalStatement, stm1 as Compiler.AST.Data.GlobalStatement) as Compiler.AST.Data.GlobalStatement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatementsP globalStatementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__globalStatementsP_symbolTable++;
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && true && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && true && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && (globalStatementsP[2].Count == 1 && globalStatementsP[2][0] != null && globalStatementsP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatementsP[1] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.GlobalStatement } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && true && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && true && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatementsP[1] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatementsP[2] as Compiler.Parsing.Data.GlobalStatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && true && s2 != null && s2.Name == "SymbolTable" && true)
					{
						return (Insert(stm2 as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.GlobalStatement } }) as Compiler.AST.Data.GlobalStatement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__globalStatement_symbolTable++;
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node inter1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Interrupt, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(inter1 != null && inter1.Name == "Interrupt" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { inter1 as Compiler.AST.Data.Interrupt }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { stm1 as Compiler.AST.Data.Statement }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__interrupt_symbolTable++;
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && true && interrupt[1] != null && interrupt[1].Name == "(" && true && interrupt[2] != null && interrupt[2].Name == "numeral" && true && interrupt[3] != null && interrupt[3].Name == ")" && true && interrupt[4] != null && interrupt[4].Name == "indent" && true && interrupt[5] != null && interrupt[5].Name == "Statements" && true && interrupt[6] != null && interrupt[6].Name == "dedent" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node i1 = Translatep(interrupt[2] as Compiler.Parsing.Data.Token);
				if(i1 != null && i1.Name == "numeral" && true)
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(interrupt[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
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
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && true && statements[1] != null && statements[1].Name == "StatementsP" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (stm1 as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && true && statements[1] != null && statements[1].Name == "StatementsP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.StatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && true && s2 != null && s2.Name == "SymbolTable" && true)
					{
						return (Insert(stm2 as Compiler.AST.Data.Statement, stm1 as Compiler.AST.Data.Statement) as Compiler.AST.Data.Statement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.StatementsP statementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__statementsP_symbolTable++;
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && true && statementsP[1] != null && statementsP[1].Name == "Statement" && true && statementsP[2] != null && statementsP[2].Name == "StatementsP" && (statementsP[2].Count == 1 && statementsP[2][0] != null && statementsP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statementsP[1] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { new Compiler.AST.Data.Statement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.Statement } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && true && statementsP[1] != null && statementsP[1].Name == "Statement" && true && statementsP[2] != null && statementsP[2].Name == "StatementsP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statementsP[1] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statementsP[2] as Compiler.Parsing.Data.StatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && true && s2 != null && s2.Name == "SymbolTable" && true)
					{
						return (Insert(stm2 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { new Compiler.AST.Data.Statement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.Statement } }) as Compiler.AST.Data.Statement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__statement_symbolTable++;
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "EPSILON" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == dclStm.Name && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "Assignment" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node assStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.Assignment, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(assStm != null && assStm.Name == assStm.Name && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { assStm as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node ifStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IfStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(ifStm1 != null && ifStm1.Name == "IfStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { ifStm1 as Compiler.AST.Data.IfStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node whileStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.WhileStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(whileStm1 != null && whileStm1.Name == "WhileStatement" && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { whileStm1 as Compiler.AST.Data.WhileStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node forStm1, Compiler.Translation.SymbolTable.Data.Node s) = Translate(statement[0] as Compiler.Parsing.Data.ForStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(forStm1 != null && forStm1.Name == "ForStatement" && true && s != null && s.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { forStm1 as Compiler.AST.Data.ForStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterStatement" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node regStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.RegisterStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(regStm1 != null && regStm1.Name == regStm1.Name && true && s1 != null && s1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.Statement(false) { regStm1 as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__identifierDeclaration_symbolTable++;
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && true && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && true && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Initialization" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
								{
									return (new Compiler.AST.Data.IntegerDeclaration(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && true && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && true && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Initialization" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && true && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "Expression" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								(Compiler.AST.Data.Node iexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(iexpr != null && iexpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
								{
									Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
									{
										return (new Compiler.AST.Data.IntegerDeclarationInit(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, iexpr as Compiler.AST.Data.IntegerExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && true && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && true && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Initialization" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t2 != null && t2.Name == "BooleanType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
								{
									return (new Compiler.AST.Data.BooleanDeclaration(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && true && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && true && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Initialization" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && true && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "Expression" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
					if(t2 != null && t2.Name == "BooleanType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								(Compiler.AST.Data.Node bexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(bexpr != null && bexpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
								{
									Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
									{
										return (new Compiler.AST.Data.BooleanDeclarationInit(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, bexpr as Compiler.AST.Data.BooleanExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.IntType intType)
		{
			Translatep__intType++;
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint8", Value = "uint8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint16", Value = "uint16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint32", Value = "uint32" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int8", Value = "int8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int16", Value = "int16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32" && true))
			{
				return new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int32", Value = "int32" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.IntType intType)
		{
			Translateq__intType++;
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint8", Value = "uint8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint16", Value = "uint16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint32", Value = "uint32" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int8", Value = "int8" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int16", Value = "int16" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int32", Value = "int32" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__registerStatement_symbolTable++;
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && true && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && true && registerStatement[1][1] != null && registerStatement[1][1].Name == "Initialization" && (registerStatement[1][1].Count == 1 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "EPSILON" && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
					if(t2 != null && t2.Name == "RegisterType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
								{
									return (new Compiler.AST.Data.RegisterDeclaration(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && true && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && true && registerStatement[1][1] != null && registerStatement[1][1].Name == "Initialization" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && true && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "Expression" && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
					if(t2 != null && t2.Name == "RegisterType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								(Compiler.AST.Data.Node rexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(registerStatement[1][1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(rexpr != null && rexpr.Name == "RegisterExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
								{
									Compiler.Translation.SymbolTable.Data.Node variable = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && true))
									{
										return (new Compiler.AST.Data.RegisterDeclarationInit(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, rexpr as Compiler.AST.Data.RegisterExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									}
								}
							}
						}
					}
				}
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && true && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 8 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && true && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && true && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && true && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && true && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && true && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && true && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && true && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node regType = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
				if(regType != null && regType.Name == "RegisterType" && true)
				{
					(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(registerStatement[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && s1 != null && s1.Name == "SymbolTable" && true)
					{
						(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(registerStatement[1][4] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && s2 != null && s2.Name == "SymbolTable" && true)
						{
							(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s3) = Translate(registerStatement[1][7] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && s3 != null && s3.Name == "SymbolTable" && true)
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
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8" && true))
			{
				return new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register8", Value = "register8" } };
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16" && true))
			{
				return new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register16", Value = "register16" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.RegisterType registerType)
		{
			Translateq__registerType++;
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register8", Value = "register8" } };
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register16", Value = "register16" } };
			}
			throw new System.Exception();
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.BooleanType booleanType)
		{
			Translatep__booleanType++;
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool" && true))
			{
				return new Compiler.AST.Data.BooleanType(false) { new Compiler.AST.Data.Token() { Name = "bool", Value = "bool" } };
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.BooleanType booleanType)
		{
			Translateq__booleanType++;
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool" && true))
			{
				return new Compiler.Translation.SymbolTable.Data.BooleanType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "bool", Value = "bool" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Assignment assignment, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__assignment_symbolTable++;
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && true && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 3 && assignment[1][0] != null && assignment[1][0].Name == "{" && true && assignment[1][1] != null && assignment[1][1].Name == "Expression" && true && assignment[1][2] != null && assignment[1][2].Name == "}" && true) && assignment[2] != null && assignment[2].Name == "=" && true && assignment[3] != null && assignment[3].Name == "Expression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "RegisterType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(assignment[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && true && s1 != null && s1.Name == "SymbolTable" && true)
						{
							(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && s2 != null && s2.Name == "SymbolTable" && true)
							{
								return (new Compiler.AST.Data.IndirectBitAssignment(false) { new Compiler.AST.Data.RegisterVariable(false) { id1 as Compiler.AST.Data.Token }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							}
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && true && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && true) && assignment[2] != null && assignment[2].Name == "=" && true && assignment[3] != null && assignment[3].Name == "Expression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "IntType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && true && s1 != null && s1.Name == "SymbolTable" && true)
						{
							return (new Compiler.AST.Data.IntegerAssignment(false) { new Compiler.AST.Data.IntegerVariable(false) { id1 as Compiler.AST.Data.Token }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, intExpr as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && true && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && true) && assignment[2] != null && assignment[2].Name == "=" && true && assignment[3] != null && assignment[3].Name == "Expression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "RegisterType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						(Compiler.AST.Data.Node registerExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(registerExpr != null && registerExpr.Name == "RegisterExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
						{
							return (new Compiler.AST.Data.RegisterAssignment(false) { new Compiler.AST.Data.RegisterVariable(false) { id1 as Compiler.AST.Data.Token }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, registerExpr as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && true && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && true) && assignment[2] != null && assignment[2].Name == "=" && true && assignment[3] != null && assignment[3].Name == "Expression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "BooleanType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
						{
							return (new Compiler.AST.Data.BooleanAssignment(false) { new Compiler.AST.Data.BooleanVariable(false) { id1 as Compiler.AST.Data.Token }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IfStatement ifStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__ifStatement_symbolTable++;
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && true && ifStatement[1] != null && ifStatement[1].Name == "(" && true && ifStatement[2] != null && ifStatement[2].Name == "Expression" && true && ifStatement[3] != null && ifStatement[3].Name == ")" && true && ifStatement[4] != null && ifStatement[4].Name == "indent" && true && ifStatement[5] != null && ifStatement[5].Name == "Statements" && true && ifStatement[6] != null && ifStatement[6].Name == "dedent" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (new Compiler.AST.Data.IfStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.WhileStatement whileStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__whileStatement_symbolTable++;
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && true && whileStatement[1] != null && whileStatement[1].Name == "(" && true && whileStatement[2] != null && whileStatement[2].Name == "Expression" && true && whileStatement[3] != null && whileStatement[3].Name == ")" && true && whileStatement[4] != null && whileStatement[4].Name == "indent" && true && whileStatement[5] != null && whileStatement[5].Name == "Statements" && true && whileStatement[6] != null && whileStatement[6].Name == "dedent" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(whileStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(whileStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(forStatement != null && forStatement.Name == "ForStatement" && (forStatement.Count == 12 && forStatement[0] != null && forStatement[0].Name == "for" && true && forStatement[1] != null && forStatement[1].Name == "(" && true && forStatement[2] != null && forStatement[2].Name == "IntType" && true && forStatement[3] != null && forStatement[3].Name == "identifier" && true && forStatement[4] != null && forStatement[4].Name == "from" && true && forStatement[5] != null && forStatement[5].Name == "Expression" && true && forStatement[6] != null && forStatement[6].Name == "to" && true && forStatement[7] != null && forStatement[7].Name == "Expression" && true && forStatement[8] != null && forStatement[8].Name == ")" && true && forStatement[9] != null && forStatement[9].Name == "indent" && true && forStatement[10] != null && forStatement[10].Name == "Statements" && true && forStatement[11] != null && forStatement[11].Name == "dedent" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(forStatement[2] as Compiler.Parsing.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(forStatement[2] as Compiler.Parsing.Data.IntType);
					if(t2 != null && t2.Name == "IntType" && true)
					{
						Compiler.AST.Data.Node id1 = Translatep(forStatement[3] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(forStatement[3] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && true)
							{
								(Compiler.AST.Data.Node iexpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(forStatement[5] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
								{
									(Compiler.AST.Data.Node iexpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(forStatement[7] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
									if(iexpr2 != null && iexpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
									{
										(Compiler.AST.Data.Node stms1, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(forStatement[10] as Compiler.Parsing.Data.Statements, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Variables(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Variables(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
										if(stms1 != null && stms1.Name == "Statement" && true && symbolTable3 != null && symbolTable3.Name == "SymbolTable" && true)
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
			if(expression != null && expression.Name == "Expression" && (expression.Count == 1 && expression[0] != null && expression[0].Name == "OrExpression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression[0] as Compiler.Parsing.Data.OrExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpression orExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__orExpression_symbolTable++;
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && true && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 1 && orExpression[1][0] != null && orExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && true && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpression[1] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && true && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && true && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 1 && orExpressionP[2][0] != null && orExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && true && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && true && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpressionP[2] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && true && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 1 && andExpression[1][0] != null && andExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == expr.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && true && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpression[1] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && true && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && true && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 1 && andExpressionP[2][0] != null && andExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && true && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && true && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpressionP[2] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "And", Value = "And" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpression eqExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			Translate__eqExpression_symbolTable++;
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && true && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 1 && eqExpression[1][0] != null && eqExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && true && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, boolExpr as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && true && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanNotEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && true && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && true && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && true && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 1 && relationalExpression[1][0] != null && relationalExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && true && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpression[1] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">=", Value = ">=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && true && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && true && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && true && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 1 && addSubExpression[1][0] != null && addSubExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && true && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpression[1] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && true && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && true && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && true && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && true && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && true && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && true && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && true && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && true && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && true && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 1 && mulDivExpression[1][0] != null && mulDivExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && true && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpression[1] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.ModExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "%", Value = "%" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && true && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && true && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && true && powExpression[1] != null && powExpression[1].Name == "PowExpressionP" && (powExpression[1].Count == 1 && powExpression[1][0] != null && powExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == expr1.Name && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && true && powExpression[1] != null && powExpression[1].Name == "PowExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpression[1] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && true && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && true && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP" && (powExpressionP[2].Count == 1 && powExpressionP[2][0] != null && powExpressionP[2][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.PowExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "^", Value = "^" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && true && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && true && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpressionP[2] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
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
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "numeral" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node i1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(i1 != null && i1.Name == "numeral" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { i1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && true && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "IntType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.IntegerVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && true && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "RegisterType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && true && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "BooleanType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && true && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "{" && true && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "Expression" && true && primaryExpression[1][2] != null && primaryExpression[1][2].Name == "}" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "RegisterType" && true) && variable[1] != null && variable[1].Name == "identifier" && true))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IndirectBitValue(false) { new Compiler.AST.Data.RegisterVariable(false) { id1 as Compiler.AST.Data.Token }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && true && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && true && primaryExpression[2] != null && primaryExpression[2].Name == ")" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && true && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && true && primaryExpression[2] != null && primaryExpression[2].Name == ")" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "!" && true && primaryExpression[1] != null && primaryExpression[1].Name == "PrimaryExpression" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.NotExpression(false) { new Compiler.AST.Data.Token() { Name = "!", Value = "!" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && true && primaryExpression[1] != null && primaryExpression[1].Name == "(" && true && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && true && primaryExpression[3] != null && primaryExpression[3].Name == ")" && true && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 1 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "EPSILON" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr != null && intExpr.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterLiteral(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && true && primaryExpression[1] != null && primaryExpression[1].Name == "(" && true && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && true && primaryExpression[3] != null && primaryExpression[3].Name == ")" && true && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 3 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "{" && true && primaryExpression[4][1] != null && primaryExpression[4][1].Name == "Expression" && true && primaryExpression[4][2] != null && primaryExpression[4][2].Name == "}" && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && true && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && true)
					{
						(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(primaryExpression[4][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && true && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && true)
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.DirectBitValue(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "true" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "true" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { t1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "false" && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && true)
			{
				Compiler.AST.Data.Node f1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(f1 != null && f1.Name == "false" && true)
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { f1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
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
			System.Console.WriteLine("Translates__identifier_variables: "+Translates__identifier_variables);
			System.Console.WriteLine("Translate__program_symbolTable: "+Translate__program_symbolTable);
			System.Console.WriteLine("Translate__globalStatements_symbolTable: "+Translate__globalStatements_symbolTable);
			System.Console.WriteLine("Translate__globalStatementsP_symbolTable: "+Translate__globalStatementsP_symbolTable);
			System.Console.WriteLine("Translate__globalStatement_symbolTable: "+Translate__globalStatement_symbolTable);
			System.Console.WriteLine("Translate__interrupt_symbolTable: "+Translate__interrupt_symbolTable);
			System.Console.WriteLine("Translate__statements_symbolTable: "+Translate__statements_symbolTable);
			System.Console.WriteLine("Translate__statementsP_symbolTable: "+Translate__statementsP_symbolTable);
			System.Console.WriteLine("Translate__statement_symbolTable: "+Translate__statement_symbolTable);
			System.Console.WriteLine("Translate__identifierDeclaration_symbolTable: "+Translate__identifierDeclaration_symbolTable);
			System.Console.WriteLine("Translatep__intType: "+Translatep__intType);
			System.Console.WriteLine("Translateq__intType: "+Translateq__intType);
			System.Console.WriteLine("Translate__registerStatement_symbolTable: "+Translate__registerStatement_symbolTable);
			System.Console.WriteLine("Translatep__registerType: "+Translatep__registerType);
			System.Console.WriteLine("Translateq__registerType: "+Translateq__registerType);
			System.Console.WriteLine("Translatep__booleanType: "+Translatep__booleanType);
			System.Console.WriteLine("Translateq__booleanType: "+Translateq__booleanType);
			System.Console.WriteLine("Translate__assignment_symbolTable: "+Translate__assignment_symbolTable);
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
		}
	}
}
