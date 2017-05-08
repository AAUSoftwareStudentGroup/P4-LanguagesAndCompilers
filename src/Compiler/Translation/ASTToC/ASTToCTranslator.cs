namespace Compiler.Translation.ASTToC
{
	public class ASTToCTranslator 
	{
		public int Translate__aST = 0;
		public int Translatea__globalStatement_declaration_function_statement = 0;
		public int Translatea__compoundGlobalStatement_declaration_function_statement = 0;
		public int Translatea__interrupt_declaration_function_statement = 0;
		public int Translatea__function_declaration_function1_statement = 0;
		public int Translate__formalParameters = 0;
		public int Translate__formalParameter = 0;
		public int Translate__compoundFormalParameter = 0;
		public int Translatea__statement_declaration_function_statement1 = 0;
		public int Translatea__compoundStatement_declaration_function_statement = 0;
		public int Translate__integerDeclaration = 0;
		public int Translate__integerArrayDeclaration = 0;
		public int Translate__integerArrayDeclarationInit = 0;
		public int Translate__integerExpressionListArgs = 0;
		public int Translate__booleanArrayDeclaration = 0;
		public int Translate__registerArrayDeclaration = 0;
		public int Translate__integerDeclarationInit = 0;
		public int Translate__integerAssignment = 0;
		public int Translate__booleanDeclaration = 0;
		public int Translate__booleanDeclarationInit = 0;
		public int Translate__booleanType = 0;
		public int Translate__booleanAssignment = 0;
		public int Translate__directBitAssignment = 0;
		public int Translate__registerType = 0;
		public int Translate__indirectBitAssignment = 0;
		public int Translate__registerDeclaration = 0;
		public int Translate__registerDeclarationInit = 0;
		public int Translate__registerAssignment = 0;
		public int Translate__registerExpression = 0;
		public int Translate__integerReturn = 0;
		public int Translate__booleanReturn = 0;
		public int Translate__registerReturn = 0;
		public int Translate__call = 0;
		public int Translate__expressionList = 0;
		public int Translate__expressionListArgs = 0;
		public int Translate__registerLiteral = 0;
		public int Translatea__ifStatement_declaration_function_statement = 0;
		public int Translatea__ifElseStatement_declaration_function_statement = 0;
		public int Translatea__whileStatement_declaration_function_statement = 0;
		public int Translatea__forStatement_declaration_function_statement = 0;
		public int Translate__type = 0;
		public int Translate__intType = 0;
		public int Translate__integerExpression = 0;
		public int Translate__integerParenthesisExpression = 0;
		public int Translate__addExpression = 0;
		public int Translate__subExpression = 0;
		public int Translate__mulExpression = 0;
		public int Translate__divExpression = 0;
		public int Translate__modExpression = 0;
		public int Translate__powExpression = 0;
		public int Translate__booleanExpression = 0;
		public int Translate__directBitValue = 0;
		public int Translate__indirectBitValue = 0;
		public int Translate__booleanParenthesisExpression = 0;
		public int Translate__integerEqExpression = 0;
		public int Translate__booleanEqExpression = 0;
		public int Translate__integerNotEqExpression = 0;
		public int Translate__booleanNotEqExpression = 0;
		public int Translate__lessThanExpression = 0;
		public int Translate__greaterThanExpression = 0;
		public int Translate__lessThanOrEqExpression = 0;
		public int Translate__greaterThanOrEqExpression = 0;
		public int Translate__notExpression = 0;
		public int Translate__andExpression = 0;
		public int Translate__orExpression = 0;
		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AST aST)
		{
			Translate__aST++;
			if(aST != null && aST.Name == "AST" && (aST.Count == 1 && aST[0] != null && aST[0].Name == "eof" && true))
			{
				return new Compiler.C.Data.C(false) { new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } };
			}
			if(aST != null && aST.Name == "AST" && (aST.Count == 2 && aST[0] != null && aST[0].Name == "GlobalStatement" && true && aST[1] != null && aST[1].Name == "eof" && true))
			{
				(Compiler.C.Data.Node dcl, Compiler.C.Data.Node f, Compiler.C.Data.Node s) = Translatea(aST[0] as Compiler.AST.Data.GlobalStatement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
				if(dcl != null && dcl.Name == "Declaration" && true && f != null && f.Name == "Function" && true && s != null && s.Name == "Statement" && true)
				{
					return new Compiler.C.Data.C(false) { new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { dcl as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "main", Value = "main" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { f as Compiler.C.Data.Function, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "main", Value = "main" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, s as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } };
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.GlobalStatement globalStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__globalStatement_declaration_function_statement++;
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.Interrupt, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Function" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.Function, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(globalStatement[0] as Compiler.AST.Data.Statement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && s2 != null && s2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, s2 as Compiler.C.Data.Statement);
				}
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && s1 != null && s1.Name == "Statement" && true)
				{
					return (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundGlobalStatement compoundGlobalStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__compoundGlobalStatement_declaration_function_statement++;
			if(compoundGlobalStatement != null && compoundGlobalStatement.Name == "CompoundGlobalStatement" && (compoundGlobalStatement.Count == 3 && compoundGlobalStatement[0] != null && compoundGlobalStatement[0].Name == "GlobalStatement" && true && compoundGlobalStatement[1] != null && compoundGlobalStatement[1].Name == "newline" && true && compoundGlobalStatement[2] != null && compoundGlobalStatement[2].Name == "GlobalStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(compoundGlobalStatement[0] as Compiler.AST.Data.GlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && s1 != null && s1.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(compoundGlobalStatement[2] as Compiler.AST.Data.GlobalStatement, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
					if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && s2 != null && s2.Name == "Statement" && true)
					{
						return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, s2 as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Interrupt interrupt, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__interrupt_declaration_function_statement++;
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && true && interrupt[1] != null && interrupt[1].Name == "(" && true && interrupt[2] != null && interrupt[2].Name == "numeral" && true && interrupt[3] != null && interrupt[3].Name == ")" && true && interrupt[4] != null && interrupt[4].Name == "indent" && true && interrupt[5] != null && interrupt[5].Name == "Statement" && true && interrupt[6] != null && interrupt[6].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node i1 = Translate(interrupt[2] as Compiler.AST.Data.Token);
				if(i1 != null && i1.Name == "numeral" && true)
				{
					(Compiler.C.Data.Node gs1, Compiler.C.Data.Node function1, Compiler.C.Data.Node si2) = Translatea(interrupt[5] as Compiler.AST.Data.Statement, declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(gs1 != null && gs1.Name == "Declaration" && true && function1 != null && function1.Name == "Function" && (function1.Count == 1 && function1[0] != null && function1[0].Name == "EPSILON" && true) && si2 != null && si2.Name == "Statement" && true)
					{
						return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "__vector_21", Value = "__vector_21" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.FormalParameters(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { function as Compiler.C.Data.Function, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "__vector_21", Value = "__vector_21" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.FormalParameters(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, gs1 as Compiler.C.Data.Declaration, si2 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } }, statement as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Function function, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function1, Compiler.C.Data.Statement statement)
		{
			Translatea__function_declaration_function1_statement++;
			if(function != null && function.Name == "Function" && (function.Count == 8 && function[0] != null && function[0].Name == "Type" && true && function[1] != null && function[1].Name == "identifier" && true && function[2] != null && function[2].Name == "(" && true && function[3] != null && function[3].Name == "FormalParameters" && true && function[4] != null && function[4].Name == ")" && true && function[5] != null && function[5].Name == "indent" && true && function[6] != null && function[6].Name == "Statement" && true && function[7] != null && function[7].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function1 != null && function1.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node t1 = Translate(function[0] as Compiler.AST.Data.Type);
				if(t1 != null && t1.Name == "Type" && true)
				{
					Compiler.C.Data.Node id1 = Translate(function[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node p1 = Translate(function[3] as Compiler.AST.Data.FormalParameters);
						if(p1 != null && p1.Name == "FormalParameters" && true)
						{
							(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node function2, Compiler.C.Data.Node s1) = Translatea(function[6] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
							if(dcl1 != null && dcl1.Name == "Declaration" && true && function2 != null && function2.Name == "Function" && (function2.Count == 1 && function2[0] != null && function2[0].Name == "EPSILON" && true) && s1 != null && s1.Name == "Statement" && true)
							{
								return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.FormalParameters, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { function1 as Compiler.C.Data.Function, new Compiler.C.Data.Function(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.FormalParameters, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl1 as Compiler.C.Data.Declaration, s1 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } }, statement as Compiler.C.Data.Statement);
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.FormalParameters formalParameters)
		{
			Translate__formalParameters++;
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON" && true))
			{
				return new Compiler.C.Data.FormalParameters(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && true))
			{
				Compiler.C.Data.Node p1 = Translate(formalParameters[0] as Compiler.AST.Data.FormalParameter);
				if(p1 != null && p1.Name == "FormalParameter" && true)
				{
					return new Compiler.C.Data.FormalParameters(false) { p1 as Compiler.C.Data.FormalParameter };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.FormalParameter formalParameter)
		{
			Translate__formalParameter++;
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && true && formalParameter[1] != null && formalParameter[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node t1 = Translate(formalParameter[0] as Compiler.AST.Data.Type);
				if(t1 != null && t1.Name == "Type" && true)
				{
					Compiler.C.Data.Node id1 = Translate(formalParameter[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						return new Compiler.C.Data.FormalParameter(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token };
					}
				}
			}
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 1 && formalParameter[0] != null && formalParameter[0].Name == "CompoundFormalParameter" && true))
			{
				Compiler.C.Data.Node cpar1 = Translate(formalParameter[0] as Compiler.AST.Data.CompoundFormalParameter);
				if(cpar1 != null && cpar1.Name == "CompoundFormalParameter" && true)
				{
					return new Compiler.C.Data.FormalParameter(false) { cpar1 as Compiler.C.Data.CompoundFormalParameter };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.CompoundFormalParameter compoundFormalParameter)
		{
			Translate__compoundFormalParameter++;
			if(compoundFormalParameter != null && compoundFormalParameter.Name == "CompoundFormalParameter" && (compoundFormalParameter.Count == 3 && compoundFormalParameter[0] != null && compoundFormalParameter[0].Name == "FormalParameter" && true && compoundFormalParameter[1] != null && compoundFormalParameter[1].Name == "," && true && compoundFormalParameter[2] != null && compoundFormalParameter[2].Name == "FormalParameter" && true))
			{
				Compiler.C.Data.Node p3 = Translate(compoundFormalParameter[0] as Compiler.AST.Data.FormalParameter);
				if(p3 != null && p3.Name == "FormalParameter" && true)
				{
					Compiler.C.Data.Node p4 = Translate(compoundFormalParameter[2] as Compiler.AST.Data.FormalParameter);
					if(p4 != null && p4.Name == "FormalParameters" && true)
					{
						return new Compiler.C.Data.CompoundFormalParameter(false) { p3 as Compiler.C.Data.FormalParameter, new Compiler.C.Data.Token() { Name = ",", Value = "," }, p4 as Compiler.C.Data.FormalParameters };
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Statement statement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement1)
		{
			Translatea__statement_declaration_function_statement1++;
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "EPSILON" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "CompoundStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.CompoundStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerDeclaration);
				if(s1 != null && s1.Name == "IntegerDeclaration" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.IntegerDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerArrayDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerArrayDeclaration);
				if(s1 != null && s1.Name == "IntegerArray" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.IntegerArray, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerArrayDeclarationInit" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerArrayDeclarationInit);
				if(s1 != null && s1.Name == "IntegerArrayInit" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.IntegerArrayInit, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanArrayDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanArrayDeclaration);
				if(s1 != null && s1.Name == "IntegerArray" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.IntegerArray, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterArrayDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterArrayDeclaration);
				if(s1 != null && s1.Name == "RegisterArray" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.RegisterArray, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "IntType" && true && statement[0][1] != null && statement[0][1].Name == "identifier" && true && statement[0][2] != null && statement[0][2].Name == "=" && true && statement[0][3] != null && statement[0][3].Name == "IntegerExpression" && true)) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.IntegerDeclaration(false) { statement[0][0] as Compiler.AST.Data.IntType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && si1 != null && si1.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.IntegerAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.IntegerExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
					if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
					{
						return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
					}
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanDeclaration);
				if(s1 != null && s1.Name == "BooleanDeclaration" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.BooleanDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "BooleanType" && true && statement[0][1] != null && statement[0][1].Name == "identifier" && true && statement[0][2] != null && statement[0][2].Name == "=" && true && statement[0][3] != null && statement[0][3].Name == "BooleanExpression" && true)) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.BooleanDeclaration(false) { statement[0][0] as Compiler.AST.Data.BooleanType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && si1 != null && si1.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.BooleanAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.BooleanExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
					if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
					{
						return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
					}
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterDeclaration" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterDeclaration);
				if(s1 != null && s1.Name == "RegisterDeclaration" && true)
				{
					return (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.RegisterDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "RegisterType" && true && statement[0][1] != null && statement[0][1].Name == "identifier" && true && statement[0][2] != null && statement[0][2].Name == "=" && true && statement[0][3] != null && statement[0][3].Name == "RegisterExpression" && true)) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.RegisterDeclaration(false) { statement[0][0] as Compiler.AST.Data.RegisterType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl1 != null && dcl1.Name == "Declaration" && true && f1 != null && f1.Name == "Function" && true && si1 != null && si1.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.RegisterAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.RegisterExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
					if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
					{
						return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
					}
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "DirectBitAssignment" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.DirectBitAssignment);
				if(s1 != null && s1.Name == "DirectBitAssignment" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.DirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IndirectBitAssignment" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IndirectBitAssignment);
				if(s1 != null && s1.Name == "IndirectBitAssignment" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IndirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerAssignment" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerAssignment);
				if(s1 != null && s1.Name == "IntegerAssignment" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IntegerAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanAssignment" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanAssignment);
				if(s1 != null && s1.Name == "BooleanAssignment" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.BooleanAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterAssignment" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterAssignment);
				if(s1 != null && s1.Name == "RegisterAssignment" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.RegisterAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfElseStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfElseStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.WhileStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.ForStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					return (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerReturn" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node iret1 = Translate(statement[0] as Compiler.AST.Data.IntegerReturn);
				if(iret1 != null && iret1.Name == "IntegerReturn" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { iret1 as Compiler.C.Data.IntegerReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanReturn" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bret1 = Translate(statement[0] as Compiler.AST.Data.BooleanReturn);
				if(bret1 != null && bret1.Name == "BooleanReturn" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { bret1 as Compiler.C.Data.BooleanReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterReturn" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node rret1 = Translate(statement[0] as Compiler.AST.Data.RegisterReturn);
				if(rret1 != null && rret1.Name == "RegisterReturn" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { rret1 as Compiler.C.Data.RegisterReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "Call" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement1 != null && statement1.Name == "Statement" && true)
			{
				Compiler.C.Data.Node c1 = Translate(statement[0] as Compiler.AST.Data.Call);
				if(c1 != null && c1.Name == "Call" && true)
				{
					return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { c1 as Compiler.C.Data.Call, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundStatement compoundStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__compoundStatement_declaration_function_statement++;
			if(compoundStatement != null && compoundStatement.Name == "CompoundStatement" && (compoundStatement.Count == 3 && compoundStatement[0] != null && compoundStatement[0].Name == "Statement" && true && compoundStatement[1] != null && compoundStatement[1].Name == "newline" && true && compoundStatement[2] != null && compoundStatement[2].Name == "Statement" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				(Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(compoundStatement[0] as Compiler.AST.Data.Statement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
				if(dcl2 != null && dcl2.Name == "Declaration" && true && f2 != null && f2.Name == "Function" && true && si2 != null && si2.Name == "Statement" && true)
				{
					(Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(compoundStatement[2] as Compiler.AST.Data.Statement, dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
					if(dcl3 != null && dcl3.Name == "Declaration" && true && f3 != null && f3.Name == "Function" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (dcl3 as Compiler.C.Data.Declaration, f3 as Compiler.C.Data.Function, si3 as Compiler.C.Data.Statement);
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerDeclaration integerDeclaration)
		{
			Translate__integerDeclaration++;
			if(integerDeclaration != null && integerDeclaration.Name == "IntegerDeclaration" && (integerDeclaration.Count == 2 && integerDeclaration[0] != null && integerDeclaration[0].Name == "IntType" && true && integerDeclaration[1] != null && integerDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node i1 = Translate(integerDeclaration[0] as Compiler.AST.Data.IntType);
				if(i1 != null && i1.Name == "IntType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(integerDeclaration[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						return new Compiler.C.Data.IntegerDeclaration(false) { i1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerArrayDeclaration integerArrayDeclaration)
		{
			Translate__integerArrayDeclaration++;
			if(integerArrayDeclaration != null && integerArrayDeclaration.Name == "IntegerArrayDeclaration" && (integerArrayDeclaration.Count == 5 && integerArrayDeclaration[0] != null && integerArrayDeclaration[0].Name == "IntType" && true && integerArrayDeclaration[1] != null && integerArrayDeclaration[1].Name == "[" && true && integerArrayDeclaration[2] != null && integerArrayDeclaration[2].Name == "numeral" && true && integerArrayDeclaration[3] != null && integerArrayDeclaration[3].Name == "]" && true && integerArrayDeclaration[4] != null && integerArrayDeclaration[4].Name == "identifier" && true))
			{
				Compiler.C.Data.Node t1 = Translate(integerArrayDeclaration[0] as Compiler.AST.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(integerArrayDeclaration[4] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node num1 = Translate(integerArrayDeclaration[2] as Compiler.AST.Data.Token);
						if(num1 != null && num1.Name == "numeral" && true)
						{
							return new Compiler.C.Data.IntegerArray(false) { t1 as Compiler.C.Data.IntType, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, num1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, id1 as Compiler.C.Data.Token };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerArrayDeclarationInit integerArrayDeclarationInit)
		{
			Translate__integerArrayDeclarationInit++;
			if(integerArrayDeclarationInit != null && integerArrayDeclarationInit.Name == "IntegerArrayDeclarationInit" && (integerArrayDeclarationInit.Count == 8 && integerArrayDeclarationInit[0] != null && integerArrayDeclarationInit[0].Name == "IntType" && true && integerArrayDeclarationInit[1] != null && integerArrayDeclarationInit[1].Name == "[" && true && integerArrayDeclarationInit[2] != null && integerArrayDeclarationInit[2].Name == "]" && true && integerArrayDeclarationInit[3] != null && integerArrayDeclarationInit[3].Name == "identifier" && true && integerArrayDeclarationInit[4] != null && integerArrayDeclarationInit[4].Name == "=" && true && integerArrayDeclarationInit[5] != null && integerArrayDeclarationInit[5].Name == "[" && true && integerArrayDeclarationInit[6] != null && integerArrayDeclarationInit[6].Name == "IntegerExpressionListArgs" && true && integerArrayDeclarationInit[7] != null && integerArrayDeclarationInit[7].Name == "]" && true))
			{
				Compiler.C.Data.Node t1 = Translate(integerArrayDeclarationInit[0] as Compiler.AST.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(integerArrayDeclarationInit[3] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node ielist1 = Translate(integerArrayDeclarationInit[6] as Compiler.AST.Data.IntegerExpressionListArgs);
						if(ielist1 != null && ielist1.Name == "IntegerExpressionListArgs" && true)
						{
							return new Compiler.C.Data.IntegerArrayInit(false) { t1 as Compiler.C.Data.IntType, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, ielist1 as Compiler.C.Data.IntegerExpressionListArgs, new Compiler.C.Data.Token() { Name = "]", Value = "]" } };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerExpressionListArgs integerExpressionListArgs)
		{
			Translate__integerExpressionListArgs++;
			if(integerExpressionListArgs != null && integerExpressionListArgs.Name == "IntegerExpressionListArgs" && (integerExpressionListArgs.Count == 1 && integerExpressionListArgs[0] != null && integerExpressionListArgs[0].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr = Translate(integerExpressionListArgs[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr != null && iexpr.Name == "IntegerExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpressionListArgs(false) { iexpr as Compiler.C.Data.IntegerExpression };
				}
			}
			if(integerExpressionListArgs != null && integerExpressionListArgs.Name == "IntegerExpressionListArgs" && (integerExpressionListArgs.Count == 1 && integerExpressionListArgs[0] != null && integerExpressionListArgs[0].Name == "IntegerCompoundArgs" && (integerExpressionListArgs[0].Count == 3 && integerExpressionListArgs[0][0] != null && integerExpressionListArgs[0][0].Name == "IntegerExpressionListArgs" && true && integerExpressionListArgs[0][1] != null && integerExpressionListArgs[0][1].Name == "," && true && integerExpressionListArgs[0][2] != null && integerExpressionListArgs[0][2].Name == "IntegerExpressionListArgs" && true)))
			{
				Compiler.C.Data.Node p3 = Translate(integerExpressionListArgs[0][0] as Compiler.AST.Data.IntegerExpressionListArgs);
				if(p3 != null && p3.Name == "IntegerExpressionListArgs" && true)
				{
					Compiler.C.Data.Node p4 = Translate(integerExpressionListArgs[0][2] as Compiler.AST.Data.IntegerExpressionListArgs);
					if(p4 != null && p4.Name == "IntegerExpressionListArgs" && true)
					{
						return new Compiler.C.Data.IntegerExpressionListArgs(false) { new Compiler.C.Data.IntegerCompoundArgs(false) { p3 as Compiler.C.Data.IntegerExpressionListArgs, new Compiler.C.Data.Token() { Name = ",", Value = "," }, p4 as Compiler.C.Data.IntegerExpressionListArgs } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanArrayDeclaration booleanArrayDeclaration)
		{
			Translate__booleanArrayDeclaration++;
			if(booleanArrayDeclaration != null && booleanArrayDeclaration.Name == "BooleanArrayDeclaration" && (booleanArrayDeclaration.Count == 5 && booleanArrayDeclaration[0] != null && booleanArrayDeclaration[0].Name == "BooleanType" && true && booleanArrayDeclaration[1] != null && booleanArrayDeclaration[1].Name == "[" && true && booleanArrayDeclaration[2] != null && booleanArrayDeclaration[2].Name == "numeral" && true && booleanArrayDeclaration[3] != null && booleanArrayDeclaration[3].Name == "]" && true && booleanArrayDeclaration[4] != null && booleanArrayDeclaration[4].Name == "identifier" && true))
			{
				Compiler.C.Data.Node t1 = Translate(booleanArrayDeclaration[0] as Compiler.AST.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(booleanArrayDeclaration[4] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node num1 = Translate(booleanArrayDeclaration[2] as Compiler.AST.Data.Token);
						if(num1 != null && num1.Name == "numeral" && true)
						{
							return new Compiler.C.Data.BooleanArray(false) { t1 as Compiler.C.Data.BooleanType, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, num1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, id1 as Compiler.C.Data.Token };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterArrayDeclaration registerArrayDeclaration)
		{
			Translate__registerArrayDeclaration++;
			if(registerArrayDeclaration != null && registerArrayDeclaration.Name == "RegisterArrayDeclaration" && (registerArrayDeclaration.Count == 5 && registerArrayDeclaration[0] != null && registerArrayDeclaration[0].Name == "RegisterType" && true && registerArrayDeclaration[1] != null && registerArrayDeclaration[1].Name == "[" && true && registerArrayDeclaration[2] != null && registerArrayDeclaration[2].Name == "numeral" && true && registerArrayDeclaration[3] != null && registerArrayDeclaration[3].Name == "]" && true && registerArrayDeclaration[4] != null && registerArrayDeclaration[4].Name == "identifier" && true))
			{
				Compiler.C.Data.Node t1 = Translate(registerArrayDeclaration[0] as Compiler.AST.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(registerArrayDeclaration[4] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node num1 = Translate(registerArrayDeclaration[2] as Compiler.AST.Data.Token);
						if(num1 != null && num1.Name == "numeral" && true)
						{
							return new Compiler.C.Data.RegisterArray(false) { t1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, num1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, id1 as Compiler.C.Data.Token };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerDeclarationInit integerDeclarationInit)
		{
			Translate__integerDeclarationInit++;
			if(integerDeclarationInit != null && integerDeclarationInit.Name == "IntegerDeclarationInit" && (integerDeclarationInit.Count == 4 && integerDeclarationInit[0] != null && integerDeclarationInit[0].Name == "IntType" && true && integerDeclarationInit[1] != null && integerDeclarationInit[1].Name == "identifier" && true && integerDeclarationInit[2] != null && integerDeclarationInit[2].Name == "=" && true && integerDeclarationInit[3] != null && integerDeclarationInit[3].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node intType1 = Translate(integerDeclarationInit[0] as Compiler.AST.Data.IntType);
				if(intType1 != null && intType1.Name == "IntType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(integerDeclarationInit[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node iexpr1 = Translate(integerDeclarationInit[3] as Compiler.AST.Data.IntegerExpression);
						if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
						{
							return new Compiler.C.Data.IntegerDeclarationInit(false) { intType1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, iexpr1 as Compiler.C.Data.IntegerExpression };
						}
					}
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
			if(booleanDeclaration != null && booleanDeclaration.Name == "BooleanDeclaration" && (booleanDeclaration.Count == 2 && booleanDeclaration[0] != null && booleanDeclaration[0].Name == "BooleanType" && true && booleanDeclaration[1] != null && booleanDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node boolType1 = Translate(booleanDeclaration[0] as Compiler.AST.Data.BooleanType);
				if(boolType1 != null && boolType1.Name == "BooleanType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(booleanDeclaration[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						return new Compiler.C.Data.BooleanDeclaration(false) { boolType1 as Compiler.C.Data.BooleanType, id1 as Compiler.C.Data.Token };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanDeclarationInit booleanDeclarationInit)
		{
			Translate__booleanDeclarationInit++;
			if(booleanDeclarationInit != null && booleanDeclarationInit.Name == "BooleanDeclarationInit" && (booleanDeclarationInit.Count == 4 && booleanDeclarationInit[0] != null && booleanDeclarationInit[0].Name == "BooleanType" && true && booleanDeclarationInit[1] != null && booleanDeclarationInit[1].Name == "identifier" && true && booleanDeclarationInit[2] != null && booleanDeclarationInit[2].Name == "=" && true && booleanDeclarationInit[3] != null && booleanDeclarationInit[3].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node boolType1 = Translate(booleanDeclarationInit[0] as Compiler.AST.Data.BooleanType);
				if(boolType1 != null && boolType1.Name == "BooleanType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(booleanDeclarationInit[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node bexpr1 = Translate(booleanDeclarationInit[3] as Compiler.AST.Data.BooleanExpression);
						if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
						{
							return new Compiler.C.Data.BooleanDeclarationInit(false) { boolType1 as Compiler.C.Data.BooleanType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, bexpr1 as Compiler.C.Data.BooleanExpression };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanType booleanType)
		{
			Translate__booleanType++;
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool" && true))
			{
				return new Compiler.C.Data.BooleanType(false) { new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" } };
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
			if(directBitAssignment != null && directBitAssignment.Name == "DirectBitAssignment" && (directBitAssignment.Count == 9 && directBitAssignment[0] != null && directBitAssignment[0].Name == "RegisterType" && true && directBitAssignment[1] != null && directBitAssignment[1].Name == "(" && true && directBitAssignment[2] != null && directBitAssignment[2].Name == "IntegerExpression" && true && directBitAssignment[3] != null && directBitAssignment[3].Name == ")" && true && directBitAssignment[4] != null && directBitAssignment[4].Name == "{" && true && directBitAssignment[5] != null && directBitAssignment[5].Name == "IntegerExpression" && true && directBitAssignment[6] != null && directBitAssignment[6].Name == "}" && true && directBitAssignment[7] != null && directBitAssignment[7].Name == "=" && true && directBitAssignment[8] != null && directBitAssignment[8].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node regType1 = Translate(directBitAssignment[0] as Compiler.AST.Data.RegisterType);
				if(regType1 != null && regType1.Name == "RegisterType" && true)
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
								return new Compiler.C.Data.DirectBitAssignment(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "|", Value = "|" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "~", Value = "~" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterType registerType)
		{
			Translate__registerType++;
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8" && true))
			{
				return new Compiler.C.Data.RegisterType(false) { new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" } };
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16" && true))
			{
				return new Compiler.C.Data.RegisterType(false) { new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "short", Value = "short" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" } };
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
			if(registerDeclaration != null && registerDeclaration.Name == "RegisterDeclaration" && (registerDeclaration.Count == 2 && registerDeclaration[0] != null && registerDeclaration[0].Name == "RegisterType" && true && registerDeclaration[1] != null && registerDeclaration[1].Name == "identifier" && true))
			{
				Compiler.C.Data.Node regType1 = Translate(registerDeclaration[0] as Compiler.AST.Data.RegisterType);
				if(regType1 != null && regType1.Name == "RegisterType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(registerDeclaration[1] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						return new Compiler.C.Data.RegisterDeclaration(false) { regType1 as Compiler.C.Data.RegisterType, id1 as Compiler.C.Data.Token };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterDeclarationInit registerDeclarationInit)
		{
			Translate__registerDeclarationInit++;
			if(registerDeclarationInit != null && registerDeclarationInit.Name == "RegisterDeclarationInit" && (registerDeclarationInit.Count == 4 && registerDeclarationInit[0] != null && registerDeclarationInit[0].Name == "RegisterType" && true && registerDeclarationInit[1] != null && registerDeclarationInit[1].Name == "identifier" && true && registerDeclarationInit[2] != null && registerDeclarationInit[2].Name == "=" && true && registerDeclarationInit[3] != null && registerDeclarationInit[3].Name == "RegisterExpression" && true))
			{
				Compiler.C.Data.Node rexpr1 = Translate(registerDeclarationInit[3] as Compiler.AST.Data.RegisterExpression);
				if(rexpr1 != null && rexpr1.Name == "RegisterExpression" && true)
				{
					Compiler.C.Data.Node regType1 = Translate(registerDeclarationInit[0] as Compiler.AST.Data.RegisterType);
					if(regType1 != null && regType1.Name == "RegisterType" && true)
					{
						Compiler.C.Data.Node id1 = Translate(registerDeclarationInit[1] as Compiler.AST.Data.Token);
						if(id1 != null && id1.Name == "identifier" && true)
						{
							return new Compiler.C.Data.RegisterDeclarationInit(false) { regType1 as Compiler.C.Data.RegisterType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, rexpr1 as Compiler.C.Data.RegisterExpression };
						}
					}
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
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(registerExpression[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.RegisterExpression(false) { id1 as Compiler.C.Data.Token };
				}
			}
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "Call" && true))
			{
				Compiler.C.Data.Node s1 = Translate(registerExpression[0] as Compiler.AST.Data.Call);
				if(s1 != null && s1.Name == "Call" && true)
				{
					return new Compiler.C.Data.RegisterExpression(false) { s1 as Compiler.C.Data.Call };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerReturn integerReturn)
		{
			Translate__integerReturn++;
			if(integerReturn != null && integerReturn.Name == "IntegerReturn" && (integerReturn.Count == 2 && integerReturn[0] != null && integerReturn[0].Name == "return" && true && integerReturn[1] != null && integerReturn[1].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr = Translate(integerReturn[1] as Compiler.AST.Data.IntegerExpression);
				if(iexpr != null && iexpr.Name == "IntegerExpression" && true)
				{
					return new Compiler.C.Data.IntegerReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, iexpr as Compiler.C.Data.IntegerExpression };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanReturn booleanReturn)
		{
			Translate__booleanReturn++;
			if(booleanReturn != null && booleanReturn.Name == "BooleanReturn" && (booleanReturn.Count == 2 && booleanReturn[0] != null && booleanReturn[0].Name == "return" && true && booleanReturn[1] != null && booleanReturn[1].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr = Translate(booleanReturn[1] as Compiler.AST.Data.BooleanExpression);
				if(bexpr != null && bexpr.Name == "BooleanExpression" && true)
				{
					return new Compiler.C.Data.BooleanReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, bexpr as Compiler.C.Data.BooleanExpression };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterReturn registerReturn)
		{
			Translate__registerReturn++;
			if(registerReturn != null && registerReturn.Name == "RegisterReturn" && (registerReturn.Count == 2 && registerReturn[0] != null && registerReturn[0].Name == "return" && true && registerReturn[1] != null && registerReturn[1].Name == "RegisterExpression" && true))
			{
				Compiler.C.Data.Node rexpr = Translate(registerReturn[1] as Compiler.AST.Data.RegisterExpression);
				if(rexpr != null && rexpr.Name == "RegisterExpression" && true)
				{
					return new Compiler.C.Data.RegisterReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, rexpr as Compiler.C.Data.RegisterExpression };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.Call call)
		{
			Translate__call++;
			if(call != null && call.Name == "Call" && (call.Count == 4 && call[0] != null && call[0].Name == "identifier" && true && call[1] != null && call[1].Name == "(" && true && call[2] != null && call[2].Name == "ExpressionList" && true && call[3] != null && call[3].Name == ")" && true))
			{
				Compiler.C.Data.Node id1 = Translate(call[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node p1 = Translate(call[2] as Compiler.AST.Data.ExpressionList);
					if(p1 != null && p1.Name == "ExpressionList" && true)
					{
						return new Compiler.C.Data.Call(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.ExpressionList, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ExpressionList expressionList)
		{
			Translate__expressionList++;
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "EPSILON" && true))
			{
				return new Compiler.C.Data.ExpressionList(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "ExpressionListArgs" && true))
			{
				Compiler.C.Data.Node p1 = Translate(expressionList[0] as Compiler.AST.Data.ExpressionListArgs);
				if(p1 != null && p1.Name == "ExpressionListArgs" && true)
				{
					return new Compiler.C.Data.ExpressionList(false) { p1 as Compiler.C.Data.ExpressionListArgs };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ExpressionListArgs expressionListArgs)
		{
			Translate__expressionListArgs++;
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr != null && iexpr.Name == "IntegerExpression" && true)
				{
					return new Compiler.C.Data.ExpressionListArgs(false) { iexpr as Compiler.C.Data.IntegerExpression };
				}
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.BooleanExpression);
				if(bexpr != null && bexpr.Name == "BooleanExpression" && true)
				{
					return new Compiler.C.Data.ExpressionListArgs(false) { bexpr as Compiler.C.Data.BooleanExpression };
				}
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "RegisterExpression" && true))
			{
				Compiler.C.Data.Node rexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.RegisterExpression);
				if(rexpr != null && rexpr.Name == "RegisterExpression" && true)
				{
					return new Compiler.C.Data.ExpressionListArgs(false) { rexpr as Compiler.C.Data.RegisterExpression };
				}
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "CompoundArgs" && (expressionListArgs[0].Count == 3 && expressionListArgs[0][0] != null && expressionListArgs[0][0].Name == "ExpressionListArgs" && true && expressionListArgs[0][1] != null && expressionListArgs[0][1].Name == "," && true && expressionListArgs[0][2] != null && expressionListArgs[0][2].Name == "ExpressionListArgs" && true)))
			{
				Compiler.C.Data.Node p3 = Translate(expressionListArgs[0][0] as Compiler.AST.Data.ExpressionListArgs);
				if(p3 != null && p3.Name == "ExpressionListArgs" && true)
				{
					Compiler.C.Data.Node p4 = Translate(expressionListArgs[0][2] as Compiler.AST.Data.ExpressionListArgs);
					if(p4 != null && p4.Name == "ExpressionListArgs" && true)
					{
						return new Compiler.C.Data.ExpressionListArgs(false) { new Compiler.C.Data.CompoundArgs(false) { p3 as Compiler.C.Data.ExpressionListArgs, new Compiler.C.Data.Token() { Name = ",", Value = "," }, p4 as Compiler.C.Data.ExpressionListArgs } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterLiteral registerLiteral)
		{
			Translate__registerLiteral++;
			if(registerLiteral != null && registerLiteral.Name == "RegisterLiteral" && (registerLiteral.Count == 4 && registerLiteral[0] != null && registerLiteral[0].Name == "RegisterType" && true && registerLiteral[1] != null && registerLiteral[1].Name == "(" && true && registerLiteral[2] != null && registerLiteral[2].Name == "IntegerExpression" && true && registerLiteral[3] != null && registerLiteral[3].Name == ")" && true))
			{
				Compiler.C.Data.Node regType1 = Translate(registerLiteral[0] as Compiler.AST.Data.RegisterType);
				if(regType1 != null && regType1.Name == "RegisterType" && true)
				{
					Compiler.C.Data.Node iexpr1 = Translate(registerLiteral[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.RegisterLiteral(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfStatement ifStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__ifStatement_declaration_function_statement++;
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && true && ifStatement[1] != null && ifStatement[1].Name == "(" && true && ifStatement[2] != null && ifStatement[2].Name == "BooleanExpression" && true && ifStatement[3] != null && ifStatement[3].Name == ")" && true && ifStatement[4] != null && ifStatement[4].Name == "indent" && true && ifStatement[5] != null && ifStatement[5].Name == "Statement" && true && ifStatement[6] != null && ifStatement[6].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bexpr1 = Translate(ifStatement[2] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					(Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(dcl3 != null && dcl3.Name == "Declaration" && true && f3 != null && f3.Name == "Function" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfElseStatement ifElseStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__ifElseStatement_declaration_function_statement++;
			if(ifElseStatement != null && ifElseStatement.Name == "IfElseStatement" && (ifElseStatement.Count == 11 && ifElseStatement[0] != null && ifElseStatement[0].Name == "if" && true && ifElseStatement[1] != null && ifElseStatement[1].Name == "(" && true && ifElseStatement[2] != null && ifElseStatement[2].Name == "BooleanExpression" && true && ifElseStatement[3] != null && ifElseStatement[3].Name == ")" && true && ifElseStatement[4] != null && ifElseStatement[4].Name == "indent" && true && ifElseStatement[5] != null && ifElseStatement[5].Name == "Statement" && true && ifElseStatement[6] != null && ifElseStatement[6].Name == "dedent" && true && ifElseStatement[7] != null && ifElseStatement[7].Name == "else" && true && ifElseStatement[8] != null && ifElseStatement[8].Name == "indent" && true && ifElseStatement[9] != null && ifElseStatement[9].Name == "Statement" && true && ifElseStatement[10] != null && ifElseStatement[10].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bexpr1 = Translate(ifElseStatement[2] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					(Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifElseStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(dcl3 != null && dcl3.Name == "Declaration" && true && f3 != null && f3.Name == "Function" && true && si3 != null && si3.Name == "Statement" && true)
					{
						(Compiler.C.Data.Node dcl4, Compiler.C.Data.Node f4, Compiler.C.Data.Node si4) = Translatea(ifElseStatement[9] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
						if(dcl4 != null && dcl4.Name == "Declaration" && true && f4 != null && f4.Name == "Function" && true && si4 != null && si4.Name == "Statement" && true)
						{
							return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfElseStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "else", Value = "else" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl4 as Compiler.C.Data.Declaration, si4 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
						}
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.WhileStatement whileStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__whileStatement_declaration_function_statement++;
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && true && whileStatement[1] != null && whileStatement[1].Name == "(" && true && whileStatement[2] != null && whileStatement[2].Name == "BooleanExpression" && true && whileStatement[3] != null && whileStatement[3].Name == ")" && true && whileStatement[4] != null && whileStatement[4].Name == "indent" && true && whileStatement[5] != null && whileStatement[5].Name == "Statement" && true && whileStatement[6] != null && whileStatement[6].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node bexpr1 = Translate(whileStatement[2] as Compiler.AST.Data.BooleanExpression);
				if(bexpr1 != null && bexpr1.Name == "BooleanExpression" && true)
				{
					(Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(whileStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
					if(dcl3 != null && dcl3.Name == "Declaration" && true && f3 != null && f3.Name == "Function" && true && si3 != null && si3.Name == "Statement" && true)
					{
						return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.WhileStatement(false) { new Compiler.C.Data.Token() { Name = "while", Value = "while" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
					}
				}
			}
			throw new System.Exception();
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.ForStatement forStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			Translatea__forStatement_declaration_function_statement++;
			if(forStatement != null && forStatement.Name == "ForStatement" && (forStatement.Count == 12 && forStatement[0] != null && forStatement[0].Name == "for" && true && forStatement[1] != null && forStatement[1].Name == "(" && true && forStatement[2] != null && forStatement[2].Name == "IntType" && true && forStatement[3] != null && forStatement[3].Name == "identifier" && true && forStatement[4] != null && forStatement[4].Name == "from" && true && forStatement[5] != null && forStatement[5].Name == "IntegerExpression" && true && forStatement[6] != null && forStatement[6].Name == "to" && true && forStatement[7] != null && forStatement[7].Name == "IntegerExpression" && true && forStatement[8] != null && forStatement[8].Name == ")" && true && forStatement[9] != null && forStatement[9].Name == "indent" && true && forStatement[10] != null && forStatement[10].Name == "Statement" && true && forStatement[11] != null && forStatement[11].Name == "dedent" && true) && declaration != null && declaration.Name == "Declaration" && true && function != null && function.Name == "Function" && true && statement != null && statement.Name == "Statement" && true)
			{
				Compiler.C.Data.Node intType1 = Translate(forStatement[2] as Compiler.AST.Data.IntType);
				if(intType1 != null && intType1.Name == "IntType" && true)
				{
					Compiler.C.Data.Node id1 = Translate(forStatement[3] as Compiler.AST.Data.Token);
					if(id1 != null && id1.Name == "identifier" && true)
					{
						Compiler.C.Data.Node iexpr1 = Translate(forStatement[5] as Compiler.AST.Data.IntegerExpression);
						if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
						{
							Compiler.C.Data.Node iexpr2 = Translate(forStatement[7] as Compiler.AST.Data.IntegerExpression);
							if(iexpr2 != null && iexpr2.Name == "IntegerExpression" && true)
							{
								(Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(forStatement[10] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
								if(dcl3 != null && dcl3.Name == "Declaration" && true && f3 != null && f3.Name == "Function" && true && si3 != null && si3.Name == "Statement" && true)
								{
									return (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.ForStatement(false) { new Compiler.C.Data.Token() { Name = "for", Value = "for" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, intType1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "<=", Value = "<=" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "++", Value = "++" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
								}
							}
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.Type type)
		{
			Translate__type++;
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType" && true))
			{
				Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.IntType);
				if(t1 != null && t1.Name == "IntType" && true)
				{
					return new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.IntType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType" && true))
			{
				Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.RegisterType);
				if(t1 != null && t1.Name == "RegisterType" && true)
				{
					return new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.RegisterType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType" && true))
			{
				Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.BooleanType);
				if(t1 != null && t1.Name == "BooleanType" && true)
				{
					return new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.BooleanType };
				}
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "nothing" && true))
			{
				return new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } };
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntType intType)
		{
			Translate__intType++;
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "int", Value = "int" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "int", Value = "int" } };
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32" && true))
			{
				return new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" } };
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerExpression integerExpression)
		{
			Translate__integerExpression++;
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(integerExpression[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { id1 as Compiler.C.Data.Token };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "numeral" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.Token);
				if(s1 != null && s1.Name == "numeral" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.Token };
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
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "ModExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.ModExpression);
				if(s1 != null && s1.Name == "ModExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.ModExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "PowExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.PowExpression);
				if(s1 != null && s1.Name == "PowExpression" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.PowExpression };
				}
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "Call" && true))
			{
				Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.Call);
				if(s1 != null && s1.Name == "Call" && true)
				{
					return new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.Call };
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
			if(mulExpression != null && mulExpression.Name == "MulExpression" && (mulExpression.Count == 3 && mulExpression[0] != null && mulExpression[0].Name == "IntegerExpression" && true && mulExpression[1] != null && mulExpression[1].Name == "*" && true && mulExpression[2] != null && mulExpression[2].Name == "IntegerExpression" && true))
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

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ModExpression modExpression)
		{
			Translate__modExpression++;
			if(modExpression != null && modExpression.Name == "ModExpression" && (modExpression.Count == 3 && modExpression[0] != null && modExpression[0].Name == "IntegerExpression" && true && modExpression[1] != null && modExpression[1].Name == "%" && true && modExpression[2] != null && modExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(modExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(modExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.ModExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "%", Value = "%" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.PowExpression powExpression)
		{
			Translate__powExpression++;
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 3 && powExpression[0] != null && powExpression[0].Name == "IntegerExpression" && true && powExpression[1] != null && powExpression[1].Name == "^" && true && powExpression[2] != null && powExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(powExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(powExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.PowExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
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
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "identifier" && true))
			{
				Compiler.C.Data.Node id1 = Translate(booleanExpression[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { id1 as Compiler.C.Data.Token };
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
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IntegerNotEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IntegerNotEqExpression);
				if(s1 != null && s1.Name == "IntegerNotEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IntegerNotEqExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanNotEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanNotEqExpression);
				if(s1 != null && s1.Name == "BooleanNotEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanNotEqExpression };
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
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "LessThanOrEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.LessThanOrEqExpression);
				if(s1 != null && s1.Name == "LessThanOrEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.LessThanOrEqExpression };
				}
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "GreaterThanOrEqExpression" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.GreaterThanOrEqExpression);
				if(s1 != null && s1.Name == "GreaterThanOrEqExpression" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.GreaterThanOrEqExpression };
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
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "Call" && true))
			{
				Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.Call);
				if(s1 != null && s1.Name == "Call" && true)
				{
					return new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.Call };
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DirectBitValue directBitValue)
		{
			Translate__directBitValue++;
			if(directBitValue != null && directBitValue.Name == "DirectBitValue" && (directBitValue.Count == 7 && directBitValue[0] != null && directBitValue[0].Name == "RegisterType" && true && directBitValue[1] != null && directBitValue[1].Name == "(" && true && directBitValue[2] != null && directBitValue[2].Name == "IntegerExpression" && true && directBitValue[3] != null && directBitValue[3].Name == ")" && true && directBitValue[4] != null && directBitValue[4].Name == "{" && true && directBitValue[5] != null && directBitValue[5].Name == "IntegerExpression" && true && directBitValue[6] != null && directBitValue[6].Name == "}" && true))
			{
				Compiler.C.Data.Node regType1 = Translate(directBitValue[0] as Compiler.AST.Data.RegisterType);
				if(regType1 != null && regType1.Name == "RegisterType" && true)
				{
					Compiler.C.Data.Node iexpr3 = Translate(directBitValue[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
					{
						Compiler.C.Data.Node iexpr4 = Translate(directBitValue[5] as Compiler.AST.Data.IntegerExpression);
						if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
						{
							return new Compiler.C.Data.DirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
						}
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IndirectBitValue indirectBitValue)
		{
			Translate__indirectBitValue++;
			if(indirectBitValue != null && indirectBitValue.Name == "IndirectBitValue" && (indirectBitValue.Count == 4 && indirectBitValue[0] != null && indirectBitValue[0].Name == "identifier" && true && indirectBitValue[1] != null && indirectBitValue[1].Name == "{" && true && indirectBitValue[2] != null && indirectBitValue[2].Name == "IntegerExpression" && true && indirectBitValue[3] != null && indirectBitValue[3].Name == "}" && true))
			{
				Compiler.C.Data.Node id1 = Translate(indirectBitValue[0] as Compiler.AST.Data.Token);
				if(id1 != null && id1.Name == "identifier" && true)
				{
					Compiler.C.Data.Node iexpr1 = Translate(indirectBitValue[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr1 != null && iexpr1.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.IndirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
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
			if(integerEqExpression != null && integerEqExpression.Name == "IntegerEqExpression" && (integerEqExpression.Count == 3 && integerEqExpression[0] != null && integerEqExpression[0].Name == "IntegerExpression" && true && integerEqExpression[1] != null && integerEqExpression[1].Name == "==" && true && integerEqExpression[2] != null && integerEqExpression[2].Name == "IntegerExpression" && true))
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
			if(booleanEqExpression != null && booleanEqExpression.Name == "BooleanEqExpression" && (booleanEqExpression.Count == 3 && booleanEqExpression[0] != null && booleanEqExpression[0].Name == "BooleanExpression" && true && booleanEqExpression[1] != null && booleanEqExpression[1].Name == "==" && true && booleanEqExpression[2] != null && booleanEqExpression[2].Name == "BooleanExpression" && true))
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

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerNotEqExpression integerNotEqExpression)
		{
			Translate__integerNotEqExpression++;
			if(integerNotEqExpression != null && integerNotEqExpression.Name == "IntegerNotEqExpression" && (integerNotEqExpression.Count == 3 && integerNotEqExpression[0] != null && integerNotEqExpression[0].Name == "IntegerExpression" && true && integerNotEqExpression[1] != null && integerNotEqExpression[1].Name == "!=" && true && integerNotEqExpression[2] != null && integerNotEqExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(integerNotEqExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(integerNotEqExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.IntegerNotEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "!=", Value = "!=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanNotEqExpression booleanNotEqExpression)
		{
			Translate__booleanNotEqExpression++;
			if(booleanNotEqExpression != null && booleanNotEqExpression.Name == "BooleanNotEqExpression" && (booleanNotEqExpression.Count == 3 && booleanNotEqExpression[0] != null && booleanNotEqExpression[0].Name == "BooleanExpression" && true && booleanNotEqExpression[1] != null && booleanNotEqExpression[1].Name == "!=" && true && booleanNotEqExpression[2] != null && booleanNotEqExpression[2].Name == "BooleanExpression" && true))
			{
				Compiler.C.Data.Node bexpr3 = Translate(booleanNotEqExpression[0] as Compiler.AST.Data.BooleanExpression);
				if(bexpr3 != null && bexpr3.Name == "BooleanExpression" && true)
				{
					Compiler.C.Data.Node bexpr4 = Translate(booleanNotEqExpression[2] as Compiler.AST.Data.BooleanExpression);
					if(bexpr4 != null && bexpr4.Name == "BooleanExpression" && true)
					{
						return new Compiler.C.Data.BooleanNotEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "!=", Value = "!=" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
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

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.LessThanOrEqExpression lessThanOrEqExpression)
		{
			Translate__lessThanOrEqExpression++;
			if(lessThanOrEqExpression != null && lessThanOrEqExpression.Name == "LessThanOrEqExpression" && (lessThanOrEqExpression.Count == 3 && lessThanOrEqExpression[0] != null && lessThanOrEqExpression[0].Name == "IntegerExpression" && true && lessThanOrEqExpression[1] != null && lessThanOrEqExpression[1].Name == "<=" && true && lessThanOrEqExpression[2] != null && lessThanOrEqExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(lessThanOrEqExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(lessThanOrEqExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.LessThanOrEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "<=", Value = "<=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
					}
				}
			}
			throw new System.Exception();
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.GreaterThanOrEqExpression greaterThanOrEqExpression)
		{
			Translate__greaterThanOrEqExpression++;
			if(greaterThanOrEqExpression != null && greaterThanOrEqExpression.Name == "GreaterThanOrEqExpression" && (greaterThanOrEqExpression.Count == 3 && greaterThanOrEqExpression[0] != null && greaterThanOrEqExpression[0].Name == "IntegerExpression" && true && greaterThanOrEqExpression[1] != null && greaterThanOrEqExpression[1].Name == ">=" && true && greaterThanOrEqExpression[2] != null && greaterThanOrEqExpression[2].Name == "IntegerExpression" && true))
			{
				Compiler.C.Data.Node iexpr3 = Translate(greaterThanOrEqExpression[0] as Compiler.AST.Data.IntegerExpression);
				if(iexpr3 != null && iexpr3.Name == "IntegerExpression" && true)
				{
					Compiler.C.Data.Node iexpr4 = Translate(greaterThanOrEqExpression[2] as Compiler.AST.Data.IntegerExpression);
					if(iexpr4 != null && iexpr4.Name == "IntegerExpression" && true)
					{
						return new Compiler.C.Data.GreaterThanOrEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ">=", Value = ">=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
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

		public Compiler.C.Data.Node Insert(Compiler.C.Data.Node left, Compiler.C.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name) {
			    return right.Accept(new Compiler.C.Visitors.CloneVisitor());
			}
			var leftClone = left.Accept(new Compiler.C.Visitors.CloneVisitor());
			Compiler.C.Data.Node Insertion = InsertAux(leftClone, right);
			return (Insertion == null ? null : leftClone);
		}

		public Compiler.C.Data.Node InsertAux(Compiler.C.Data.Node left, Compiler.C.Data.Node right)
		{
			for (int i = 0; i < left.Count;  i++)
			{
			    if(left[i].IsPlaceholder && left[i].Name == right.Name) {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else {
			        Compiler.C.Data.Node leftUpdated = InsertAux(left[i], right);
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
			System.Console.WriteLine("Translate__aST: "+Translate__aST);
			System.Console.WriteLine("Translatea__globalStatement_declaration_function_statement: "+Translatea__globalStatement_declaration_function_statement);
			System.Console.WriteLine("Translatea__compoundGlobalStatement_declaration_function_statement: "+Translatea__compoundGlobalStatement_declaration_function_statement);
			System.Console.WriteLine("Translatea__interrupt_declaration_function_statement: "+Translatea__interrupt_declaration_function_statement);
			System.Console.WriteLine("Translatea__function_declaration_function1_statement: "+Translatea__function_declaration_function1_statement);
			System.Console.WriteLine("Translate__formalParameters: "+Translate__formalParameters);
			System.Console.WriteLine("Translate__formalParameter: "+Translate__formalParameter);
			System.Console.WriteLine("Translate__compoundFormalParameter: "+Translate__compoundFormalParameter);
			System.Console.WriteLine("Translatea__statement_declaration_function_statement1: "+Translatea__statement_declaration_function_statement1);
			System.Console.WriteLine("Translatea__compoundStatement_declaration_function_statement: "+Translatea__compoundStatement_declaration_function_statement);
			System.Console.WriteLine("Translate__integerDeclaration: "+Translate__integerDeclaration);
			System.Console.WriteLine("Translate__integerArrayDeclaration: "+Translate__integerArrayDeclaration);
			System.Console.WriteLine("Translate__integerArrayDeclarationInit: "+Translate__integerArrayDeclarationInit);
			System.Console.WriteLine("Translate__integerExpressionListArgs: "+Translate__integerExpressionListArgs);
			System.Console.WriteLine("Translate__booleanArrayDeclaration: "+Translate__booleanArrayDeclaration);
			System.Console.WriteLine("Translate__registerArrayDeclaration: "+Translate__registerArrayDeclaration);
			System.Console.WriteLine("Translate__integerDeclarationInit: "+Translate__integerDeclarationInit);
			System.Console.WriteLine("Translate__integerAssignment: "+Translate__integerAssignment);
			System.Console.WriteLine("Translate__booleanDeclaration: "+Translate__booleanDeclaration);
			System.Console.WriteLine("Translate__booleanDeclarationInit: "+Translate__booleanDeclarationInit);
			System.Console.WriteLine("Translate__booleanType: "+Translate__booleanType);
			System.Console.WriteLine("Translate__booleanAssignment: "+Translate__booleanAssignment);
			System.Console.WriteLine("Translate__directBitAssignment: "+Translate__directBitAssignment);
			System.Console.WriteLine("Translate__registerType: "+Translate__registerType);
			System.Console.WriteLine("Translate__indirectBitAssignment: "+Translate__indirectBitAssignment);
			System.Console.WriteLine("Translate__registerDeclaration: "+Translate__registerDeclaration);
			System.Console.WriteLine("Translate__registerDeclarationInit: "+Translate__registerDeclarationInit);
			System.Console.WriteLine("Translate__registerAssignment: "+Translate__registerAssignment);
			System.Console.WriteLine("Translate__registerExpression: "+Translate__registerExpression);
			System.Console.WriteLine("Translate__integerReturn: "+Translate__integerReturn);
			System.Console.WriteLine("Translate__booleanReturn: "+Translate__booleanReturn);
			System.Console.WriteLine("Translate__registerReturn: "+Translate__registerReturn);
			System.Console.WriteLine("Translate__call: "+Translate__call);
			System.Console.WriteLine("Translate__expressionList: "+Translate__expressionList);
			System.Console.WriteLine("Translate__expressionListArgs: "+Translate__expressionListArgs);
			System.Console.WriteLine("Translate__registerLiteral: "+Translate__registerLiteral);
			System.Console.WriteLine("Translatea__ifStatement_declaration_function_statement: "+Translatea__ifStatement_declaration_function_statement);
			System.Console.WriteLine("Translatea__ifElseStatement_declaration_function_statement: "+Translatea__ifElseStatement_declaration_function_statement);
			System.Console.WriteLine("Translatea__whileStatement_declaration_function_statement: "+Translatea__whileStatement_declaration_function_statement);
			System.Console.WriteLine("Translatea__forStatement_declaration_function_statement: "+Translatea__forStatement_declaration_function_statement);
			System.Console.WriteLine("Translate__type: "+Translate__type);
			System.Console.WriteLine("Translate__intType: "+Translate__intType);
			System.Console.WriteLine("Translate__integerExpression: "+Translate__integerExpression);
			System.Console.WriteLine("Translate__integerParenthesisExpression: "+Translate__integerParenthesisExpression);
			System.Console.WriteLine("Translate__addExpression: "+Translate__addExpression);
			System.Console.WriteLine("Translate__subExpression: "+Translate__subExpression);
			System.Console.WriteLine("Translate__mulExpression: "+Translate__mulExpression);
			System.Console.WriteLine("Translate__divExpression: "+Translate__divExpression);
			System.Console.WriteLine("Translate__modExpression: "+Translate__modExpression);
			System.Console.WriteLine("Translate__powExpression: "+Translate__powExpression);
			System.Console.WriteLine("Translate__booleanExpression: "+Translate__booleanExpression);
			System.Console.WriteLine("Translate__directBitValue: "+Translate__directBitValue);
			System.Console.WriteLine("Translate__indirectBitValue: "+Translate__indirectBitValue);
			System.Console.WriteLine("Translate__booleanParenthesisExpression: "+Translate__booleanParenthesisExpression);
			System.Console.WriteLine("Translate__integerEqExpression: "+Translate__integerEqExpression);
			System.Console.WriteLine("Translate__booleanEqExpression: "+Translate__booleanEqExpression);
			System.Console.WriteLine("Translate__integerNotEqExpression: "+Translate__integerNotEqExpression);
			System.Console.WriteLine("Translate__booleanNotEqExpression: "+Translate__booleanNotEqExpression);
			System.Console.WriteLine("Translate__lessThanExpression: "+Translate__lessThanExpression);
			System.Console.WriteLine("Translate__greaterThanExpression: "+Translate__greaterThanExpression);
			System.Console.WriteLine("Translate__lessThanOrEqExpression: "+Translate__lessThanOrEqExpression);
			System.Console.WriteLine("Translate__greaterThanOrEqExpression: "+Translate__greaterThanOrEqExpression);
			System.Console.WriteLine("Translate__notExpression: "+Translate__notExpression);
			System.Console.WriteLine("Translate__andExpression: "+Translate__andExpression);
			System.Console.WriteLine("Translate__orExpression: "+Translate__orExpression);
		}
	}
}
