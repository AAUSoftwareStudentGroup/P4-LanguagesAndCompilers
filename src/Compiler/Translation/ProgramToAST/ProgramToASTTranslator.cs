namespace Compiler.Translation.ProgramToAST
{
	public class ProgramToASTTranslator 
	{
		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Program program)
		{
			if(program != null && program.Name == "Program" && (program.Count == 0 && true))
			{
				(Compiler.AST.Data.Node ast, Compiler.Translation.SymbolTable.Data.Node symbolTable) = Translate(program as Compiler.Parsing.Data.Program, new Compiler.Translation.SymbolTable.Data.SymbolTable(false) { new Compiler.Translation.SymbolTable.Data.Declaration(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } });
				if(ast != null && ast.Name == "AST" && (ast.Count == 0 && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
				{
					return ast as Compiler.AST.Data.AST;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declaration" && (symbolTable[0].Count == 0 && true)))
			{
				Compiler.Translation.SymbolTable.Data.Node var = Translates(identifier as Compiler.Parsing.Data.Token, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Declaration);
				if(var != null && var.Name == "Variable" && (var.Count == 0 && true))
				{
					return var as Compiler.Translation.SymbolTable.Data.Variable;
				}
			}
			throw new System.Exception();
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.Declaration declaration)
		{
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 2 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 0 && true) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && (declaration[0][1].Count == 0 && true)) && declaration[1] != null && declaration[1].Name == "Declaration" && (declaration[1].Count == 0 && true)))
			{
				return declaration[0] as Compiler.Translation.SymbolTable.Data.Variable;
			}
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 2 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 0 && true) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && (declaration[0][1].Count == 0 && true)) && declaration[1] != null && declaration[1].Name == "Declaration" && (declaration[1].Count == 0 && true)))
			{
				Compiler.Translation.SymbolTable.Data.Node var = Translates(identifier as Compiler.Parsing.Data.Token, declaration[1] as Compiler.Translation.SymbolTable.Data.Declaration);
				if(var != null && var.Name == "Variable" && (var.Count == 0 && true))
				{
					return var as Compiler.Translation.SymbolTable.Data.Variable;
				}
			}
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON" && (declaration[0].Count == 0 && true)))
			{
				return new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON" && (program[0][0].Count == 0 && true)) && program[1] != null && program[1].Name == "eof" && (program[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return (new Compiler.AST.Data.Token() { Name = "Program", Value = "Program" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 0 && true) && program[1] != null && program[1].Name == "eof" && (program[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node GlobalStatement, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(GlobalStatement != null && GlobalStatement.Name == "stm" && (GlobalStatement.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.Token() { Name = "Program", Value = "Program" }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && (globalStatements[0].Count == 0 && true) && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatementsP" && (globalStatements[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatements[1] as Compiler.Parsing.Data.GlobalStatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return (Insert(stm2 as Compiler.AST.Data.GlobalStatement, stm1 as Compiler.AST.Data.GlobalStatement) as Compiler.AST.Data.GlobalStatement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatementsP globalStatementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && (globalStatementsP[0].Count == 0 && true) && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && (globalStatementsP[1].Count == 0 && true) && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && (globalStatementsP[2].Count == 1 && globalStatementsP[2][0] != null && globalStatementsP[2][0].Name == "EPSILON" && (globalStatementsP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatementsP[1] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.GlobalStatement } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && (globalStatementsP[0].Count == 0 && true) && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && (globalStatementsP[1].Count == 0 && true) && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && (globalStatementsP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatementsP[1] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatementsP[2] as Compiler.Parsing.Data.GlobalStatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "GlobalStatement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return (Insert(stm2 as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.GlobalStatement } }) as Compiler.AST.Data.GlobalStatement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt" && (globalStatement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node inter1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Interrupt, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(inter1 != null && inter1.Name == "Interrupt" && (inter1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { inter1 as Compiler.AST.Data.Interrupt }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement" && (globalStatement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.GlobalStatement(false) { stm1 as Compiler.AST.Data.Statement }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && (interrupt[0].Count == 0 && true) && interrupt[1] != null && interrupt[1].Name == "(" && (interrupt[1].Count == 0 && true) && interrupt[2] != null && interrupt[2].Name == "Expression" && (interrupt[2].Count == 0 && true) && interrupt[3] != null && interrupt[3].Name == ")" && (interrupt[3].Count == 0 && true) && interrupt[4] != null && interrupt[4].Name == "indent" && (interrupt[4].Count == 0 && true) && interrupt[5] != null && interrupt[5].Name == "Statements" && (interrupt[5].Count == 0 && true) && interrupt[6] != null && interrupt[6].Name == "dedent" && (interrupt[6].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(interrupt[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(interrupt[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (new Compiler.AST.Data.Interrupt(false) { new Compiler.AST.Data.Token() { Name = "interrupt", Value = "interrupt" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && (statements[0].Count == 0 && true) && statements[1] != null && statements[1].Name == "StatementsP" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON" && (statements[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (stm1 as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && (statements[0].Count == 0 && true) && statements[1] != null && statements[1].Name == "StatementsP" && (statements[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.StatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return (Insert(stm2 as Compiler.AST.Data.Statement, stm1 as Compiler.AST.Data.Statement) as Compiler.AST.Data.Statement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.StatementsP statementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && (statementsP[0].Count == 0 && true) && statementsP[1] != null && statementsP[1].Name == "Statement" && (statementsP[1].Count == 0 && true) && statementsP[2] != null && statementsP[2].Name == "StatementsP" && (statementsP[2].Count == 1 && statementsP[2][0] != null && statementsP[2][0].Name == "EPSILON" && (statementsP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statementsP[1] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { new Compiler.AST.Data.Statement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.Statement } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && (statementsP[0].Count == 0 && true) && statementsP[1] != null && statementsP[1].Name == "Statement" && (statementsP[1].Count == 0 && true) && statementsP[2] != null && statementsP[2].Name == "StatementsP" && (statementsP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statementsP[1] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statementsP[2] as Compiler.Parsing.Data.StatementsP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm2 != null && stm2.Name == "Statement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return (Insert(stm2 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { new Compiler.AST.Data.Statement(true), new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm1 as Compiler.AST.Data.Statement } }) as Compiler.AST.Data.Statement, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(dclStm != null && dclStm.Name == "Statement" && (dclStm.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (dclStm as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "Assignment" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node assStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.Assignment, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(assStm != null && assStm.Name == "Statement" && (assStm.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (assStm as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node ifStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IfStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(ifStm1 != null && ifStm1.Name == "Statement" && (ifStm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (ifStm1 as Compiler.AST.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node whileStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.WhileStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(whileStm1 != null && whileStm1.Name == "Statement" && (whileStm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return (whileStm1 as Compiler.AST.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 2 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "intType" && (identifierDeclaration[0].Count == 0 && true) && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && (identifierDeclaration[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "intType" && (t1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
					if(t2 != null && t2.Name == "intType" && (t2.Count == 0 && true))
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && (id2.Count == 0 && true))
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
								{
									return (new Compiler.AST.Data.IntegerDeclaration(false) { t1 as Compiler.AST.Data.Token, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.Token }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Declaration(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 2 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "booleanType" && (identifierDeclaration[0].Count == 0 && true) && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && (identifierDeclaration[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "registerType" && (t1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
					if(t2 != null && t2.Name == "registerType" && (t2.Count == 0 && true))
					{
						Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && (id2.Count == 0 && true))
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
								{
									return (new Compiler.AST.Data.BooleanDeclaration(false) { t1 as Compiler.AST.Data.Token, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.Token }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Declaration(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "registerType" && (registerStatement[0].Count == 0 && true) && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 1 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && (registerStatement[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "registerType" && (t1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.Token);
					if(t2 != null && t2.Name == "registerType" && (t2.Count == 0 && true))
					{
						Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
						if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
						{
							Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
							if(id2 != null && id2.Name == "identifier" && (id2.Count == 0 && true))
							{
								Compiler.Translation.SymbolTable.Data.Node variable = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
								if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
								{
									return (new Compiler.AST.Data.RegisterDeclaration(false) { t1 as Compiler.AST.Data.Token, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.Token }, id2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Declaration(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
								}
							}
						}
					}
				}
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "registerType" && (registerStatement[0].Count == 0 && true) && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 8 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && (registerStatement[1][0].Count == 0 && true) && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && (registerStatement[1][1].Count == 0 && true) && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && (registerStatement[1][2].Count == 0 && true) && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && (registerStatement[1][3].Count == 0 && true) && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && (registerStatement[1][4].Count == 0 && true) && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && (registerStatement[1][5].Count == 0 && true) && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && (registerStatement[1][6].Count == 0 && true) && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && (registerStatement[1][7].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(registerStatement[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(registerStatement[1][4] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s3) = Translate(registerStatement[1][7] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && s3 != null && s3.Name == "SymbolTable" && (s3.Count == 0 && true))
						{
							return (new Compiler.AST.Data.DirectBitAssignment(false) { new Compiler.AST.Data.Token() { Name = "registerType", Value = "registerType" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Assignment assignment, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 3 && assignment[1][0] != null && assignment[1][0].Name == "{" && (assignment[1][0].Count == 0 && true) && assignment[1][1] != null && assignment[1][1].Name == "Expression" && (assignment[1][1].Count == 0 && true) && assignment[1][2] != null && assignment[1][2].Name == "}" && (assignment[1][2].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "registerType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(assignment[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
						{
							(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
							{
								return (new Compiler.AST.Data.Token() { Name = "IndirectBitAssigment", Value = "IndirectBitAssigment" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
							}
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "intType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
						{
							return (new Compiler.AST.Data.IntegerAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, intExpr as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "registerType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						(Compiler.AST.Data.Node registerExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(registerExpr != null && registerExpr.Name == "RegisterExpression" && (registerExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
						{
							return (new Compiler.AST.Data.RegisterAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, registerExpr as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(assignment[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(assignment[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "booleanType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(assignment[3] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
						{
							return (new Compiler.AST.Data.BooleanAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IfStatement ifStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && (ifStatement[0].Count == 0 && true) && ifStatement[1] != null && ifStatement[1].Name == "(" && (ifStatement[1].Count == 0 && true) && ifStatement[2] != null && ifStatement[2].Name == "Expression" && (ifStatement[2].Count == 0 && true) && ifStatement[3] != null && ifStatement[3].Name == ")" && (ifStatement[3].Count == 0 && true) && ifStatement[4] != null && ifStatement[4].Name == "indent" && (ifStatement[4].Count == 0 && true) && ifStatement[5] != null && ifStatement[5].Name == "Statements" && (ifStatement[5].Count == 0 && true) && ifStatement[6] != null && ifStatement[6].Name == "dedent" && (ifStatement[6].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (new Compiler.AST.Data.IfStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.WhileStatement whileStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && (whileStatement[0].Count == 0 && true) && whileStatement[1] != null && whileStatement[1].Name == "(" && (whileStatement[1].Count == 0 && true) && whileStatement[2] != null && whileStatement[2].Name == "Expression" && (whileStatement[2].Count == 0 && true) && whileStatement[3] != null && whileStatement[3].Name == ")" && (whileStatement[3].Count == 0 && true) && whileStatement[4] != null && whileStatement[4].Name == "indent" && (whileStatement[4].Count == 0 && true) && whileStatement[5] != null && whileStatement[5].Name == "Statements" && (whileStatement[5].Count == 0 && true) && whileStatement[6] != null && whileStatement[6].Name == "dedent" && (whileStatement[6].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(whileStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(whileStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (new Compiler.AST.Data.WhileStatement(false) { new Compiler.AST.Data.Token() { Name = "while", Value = "while" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(expression != null && expression.Name == "Expression" && (expression.Count == 1 && expression[0] != null && expression[0].Name == "OrExpression" && (expression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression[0] as Compiler.Parsing.Data.OrExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpression orExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && (orExpression[0].Count == 0 && true) && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 1 && orExpression[1][0] != null && orExpression[1][0].Name == "EPSILON" && (orExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && (orExpression[0].Count == 0 && true) && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpression[1] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanAssignment" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanAssignment, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanAssignment, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpressionP orExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && (orExpressionP[0].Count == 0 && true) && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && (orExpressionP[1].Count == 0 && true) && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 1 && orExpressionP[2][0] != null && orExpressionP[2][0].Name == "EPSILON" && (orExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && (orExpressionP[0].Count == 0 && true) && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && (orExpressionP[1].Count == 0 && true) && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpressionP[2] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpression andExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && (andExpression[0].Count == 0 && true) && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 1 && andExpression[1][0] != null && andExpression[1][0].Name == "EPSILON" && (andExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && (andExpression[0].Count == 0 && true) && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpression[1] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanAssignment" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanAssignment, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanAssignment, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpressionP andExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && (andExpressionP[0].Count == 0 && true) && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && (andExpressionP[1].Count == 0 && true) && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 1 && andExpressionP[2][0] != null && andExpressionP[2][0].Name == "EPSILON" && (andExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr != null && expr.Name == "BooleanExpression" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && (andExpressionP[0].Count == 0 && true) && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && (andExpressionP[1].Count == 0 && true) && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpressionP[2] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr2 != null && expr2.Name == "BooleanExpression" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "And", Value = "And" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpression eqExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 1 && eqExpression[1][0] != null && eqExpression[1][0].Name == "EPSILON" && (eqExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr1 as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, boolExpr as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpressionP eqExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && (eqExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && (eqExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpression relationalExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && (relationalExpression[0].Count == 0 && true) && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 1 && relationalExpression[1][0] != null && relationalExpression[1][0].Name == "EPSILON" && (relationalExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr1 as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && (relationalExpression[0].Count == 0 && true) && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpression[1] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpressionP relationalExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && (relationalExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && (relationalExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpression addSubExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && (addSubExpression[0].Count == 0 && true) && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 1 && addSubExpression[1][0] != null && addSubExpression[1][0].Name == "EPSILON" && (addSubExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr1 as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && (addSubExpression[0].Count == 0 && true) && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpression[1] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "BooleanExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.BooleanExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpressionP addSubExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && (addSubExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && (addSubExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpression mulDivExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PrimaryExpression" && (mulDivExpression[0].Count == 0 && true) && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 1 && mulDivExpression[1][0] != null && mulDivExpression[1][0].Name == "EPSILON" && (mulDivExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (expr1 as Compiler.AST.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PrimaryExpression" && (mulDivExpression[0].Count == 0 && true) && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpression[1] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpressionP mulDivExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && (mulDivExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && (mulDivExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PrimaryExpression primaryExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "intLiteral" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node i1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(i1 != null && i1.Name == "intLiteral" && (i1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { i1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "intType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.IntegerVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "registerType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "booleanType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanVariable(false) { id1 as Compiler.AST.Data.Token } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "{" && (primaryExpression[1][0].Count == 0 && true) && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "Expression" && (primaryExpression[1][1].Count == 0 && true) && primaryExpression[1][2] != null && primaryExpression[1][2].Name == "}" && (primaryExpression[1][2].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(id1 != null && id1.Name == "identifier" && (id1.Count == 0 && true))
				{
					Compiler.Translation.SymbolTable.Data.Node variable = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "Type" && (variable[0].Count == 1 && variable[0][0] != null && variable[0][0].Name == "registerType" && (variable[0][0].Count == 0 && true)) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
					{
						(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IndirectBitValue(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == ")" && (primaryExpression[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == ")" && (primaryExpression[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				(Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "registerType" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "(" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && (primaryExpression[2].Count == 0 && true) && primaryExpression[3] != null && primaryExpression[3].Name == ")" && (primaryExpression[3].Count == 0 && true) && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 1 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "EPSILON" && (primaryExpression[4][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "registerType" && (t1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						return (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterLiteral(false) { t1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "registerType" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "(" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && (primaryExpression[2].Count == 0 && true) && primaryExpression[3] != null && primaryExpression[3].Name == ")" && (primaryExpression[3].Count == 0 && true) && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 3 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "{" && (primaryExpression[4][0].Count == 0 && true) && primaryExpression[4][1] != null && primaryExpression[4][1].Name == "Expression" && (primaryExpression[4][1].Count == 0 && true) && primaryExpression[4][2] != null && primaryExpression[4][2].Name == "}" && (primaryExpression[4][2].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "registerType" && (t1.Count == 0 && true))
				{
					(Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
					if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						(Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(primaryExpression[4][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
						{
							return (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.DirectBitValue(false) { t1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
						}
					}
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "true" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(t1 != null && t1.Name == "true" && (t1.Count == 0 && true))
				{
					return (new Compiler.AST.Data.BooleanExpression(false) { t1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
				}
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "false" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Compiler.AST.Data.Node f1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
				if(f1 != null && f1.Name == "false" && (f1.Count == 0 && true))
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

		public Compiler.Parsing.Data.Node Insert(Compiler.Parsing.Data.Node left, Compiler.Parsing.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right;
			}
			for (int i = 0; i < left.Count;  i++)
			{
			    Compiler.Parsing.Data.Node child = Insert(left[i], right);
			    if(child != null)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, child);
			        return left;
			    }
			}
			return null;
		}

		public Compiler.AST.Data.Node Insert(Compiler.AST.Data.Node left, Compiler.AST.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right;
			}
			for (int i = 0; i < left.Count;  i++)
			{
			    Compiler.AST.Data.Node child = Insert(left[i], right);
			    if(child != null)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, child);
			        return left;
			    }
			}
			return null;
		}

		public Compiler.Translation.SymbolTable.Data.Node Insert(Compiler.Translation.SymbolTable.Data.Node left, Compiler.Translation.SymbolTable.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right;
			}
			for (int i = 0; i < left.Count;  i++)
			{
			    Compiler.Translation.SymbolTable.Data.Node child = Insert(left[i], right);
			    if(child != null)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, child);
			        return left;
			    }
			}
			return null;
		}
	}
}
