namespace Compiler.Translation.ASTToC
{
	public class ASTToCTranslator 
	{
		public int Translate__aST = 0;
		public int Translatea__globalStatement_globalDeclarations_functions_statement = 0;
		public int Translatea__compoundGlobalStatement_globalDeclarations_functions_statement = 0;
		public int Translatea__interrupt_globalDeclarations_functions_statement = 0;
		public int Translatea__statement_globalDeclarations_functions_statement1 = 0;
		public int Translatea__compoundStatement_globalDeclarations_functions_statement = 0;
		public int Translate__integerDeclaration = 0;
		public int Translate__integerAssignment = 0;
		public int Translate__booleanDeclaration = 0;
		public int Translate__booleanAssignment = 0;
		public int Translate__directBitAssignment = 0;
		public int Translate__indirectBitAssignment = 0;
		public int Translate__registerDeclaration = 0;
		public int Translate__registerAssignment = 0;
		public int Translate__registerExpression = 0;
		public int Translate__registerLiteral = 0;
		public int Translate__registerVariable = 0;
		public int Translatea__ifStatement_globalDeclarations_functions_statement = 0;
		public int Translatea__whileStatement_globalDeclarations_functions_statement = 0;
		public int Translate__integerExpression = 0;
		public int Translate__integerVariable = 0;
		public int Translate__integerParenthesisExpression = 0;
		public int Translate__addExpression = 0;
		public int Translate__subExpression = 0;
		public int Translate__mulExpression = 0;
		public int Translate__divExpression = 0;
		public int Translate__booleanExpression = 0;
		public int Translate__booleanVariable = 0;
		public int Translate__directBitValue = 0;
		public int Translate__indirectBitValue = 0;
		public int Translate__booleanParenthesisExpression = 0;
		public int Translate__integerEqExpression = 0;
		public int Translate__booleanEqExpression = 0;
		public int Translate__lessThanExpression = 0;
		public int Translate__greaterThanExpression = 0;
		public int Translate__notExpression = 0;
		public int Translate__andExpression = 0;
		public int Translate__orExpression = 0;
		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AST aST)
		{
			Translate__aST++;
			if(aST != null && aST.Name == "AST" && (aST.Count == 2 && aST[0] != null && aST[0].Name == "GlobalStatement" && true && aST[1] != null && aST[1].Name == "eof" && true))
			{
				(Compiler.C.Data.Node gd, Compiler.C.Data.Node f, Compiler.C.Data.Node s) = Translatea(aST[0] as Compiler.AST.Data.GlobalStatement, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Functions(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
				if(gd != null && gd.Name == "GlobalDeclarations" && true && f != null && f.Name == "Functions" && true && s != null && s.Name == "Statement" && true)
				{
					return new Compiler.C.Data.C(false) { gd as Compiler.C.Data.GlobalDeclarations, Insert(f as Compiler.C.Data.Functions, new Compiler.C.Data.Functions(false) { new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = "main", Value = "main" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, s as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } }, new Compiler.C.Data.Functions(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.Functions };
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.GlobalStatement globalStatement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__globalStatement_globalDeclarations_functions_statement++;
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd1 != null && gd1.Name == "GlobalDeclarations" && true && f1 != null && f1.Name == "Functions" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (gd1 as Compiler.C.Data.GlobalDeclarations, f1 as Compiler.C.Data.Functions, s1 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.Interrupt, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd1 != null && gd1.Name == "GlobalDeclarations" && true && f1 != null && f1.Name == "Functions" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (gd1 as Compiler.C.Data.GlobalDeclarations, f1 as Compiler.C.Data.Functions, s1 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(globalStatement[0] as Compiler.AST.Data.Statement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && s2 != null && s2.Name == "Statement" && true)
				{
					return (gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, s2 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd1 != null && gd1.Name == "GlobalDeclarations" && true && f1 != null && f1.Name == "Functions" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (gd1 as Compiler.C.Data.GlobalDeclarations, f1 as Compiler.C.Data.Functions, s1 as Compiler.C.Data.Statement);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundGlobalStatement compoundGlobalStatement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__compoundGlobalStatement_globalDeclarations_functions_statement++;
			if(compoundGlobalStatement != null && compoundGlobalStatement.Name == "CompoundGlobalStatement" && (compoundGlobalStatement.Count == 3 && compoundGlobalStatement[0] != null && compoundGlobalStatement[0].Name == "GlobalStatement" && true && compoundGlobalStatement[1] != null && compoundGlobalStatement[1].Name == "newline" && true && compoundGlobalStatement[2] != null && compoundGlobalStatement[2].Name == "GlobalStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(compoundGlobalStatement[0] as Compiler.AST.Data.GlobalStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd1 != null && gd1.Name == "GlobalDeclarations" && true && f1 != null && f1.Name == "Functions" && true && s1 != null && s1.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(compoundGlobalStatement[2] as Compiler.AST.Data.GlobalStatement, gd1 as Compiler.C.Data.GlobalDeclarations, f1 as Compiler.C.Data.Functions, s1 as Compiler.C.Data.Statement);
					if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && s2 != null && s2.Name == "Statement" && true)
					{
						return (gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, s2 as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Interrupt interrupt, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__interrupt_globalDeclarations_functions_statement++;
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && true && interrupt[1] != null && interrupt[1].Name == "(" && true && interrupt[2] != null && interrupt[2].Name == "intLiteral" && true && interrupt[3] != null && interrupt[3].Name == ")" && true && interrupt[4] != null && interrupt[4].Name == "indent" && true && interrupt[5] != null && interrupt[5].Name == "Statement" && true && interrupt[6] != null && interrupt[6].Name == "dedent" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node i1 = Translate(interrupt[2] as Compiler.AST.Data.Token);
				if(i1 != null && i1.Name == "intLiteral" && true)
				{
					(Compiler.C.Data.Node gs1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si2) = Translatea(interrupt[5] as Compiler.AST.Data.Statement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
					if(gs1 != null && gs1.Name == "GlobalDeclarations" && true && f1 != null && f1.Name == "Functions" && true && si2 != null && si2.Name == "Statement" && true)
					{
						return (Insert(globalDeclarations as Compiler.C.Data.GlobalDeclarations, new Compiler.C.Data.GlobalDeclarations(false) { new Compiler.C.Data.GlobalDeclaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = "__vector_21", Value = "__vector_21" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } }, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.GlobalDeclarations, Insert(functions as Compiler.C.Data.Functions, new Compiler.C.Data.Functions(false) { new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = "__vector_21", Value = "__vector_21" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "void", Value = "void" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, si2 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } }, new Compiler.C.Data.Functions(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Statement statement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement1)
		{
			Translatea__statement_globalDeclarations_functions_statement1++;
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "EPSILON" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "CompoundStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.CompoundStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerDeclaration" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerDeclaration);
				if(s1 != null && s1.Name == "IntegerDeclaration" && true)
				{
					return (Insert(globalDeclarations as Compiler.C.Data.GlobalDeclarations, new Compiler.C.Data.GlobalDeclarations(false) { new Compiler.C.Data.GlobalDeclaration(false) { s1 as Compiler.C.Data.IntegerDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanDeclaration" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanDeclaration);
				if(s1 != null && s1.Name == "BooleanDeclaration" && true)
				{
					return (Insert(globalDeclarations as Compiler.C.Data.GlobalDeclarations, new Compiler.C.Data.GlobalDeclarations(false) { new Compiler.C.Data.GlobalDeclaration(false) { s1 as Compiler.C.Data.BooleanDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterDeclaration" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterDeclaration);
				if(s1 != null && s1.Name == "RegisterDeclaration" && true)
				{
					return (Insert(globalDeclarations as Compiler.C.Data.GlobalDeclarations, new Compiler.C.Data.GlobalDeclarations(false) { new Compiler.C.Data.GlobalDeclaration(false) { s1 as Compiler.C.Data.RegisterDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "DirectBitAssignment" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.DirectBitAssignment);
				if(s1 != null && s1.Name == "DirectBitAssignment" && true)
				{
					return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.DirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IndirectBitAssignment" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IndirectBitAssignment);
				if(s1 != null && s1.Name == "IndirectBitAssignment" && true)
				{
					return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IndirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerAssignment" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerAssignment);
				if(s1 != null && s1.Name == "IntegerAssignment" && true)
				{
					return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IntegerAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanAssignment" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanAssignment);
				if(s1 != null && s1.Name == "BooleanAssignment" && true)
				{
					return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.BooleanAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterAssignment" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterAssignment);
				if(s1 != null && s1.Name == "RegisterAssignment" && true)
				{
					return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.RegisterAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.WhileStatement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement1 as Compiler.C.Data.Statement);
				if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, si2 as Compiler.C.Data.Statement);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundStatement compoundStatement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__compoundStatement_globalDeclarations_functions_statement++;
			if(compoundStatement != null && compoundStatement.Name == "CompoundStatement" && (compoundStatement.Count == 3 && compoundStatement[0] != null && compoundStatement[0].Name == "Statement" && true && compoundStatement[1] != null && compoundStatement[1].Name == "newline" && true && compoundStatement[2] != null && compoundStatement[2].Name == "Statement" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node gd2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(compoundStatement[0] as Compiler.AST.Data.Statement, globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, statement as Compiler.C.Data.Statement);
				if(gd2 != null && gd2.Name == "GlobalDeclarations" && true && f2 != null && f2.Name == "Functions" && true && si2 != null && si2.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node gd3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(compoundStatement[2] as Compiler.AST.Data.Statement, gd2 as Compiler.C.Data.GlobalDeclarations, f2 as Compiler.C.Data.Functions, si2 as Compiler.C.Data.Statement);
					if(gd3 != null && gd3.Name == "GlobalDeclarations" && true && f3 != null && f3.Name == "Functions" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (gd3 as Compiler.C.Data.GlobalDeclarations, f3 as Compiler.C.Data.Functions, si3 as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerDeclaration integerDeclaration)
		{
			Translate__integerDeclaration++;
			if(integerDeclaration != null && integerDeclaration.Name == "IntegerDeclaration" && (integerDeclaration.Count == 2 && integerDeclaration[0] != null && integerDeclaration[0].Name == "intType" && true && integerDeclaration[1] != null && integerDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(integerDeclaration[1] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.IntegerDeclaration(false) { new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "int", Value = "int" }, id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerAssignment integerAssignment)
		{
			Translate__integerAssignment++;
			if(integerAssignment != null && integerAssignment.Name == "IntegerAssignment" && (integerAssignment.Count == 3 && integerAssignment[0] != null && integerAssignment[0].Name == "identifier" && true && integerAssignment[1] != null && integerAssignment[1].Name == "=" && true && integerAssignment[2] != null && integerAssignment[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node id1 = Translate(integerAssignment[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node iexpr1 = Translate(integerAssignment[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.IntegerAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, iexpr1 as Compiler.C.Data.IntegerExpression };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanDeclaration booleanDeclaration)
		{
			Translate__booleanDeclaration++;
			if(booleanDeclaration != null && booleanDeclaration.Name == "BooleanDeclaration" && (booleanDeclaration.Count == 2 && booleanDeclaration[0] != null && booleanDeclaration[0].Name == "booleanType" && true && booleanDeclaration[1] != null && booleanDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(booleanDeclaration[1] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.BooleanDeclaration(false) { new Compiler.C.Data.Token() { Name = "char", Value = "char" }, id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanAssignment booleanAssignment)
		{
			Translate__booleanAssignment++;
			if(booleanAssignment != null && booleanAssignment.Name == "BooleanAssignment" && (booleanAssignment.Count == 3 && booleanAssignment[0] != null && booleanAssignment[0].Name == "identifier" && true && booleanAssignment[1] != null && booleanAssignment[1].Name == "=" && true && booleanAssignment[2] != null && booleanAssignment[2].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node id1 = Translate(booleanAssignment[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node bexpr1 = Translate(booleanAssignment[2] as Compiler.AST.Data.BooleanExpression);
					if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
					{
						return new Compiler.C.Data.BooleanAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, bexpr1 as Compiler.C.Data.BooleanExpression };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DirectBitAssignment directBitAssignment)
		{
			Translate__directBitAssignment++;
			if(directBitAssignment != null && directBitAssignment.Name == "DirectBitAssignment" && (directBitAssignment.Count == 9 && directBitAssignment[0] != null && directBitAssignment[0].Name == "registerType" && true && directBitAssignment[1] != null && directBitAssignment[1].Name == "(" && true && directBitAssignment[2] != null && directBitAssignment[2].Name == "IntegerExpression" && true && directBitAssignment[3] != null && directBitAssignment[3].Name == ")" && true && directBitAssignment[4] != null && directBitAssignment[4].Name == "{" && true && directBitAssignment[5] != null && directBitAssignment[5].Name == "IntegerExpression" && true && directBitAssignment[6] != null && directBitAssignment[6].Name == "}" && true && directBitAssignment[7] != null && directBitAssignment[7].Name == "=" && true && directBitAssignment[8] != null && directBitAssignment[8].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node iexpr1 = Translate(directBitAssignment[2] as Compiler.AST.Data.IntegerExpression);
				if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr2 = Translate(directBitAssignment[5] as Compiler.AST.Data.IntegerExpression);
					if(iexpr2 != null && iexpr2.Name == "IntegerExpression" && true)
					{
						Compiler.C.Data.Node bexpr1 = Translate(directBitAssignment[8] as Compiler.AST.Data.BooleanExpression);
						if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
						{
							return new Compiler.C.Data.DirectBitAssignment(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "|", Value = "|" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "~", Value = "~" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IndirectBitAssignment indirectBitAssignment)
		{
			Translate__indirectBitAssignment++;
			if(indirectBitAssignment != null && indirectBitAssignment.Name == "IndirectBitAssignment" && (indirectBitAssignment.Count == 6 && indirectBitAssignment[0] != null && indirectBitAssignment[0].Name == "identifier" && true && indirectBitAssignment[1] != null && indirectBitAssignment[1].Name == "{" && true && indirectBitAssignment[2] != null && indirectBitAssignment[2].Name == "IntegerExpression" && true && indirectBitAssignment[3] != null && indirectBitAssignment[3].Name == "}" && true && indirectBitAssignment[4] != null && indirectBitAssignment[4].Name == "=" && true && indirectBitAssignment[5] != null && indirectBitAssignment[5].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node id1 = Translate(indirectBitAssignment[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node iexpr1 = Translate(indirectBitAssignment[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
					{
						Compiler.C.Data.Node bexpr1 = Translate(indirectBitAssignment[5] as Compiler.AST.Data.BooleanExpression);
						if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
						{
							return new Compiler.C.Data.IndirectBitAssignment(false) { new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "|", Value = "|" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "~", Value = "~" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterDeclaration registerDeclaration)
		{
			Translate__registerDeclaration++;
			if(registerDeclaration != null && registerDeclaration.Name == "RegisterDeclaration" && (registerDeclaration.Count == 2 && registerDeclaration[0] != null && registerDeclaration[0].Name == "registerType" && true && registerDeclaration[1] != null && registerDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(registerDeclaration[1] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.RegisterDeclaration(false) { new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterAssignment registerAssignment)
		{
			Translate__registerAssignment++;
			if(registerAssignment != null && registerAssignment.Name == "RegisterAssignment" && (registerAssignment.Count == 3 && registerAssignment[0] != null && registerAssignment[0].Name == "identifier" && true && registerAssignment[1] != null && registerAssignment[1].Name == "=" && true && registerAssignment[2] != null && registerAssignment[2].Name == "RegisterExpression" && true))
			{
				Compiler.C.Data.Node id1 = Translate(registerAssignment[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node rexpr1 = Translate(registerAssignment[2] as Compiler.AST.Data.RegisterExpression);
					if(rexpr1 != null && rexpr1.Name == "RegisterExpression" && true)
					{
						return new Compiler.C.Data.RegisterAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, rexpr1 as Compiler.C.Data.RegisterExpression };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterExpression registerExpression)
		{
			Translate__registerExpression++;
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "RegisterLiteral" && true))
			{
				Compiler.C.Data.Node rlit1 = Translate(registerExpression[0] as Compiler.AST.Data.RegisterLiteral);
				if(rlit1 != null && rlit1.Name == "RegisterLiteral" && true)
				{
					return new Compiler.C.Data.RegisterExpression(false) { rlit1 as Compiler.C.Data.RegisterLiteral };
				}
			}
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "RegisterVariable" && true))
			{
				Compiler.C.Data.Node rvar1 = Translate(registerExpression[0] as Compiler.AST.Data.RegisterVariable);
				if(rvar1 != null && rvar1.Name == "RegisterVariable" && true)
				{
					return new Compiler.C.Data.RegisterExpression(false) { rvar1 as Compiler.C.Data.RegisterVariable };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterLiteral registerLiteral)
		{
			Translate__registerLiteral++;
			if(registerLiteral != null && registerLiteral.Name == "RegisterLiteral" && (registerLiteral.Count == 4 && registerLiteral[0] != null && registerLiteral[0].Name == "registerType" && true && registerLiteral[1] != null && registerLiteral[1].Name == "(" && true && registerLiteral[2] != null && registerLiteral[2].Name == "IntegerExpression" && true && registerLiteral[3] != null && registerLiteral[3].Name == ")" && true))
			{
				Compiler.C.Data.Node iexpr1 = Translate(registerLiteral[2] as Compiler.AST.Data.IntegerExpression);
				if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
				{
					return new Compiler.C.Data.RegisterLiteral(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterVariable registerVariable)
		{
			Translate__registerVariable++;
			if(registerVariable != null && registerVariable.Name == "RegisterVariable" && (registerVariable.Count == 1 && registerVariable[0] != null && registerVariable[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(registerVariable[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.RegisterVariable(false) { id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfStatement ifStatement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__ifStatement_globalDeclarations_functions_statement++;
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && true && ifStatement[1] != null && ifStatement[1].Name == "(" && true && ifStatement[2] != null && ifStatement[2].Name == "BooleanExpression" && true && ifStatement[3] != null && ifStatement[3].Name == ")" && true && ifStatement[4] != null && ifStatement[4].Name == "indent" && true && ifStatement[5] != null && ifStatement[5].Name == "Statement" && true && ifStatement[6] != null && ifStatement[6].Name == "dedent" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bexpr1 = Translate(ifStatement[2] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					(Compiler.C.Data.Node gd3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Functions(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(gd3 != null && gd3.Name == "GlobalDeclarations" && true && f3 != null && f3.Name == "Functions" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, gd3 as Compiler.C.Data.GlobalDeclarations, Insert(si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }) as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.WhileStatement whileStatement, Compiler.C.Data.GlobalDeclarations globalDeclarations, Compiler.C.Data.Functions functions, Compiler.C.Data.Statement statement)
		{
			Translatea__whileStatement_globalDeclarations_functions_statement++;
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && true && whileStatement[1] != null && whileStatement[1].Name == "(" && true && whileStatement[2] != null && whileStatement[2].Name == "BooleanExpression" && true && whileStatement[3] != null && whileStatement[3].Name == ")" && true && whileStatement[4] != null && whileStatement[4].Name == "indent" && true && whileStatement[5] != null && whileStatement[5].Name == "Statement" && true && whileStatement[6] != null && whileStatement[6].Name == "dedent" && true) && globalDeclarations != null && globalDeclarations.Name == "GlobalDeclarations" && true && functions != null && functions.Name == "Functions" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bexpr1 = Translate(whileStatement[2] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					(Compiler.C.Data.Node gd3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(whileStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.GlobalDeclarations(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Functions(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(gd3 != null && gd3.Name == "GlobalDeclarations" && true && f3 != null && f3.Name == "Functions" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (globalDeclarations as Compiler.C.Data.GlobalDeclarations, functions as Compiler.C.Data.Functions, Insert(statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { new Compiler.C.Data.Statement(false) { new Compiler.C.Data.WhileStatement(false) { new Compiler.C.Data.Token() { Name = "while", Value = "while" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, gd3 as Compiler.C.Data.GlobalDeclarations, Insert(si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }) as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } }, new Compiler.C.Data.Statement(true) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } } }) as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerExpression integerExpression)
		{
			Translate__integerExpression++;
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "IntegerVariable" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.IntegerVariable);
				if(s1 != null && s1.Name == "IntegerVariable" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.IntegerVariable };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "IntegerParenthesisExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.IntegerParenthesisExpression);
				if(s1 != null && s1.Name == "IntegerParenthesisExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.IntegerParenthesisExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "AddExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.AddExpression);
				if(s1 != null && s1.Name == "AddExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.AddExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "SubExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.SubExpression);
				if(s1 != null && s1.Name == "SubExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.SubExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "MulExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.MulExpression);
				if(s1 != null && s1.Name == "MulExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.MulExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "DivExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.DivExpression);
				if(s1 != null && s1.Name == "DivExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.DivExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "intLiteral" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.Token);
				if(s1 != null && s1.Name == "intLiteral" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerVariable integerVariable)
		{
			Translate__integerVariable++;
			if(integerVariable != null && integerVariable.Name == "IntegerVariable" && (integerVariable.Count == 1 && integerVariable[0] != null && integerVariable[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(integerVariable[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.IntegerVariable(false) { id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerParenthesisExpression integerParenthesisExpression)
		{
			Translate__integerParenthesisExpression++;
			if(integerParenthesisExpression != null && integerParenthesisExpression.Name == "IntegerParenthesisExpression" && (integerParenthesisExpression.Count == 3 && integerParenthesisExpression[0] != null && integerParenthesisExpression[0].Name == "(" && true && integerParenthesisExpression[1] != null && integerParenthesisExpression[1].Name == "IntegerExpression" && true && integerParenthesisExpression[2] != null && integerParenthesisExpression[2].Name == ")" && true))
			{
				Compiler.C.Data.Node iexpr1 = Translate(integerParenthesisExpression[1] as Compiler.AST.Data.IntegerExpression);
				if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
				{
					return new Compiler.C.Data.IntegerParenthesisExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AddExpression addExpression)
		{
			Translate__addExpression++;
			if(addExpression != null && addExpression.Name == "AddExpression" && (addExpression.Count == 3 && addExpression[0] != null && addExpression[0].Name == "IntegerExpression" && true && addExpression[1] != null && addExpression[1].Name == "+" && true && addExpression[2] != null && addExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(addExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(addExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.AddExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "+", Value = "+" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.SubExpression subExpression)
		{
			Translate__subExpression++;
			if(subExpression != null && subExpression.Name == "SubExpression" && (subExpression.Count == 3 && subExpression[0] != null && subExpression[0].Name == "IntegerExpression" && true && subExpression[1] != null && subExpression[1].Name == "-" && true && subExpression[2] != null && subExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(subExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(subExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.SubExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "-", Value = "-" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.MulExpression mulExpression)
		{
			Translate__mulExpression++;
			if(mulExpression != null && mulExpression.Name == "MulExpression" && (mulExpression.Count == 3 && mulExpression[0] != null && mulExpression[0].Name == "IntegerExpression" && true && mulExpression[1] != null && mulExpression[1].Name == mulExpression[1].Name && true && mulExpression[2] != null && mulExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(mulExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(mulExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.MulExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DivExpression divExpression)
		{
			Translate__divExpression++;
			if(divExpression != null && divExpression.Name == "DivExpression" && (divExpression.Count == 3 && divExpression[0] != null && divExpression[0].Name == "IntegerExpression" && true && divExpression[1] != null && divExpression[1].Name == "/" && true && divExpression[2] != null && divExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(divExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(divExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.DivExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "/", Value = "/" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanExpression booleanExpression)
		{
			Translate__booleanExpression++;
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "true" && true))
			{
				return new Compiler.C.Data.BooleanExpression(false) { new Compiler.C.Data.Token() { Name = "1", Value = "1" } };
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "false" && true))
			{
				return new Compiler.C.Data.BooleanExpression(false) { new Compiler.C.Data.Token() { Name = "0", Value = "0" } };
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanVariable" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanVariable);
				if(s1 != null && s1.Name == "BooleanVariable" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanVariable };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "DirectBitValue" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.DirectBitValue);
				if(s1 != null && s1.Name == "DirectBitValue" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.DirectBitValue };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IndirectBitValue" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IndirectBitValue);
				if(s1 != null && s1.Name == "IndirectBitValue" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IndirectBitValue };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanParenthesisExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanParenthesisExpression);
				if(s1 != null && s1.Name == "BooleanParenthesisExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanParenthesisExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IntegerEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IntegerEqExpression);
				if(s1 != null && s1.Name == "IntegerEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IntegerEqExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanEqExpression);
				if(s1 != null && s1.Name == "BooleanEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanEqExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "LessThanExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.LessThanExpression);
				if(s1 != null && s1.Name == "LessThanExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.LessThanExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "GreaterThanExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.GreaterThanExpression);
				if(s1 != null && s1.Name == "GreaterThanExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.GreaterThanExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "NotExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.NotExpression);
				if(s1 != null && s1.Name == "NotExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.NotExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "AndExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.AndExpression);
				if(s1 != null && s1.Name == "AndExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.AndExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "OrExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.OrExpression);
				if(s1 != null && s1.Name == "OrExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.OrExpression };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanVariable booleanVariable)
		{
			Translate__booleanVariable++;
			if(booleanVariable != null && booleanVariable.Name == "BooleanVariable" && (booleanVariable.Count == 1 && booleanVariable[0] != null && booleanVariable[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(booleanVariable[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.BooleanVariable(false) { id1 as Compiler.C.Data.Token };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DirectBitValue directBitValue)
		{
			Translate__directBitValue++;
			if(directBitValue != null && directBitValue.Name == "DirectBitValue" && (directBitValue.Count == 7 && directBitValue[0] != null && directBitValue[0].Name == "registerType" && true && directBitValue[1] != null && directBitValue[1].Name == "(" && true && directBitValue[2] != null && directBitValue[2].Name == "IntegerExpression" && true && directBitValue[3] != null && directBitValue[3].Name == ")" && true && directBitValue[4] != null && directBitValue[4].Name == "{" && true && directBitValue[5] != null && directBitValue[5].Name == "IntegerExpression" && true && directBitValue[6] != null && directBitValue[6].Name == "}" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(directBitValue[2] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(directBitValue[5] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.DirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IndirectBitValue indirectBitValue)
		{
			Translate__indirectBitValue++;
			if(indirectBitValue != null && indirectBitValue.Name == "IndirectBitValue" && (indirectBitValue.Count == 4 && indirectBitValue[0] != null && indirectBitValue[0].Name == "RegisterVariable" && true && indirectBitValue[1] != null && indirectBitValue[1].Name == "{" && true && indirectBitValue[2] != null && indirectBitValue[2].Name == "IntegerExpression" && true && indirectBitValue[3] != null && indirectBitValue[3].Name == "}" && true))
			{
				Compiler.C.Data.Node rvar1 = Translate(indirectBitValue[0] as Compiler.AST.Data.RegisterVariable);
				if(rvar1 != null && rvar1.Name == "RegisterVariable" && true)
				{
					Compiler.C.Data.Node iexpr1 = Translate(indirectBitValue[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.IndirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, rvar1 as Compiler.C.Data.RegisterVariable, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanParenthesisExpression booleanParenthesisExpression)
		{
			Translate__booleanParenthesisExpression++;
			if(booleanParenthesisExpression != null && booleanParenthesisExpression.Name == "BooleanParenthesisExpression" && (booleanParenthesisExpression.Count == 3 && booleanParenthesisExpression[0] != null && booleanParenthesisExpression[0].Name == "(" && true && booleanParenthesisExpression[1] != null && booleanParenthesisExpression[1].Name == "BooleanExpression" && true && booleanParenthesisExpression[2] != null && booleanParenthesisExpression[2].Name == ")" && true))
			{
				Compiler.C.Data.Node bexpr1 = Translate(booleanParenthesisExpression[1] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					return new Compiler.C.Data.BooleanParenthesisExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerEqExpression integerEqExpression)
		{
			Translate__integerEqExpression++;
			if(integerEqExpression != null && integerEqExpression.Name == "IntegerEqExpression" && (integerEqExpression.Count == 3 && integerEqExpression[0] != null && integerEqExpression[0].Name == "IntegerExpression" && true && integerEqExpression[1] != null && integerEqExpression[1].Name == "=" && true && integerEqExpression[2] != null && integerEqExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(integerEqExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(integerEqExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.IntegerEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "==", Value = "==" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanEqExpression booleanEqExpression)
		{
			Translate__booleanEqExpression++;
			if(booleanEqExpression != null && booleanEqExpression.Name == "BooleanEqExpression" && (booleanEqExpression.Count == 3 && booleanEqExpression[0] != null && booleanEqExpression[0].Name == "BooleanExpression" && true && booleanEqExpression[1] != null && booleanEqExpression[1].Name == "=" && true && booleanEqExpression[2] != null && booleanEqExpression[2].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr3 = Translate(booleanEqExpression[0] as Compiler.AST.Data.BooleanExpression);
				if(bexpr3 != null && bexpr3.Name == "BooleanExpression" && true)
				{
					Compiler.C.Data.Node bexpr4 = Translate(booleanEqExpression[2] as Compiler.AST.Data.BooleanExpression);
					if(bexpr4 != null && bexpr4.Name == "BooleanExpression" && true)
					{
						return new Compiler.C.Data.BooleanEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "==", Value = "==" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.LessThanExpression lessThanExpression)
		{
			Translate__lessThanExpression++;
			if(lessThanExpression != null && lessThanExpression.Name == "LessThanExpression" && (lessThanExpression.Count == 3 && lessThanExpression[0] != null && lessThanExpression[0].Name == "IntegerExpression" && true && lessThanExpression[1] != null && lessThanExpression[1].Name == "<" && true && lessThanExpression[2] != null && lessThanExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(lessThanExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(lessThanExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.LessThanExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "<", Value = "<" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.GreaterThanExpression greaterThanExpression)
		{
			Translate__greaterThanExpression++;
			if(greaterThanExpression != null && greaterThanExpression.Name == "GreaterThanExpression" && (greaterThanExpression.Count == 3 && greaterThanExpression[0] != null && greaterThanExpression[0].Name == "IntegerExpression" && true && greaterThanExpression[1] != null && greaterThanExpression[1].Name == ">" && true && greaterThanExpression[2] != null && greaterThanExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(greaterThanExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(greaterThanExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.GreaterThanExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ">", Value = ">" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.NotExpression notExpression)
		{
			Translate__notExpression++;
			if(notExpression != null && notExpression.Name == "NotExpression" && (notExpression.Count == 2 && notExpression[0] != null && notExpression[0].Name == "!" && true && notExpression[1] != null && notExpression[1].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr1 = Translate(notExpression[1] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					return new Compiler.C.Data.NotExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "!", Value = "!" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AndExpression andExpression)
		{
			Translate__andExpression++;
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 3 && andExpression[0] != null && andExpression[0].Name == "BooleanExpression" && true && andExpression[1] != null && andExpression[1].Name == "and" && true && andExpression[2] != null && andExpression[2].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr3 = Translate(andExpression[0] as Compiler.AST.Data.BooleanExpression);
				if(bexpr3 != null && bexpr3.Name == "BooleanExpression" && true)
				{
					Compiler.C.Data.Node bexpr4 = Translate(andExpression[2] as Compiler.AST.Data.BooleanExpression);
					if(bexpr4 != null && bexpr4.Name == "BooleanExpression" && true)
					{
						return new Compiler.C.Data.AndExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "&&", Value = "&&" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.OrExpression orExpression)
		{
			Translate__orExpression++;
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 3 && orExpression[0] != null && orExpression[0].Name == "BooleanExpression" && true && orExpression[1] != null && orExpression[1].Name == "or" && true && orExpression[2] != null && orExpression[2].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr3 = Translate(orExpression[0] as Compiler.AST.Data.BooleanExpression);
				if(bexpr3 != null && bexpr3.Name == "BooleanExpression" && true)
				{
					Compiler.C.Data.Node bexpr4 = Translate(orExpression[2] as Compiler.AST.Data.BooleanExpression);
					if(bexpr4 != null && bexpr4.Name == "BooleanExpression" && true)
					{
						return new Compiler.C.Data.OrExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "||", Value = "||" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Token Translate(Compiler.AST.Data.Token token)
		{
			return new Compiler.C.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
		}

		public Compiler.AST.Data.Node Insert(Compiler.AST.Data.Node left, Compiler.AST.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right.Accept(new Compiler.AST.Visitors.CloneVisitor());
			}
			for (int i = 0; i < left.Count;  i++)
			{
			    Compiler.AST.Data.Node child = Insert(left[i], right);
			    if(child != null)
			    {
			        var leftClone = left.Accept(new Compiler.AST.Visitors.CloneVisitor());
			        leftClone.RemoveAt(i);
			        leftClone.Insert(i, child);
			        return leftClone;
			    }
			}
			return null;
		}

		public Compiler.C.Data.Node Insert(Compiler.C.Data.Node left, Compiler.C.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right.Accept(new Compiler.C.Visitors.CloneVisitor());
			}
			for (int i = 0; i < left.Count;  i++)
			{
			    Compiler.C.Data.Node child = Insert(left[i], right);
			    if(child != null)
			    {
			        var leftClone = left.Accept(new Compiler.C.Visitors.CloneVisitor());
			        leftClone.RemoveAt(i);
			        leftClone.Insert(i, child);
			        return leftClone;
			    }
			}
			return null;
		}

		public void printCounts()
		{
			System.Console.WriteLine("___Translation methods calls___");
			System.Console.WriteLine("Translate__aST: "+Translate__aST);
			System.Console.WriteLine("Translatea__globalStatement_globalDeclarations_functions_statement: "+Translatea__globalStatement_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translatea__compoundGlobalStatement_globalDeclarations_functions_statement: "+Translatea__compoundGlobalStatement_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translatea__interrupt_globalDeclarations_functions_statement: "+Translatea__interrupt_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translatea__statement_globalDeclarations_functions_statement1: "+Translatea__statement_globalDeclarations_functions_statement1);
			System.Console.WriteLine("Translatea__compoundStatement_globalDeclarations_functions_statement: "+Translatea__compoundStatement_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translate__integerDeclaration: "+Translate__integerDeclaration);
			System.Console.WriteLine("Translate__integerAssignment: "+Translate__integerAssignment);
			System.Console.WriteLine("Translate__booleanDeclaration: "+Translate__booleanDeclaration);
			System.Console.WriteLine("Translate__booleanAssignment: "+Translate__booleanAssignment);
			System.Console.WriteLine("Translate__directBitAssignment: "+Translate__directBitAssignment);
			System.Console.WriteLine("Translate__indirectBitAssignment: "+Translate__indirectBitAssignment);
			System.Console.WriteLine("Translate__registerDeclaration: "+Translate__registerDeclaration);
			System.Console.WriteLine("Translate__registerAssignment: "+Translate__registerAssignment);
			System.Console.WriteLine("Translate__registerExpression: "+Translate__registerExpression);
			System.Console.WriteLine("Translate__registerLiteral: "+Translate__registerLiteral);
			System.Console.WriteLine("Translate__registerVariable: "+Translate__registerVariable);
			System.Console.WriteLine("Translatea__ifStatement_globalDeclarations_functions_statement: "+Translatea__ifStatement_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translatea__whileStatement_globalDeclarations_functions_statement: "+Translatea__whileStatement_globalDeclarations_functions_statement);
			System.Console.WriteLine("Translate__integerExpression: "+Translate__integerExpression);
			System.Console.WriteLine("Translate__integerVariable: "+Translate__integerVariable);
			System.Console.WriteLine("Translate__integerParenthesisExpression: "+Translate__integerParenthesisExpression);
			System.Console.WriteLine("Translate__addExpression: "+Translate__addExpression);
			System.Console.WriteLine("Translate__subExpression: "+Translate__subExpression);
			System.Console.WriteLine("Translate__mulExpression: "+Translate__mulExpression);
			System.Console.WriteLine("Translate__divExpression: "+Translate__divExpression);
			System.Console.WriteLine("Translate__booleanExpression: "+Translate__booleanExpression);
			System.Console.WriteLine("Translate__booleanVariable: "+Translate__booleanVariable);
			System.Console.WriteLine("Translate__directBitValue: "+Translate__directBitValue);
			System.Console.WriteLine("Translate__indirectBitValue: "+Translate__indirectBitValue);
			System.Console.WriteLine("Translate__booleanParenthesisExpression: "+Translate__booleanParenthesisExpression);
			System.Console.WriteLine("Translate__integerEqExpression: "+Translate__integerEqExpression);
			System.Console.WriteLine("Translate__booleanEqExpression: "+Translate__booleanEqExpression);
			System.Console.WriteLine("Translate__lessThanExpression: "+Translate__lessThanExpression);
			System.Console.WriteLine("Translate__greaterThanExpression: "+Translate__greaterThanExpression);
			System.Console.WriteLine("Translate__notExpression: "+Translate__notExpression);
			System.Console.WriteLine("Translate__andExpression: "+Translate__andExpression);
			System.Console.WriteLine("Translate__orExpression: "+Translate__orExpression);
		}
	}
}
