namespace Compiler.Translation.ProgramToAST
{
	public class ProgramToASTTranslator 
	{
		public Node Translate(Undefined identifier, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declaration" && (symbolTable[0].Count == 0 && true)))
			{
				Node node1 = Translate(identifier, symbolTable[0]);
				Compiler.Translation.SymbolTable.Data.Variable var = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(var != null && var.Name == "Variable" && (var.Count == 0 && true))
				{
					return var;
				}
			// (id = identifier), (SymbolTable = symbolTable), (dcl = symbolTable[0]), (var = var)
			}
		}

		public Node Translate(Undefined identifier, Compiler.Translation.SymbolTable.Data.Declaration declaration)
		{
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 2 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "identifier" && (declaration[0][0].Count == 0 && true) && declaration[0][1] != null && declaration[0][1].Name == "Definition" && (declaration[0][1].Count == 0 && true)) && declaration[1] != null && declaration[1].Name == "Declaration" && (declaration[1].Count == 0 && true)))
			{
				return declaration[0];
			// (id1 = identifier), (dcl1 = declaration), (var = declaration[0]), (id2 = declaration[0][0]), (def = declaration[0][1]), (dcl2 = declaration[1])
			}
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 2 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "identifier" && (declaration[0][0].Count == 0 && true) && declaration[0][1] != null && declaration[0][1].Name == "Definition" && (declaration[0][1].Count == 0 && true)) && declaration[1] != null && declaration[1].Name == "Declaration" && (declaration[1].Count == 0 && true)))
			{
				Node node1 = Translate(identifier, declaration[1]);
				Compiler.Translation.SymbolTable.Data.Variable var = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(var != null && var.Name == "Variable" && (var.Count == 0 && true))
				{
					return var;
				}
			// (id1 = identifier), (dcl1 = declaration), (Variable = declaration[0]), (id2 = declaration[0][0]), (def = declaration[0][1]), (dcl2 = declaration[1]), (var = var)
			}
			if(identifier != null && identifier.Name == "identifier" && (identifier.Count == 0 && true) && declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON" && (declaration[0].Count == 0 && true)))
			{
				return new Variable() { declaration[0] };
			// (id1 = identifier), (Declaration = declaration), (EPSILON = declaration[0])
			}
		}

		public Node Translate(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON" && (program[0][0].Count == 0 && true)) && program[1] != null && program[1].Name == "eof" && (program[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return new ListNode() { program, symbolTable };
			// (Program = program), (GlobalStatements = program[0]), (EPSILON = program[0][0]), (eof = program[1]), (s = symbolTable)
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 0 && true) && program[1] != null && program[1].Name == "eof" && (program[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(program[0], symbolTable);
				Undefined GlobalStatement = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(GlobalStatement != null && GlobalStatement.Name == "stm" && (GlobalStatement.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { program, s1 };
				}
			// (Program = program), (stms = program[0]), (eof = program[1]), (s = symbolTable), (GlobalStatement = GlobalStatement), (s1 = s1)
			}
		}

		public Node Translate(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && (globalStatements[0].Count == 0 && true) && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatementsP" && (globalStatements[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(globalStatements[0], symbolTable);
				Compiler.AST.Data.GlobalStatement stm1 = node1[0] as Compiler.AST.Data.GlobalStatement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					Node node2 = Translate(globalStatements[1], s1);
					Compiler.AST.Data.GlobalStatement stm2 = node2[0] as Compiler.AST.Data.GlobalStatement;
					Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm2 != null && stm2.Name == "GlobalStatement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return new ListNode() { stm2, s2 };
					}
				}
			// (GlobalStatements = globalStatements), (stm = globalStatements[0]), (stmsp = globalStatements[1]), (s = symbolTable), (stm1 = stm1), (s1 = s1), (stm2 = stm2), (s2 = s2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.GlobalStatementsP globalStatementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && (globalStatementsP[0].Count == 0 && true) && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && (globalStatementsP[1].Count == 0 && true) && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && (globalStatementsP[2].Count == 1 && globalStatementsP[2][0] != null && globalStatementsP[2][0].Name == "EPSILON" && (globalStatementsP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(globalStatementsP[1], symbolTable);
				Compiler.AST.Data.GlobalStatement stm1 = node1[0] as Compiler.AST.Data.GlobalStatement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { new GlobalStatement() { new CompoundGlobalStatement() { new GlobalStatement(), new newline(), stm1 } }, s1 };
				}
			// (GlobalStatementsP = globalStatementsP), (nl = globalStatementsP[0]), (stm = globalStatementsP[1]), (EPSILON = globalStatementsP[2][0]), (s = symbolTable), (stm1 = stm1), (s1 = s1)
			}
			if(globalStatementsP != null && globalStatementsP.Name == "GlobalStatementsP" && (globalStatementsP.Count == 3 && globalStatementsP[0] != null && globalStatementsP[0].Name == "newline" && (globalStatementsP[0].Count == 0 && true) && globalStatementsP[1] != null && globalStatementsP[1].Name == "GlobalStatement" && (globalStatementsP[1].Count == 0 && true) && globalStatementsP[2] != null && globalStatementsP[2].Name == "GlobalStatementsP" && (globalStatementsP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(globalStatementsP[1], symbolTable);
				Compiler.AST.Data.GlobalStatement stm1 = node1[0] as Compiler.AST.Data.GlobalStatement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "GlobalStatement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					Node node2 = Translate(globalStatementsP[2], s1);
					Compiler.AST.Data.GlobalStatement stm2 = node2[0] as Compiler.AST.Data.GlobalStatement;
					Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm2 != null && stm2.Name == "GlobalStatement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return new ListNode() { stm2, s2 };
					}
				}
			// (GlobalStatementsP = globalStatementsP), (newline = globalStatementsP[0]), (stm = globalStatementsP[1]), (stmsp = globalStatementsP[2]), (s = symbolTable), (stm1 = stm1), (s1 = s1), (stm2 = stm2), (s2 = s2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt" && (globalStatement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(globalStatement[0], symbolTable);
				Compiler.AST.Data.Interrupt inter1 = node1[0] as Compiler.AST.Data.Interrupt;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(inter1 != null && inter1.Name == "Interrupt" && (inter1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { globalStatement, symbolTable };
				}
			// (GlobalStatement = globalStatement), (inter = globalStatement[0]), (s = symbolTable), (inter1 = inter1), (SymbolTable = symbolTable1)
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement" && (globalStatement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(globalStatement[0], symbolTable);
				Compiler.AST.Data.Statement stm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { globalStatement, s1 };
				}
			// (GlobalStatement = globalStatement), (stm = globalStatement[0]), (s = symbolTable), (stm1 = stm1), (s1 = s1)
			}
		}

		public Node Translate(Compiler.Parsing.Data.Interrupt interrupt)
		{
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && (interrupt[0].Count == 0 && true) && interrupt[1] != null && interrupt[1].Name == "(" && (interrupt[1].Count == 0 && true) && interrupt[2] != null && interrupt[2].Name == "Expression" && (interrupt[2].Count == 0 && true) && interrupt[3] != null && interrupt[3].Name == ")" && (interrupt[3].Count == 0 && true) && interrupt[4] != null && interrupt[4].Name == "indent" && (interrupt[4].Count == 0 && true) && interrupt[5] != null && interrupt[5].Name == "Statements" && (interrupt[5].Count == 0 && true) && interrupt[6] != null && interrupt[6].Name == "dedent" && (interrupt[6].Count == 0 && true)))
			{
				Node node1 = Translate(interrupt[2], new s());
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
				{
					Node node2 = Translate(interrupt[5], new s());
					Compiler.AST.Data.Statement stm = node2[0] as Compiler.AST.Data.Statement;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						return interrupt;
					}
				}
			// (Interrupt = interrupt), (interrupt = interrupt[0]), (( = interrupt[1]), (expr = interrupt[2]), () = interrupt[3]), (indent = interrupt[4]), (stms = interrupt[5]), (dedent = interrupt[6]), (intExpr = intExpr), (SymbolTable = symbolTable), (stm = stm)
			}
		}

		public Node Translate(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && (statements[0].Count == 0 && true) && statements[1] != null && statements[1].Name == "StatementsP" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON" && (statements[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statements[0], symbolTable);
				Compiler.AST.Data.Statement stm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { stm1, s1 };
				}
			// (Statements = statements), (stm = statements[0]), (StatementsP = statements[1]), (EPSILON = statements[1][0]), (s = symbolTable), (stm1 = stm1), (s1 = s1)
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && (statements[0].Count == 0 && true) && statements[1] != null && statements[1].Name == "StatementsP" && (statements[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statements[0], symbolTable);
				Compiler.AST.Data.Statement stm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					Node node2 = Translate(statements[1], s1);
					Compiler.AST.Data.Statement stm2 = node2[0] as Compiler.AST.Data.Statement;
					Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm2 != null && stm2.Name == "Statement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return new ListNode() { stm2, s2 };
					}
				}
			// (Statements = statements), (stm = statements[0]), (stmsp = statements[1]), (s = symbolTable), (stm1 = stm1), (s1 = s1), (stm2 = stm2), (s2 = s2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.StatementsP statementsP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && (statementsP[0].Count == 0 && true) && statementsP[1] != null && statementsP[1].Name == "Statement" && (statementsP[1].Count == 0 && true) && statementsP[2] != null && statementsP[2].Name == "StatementsP" && (statementsP[2].Count == 1 && statementsP[2][0] != null && statementsP[2][0].Name == "EPSILON" && (statementsP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statementsP[1], symbolTable);
				Compiler.AST.Data.Statement stm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { new Statement() { new CompoundStatement() { new Statement(), new newline(), stm1 } }, s1 };
				}
			// (StatementsP = statementsP), (nl = statementsP[0]), (stm = statementsP[1]), (EPSILON = statementsP[2][0]), (s = symbolTable), (stm1 = stm1), (s1 = s1)
			}
			if(statementsP != null && statementsP.Name == "StatementsP" && (statementsP.Count == 3 && statementsP[0] != null && statementsP[0].Name == "newline" && (statementsP[0].Count == 0 && true) && statementsP[1] != null && statementsP[1].Name == "Statement" && (statementsP[1].Count == 0 && true) && statementsP[2] != null && statementsP[2].Name == "StatementsP" && (statementsP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statementsP[1], symbolTable);
				Compiler.AST.Data.Statement stm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(stm1 != null && stm1.Name == "Statement" && (stm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					Node node2 = Translate(statementsP[2], s1);
					Compiler.AST.Data.Statement stm2 = node2[0] as Compiler.AST.Data.Statement;
					Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm2 != null && stm2.Name == "Statement" && (stm2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						return new ListNode() { stm2, s2 };
					}
				}
			// (StatementsP = statementsP), (newline = statementsP[0]), (stm = statementsP[1]), (stmsp = statementsP[2]), (s = symbolTable), (stm1 = stm1), (s1 = s1), (stm2 = stm2), (s2 = s2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return new ListNode() { statement, symbolTable };
			// (Statement = statement), (newline = statement[0]), (s = symbolTable)
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statement[0], symbolTable);
				Compiler.AST.Data.Statement dclStm = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(dclStm != null && dclStm.Name == "Statement" && (dclStm.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { dclStm, s1 };
				}
			// (Statement = statement), (idDcl = statement[0]), (s = symbolTable), (dclStm = dclStm), (s1 = s1)
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "Assignment" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statement[0], symbolTable);
				Compiler.AST.Data.Statement assStm = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(assStm != null && assStm.Name == "Statement" && (assStm.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { assStm, s1 };
				}
			// (Statement = statement), (ass = statement[0]), (s = symbolTable), (assStm = assStm), (s1 = s1)
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statement[0], symbolTable);
				Compiler.AST.Data.Statement ifStm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(ifStm1 != null && ifStm1.Name == "Statement" && (ifStm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { ifStm1, symbolTable };
				}
			// (Statement = statement), (ifStm = statement[0]), (s = symbolTable), (ifStm1 = ifStm1), (s1 = s1)
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement" && (statement[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(statement[0], symbolTable);
				Compiler.AST.Data.Statement whileStm1 = node1[0] as Compiler.AST.Data.Statement;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(whileStm1 != null && whileStm1.Name == "Statement" && (whileStm1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					return new ListNode() { whileStm1, symbolTable };
				}
			// (Statement = statement), (whileStm = statement[0]), (s = symbolTable), (whileStm1 = whileStm1), (s1 = s1)
			}
		}

		public Node Translate(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 2 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "intType" && (identifierDeclaration[0].Count == 0 && true) && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && (identifierDeclaration[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(identifierDeclaration[1], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
				{
					return new ListNode() { new IntegerDeclaration() { identifierDeclaration[0], identifierDeclaration[1] }, symbolTable };
				}
			// (IdentifierDeclaration = identifierDeclaration), (t = identifierDeclaration[0]), (id = identifierDeclaration[1]), (s = symbolTable), (Variable = variable), (EPSILON = variable[0])
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 2 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "booleanType" && (identifierDeclaration[0].Count == 0 && true) && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && (identifierDeclaration[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(identifierDeclaration[1], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
				{
					return new ListNode() { new BooleanDeclaration() { identifierDeclaration[0], identifierDeclaration[1] }, symbolTable };
				}
			// (IdentifierDeclaration = identifierDeclaration), (t = identifierDeclaration[0]), (id = identifierDeclaration[1]), (s = symbolTable), (Variable = variable), (EPSILON = variable[0])
			}
		}

		public Node Translate(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "registerType" && (registerStatement[0].Count == 0 && true) && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 1 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && (registerStatement[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(registerStatement[1][0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 1 && variable[0] != null && variable[0].Name == "EPSILON" && (variable[0].Count == 0 && true)))
				{
					return new ListNode() { new RegisterDeclaration() { registerStatement[0], registerStatement[1][0] }, symbolTable };
				}
			// (RegisterStatement = registerStatement), (t = registerStatement[0]), (RegisterOperation = registerStatement[1]), (id = registerStatement[1][0]), (s = symbolTable), (Variable = variable), (EPSILON = variable[0])
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "registerType" && (registerStatement[0].Count == 0 && true) && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 8 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && (registerStatement[1][0].Count == 0 && true) && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && (registerStatement[1][1].Count == 0 && true) && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && (registerStatement[1][2].Count == 0 && true) && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && (registerStatement[1][3].Count == 0 && true) && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && (registerStatement[1][4].Count == 0 && true) && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && (registerStatement[1][5].Count == 0 && true) && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && (registerStatement[1][6].Count == 0 && true) && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && (registerStatement[1][7].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(registerStatement[1][1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
				{
					Node node2 = Translate(registerStatement[1][4], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
					{
						Node node3 = Translate(registerStatement[1][7], symbolTable);
						Compiler.AST.Data.BooleanExpression boolExpr = node3[0] as Compiler.AST.Data.BooleanExpression;
						Compiler.Translation.SymbolTable.Data.SymbolTable s3 = node3[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && s3 != null && s3.Name == "SymbolTable" && (s3.Count == 0 && true))
						{
							return new ListNode() { new DirectBitAssignment() { registerStatement[0], registerStatement[1][0], intExpr1, registerStatement[1][2], registerStatement[1][3], intExpr2, registerStatement[1][5], registerStatement[1][6], boolExpr }, symbolTable };
						}
					}
				}
			// (RegisterStatement = registerStatement), (registerType = registerStatement[0]), (RegisterOperation = registerStatement[1]), (( = registerStatement[1][0]), (expr1 = registerStatement[1][1]), () = registerStatement[1][2]), ({ = registerStatement[1][3]), (expr2 = registerStatement[1][4]), (} = registerStatement[1][5]), (= = registerStatement[1][6]), (expr3 = registerStatement[1][7]), (s = symbolTable), (intExpr1 = intExpr1), (s1 = s1), (intExpr2 = intExpr2), (s2 = s2), (boolExpr = boolExpr), (s3 = s3)
			}
		}

		public Node Translate(Compiler.Parsing.Data.Assignment assignment, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 3 && assignment[1][0] != null && assignment[1][0].Name == "{" && (assignment[1][0].Count == 0 && true) && assignment[1][1] != null && assignment[1][1].Name == "Expression" && (assignment[1][1].Count == 0 && true) && assignment[1][2] != null && assignment[1][2].Name == "}" && (assignment[1][2].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(assignment[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "registerType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					Node node2 = Translate(assignment[1][1], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
					{
						Node node3 = Translate(assignment[3], symbolTable);
						Compiler.AST.Data.BooleanExpression boolExpr = node3[0] as Compiler.AST.Data.BooleanExpression;
						Compiler.Translation.SymbolTable.Data.SymbolTable s2 = node3[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
						if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && s2 != null && s2.Name == "SymbolTable" && (s2.Count == 0 && true))
						{
							return new ListNode() { new IndirectBitAssigment() { assignment[0], assignment[1][0], intExpr, assignment[1][2], assignment[2], boolExpr }, symbolTable };
						}
					}
				}
			// (Assignment = assignment), (id = assignment[0]), (BitSelector = assignment[1]), ({ = assignment[1][0]), (expr1 = assignment[1][1]), (} = assignment[1][2]), (= = assignment[2]), (expr2 = assignment[3]), (s = symbolTable), (Variable = variable), (registerType = variable[0]), (identifier = variable[1]), (intExpr = intExpr), (s1 = s1), (boolExpr = boolExpr), (s2 = s2)
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(assignment[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "intType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					Node node2 = Translate(assignment[3], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable s1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && s1 != null && s1.Name == "SymbolTable" && (s1.Count == 0 && true))
					{
						return new ListNode() { new IntegerAssignment() { assignment[0], assignment[2], intExpr }, symbolTable };
					}
				}
			// (Assignment = assignment), (id = assignment[0]), (BitSelector = assignment[1]), (EPSILON = assignment[1][0]), (= = assignment[2]), (expr = assignment[3]), (s = symbolTable), (Variable = variable), (intType = variable[0]), (identifier = variable[1]), (intExpr = intExpr), (s1 = s1)
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(assignment[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "registerType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					Node node2 = Translate(assignment[3], symbolTable);
					Compiler.AST.Data.RegisterExpression registerExpr = node2[0] as Compiler.AST.Data.RegisterExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(registerExpr != null && registerExpr.Name == "RegisterExpression" && (registerExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						return new ListNode() { new RegisterAssignment() { assignment[0], assignment[2], registerExpr }, symbolTable };
					}
				}
			// (Assignment = assignment), (id = assignment[0]), (BitSelector = assignment[1]), (EPSILON = assignment[1][0]), (= = assignment[2]), (expr = assignment[3]), (s = symbolTable), (Variable = variable), (registerType = variable[0]), (identifier = variable[1]), (registerExpr = registerExpr), (SymbolTable = symbolTable1)
			}
			if(assignment != null && assignment.Name == "Assignment" && (assignment.Count == 4 && assignment[0] != null && assignment[0].Name == "identifier" && (assignment[0].Count == 0 && true) && assignment[1] != null && assignment[1].Name == "BitSelector" && (assignment[1].Count == 1 && assignment[1][0] != null && assignment[1][0].Name == "EPSILON" && (assignment[1][0].Count == 0 && true)) && assignment[2] != null && assignment[2].Name == "=" && (assignment[2].Count == 0 && true) && assignment[3] != null && assignment[3].Name == "Expression" && (assignment[3].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(assignment[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "booleanType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					Node node2 = Translate(assignment[3], symbolTable);
					Compiler.AST.Data.BooleanExpression boolExpr = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						return new BooleanAssignment() { assignment[0], assignment[2], boolExpr };
					}
				}
			// (Assignment = assignment), (id = assignment[0]), (BitSelector = assignment[1]), (EPSILON = assignment[1][0]), (= = assignment[2]), (expr = assignment[3]), (s = symbolTable), (Variable = variable), (booleanType = variable[0]), (identifier = variable[1]), (boolExpr = boolExpr), (SymbolTable = symbolTable1)
			}
		}

		public Node Translate(Compiler.Parsing.Data.IfStatement ifStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && (ifStatement[0].Count == 0 && true) && ifStatement[1] != null && ifStatement[1].Name == "(" && (ifStatement[1].Count == 0 && true) && ifStatement[2] != null && ifStatement[2].Name == "Expression" && (ifStatement[2].Count == 0 && true) && ifStatement[3] != null && ifStatement[3].Name == ")" && (ifStatement[3].Count == 0 && true) && ifStatement[4] != null && ifStatement[4].Name == "indent" && (ifStatement[4].Count == 0 && true) && ifStatement[5] != null && ifStatement[5].Name == "Statements" && (ifStatement[5].Count == 0 && true) && ifStatement[6] != null && ifStatement[6].Name == "dedent" && (ifStatement[6].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(ifStatement[2], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(ifStatement[5], symbolTable);
					Compiler.AST.Data.Statement stm = node2[0] as Compiler.AST.Data.Statement;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { ifStatement, symbolTable };
					}
				}
			// (IfStatement = ifStatement), (if = ifStatement[0]), (( = ifStatement[1]), (expr = ifStatement[2]), () = ifStatement[3]), (indent = ifStatement[4]), (stms = ifStatement[5]), (dedent = ifStatement[6]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1), (stm = stm)
			}
		}

		public Node Translate(Compiler.Parsing.Data.WhileStatement whileStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && (whileStatement[0].Count == 0 && true) && whileStatement[1] != null && whileStatement[1].Name == "(" && (whileStatement[1].Count == 0 && true) && whileStatement[2] != null && whileStatement[2].Name == "Expression" && (whileStatement[2].Count == 0 && true) && whileStatement[3] != null && whileStatement[3].Name == ")" && (whileStatement[3].Count == 0 && true) && whileStatement[4] != null && whileStatement[4].Name == "indent" && (whileStatement[4].Count == 0 && true) && whileStatement[5] != null && whileStatement[5].Name == "Statements" && (whileStatement[5].Count == 0 && true) && whileStatement[6] != null && whileStatement[6].Name == "dedent" && (whileStatement[6].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(whileStatement[2], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(whileStatement[5], symbolTable);
					Compiler.AST.Data.Statement stm = node2[0] as Compiler.AST.Data.Statement;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(stm != null && stm.Name == "Statement" && (stm.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { whileStatement, symbolTable };
					}
				}
			// (WhileStatement = whileStatement), (while = whileStatement[0]), (( = whileStatement[1]), (expr = whileStatement[2]), () = whileStatement[3]), (indent = whileStatement[4]), (stms = whileStatement[5]), (dedent = whileStatement[6]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1), (stm = stm)
			}
		}

		public Node Translate(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(expression != null && expression.Name == "Expression" && (expression.Count == 1 && expression[0] != null && expression[0].Name == "OrExpression" && (expression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(expression[0], symbolTable);
				Undefined expr = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr, symbolTable };
				}
			// (Expression = expression), (orExpr = expression[0]), (s = symbolTable), (expr = expr), (SymbolTable = symbolTable1)
			}
		}

		public Node Translate(Compiler.Parsing.Data.OrExpression orExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && (orExpression[0].Count == 0 && true) && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 1 && orExpression[1][0] != null && orExpression[1][0].Name == "EPSILON" && (orExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(orExpression[0], symbolTable);
				Undefined expr = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr, symbolTable };
				}
			// (OrExpression = orExpression), (andExpr = orExpression[0]), (OrExpressionP = orExpression[1]), (EPSILON = orExpression[1][0]), (s = symbolTable), (expr = expr), (SymbolTable = symbolTable1)
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && (orExpression[0].Count == 0 && true) && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(orExpression[0], symbolTable);
				Compiler.AST.Data.BooleanExpression expr1 = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(orExpression[1], symbolTable);
					Compiler.AST.Data.BooleanAssignment expr2 = node2[0] as Compiler.AST.Data.BooleanAssignment;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr2 != null && expr2.Name == "BooleanAssignment" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr2, symbolTable };
					}
				}
			// (OrExpression = orExpression), (andExpr = orExpression[0]), (orExprP = orExpression[1]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1), (expr2 = expr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.OrExpressionP orExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && (orExpressionP[0].Count == 0 && true) && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && (orExpressionP[1].Count == 0 && true) && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 1 && orExpressionP[2][0] != null && orExpressionP[2][0].Name == "EPSILON" && (orExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(orExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression expr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr != null && expr.Name == "BooleanExpression" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new OrExpression() { new BooleanExpression(), orExpressionP[0], expr } }, symbolTable };
				}
			// (OrExpressionP = orExpressionP), (or = orExpressionP[0]), (andExpr = orExpressionP[1]), (EPSILON = orExpressionP[2][0]), (s = symbolTable), (expr = expr), (SymbolTable = symbolTable1)
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && (orExpressionP[0].Count == 0 && true) && orExpressionP[1] != null && orExpressionP[1].Name == "AddExpression" && (orExpressionP[1].Count == 0 && true) && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(orExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression expr1 = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(orExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression expr2 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr2 != null && expr2.Name == "BooleanExpression" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr2, symbolTable };
					}
				}
			// (OrExpressionP = orExpressionP), (or = orExpressionP[0]), (andExpr = orExpressionP[1]), (orExprP = orExpressionP[2]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1), (expr2 = expr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.AndExpression andExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && (andExpression[0].Count == 0 && true) && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 1 && andExpression[1][0] != null && andExpression[1][0].Name == "EPSILON" && (andExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(andExpression[0], symbolTable);
				Undefined expr = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr != null && expr.Name == "*" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr, symbolTable };
				}
			// (AndExpression = andExpression), (eqExpr = andExpression[0]), (AndExpressionP = andExpression[1]), (EPSILON = andExpression[1][0]), (s = symbolTable), (expr = expr), (SymbolTable = symbolTable1)
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && (andExpression[0].Count == 0 && true) && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(andExpression[0], symbolTable);
				Compiler.AST.Data.BooleanExpression expr1 = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(andExpression[1], symbolTable);
					Compiler.AST.Data.BooleanAssignment expr2 = node2[0] as Compiler.AST.Data.BooleanAssignment;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr2 != null && expr2.Name == "BooleanAssignment" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr2, symbolTable };
					}
				}
			// (AndExpression = andExpression), (eqExpr = andExpression[0]), (andExprP = andExpression[1]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1), (expr2 = expr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.AndExpressionP andExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && (andExpressionP[0].Count == 0 && true) && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && (andExpressionP[1].Count == 0 && true) && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 1 && andExpressionP[2][0] != null && andExpressionP[2][0].Name == "EPSILON" && (andExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(andExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression expr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr != null && expr.Name == "BooleanExpression" && (expr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new AndExpression() { new BooleanExpression(), andExpressionP[0], expr } }, symbolTable };
				}
			// (AndExpressionP = andExpressionP), (and = andExpressionP[0]), (eqExpr = andExpressionP[1]), (EPSILON = andExpressionP[2][0]), (s = symbolTable), (expr = expr), (SymbolTable = symbolTable1)
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && (andExpressionP[0].Count == 0 && true) && andExpressionP[1] != null && andExpressionP[1].Name == "AddExpression" && (andExpressionP[1].Count == 0 && true) && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(andExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression expr1 = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "BooleanExpression" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(andExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression expr2 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr2 != null && expr2.Name == "BooleanExpression" && (expr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr2, symbolTable };
					}
				}
			// (AndExpressionP = andExpressionP), (and = andExpressionP[0]), (eqExpr = andExpressionP[1]), (andExprP = andExpressionP[2]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1), (expr2 = expr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.EqExpression eqExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 1 && eqExpression[1][0] != null && eqExpression[1][0].Name == "EPSILON" && (eqExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpression[0], symbolTable);
				Undefined expr1 = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr1, symbolTable };
				}
			// (EqExpression = eqExpression), (expr = eqExpression[0]), (EqExpressionP = eqExpression[1]), (EPSILON = eqExpression[1][0]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1)
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpression[0], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(eqExpression[1], symbolTable);
					Compiler.AST.Data.BooleanExpression expr3 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr3, symbolTable };
					}
				}
			// (EqExpression = eqExpression), (expr1 = eqExpression[0]), (expr2 = eqExpression[1]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1), (expr3 = expr3)
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && (eqExpression[0].Count == 0 && true) && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpression[0], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(eqExpression[1], symbolTable);
					Compiler.AST.Data.BooleanExpression expr3 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr3, symbolTable };
					}
				}
			// (EqExpression = eqExpression), (expr1 = eqExpression[0]), (expr2 = eqExpression[1]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1), (expr3 = expr3)
			}
		}

		public Node Translate(Compiler.Parsing.Data.EqExpressionP eqExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && (eqExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new IntegerEqExpression() { new IntegerExpression(), eqExpressionP[0], intExpr } }, symbolTable };
				}
			// (EqExpressionP = eqExpressionP), (== = eqExpressionP[0]), (expr = eqExpressionP[1]), (EPSILON = eqExpressionP[2][0]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON" && (eqExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new BooleanEqExpression() { new BooleanExpression(), eqExpressionP[0], boolExpr } }, symbolTable };
				}
			// (EqExpressionP = eqExpressionP), (== = eqExpressionP[0]), (expr = eqExpressionP[1]), (EPSILON = eqExpressionP[2][0]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1)
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(eqExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression expr3 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr3, symbolTable };
					}
				}
			// (EqExpressionP = eqExpressionP), (== = eqExpressionP[0]), (expr1 = eqExpressionP[1]), (expr2 = eqExpressionP[2]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1), (expr3 = expr3)
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && (eqExpressionP[0].Count == 0 && true) && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && (eqExpressionP[1].Count == 0 && true) && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(eqExpressionP[1], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(eqExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression expr3 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr3, symbolTable };
					}
				}
			// (EqExpressionP = eqExpressionP), (== = eqExpressionP[0]), (expr1 = eqExpressionP[1]), (expr2 = eqExpressionP[2]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1), (expr3 = expr3)
			}
		}

		public Node Translate(Compiler.Parsing.Data.RelationalExpression relationalExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && (relationalExpression[0].Count == 0 && true) && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 1 && relationalExpression[1][0] != null && relationalExpression[1][0].Name == "EPSILON" && (relationalExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpression[0], symbolTable);
				Undefined expr1 = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr1, symbolTable };
				}
			// (RelationalExpression = relationalExpression), (expr = relationalExpression[0]), (RelationalExpressionP = relationalExpression[1]), (EPSILON = relationalExpression[1][0]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1)
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && (relationalExpression[0].Count == 0 && true) && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpression[0], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(relationalExpression[1], symbolTable);
					Compiler.AST.Data.BooleanExpression expr3 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(expr3 != null && expr3.Name == "BooleanExpression" && (expr3.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { expr3, symbolTable };
					}
				}
			// (RelationalExpression = relationalExpression), (expr1 = relationalExpression[0]), (expr2 = relationalExpression[1]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1), (expr3 = expr3)
			}
		}

		public Node Translate(Compiler.Parsing.Data.RelationalExpressionP relationalExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && (relationalExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new LessThanExpression() { new IntegerExpression(), relationalExpressionP[0], intExpr } }, symbolTable };
				}
			// (RelationalExpressionP = relationalExpressionP), (< = relationalExpressionP[0]), (expr1 = relationalExpressionP[1]), (EPSILON = relationalExpressionP[2][0]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON" && (relationalExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { new GreaterThanExpression() { new IntegerExpression(), relationalExpressionP[0], intExpr } }, symbolTable };
				}
			// (RelationalExpressionP = relationalExpressionP), (> = relationalExpressionP[0]), (expr1 = relationalExpressionP[1]), (EPSILON = relationalExpressionP[2][0]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(relationalExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression boolExpr = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { new expr3(), symbolTable };
					}
				}
			// (RelationalExpressionP = relationalExpressionP), (< = relationalExpressionP[0]), (expr1 = relationalExpressionP[1]), (expr2 = relationalExpressionP[2]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1), (boolExpr = boolExpr)
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && (relationalExpressionP[0].Count == 0 && true) && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && (relationalExpressionP[1].Count == 0 && true) && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(relationalExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(relationalExpressionP[2], symbolTable);
					Compiler.AST.Data.BooleanExpression boolExpr = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { new expr3(), symbolTable };
					}
				}
			// (RelationalExpressionP = relationalExpressionP), (> = relationalExpressionP[0]), (expr1 = relationalExpressionP[1]), (expr2 = relationalExpressionP[2]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1), (boolExpr = boolExpr)
			}
		}

		public Node Translate(Compiler.Parsing.Data.AddSubExpression addSubExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && (addSubExpression[0].Count == 0 && true) && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 1 && addSubExpression[1][0] != null && addSubExpression[1][0].Name == "EPSILON" && (addSubExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpression[0], symbolTable);
				Undefined expr1 = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr1, symbolTable };
				}
			// (AddSubExpression = addSubExpression), (expr = addSubExpression[0]), (AddSubExpressionP = addSubExpression[1]), (EPSILON = addSubExpression[1][0]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1)
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && (addSubExpression[0].Count == 0 && true) && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpression[0], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(addSubExpression[1], symbolTable);
					Compiler.AST.Data.BooleanExpression intExpr2 = node2[0] as Compiler.AST.Data.BooleanExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "BooleanExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (AddSubExpression = addSubExpression), (expr1 = addSubExpression[0]), (expr2 = addSubExpression[1]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.AddSubExpressionP addSubExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && (addSubExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new IntegerExpression() { new AddExpression() { new IntegerExpression(), addSubExpressionP[0], intExpr1 } }, symbolTable };
				}
			// (AddSubExpressionP = addSubExpressionP), (+ = addSubExpressionP[0]), (expr1 = addSubExpressionP[1]), (EPSILON = addSubExpressionP[2][0]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1)
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON" && (addSubExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new IntegerExpression() { new SubExpression() { new IntegerExpression(), addSubExpressionP[0], intExpr1 } }, symbolTable };
				}
			// (AddSubExpressionP = addSubExpressionP), (- = addSubExpressionP[0]), (expr1 = addSubExpressionP[1]), (EPSILON = addSubExpressionP[2][0]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1)
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(addSubExpressionP[2], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (AddSubExpressionP = addSubExpressionP), (+ = addSubExpressionP[0]), (expr1 = addSubExpressionP[1]), (expr2 = addSubExpressionP[2]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && (addSubExpressionP[0].Count == 0 && true) && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && (addSubExpressionP[1].Count == 0 && true) && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(addSubExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(addSubExpressionP[2], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (AddSubExpressionP = addSubExpressionP), (- = addSubExpressionP[0]), (expr1 = addSubExpressionP[1]), (expr2 = addSubExpressionP[2]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.MulDivExpression mulDivExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PrimaryExpression" && (mulDivExpression[0].Count == 0 && true) && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 1 && mulDivExpression[1][0] != null && mulDivExpression[1][0].Name == "EPSILON" && (mulDivExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpression[0], symbolTable);
				Undefined expr1 = node1[0] as Undefined;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(expr1 != null && expr1.Name == "*" && (expr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { expr1, symbolTable };
				}
			// (MulDivExpression = mulDivExpression), (expr = mulDivExpression[0]), (MulDivExpressionP = mulDivExpression[1]), (EPSILON = mulDivExpression[1][0]), (s = symbolTable), (expr1 = expr1), (SymbolTable = symbolTable1)
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PrimaryExpression" && (mulDivExpression[0].Count == 0 && true) && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpression[0], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(mulDivExpression[1], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (MulDivExpression = mulDivExpression), (expr1 = mulDivExpression[0]), (expr2 = mulDivExpression[1]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.MulDivExpressionP mulDivExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && (mulDivExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new IntegerExpression() { new MulExpression() { new IntegerExpression(), mulDivExpressionP[0], intExpr1 } }, symbolTable };
				}
			// (MulDivExpressionP = mulDivExpressionP), (* = mulDivExpressionP[0]), (expr1 = mulDivExpressionP[1]), (EPSILON = mulDivExpressionP[2][0]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1)
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON" && (mulDivExpressionP[2][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new IntegerExpression() { new DivExpression() { new IntegerExpression(), mulDivExpressionP[0], intExpr1 } }, symbolTable };
				}
			// (MulDivExpressionP = mulDivExpressionP), (/ = mulDivExpressionP[0]), (expr1 = mulDivExpressionP[1]), (EPSILON = mulDivExpressionP[2][0]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1)
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(mulDivExpressionP[2], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (MulDivExpressionP = mulDivExpressionP), (* = mulDivExpressionP[0]), (expr1 = mulDivExpressionP[1]), (expr2 = mulDivExpressionP[2]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && (mulDivExpressionP[0].Count == 0 && true) && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PrimaryExpression" && (mulDivExpressionP[1].Count == 0 && true) && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(mulDivExpressionP[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(mulDivExpressionP[2], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { intExpr2, symbolTable };
					}
				}
			// (MulDivExpressionP = mulDivExpressionP), (/ = mulDivExpressionP[0]), (expr1 = mulDivExpressionP[1]), (expr2 = mulDivExpressionP[2]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
		}

		public Node Translate(Compiler.Parsing.Data.PrimaryExpression primaryExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "intLiteral" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return new ListNode() { new IntegerExpression() { primaryExpression[0] }, symbolTable };
			// (PrimaryExpression = primaryExpression), (intLiteral = primaryExpression[0]), (s = symbolTable)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "intType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					return new ListNode() { new IntegerExpression() { new IntegerVariable() { primaryExpression[0] } }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (id = primaryExpression[0]), (BitSelector = primaryExpression[1]), (EPSILON = primaryExpression[1][0]), (s = symbolTable), (Variable = variable), (intType = variable[0]), (identifier = variable[1])
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "registerType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					return new ListNode() { new RegisterExpression() { new RegisterVariable() { primaryExpression[0] } }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (id = primaryExpression[0]), (BitSelector = primaryExpression[1]), (EPSILON = primaryExpression[1][0]), (s = symbolTable), (Variable = variable), (registerType = variable[0]), (identifier = variable[1])
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "EPSILON" && (primaryExpression[1][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "booleanType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					return new ListNode() { new BooleanExpression() { new BooleanVariable() { primaryExpression[0] } }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (id = primaryExpression[0]), (BitSelector = primaryExpression[1]), (EPSILON = primaryExpression[1][0]), (s = symbolTable), (Variable = variable), (booleanType = variable[0]), (identifier = variable[1])
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "BitSelector" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "{" && (primaryExpression[1][0].Count == 0 && true) && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "Expression" && (primaryExpression[1][1].Count == 0 && true) && primaryExpression[1][2] != null && primaryExpression[1][2].Name == "}" && (primaryExpression[1][2].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[0], symbolTable);
				Compiler.Translation.SymbolTable.Data.Variable variable = node1 as Compiler.Translation.SymbolTable.Data.Variable;
				if(variable != null && variable.Name == "Variable" && (variable.Count == 2 && variable[0] != null && variable[0].Name == "registerType" && (variable[0].Count == 0 && true) && variable[1] != null && variable[1].Name == "identifier" && (variable[1].Count == 0 && true)))
				{
					Node node2 = Translate(primaryExpression[1][1], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
					{
						return new ListNode() { new BooleanExpression() { new IndirectBitValue() { primaryExpression[0], primaryExpression[1][0], intExpr, primaryExpression[1][2] } }, symbolTable };
					}
				}
			// (PrimaryExpression = primaryExpression), (id = primaryExpression[0]), (BitSelector = primaryExpression[1]), ({ = primaryExpression[1][0]), (expr = primaryExpression[1][1]), (} = primaryExpression[1][2]), (s = symbolTable), (Variable = variable), (registerType = variable[0]), (identifier = variable[1]), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == ")" && (primaryExpression[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[1], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new IntegerExpression() { primaryExpression[0], intExpr, primaryExpression[2] }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (( = primaryExpression[0]), (expr = primaryExpression[1]), () = primaryExpression[2]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == ")" && (primaryExpression[2].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[1], symbolTable);
				Compiler.AST.Data.BooleanExpression boolExpr = node1[0] as Compiler.AST.Data.BooleanExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(boolExpr != null && boolExpr.Name == "BooleanExpression" && (boolExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new BooleanExpression() { primaryExpression[0], boolExpr, primaryExpression[2] }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (( = primaryExpression[0]), (expr = primaryExpression[1]), () = primaryExpression[2]), (s = symbolTable), (boolExpr = boolExpr), (SymbolTable = symbolTable1)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "registerType" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "(" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && (primaryExpression[2].Count == 0 && true) && primaryExpression[3] != null && primaryExpression[3].Name == ")" && (primaryExpression[3].Count == 0 && true) && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 1 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "EPSILON" && (primaryExpression[4][0].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[2], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr != null && intExpr.Name == "IntegerExpression" && (intExpr.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					return new ListNode() { new RegisterExpression() { new RegisterLiteral() { primaryExpression[0], primaryExpression[1], intExpr, primaryExpression[3] } }, symbolTable };
				}
			// (PrimaryExpression = primaryExpression), (registerType = primaryExpression[0]), (( = primaryExpression[1]), (expr = primaryExpression[2]), () = primaryExpression[3]), (BitSelector = primaryExpression[4]), (EPSILON = primaryExpression[4][0]), (s = symbolTable), (intExpr = intExpr), (SymbolTable = symbolTable1)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "registerType" && (primaryExpression[0].Count == 0 && true) && primaryExpression[1] != null && primaryExpression[1].Name == "(" && (primaryExpression[1].Count == 0 && true) && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && (primaryExpression[2].Count == 0 && true) && primaryExpression[3] != null && primaryExpression[3].Name == ")" && (primaryExpression[3].Count == 0 && true) && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 3 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "{" && (primaryExpression[4][0].Count == 0 && true) && primaryExpression[4][1] != null && primaryExpression[4][1].Name == "Expression" && (primaryExpression[4][1].Count == 0 && true) && primaryExpression[4][2] != null && primaryExpression[4][2].Name == "}" && (primaryExpression[4][2].Count == 0 && true))) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				Node node1 = Translate(primaryExpression[2], symbolTable);
				Compiler.AST.Data.IntegerExpression intExpr1 = node1[0] as Compiler.AST.Data.IntegerExpression;
				Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable1 = node1[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
				if(intExpr1 != null && intExpr1.Name == "IntegerExpression" && (intExpr1.Count == 0 && true) && symbolTable1 != null && symbolTable1.Name == "SymbolTable" && (symbolTable1.Count == 0 && true))
				{
					Node node2 = Translate(primaryExpression[4][1], symbolTable);
					Compiler.AST.Data.IntegerExpression intExpr2 = node2[0] as Compiler.AST.Data.IntegerExpression;
					Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable2 = node2[1] as Compiler.Translation.SymbolTable.Data.SymbolTable;
					if(intExpr2 != null && intExpr2.Name == "IntegerExpression" && (intExpr2.Count == 0 && true) && symbolTable2 != null && symbolTable2.Name == "SymbolTable" && (symbolTable2.Count == 0 && true))
					{
						return new ListNode() { new BooleanExpression() { new DirectBitValue() { primaryExpression[0], primaryExpression[1], intExpr1, primaryExpression[3], primaryExpression[4][0], intExpr2, primaryExpression[4][2] } }, symbolTable };
					}
				}
			// (PrimaryExpression = primaryExpression), (registerType = primaryExpression[0]), (( = primaryExpression[1]), (expr1 = primaryExpression[2]), () = primaryExpression[3]), (BitSelector = primaryExpression[4]), ({ = primaryExpression[4][0]), (expr2 = primaryExpression[4][1]), (} = primaryExpression[4][2]), (s = symbolTable), (intExpr1 = intExpr1), (SymbolTable = symbolTable1), (intExpr2 = intExpr2)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "true" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return new ListNode() { new BooleanExpression() { primaryExpression[0] }, symbolTable };
			// (PrimaryExpression = primaryExpression), (true = primaryExpression[0]), (s = symbolTable)
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "false" && (primaryExpression[0].Count == 0 && true)) && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 0 && true))
			{
				return new ListNode() { new BooleanExpression() { primaryExpression[0] }, symbolTable };
			// (PrimaryExpression = primaryExpression), (false = primaryExpression[0]), (s = symbolTable)
			}
		}
	}
}
