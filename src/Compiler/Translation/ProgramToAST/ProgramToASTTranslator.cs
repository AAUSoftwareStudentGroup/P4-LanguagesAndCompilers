namespace Compiler.Translation.ProgramToAST
{
	public class ProgramToASTTranslator 
	{
		public Compiler.Error.RuleError RuleError { get; set; } = new Compiler.Error.RuleError();
		public System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.AST.Data.Node> Relationp { get; set; } = new System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.AST.Data.Node>();
		public System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.Translation.SymbolTable.Data.Node> Relationq { get; set; } = new System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.Translation.SymbolTable.Data.Node>();
		public System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.Parsing.Data.Node> Relationw { get; set; } = new System.Collections.Generic.Dictionary<Compiler.Parsing.Data.Node,Compiler.Parsing.Data.Node>();
		public System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.Translation.SymbolTable.Data.Node> Relations { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.Translation.SymbolTable.Data.Node>();
		public System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.Translation.SymbolTable.Data.Node> Relationf { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.Translation.SymbolTable.Data.Node>();
		public System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.AST.Data.Node> Relationt { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node),Compiler.AST.Data.Node>();
		public System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),(Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)> Relation { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node),(Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)>();
		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Program program)
		{
			bool _isMatching = false;
			var key = (program);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { program.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(program != null && program.Name == "Program")
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "AST" }, "Program : p -> : p ast", (program));
			    Compiler.Translation.SymbolTable.Data.Node s = Translatef(program as Compiler.Parsing.Data.Program, new Compiler.Translation.SymbolTable.Data.SymbolTable(false) { new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } });
			    _isMatching = s != null && s.Name == "SymbolTable";
			    if(s != null && !_isMatching)
			    {
			        WrongPatternf((s), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node ast, Compiler.Translation.SymbolTable.Data.Node symbolTable) = Translate(program as Compiler.Parsing.Data.Program, s as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = ast != null && ast.Name == "AST" && symbolTable != null && symbolTable.Name == "SymbolTable";
			        if(ast != null && symbolTable != null && !_isMatching)
			        {
			            WrongPattern((ast, symbolTable), new System.Collections.Generic.List<string>() { "AST", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = ast as Compiler.AST.Data.AST;
			            RuleEndp(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndp(false);
			}
			RulesFailedp((program));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token identifier, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (identifier, symbolTable);
			if(Relations.ContainsKey(key))
			{
			    var value = Relations[key];
			    RuleStarts(new System.Collections.Generic.List<string>() { identifier.Name, symbolTable.Name }, "", key);
			    RuleEnds(true, false, value);
			    return value;
			}
			if(identifier != null && identifier.Name == "identifier" && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id SymbolTable [ Declarations : vars ] ] -> : s dcl", (identifier, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Declarations);
			    _isMatching = dcl != null && dcl.Name == "Declaration";
			    if(dcl != null && !_isMatching)
			    {
			        WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			Compiler.Parsing.Data.Token _return = identifier;
			if(_return != null && _return.Name == "return" && symbolTable != null && symbolTable.Name == "SymbolTable" && (symbolTable.Count == 1 && symbolTable[0] != null && symbolTable[0].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ return SymbolTable [ Declarations : vars ] ] -> : s dcl", (_return, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node dcl = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable[0] as Compiler.Translation.SymbolTable.Data.Declarations);
			    _isMatching = dcl != null && dcl.Name == "Declaration";
			    if(dcl != null && !_isMatching)
			    {
			        WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			RulesFaileds((identifier, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translates(Compiler.Parsing.Data.Token _return, Compiler.Translation.SymbolTable.Data.Declarations declarations)
		{
			bool _isMatching = false;
			var key = (_return, declarations);
			if(Relations.ContainsKey(key))
			{
			    var value = Relations[key];
			    RuleStarts(new System.Collections.Generic.List<string>() { _return.Name, declarations.Name }, "", key);
			    RuleEnds(true, false, value);
			    return value;
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 1 && declarations[0] != null && declarations[0].Name == "EPSILON"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ return Declarations [ EPSILON ] ] -> : s Declaration [ EPSILON ]", (_return, declarations));
			    var _result = new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEnds(true, true, _result);
			    return _result;
			    RuleEnds(false);
			}
			Compiler.Parsing.Data.Token identifier = _return;
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 1 && declarations[0] != null && declarations[0].Name == "EPSILON"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier Declarations [ EPSILON ] ] -> : s Declaration [ EPSILON ]", (identifier, declarations));
			    var _result = new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEnds(true, true, _result);
			    return _result;
			    RuleEnds(false);
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id1 Declarations [ Declaration : dcl [ Variable [ Type identifier : id2 ] ] Declarations ] ] -> : s dcl", (identifier, declarations));
			    if(AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
			    {
			        var _result = declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id1 Declarations [ Declaration [ Variable [ Type identifier : id2 ] ] Declarations : dcls ] ] -> : s dcl", (identifier, declarations));
			    if(!AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
			    {
			        Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
			        _isMatching = dcl != null && dcl.Name == "Declaration";
			        if(dcl != null && !_isMatching)
			        {
			            WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			            RuleEnds(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnds(false);
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "return")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id1 Declarations [ Declaration [ Variable [ Type return ] ] Declarations : dcls ] ] -> : s dcl", (identifier, declarations));
			    Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
			    _isMatching = dcl != null && dcl.Name == "Declaration";
			    if(dcl != null && !_isMatching)
			    {
			        WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id1 Declarations [ Declaration : dcl [ Function [ ReturnType identifier : id2 Parameters ] ] Declarations ] ] -> : s dcl", (identifier, declarations));
			    if(AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
			    {
			        var _result = declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			if(identifier != null && identifier.Name == "identifier" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ identifier : id1 Declarations [ Declaration [ Function [ ReturnType identifier : id2 Parameters ] ] Declarations : dcls ] ] -> : s dcl", (identifier, declarations));
			    if(!AreEqual((identifier as Compiler.Parsing.Data.Token), (declarations[0][0][1] as Compiler.Translation.SymbolTable.Data.Token)))
			    {
			        Compiler.Translation.SymbolTable.Data.Node dcl = Translates(identifier as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
			        _isMatching = dcl != null && dcl.Name == "Declaration";
			        if(dcl != null && !_isMatching)
			        {
			            WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			            RuleEnds(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnds(false);
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "return")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ return Declarations [ Declaration : dcl [ Variable [ Type return ] ] Declarations ] ] -> : s dcl", (_return, declarations));
			    var _result = declarations[0] as Compiler.Translation.SymbolTable.Data.Declaration;
			    RuleEnds(true, true, _result);
			    return _result;
			    RuleEnds(false);
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Variable" && (declarations[0][0].Count == 2 && declarations[0][0][0] != null && declarations[0][0][0].Name == "Type" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ return : r Declarations [ Declaration [ Variable [ Type identifier ] ] Declarations : dcls ] ] -> : s dcl", (_return, declarations));
			    Compiler.Translation.SymbolTable.Data.Node dcl = Translates(_return as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
			    _isMatching = dcl != null && dcl.Name == "Declaration";
			    if(dcl != null && !_isMatching)
			    {
			        WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			if(_return != null && _return.Name == "return" && declarations != null && declarations.Name == "Declarations" && (declarations.Count == 2 && declarations[0] != null && declarations[0].Name == "Declaration" && (declarations[0].Count == 1 && declarations[0][0] != null && declarations[0][0].Name == "Function" && (declarations[0][0].Count == 3 && declarations[0][0][0] != null && declarations[0][0][0].Name == "ReturnType" && declarations[0][0][1] != null && declarations[0][0][1].Name == "identifier" && declarations[0][0][2] != null && declarations[0][0][2].Name == "Parameters")) && declarations[1] != null && declarations[1].Name == "Declarations"))
			{
			    RuleStarts(new System.Collections.Generic.List<string>() { "Declaration" }, "[ return : r Declarations [ Declaration [ Function [ ReturnType identifier Parameters ] ] Declarations : dcls ] ] -> : s dcl", (_return, declarations));
			    Compiler.Translation.SymbolTable.Data.Node dcl = Translates(_return as Compiler.Parsing.Data.Token, declarations[1] as Compiler.Translation.SymbolTable.Data.Declarations);
			    _isMatching = dcl != null && dcl.Name == "Declaration";
			    if(dcl != null && !_isMatching)
			    {
			        WrongPatterns((dcl), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = dcl as Compiler.Translation.SymbolTable.Data.Declaration;
			        RuleEnds(true, true, _result);
			        return _result;
			    }
			    RuleEnds(false);
			}
			RulesFaileds((_return, declarations));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (program, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { program.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON") && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Program [ GlobalStatements [ EPSILON ] eof ] SymbolTable : s ] -> : f s", (program, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Program [ GlobalStatements : stms eof ] SymbolTable : s ] -> : f s1", (program, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			RulesFailedf((program, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (globalStatements, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { globalStatements.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements" && (globalStatements[1].Count == 1 && globalStatements[1][0] != null && globalStatements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ GlobalStatements [ GlobalStatement : stm GlobalStatements [ EPSILON ] ] SymbolTable : s ] -> : f s1", (globalStatements, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ GlobalStatements [ GlobalStatement : stm GlobalStatements : stmsp ] SymbolTable : s ] -> : f s2", (globalStatements, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node s2 = Translatef(globalStatements[1] as Compiler.Parsing.Data.GlobalStatements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = s2 != null && s2.Name == "SymbolTable";
			        if(s2 != null && !_isMatching)
			        {
			            WrongPatternf((s2), new System.Collections.Generic.List<string>() { "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = s2 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			            RuleEndf(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndf(false);
			}
			RulesFailedf((globalStatements, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (globalStatement, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { globalStatement.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ GlobalStatement [ Interrupt : inter ] SymbolTable : s ] -> : f s", (globalStatement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ GlobalStatement [ Statement : stm ] SymbolTable : s ] -> : f s1", (globalStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			RulesFailedf((globalStatement, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (interrupt, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { interrupt.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && interrupt[1] != null && interrupt[1].Name == "(" && interrupt[2] != null && interrupt[2].Name == "numeral" && interrupt[3] != null && interrupt[3].Name == ")" && interrupt[4] != null && interrupt[4].Name == "indent" && interrupt[5] != null && interrupt[5].Name == "Statements" && interrupt[6] != null && interrupt[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Interrupt [ interrupt ( numeral : i ) indent Statements : stms dedent ] SymbolTable : s ] -> : f s", (interrupt, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			RulesFailedf((interrupt, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (statements, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { statements.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statements [ Statement : stm Statements [ EPSILON ] ] SymbolTable : s ] -> : f s1", (statements, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statements [ Statement : stm Statements : stmsp ] SymbolTable : s ] -> : f s2", (statements, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node s2 = Translatef(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = s2 != null && s2.Name == "SymbolTable";
			        if(s2 != null && !_isMatching)
			        {
			            WrongPatternf((s2), new System.Collections.Generic.List<string>() { "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = s2 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			            RuleEndf(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndf(false);
			}
			RulesFailedf((statements, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (statement, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { statement.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ newline ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> : f s1", (statement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ IdentifierStatement ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ReturnStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ ReturnStatement ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "InterruptStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ InterruptStatement ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ IfStatement : ifStm ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ WhileStatement : whileStm ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ ForStatement : forStm ] SymbolTable : s ] -> : f s", (statement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ Statement [ RegisterStatement : regStm ] SymbolTable : s ] -> : f s1", (statement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node s1 = Translatef(statement[0] as Compiler.Parsing.Data.RegisterStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = s1 != null && s1.Name == "SymbolTable";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPatternf((s1), new System.Collections.Generic.List<string>() { "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = s1 as Compiler.Translation.SymbolTable.Data.SymbolTable;
			        RuleEndf(true, true, _result);
			        return _result;
			    }
			    RuleEndf(false);
			}
			RulesFailedf((statement, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (identifierDeclaration, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { identifierDeclaration.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ IntType identifier Definition [ = DefinitionAssign [ Expression newline ] ] ] SymbolTable : s ] -> : f s", (identifierDeclaration, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ IntType : intType identifier : id Definition [ ( FormalParameters : params ) indent Statements dedent ] ] SymbolTable : s ] -> : f s <- Declarations [ Declaration [ Function [ ReturnType [ Type [ it ] ] id1 p ] ] % Declarations [ EPSILON ] ]", (identifierDeclaration, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node it = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			        _isMatching = it != null && it.Name == "IntType";
			        if(it != null && !_isMatching)
			        {
			            WrongPatternq((it), new System.Collections.Generic.List<string>() { "IntType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternq((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters);
			                _isMatching = p != null && p.Name == "Parameters";
			                if(p != null && !_isMatching)
			                {
			                    WrongPatternq((p), new System.Collections.Generic.List<string>() { "Parameters" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { it as Compiler.Translation.SymbolTable.Data.IntType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
			                    RuleEndf(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ IntType identifier Definition [ newline ] ] SymbolTable : s ] -> : f s", (identifierDeclaration, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType identifier Definition [ = DefinitionAssign [ Expression newline ] ] ] SymbolTable : s ] -> : f s", (identifierDeclaration, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType : boolType identifier : id Definition [ ( FormalParameters : params ) indent Statements dedent ] ] SymbolTable : s ] -> : f s <- Declarations [ Declaration [ Function [ ReturnType [ Type [ t ] ] id1 p ] ] % Declarations [ EPSILON ] ]", (identifierDeclaration, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			        _isMatching = t != null && t.Name == "BooleanType";
			        if(t != null && !_isMatching)
			        {
			            WrongPatternq((t), new System.Collections.Generic.List<string>() { "BooleanType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternq((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters);
			                _isMatching = p != null && p.Name == "Parameters";
			                if(p != null && !_isMatching)
			                {
			                    WrongPatternq((p), new System.Collections.Generic.List<string>() { "Parameters" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t as Compiler.Translation.SymbolTable.Data.BooleanType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
			                    RuleEndf(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType identifier Definition [ newline ] ] SymbolTable : s ] -> : f s", (identifierDeclaration, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 8 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "nothing" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "(" && identifierDeclaration[3] != null && identifierDeclaration[3].Name == "FormalParameters" && identifierDeclaration[4] != null && identifierDeclaration[4].Name == ")" && identifierDeclaration[5] != null && identifierDeclaration[5].Name == "indent" && identifierDeclaration[6] != null && identifierDeclaration[6].Name == "Statements" && identifierDeclaration[7] != null && identifierDeclaration[7].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ IdentifierDeclaration [ nothing : n identifier : id ( FormalParameters : params ) indent Statements dedent ] SymbolTable : s ] -> : f s <- Declarations [ Declaration [ Function [ ReturnType [ t ] id1 p ] ] % Declarations [ EPSILON ] ]", (identifierDeclaration, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
			        _isMatching = t != null && t.Name == "nothing";
			        if(t != null && !_isMatching)
			        {
			            WrongPatternq((t), new System.Collections.Generic.List<string>() { "nothing" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternq((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node p = Translateq(identifierDeclaration[3] as Compiler.Parsing.Data.FormalParameters);
			                _isMatching = p != null && p.Name == "Parameters";
			                if(p != null && !_isMatching)
			                {
			                    WrongPatternq((p), new System.Collections.Generic.List<string>() { "Parameters" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { t as Compiler.Translation.SymbolTable.Data.Token }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
			                    RuleEndf(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEndf(false);
			}
			RulesFailedf((identifierDeclaration, symbolTable));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParameters formalParameters)
		{
			bool _isMatching = false;
			var key = (formalParameters);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { formalParameters.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Parameters" }, "FormalParameters [ EPSILON ] -> : q Parameters [ EPSILON ]", (formalParameters));
			    var _result = new Compiler.Translation.SymbolTable.Data.Parameters(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Parameters" }, "FormalParameters [ FormalParameter : p1 FormalParametersP : p2 ] -> : q Parameters [ p3 p4 ]", (formalParameters));
			    Compiler.Translation.SymbolTable.Data.Node p3 = Translateq(formalParameters[0] as Compiler.Parsing.Data.FormalParameter);
			    _isMatching = p3 != null && p3.Name == "Parameter";
			    if(p3 != null && !_isMatching)
			    {
			        WrongPatternq((p3), new System.Collections.Generic.List<string>() { "Parameter" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node p4 = Translateq(formalParameters[1] as Compiler.Parsing.Data.FormalParametersP);
			        _isMatching = p4 != null && p4.Name == "ParametersP";
			        if(p4 != null && !_isMatching)
			        {
			            WrongPatternq((p4), new System.Collections.Generic.List<string>() { "ParametersP" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.Translation.SymbolTable.Data.Parameters(false) { p3 as Compiler.Translation.SymbolTable.Data.Parameter, p4 as Compiler.Translation.SymbolTable.Data.ParametersP };
			            RuleEndq(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndq(false);
			}
			RulesFailedq((formalParameters));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParametersP formalParametersP)
		{
			bool _isMatching = false;
			var key = (formalParametersP);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { formalParametersP.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 1 && formalParametersP[0] != null && formalParametersP[0].Name == "EPSILON"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "ParametersP" }, "FormalParametersP [ EPSILON ] -> : q ParametersP [ EPSILON ]", (formalParametersP));
			    var _result = new Compiler.Translation.SymbolTable.Data.ParametersP(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "ParametersP" }, "FormalParametersP [ , FormalParameter : p1 FormalParametersP : p2 ] -> : q ParametersP [ , p3 p4 ]", (formalParametersP));
			    Compiler.Translation.SymbolTable.Data.Node p3 = Translateq(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter);
			    _isMatching = p3 != null && p3.Name == "Parameter";
			    if(p3 != null && !_isMatching)
			    {
			        WrongPatternq((p3), new System.Collections.Generic.List<string>() { "Parameter" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node p4 = Translateq(formalParametersP[2] as Compiler.Parsing.Data.FormalParametersP);
			        _isMatching = p4 != null && p4.Name == "ParametersP";
			        if(p4 != null && !_isMatching)
			        {
			            WrongPatternq((p4), new System.Collections.Generic.List<string>() { "ParametersP" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.Translation.SymbolTable.Data.ParametersP(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = ",", Value = "," }, p3 as Compiler.Translation.SymbolTable.Data.Parameter, p4 as Compiler.Translation.SymbolTable.Data.ParametersP };
			            RuleEndq(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndq(false);
			}
			RulesFailedq((formalParametersP));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.FormalParameter formalParameter)
		{
			bool _isMatching = false;
			var key = (formalParameter);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { formalParameter.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && formalParameter[1] != null && formalParameter[1].Name == "identifier"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Parameter" }, "FormalParameter [ Type : type identifier : id ] -> : q Parameter [ t id1 ]", (formalParameter));
			    Compiler.Translation.SymbolTable.Data.Node t = Translateq(formalParameter[0] as Compiler.Parsing.Data.Type);
			    _isMatching = t != null && t.Name == "Type";
			    if(t != null && !_isMatching)
			    {
			        WrongPatternq((t), new System.Collections.Generic.List<string>() { "Type" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(formalParameter[1] as Compiler.Parsing.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPatternq((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.Translation.SymbolTable.Data.Parameter(false) { t as Compiler.Translation.SymbolTable.Data.Type, id1 as Compiler.Translation.SymbolTable.Data.Token };
			            RuleEndq(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndq(false);
			}
			RulesFailedq((formalParameter));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.Type type)
		{
			bool _isMatching = false;
			var key = (type);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { type.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Type" }, "Type [ IntType : t ] -> : q Type [ t1 ]", (type));
			    Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternq((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.IntType };
			        RuleEndq(true, true, _result);
			        return _result;
			    }
			    RuleEndq(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Type" }, "Type [ BooleanType : t ] -> : q Type [ t1 ]", (type));
			    Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternq((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.BooleanType };
			        RuleEndq(true, true, _result);
			        return _result;
			    }
			    RuleEndq(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "Type" }, "Type [ RegisterType : t ] -> : q Type [ t1 ]", (type));
			    Compiler.Translation.SymbolTable.Data.Node t1 = Translateq(type[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternq((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.Translation.SymbolTable.Data.Type(false) { t1 as Compiler.Translation.SymbolTable.Data.RegisterType };
			        RuleEndq(true, true, _result);
			        return _result;
			    }
			    RuleEndq(false);
			}
			RulesFailedq((type));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translatef(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (registerStatement, symbolTable);
			if(Relationf.ContainsKey(key))
			{
			    var value = Relationf[key];
			    RuleStartf(new System.Collections.Generic.List<string>() { registerStatement.Name, symbolTable.Name }, "", key);
			    RuleEndf(true, false, value);
			    return value;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 9 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && registerStatement[1][8] != null && registerStatement[1][8].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ RegisterStatement [ RegisterType RegisterOperation [ ( Expression ) { Expression } = Expression newline ] ] SymbolTable : s ] -> : f s", (registerStatement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ RegisterStatement [ RegisterType RegisterOperation [ identifier Definition [ = DefinitionAssign [ Expression newline ] ] ] ] SymbolTable : s ] -> : f s", (registerStatement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ RegisterStatement [ RegisterType RegisterOperation [ identifier Definition [ = DefinitionAssign [ Expression newline ] ] ] ] SymbolTable : s ] -> : f s", (registerStatement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 1 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ RegisterStatement [ RegisterType RegisterOperation [ identifier Definition [ newline ] ] ] SymbolTable : s ] -> : f s", (registerStatement, symbolTable));
			    var _result = symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable;
			    RuleEndf(true, true, _result);
			    return _result;
			    RuleEndf(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 6 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "(" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "FormalParameters" && registerStatement[1][1][2] != null && registerStatement[1][1][2].Name == ")" && registerStatement[1][1][3] != null && registerStatement[1][1][3].Name == "indent" && registerStatement[1][1][4] != null && registerStatement[1][1][4].Name == "Statements" && registerStatement[1][1][5] != null && registerStatement[1][1][5].Name == "dedent"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartf(new System.Collections.Generic.List<string>() { "SymbolTable" }, "[ RegisterStatement [ RegisterType : regType RegisterOperation [ identifier : id Definition [ ( FormalParameters : params ) indent Statements dedent ] ] ] SymbolTable : s ] -> : f s <- Declarations [ Declaration [ Function [ ReturnType [ Type [ t ] ] id1 p ] ] % Declarations [ EPSILON ] ]", (registerStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			        _isMatching = t != null && t.Name == "RegisterType";
			        if(t != null && !_isMatching)
			        {
			            WrongPatternq((t), new System.Collections.Generic.List<string>() { "RegisterType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.Translation.SymbolTable.Data.Node id1 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternq((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node p = Translateq(registerStatement[1][1][1] as Compiler.Parsing.Data.FormalParameters);
			                _isMatching = p != null && p.Name == "Parameters";
			                if(p != null && !_isMatching)
			                {
			                    WrongPatternq((p), new System.Collections.Generic.List<string>() { "Parameters" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Function(false) { new Compiler.Translation.SymbolTable.Data.ReturnType(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t as Compiler.Translation.SymbolTable.Data.RegisterType } }, id1 as Compiler.Translation.SymbolTable.Data.Token, p as Compiler.Translation.SymbolTable.Data.Parameters } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable;
			                    RuleEndf(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEndf(false);
			}
			RulesFailedf((registerStatement, symbolTable));
			return (null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Program program, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (program, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { program.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && (program[0].Count == 1 && program[0][0] != null && program[0][0].Name == "EPSILON") && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "AST", "SymbolTable" }, "[ Program [ GlobalStatements [ EPSILON ] eof ] SymbolTable : s ] -> [ AST [ eof ] s ]", (program, symbolTable));
			    var _result = (new Compiler.AST.Data.AST(false) { new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(program != null && program.Name == "Program" && (program.Count == 2 && program[0] != null && program[0].Name == "GlobalStatements" && program[1] != null && program[1].Name == "eof") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "AST", "SymbolTable" }, "[ Program [ GlobalStatements : stms eof ] SymbolTable : s ] -> [ AST [ stm eof ] s1 ]", (program, symbolTable));
			    (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(program[0] as Compiler.Parsing.Data.GlobalStatements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm != null && stm.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm, s1), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.AST(false) { stm as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.Token() { Name = "eof", Value = "eof" } }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((program, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatements globalStatements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (globalStatements, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { globalStatements.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements" && (globalStatements[1].Count == 1 && globalStatements[1][0] != null && globalStatements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatements [ GlobalStatement : stm GlobalStatements [ EPSILON ] ] SymbolTable : s ] -> [ stm1 s1 ]", (globalStatements, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (stm1 as Compiler.AST.Data.GlobalStatement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(globalStatements != null && globalStatements.Name == "GlobalStatements" && (globalStatements.Count == 2 && globalStatements[0] != null && globalStatements[0].Name == "GlobalStatement" && globalStatements[1] != null && globalStatements[1].Name == "GlobalStatements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatements [ GlobalStatement : stm GlobalStatements : stmsp ] SymbolTable : s ] -> [ GlobalStatement [ CompoundGlobalStatement [ stm1 newline stm2 ] ] s2 ]", (globalStatements, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatements[0] as Compiler.Parsing.Data.GlobalStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(globalStatements[1] as Compiler.Parsing.Data.GlobalStatements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm2 != null && stm2.Name == "GlobalStatement" && s2 != null && s2.Name == "SymbolTable";
			        if(stm2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((stm2, s2), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { stm1 as Compiler.AST.Data.GlobalStatement, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.GlobalStatement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((globalStatements, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.GlobalStatement globalStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (globalStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { globalStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatement [ Interrupt : inter ] SymbolTable : s ] -> [ GlobalStatement [ inter1 ] s ]", (globalStatement, symbolTable));
			    (Compiler.AST.Data.Node inter1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Interrupt, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = inter1 != null && inter1.Name == "Interrupt" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(inter1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((inter1, symbolTable1), new System.Collections.Generic.List<string>() { "Interrupt", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.GlobalStatement(false) { inter1 as Compiler.AST.Data.Interrupt }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatement [ Statement : stm ] SymbolTable : s ] -> [ GlobalStatement [ stm1 ] s1 ]", (globalStatement, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.GlobalStatement(false) { stm1 as Compiler.AST.Data.Statement }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatement [ Statement : stm ] SymbolTable : s ] -> [ stm1 s1 ]", (globalStatement, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "GlobalStatement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (stm1 as Compiler.AST.Data.GlobalStatement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ GlobalStatement [ Statement : stm ] SymbolTable : s ] -> [ GlobalStatement [ func ] s1 ]", (globalStatement, symbolTable));
			    (Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(globalStatement[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable";
			    if(func != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((func, s1), new System.Collections.Generic.List<string>() { "Function", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((globalStatement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Interrupt interrupt, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (interrupt, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { interrupt.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && interrupt[1] != null && interrupt[1].Name == "(" && interrupt[2] != null && interrupt[2].Name == "numeral" && interrupt[3] != null && interrupt[3].Name == ")" && interrupt[4] != null && interrupt[4].Name == "indent" && interrupt[5] != null && interrupt[5].Name == "Statements" && interrupt[6] != null && interrupt[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Interrupt", "SymbolTable" }, "[ Interrupt [ interrupt ( numeral : i ) indent Statements : stms dedent ] SymbolTable : s ] -> [ Interrupt [ interrupt ( i1 ) indent stm dedent ] s ]", (interrupt, symbolTable));
			    Compiler.AST.Data.Node i1 = Translatep(interrupt[2] as Compiler.Parsing.Data.Token);
			    _isMatching = i1 != null && i1.Name == "numeral";
			    if(i1 != null && !_isMatching)
			    {
			        WrongPatternp((i1), new System.Collections.Generic.List<string>() { "numeral" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(interrupt[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm != null && stm.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(stm != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((stm, symbolTable1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.Interrupt(false) { new Compiler.AST.Data.Token() { Name = "interrupt", Value = "interrupt" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, i1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((interrupt, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statements statements, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (statements, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { statements.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statements [ Statement : stm Statements [ EPSILON ] ] SymbolTable : s ] -> [ stm1 s1 ]", (statements, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (stm1 as Compiler.AST.Data.Statement, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements" && (statements[1].Count == 1 && statements[1][0] != null && statements[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ Statements [ Statement : stm Statements [ EPSILON ] ] SymbolTable : s ] -> [ GlobalStatement [ func ] s1 ]", (statements, symbolTable));
			    (Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable";
			    if(func != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((func, s1), new System.Collections.Generic.List<string>() { "Function", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statements [ Statement : stm Statements : stmsp ] SymbolTable : s ] -> [ Statement [ CompoundStatement [ stm1 newline stm2 ] ] s2 ]", (statements, symbolTable));
			    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = stm1 != null && stm1.Name == "Statement" && s1 != null && s1.Name == "SymbolTable";
			    if(stm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((stm1, s1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm2 != null && stm2.Name == "Statement" && s2 != null && s2.Name == "SymbolTable";
			        if(stm2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((stm2, s2), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.CompoundStatement(false) { stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.Statement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ Statements [ Statement : stm Statements : stmsp ] SymbolTable : s ] -> [ GlobalStatement [ CompoundGlobalStatement [ GlobalStatement [ func ] newline GlobalStatement [ stm2 ] ] ] s2 ]", (statements, symbolTable));
			    (Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable";
			    if(func != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((func, s1), new System.Collections.Generic.List<string>() { "Function", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm2 != null && stm2.Name == "Statement" && s2 != null && s2.Name == "SymbolTable";
			        if(stm2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((stm2, s2), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, new Compiler.AST.Data.GlobalStatement(false) { stm2 as Compiler.AST.Data.Statement } } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(statements != null && statements.Name == "Statements" && (statements.Count == 2 && statements[0] != null && statements[0].Name == "Statement" && statements[1] != null && statements[1].Name == "Statements") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" }, "[ Statements [ Statement : stm Statements : stmsp ] SymbolTable : s ] -> [ GlobalStatement [ CompoundGlobalStatement [ GlobalStatement [ func ] newline stm2 ] ] s2 ]", (statements, symbolTable));
			    (Compiler.AST.Data.Node func, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statements[0] as Compiler.Parsing.Data.Statement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = func != null && func.Name == "Function" && s1 != null && s1.Name == "SymbolTable";
			    if(func != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((func, s1), new System.Collections.Generic.List<string>() { "Function", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(statements[1] as Compiler.Parsing.Data.Statements, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm2 != null && stm2.Name == "GlobalStatement" && s2 != null && s2.Name == "SymbolTable";
			        if(stm2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((stm2, s2), new System.Collections.Generic.List<string>() { "GlobalStatement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.GlobalStatement(false) { new Compiler.AST.Data.CompoundGlobalStatement(false) { new Compiler.AST.Data.GlobalStatement(false) { func as Compiler.AST.Data.Function }, new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" }, stm2 as Compiler.AST.Data.GlobalStatement } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((statements, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Statement statement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (statement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { statement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ newline ] SymbolTable : s ] -> [ Statement [ newline ] s ]", (statement, symbolTable));
			    var _result = (new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.Token() { Name = "newline", Value = "newline" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> [ Statement [ dclStm ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = dclStm != null && dclStm.Name == "IntegerDeclaration" && s1 != null && s1.Name == "SymbolTable";
			    if(dclStm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((dclStm, s1), new System.Collections.Generic.List<string>() { "IntegerDeclaration", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.IntegerDeclaration }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> [ Statement [ dclStm ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = dclStm != null && dclStm.Name == "IntegerDeclarationInit" && s1 != null && s1.Name == "SymbolTable";
			    if(dclStm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((dclStm, s1), new System.Collections.Generic.List<string>() { "IntegerDeclarationInit", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.IntegerDeclarationInit }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> [ Statement [ dclStm ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = dclStm != null && dclStm.Name == "BooleanDeclaration" && s1 != null && s1.Name == "SymbolTable";
			    if(dclStm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((dclStm, s1), new System.Collections.Generic.List<string>() { "BooleanDeclaration", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.BooleanDeclaration }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> [ Statement [ dclStm ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node dclStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = dclStm != null && dclStm.Name == "BooleanDeclarationInit" && s1 != null && s1.Name == "SymbolTable";
			    if(dclStm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((dclStm, s1), new System.Collections.Generic.List<string>() { "BooleanDeclarationInit", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { dclStm as Compiler.AST.Data.BooleanDeclarationInit }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "InterruptStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ InterruptStatement : itrStm ] SymbolTable : s ] -> [ Statement [ itrStm1 ] s ]", (statement, symbolTable));
			    Compiler.AST.Data.Node itrStm1 = Translatep(statement[0] as Compiler.Parsing.Data.InterruptStatement);
			    _isMatching = itrStm1 != null && itrStm1.Name == "InterruptStatement";
			    if(itrStm1 != null && !_isMatching)
			    {
			        WrongPatternp((itrStm1), new System.Collections.Generic.List<string>() { "InterruptStatement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { itrStm1 as Compiler.AST.Data.InterruptStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierDeclaration") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Function", "SymbolTable" }, "[ Statement [ IdentifierDeclaration : idDcl ] SymbolTable : s ] -> [ f s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node f, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierDeclaration, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = f != null && f.Name == "Function" && s1 != null && s1.Name == "SymbolTable";
			    if(f != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((f, s1), new System.Collections.Generic.List<string>() { "Function", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (f as Compiler.AST.Data.Function, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IdentifierStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IdentifierStatement : idStm ] SymbolTable : s ] -> [ Statement [ idStm1 ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node idStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.IdentifierStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = idStm1 != null && idStm1.Name == idStm1.Name && s1 != null && s1.Name == "SymbolTable";
			    if(idStm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((idStm1, s1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { idStm1 as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ IfStatement : ifStm ] SymbolTable : s ] -> [ Statement [ ifStm1 ] s ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node ifStm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(statement[0] as Compiler.Parsing.Data.IfStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = ifStm1 != null && ifStm1.Name == ifStm1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(ifStm1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((ifStm1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { ifStm1 as Compiler.AST.Data.Node }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ WhileStatement : whileStm ] SymbolTable : s ] -> [ Statement [ whileStm1 ] s ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node whileStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.WhileStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = whileStm1 != null && whileStm1.Name == "WhileStatement" && s1 != null && s1.Name == "SymbolTable";
			    if(whileStm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((whileStm1, s1), new System.Collections.Generic.List<string>() { "WhileStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { whileStm1 as Compiler.AST.Data.WhileStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ ForStatement : forStm ] SymbolTable : s ] -> [ Statement [ forStm1 ] s ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node forStm1, Compiler.Translation.SymbolTable.Data.Node s) = Translate(statement[0] as Compiler.Parsing.Data.ForStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = forStm1 != null && forStm1.Name == "ForStatement" && s != null && s.Name == "SymbolTable";
			    if(forStm1 != null && s != null && !_isMatching)
			    {
			        WrongPattern((forStm1, s), new System.Collections.Generic.List<string>() { "ForStatement", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { forStm1 as Compiler.AST.Data.ForStatement }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ RegisterStatement : regStm ] SymbolTable : s ] -> [ Statement [ regStm1 ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node regStm1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.RegisterStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = regStm1 != null && regStm1.Name == regStm1.Name && s1 != null && s1.Name == "SymbolTable";
			    if(regStm1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((regStm1, s1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { regStm1 as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ReturnStatement") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" }, "[ Statement [ ReturnStatement : ret ] SymbolTable : s ] -> [ Statement [ retStm ] s1 ]", (statement, symbolTable));
			    (Compiler.AST.Data.Node retStm, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(statement[0] as Compiler.Parsing.Data.ReturnStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = retStm != null && retStm.Name == retStm.Name && s1 != null && s1.Name == "SymbolTable";
			    if(retStm != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((retStm, s1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.Statement(false) { retStm as Compiler.AST.Data.Node }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((statement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.ReturnStatement returnStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (returnStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { returnStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "ReturnValue" && (returnStatement[1].Count == 1 && returnStatement[1][0] != null && returnStatement[1][0].Name == "Expression") && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerReturn", "SymbolTable" }, "[ ReturnStatement [ return ReturnValue [ Expression : expr ] newline ] SymbolTable : s ] -> [ IntegerReturn [ return iret ] s ]", (returnStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "return"));
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node iret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = iret != null && iret.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(iret != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((iret, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.IntegerReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, iret as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "ReturnValue" && (returnStatement[1].Count == 1 && returnStatement[1][0] != null && returnStatement[1][0].Name == "Expression") && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanReturn", "SymbolTable" }, "[ ReturnStatement [ return ReturnValue [ Expression : expr ] newline ] SymbolTable : s ] -> [ BooleanReturn [ return bret ] s ]", (returnStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "return"));
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node bret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = bret != null && bret.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(bret != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((bret, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.BooleanReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, bret as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "ReturnValue" && (returnStatement[1].Count == 1 && returnStatement[1][0] != null && returnStatement[1][0].Name == "Expression") && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterReturn", "SymbolTable" }, "[ ReturnStatement [ return ReturnValue [ Expression : expr ] newline ] SymbolTable : s ] -> [ RegisterReturn [ return rret ] s ]", (returnStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "return"));
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node rret, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(returnStatement[1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = rret != null && rret.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(rret != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((rret, symbolTable1), new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.RegisterReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" }, rret as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(returnStatement != null && returnStatement.Name == "ReturnStatement" && (returnStatement.Count == 3 && returnStatement[0] != null && returnStatement[0].Name == "return" && returnStatement[1] != null && returnStatement[1].Name == "ReturnValue" && (returnStatement[1].Count == 1 && returnStatement[1][0] != null && returnStatement[1][0].Name == "EPSILON") && returnStatement[2] != null && returnStatement[2].Name == "newline") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "EmptyReturn", "SymbolTable" }, "[ ReturnStatement [ return ReturnValue [ EPSILON ] newline ] SymbolTable : s ] -> [ EmptyReturn [ return ] s ]", (returnStatement, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(new Compiler.Parsing.Data.Token() { Name = "return", Value = "return" }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "nothing") && declaration[0][1] != null && declaration[0][1].Name == "return"));
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.EmptyReturn(false) { new Compiler.AST.Data.Token() { Name = "return", Value = "return" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((returnStatement, symbolTable));
			return (null, null);
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.InterruptStatement interruptStatement)
		{
			bool _isMatching = false;
			var key = (interruptStatement);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { interruptStatement.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(interruptStatement != null && interruptStatement.Name == "InterruptStatement" && (interruptStatement.Count == 3 && interruptStatement[0] != null && interruptStatement[0].Name == "enableinterrupts" && interruptStatement[1] != null && interruptStatement[1].Name == "(" && interruptStatement[2] != null && interruptStatement[2].Name == ")"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "InterruptStatement" }, "InterruptStatement [ enableinterrupts ( ) ] -> : p InterruptStatement [ enableinterrupts ( ) ]", (interruptStatement));
			    var _result = new Compiler.AST.Data.InterruptStatement(false) { new Compiler.AST.Data.Token() { Name = "enableinterrupts", Value = "enableinterrupts" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(interruptStatement != null && interruptStatement.Name == "InterruptStatement" && (interruptStatement.Count == 3 && interruptStatement[0] != null && interruptStatement[0].Name == "disableinterrupts" && interruptStatement[1] != null && interruptStatement[1].Name == "(" && interruptStatement[2] != null && interruptStatement[2].Name == ")"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "InterruptStatement" }, "InterruptStatement [ disableinterrupts ( ) ] -> : p InterruptStatement [ disableinterrupts ( ) ]", (interruptStatement));
			    var _result = new Compiler.AST.Data.InterruptStatement(false) { new Compiler.AST.Data.Token() { Name = "disableinterrupts", Value = "disableinterrupts" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			RulesFailedp((interruptStatement));
			return (null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierDeclaration identifierDeclaration, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (identifierDeclaration, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { identifierDeclaration.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerDeclaration", "SymbolTable" }, "[ IdentifierDeclaration [ IntType : t identifier : id Definition [ newline ] ] SymbolTable : s ] -> [ IntegerDeclaration [ t1 id1 ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (identifierDeclaration, symbolTable));
			    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			    if(declaration != null && !_isMatching)
			    {
			        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			        _isMatching = t1 != null && t1.Name == "IntType";
			        if(t1 != null && !_isMatching)
			        {
			            WrongPatternp((t1), new System.Collections.Generic.List<string>() { "IntType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			            _isMatching = t2 != null && t2.Name == "IntType";
			            if(t2 != null && !_isMatching)
			            {
			                WrongPatternq((t2), new System.Collections.Generic.List<string>() { "IntType" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id1 != null && id1.Name == "identifier";
			                if(id1 != null && !_isMatching)
			                {
			                    WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                    _isMatching = id2 != null && id2.Name == "identifier";
			                    if(id2 != null && !_isMatching)
			                    {
			                        WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (new Compiler.AST.Data.IntegerDeclaration(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        RuleEnd(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Function", "SymbolTable" }, "[ IdentifierDeclaration [ IntType : t identifier : id Definition [ ( FormalParameters : params ) indent Statements : stms dedent ] ] SymbolTable : s ] -> [ Function [ Type [ t1 ] id1 ( p ) indent stm1 dedent ] s ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			        _isMatching = t2 != null && t2.Name == "IntType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "IntType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                (Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                _isMatching = p != null && p.Name == "FormalParameters" && s1 != null && s1.Name == "SymbolTable";
			                if(p != null && s1 != null && !_isMatching)
			                {
			                    WrongPattern((p, s1), new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][4] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(stm1 != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((stm1, symbolTable1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.IntType }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameters, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        RuleEnd(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "IntType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerDeclarationInit", "SymbolTable" }, "[ IdentifierDeclaration [ IntType : t identifier : id Definition [ = DefinitionAssign [ Expression : expr newline ] ] ] SymbolTable : s ] -> [ IntegerDeclarationInit [ t1 id1 = iexpr ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.IntType);
			        _isMatching = t2 != null && t2.Name == "IntType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "IntType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node iexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = iexpr != null && iexpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(iexpr != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((iexpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			                        if(declaration != null && !_isMatching)
			                        {
			                            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			                        }
			                        else if(_isMatching)
			                        {
			                            var _result = (new Compiler.AST.Data.IntegerDeclarationInit(false) { t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, iexpr as Compiler.AST.Data.IntegerExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                            RuleEnd(true, true, _result);
			                            return _result;
			                        }
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 8 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "nothing" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "(" && identifierDeclaration[3] != null && identifierDeclaration[3].Name == "FormalParameters" && identifierDeclaration[4] != null && identifierDeclaration[4].Name == ")" && identifierDeclaration[5] != null && identifierDeclaration[5].Name == "indent" && identifierDeclaration[6] != null && identifierDeclaration[6].Name == "Statements" && identifierDeclaration[7] != null && identifierDeclaration[7].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Function", "SymbolTable" }, "[ IdentifierDeclaration [ nothing : t identifier : id ( FormalParameters : params ) indent Statements : stms dedent ] SymbolTable : s ] -> [ Function [ Type [ t1 ] id1 ( p ) indent stm1 dedent ] s ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
			    _isMatching = t1 != null && t1.Name == "nothing";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "nothing" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.Token);
			        _isMatching = t2 != null && t2.Name == "nothing";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "nothing" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                (Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[3] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                _isMatching = p != null && p.Name == "FormalParameters" && s1 != null && s1.Name == "SymbolTable";
			                if(p != null && s1 != null && !_isMatching)
			                {
			                    WrongPattern((p, s1), new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[6] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.Token }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(stm1 != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((stm1, symbolTable1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.Token }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameters, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        RuleEnd(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 1 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanDeclaration", "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType : t identifier : id Definition [ newline ] ] SymbolTable : s ] -> [ BooleanDeclaration [ t1 id1 ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			        _isMatching = t2 != null && t2.Name == "BooleanType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "BooleanType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			                    if(declaration != null && !_isMatching)
			                    {
			                        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (new Compiler.AST.Data.BooleanDeclaration(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        RuleEnd(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 6 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "(" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "FormalParameters" && identifierDeclaration[2][2] != null && identifierDeclaration[2][2].Name == ")" && identifierDeclaration[2][3] != null && identifierDeclaration[2][3].Name == "indent" && identifierDeclaration[2][4] != null && identifierDeclaration[2][4].Name == "Statements" && identifierDeclaration[2][5] != null && identifierDeclaration[2][5].Name == "dedent")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Function", "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType : t identifier : id Definition [ ( FormalParameters : params ) indent Statements : stms dedent ] ] SymbolTable : s ] -> [ Function [ Type [ t1 ] id1 ( p ) indent stm1 dedent ] s ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			        _isMatching = t2 != null && t2.Name == "BooleanType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "BooleanType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node p, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierDeclaration[2][1] as Compiler.Parsing.Data.FormalParameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = p != null && p.Name == "FormalParameters" && s1 != null && s1.Name == "SymbolTable";
			                    if(p != null && s1 != null && !_isMatching)
			                    {
			                        WrongPattern((p, s1), new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][4] as Compiler.Parsing.Data.Statements, Insert(s1 as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, new Compiler.Translation.SymbolTable.Data.Token() { Name = "return", Value = "return" } } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        _isMatching = stm1 != null && stm1.Name == "Statement" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                        if(stm1 != null && symbolTable1 != null && !_isMatching)
			                        {
			                            WrongPattern((stm1, symbolTable1), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			                        }
			                        else if(_isMatching)
			                        {
			                            var _result = (new Compiler.AST.Data.Function(false) { new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.BooleanType }, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p as Compiler.AST.Data.FormalParameters, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                            RuleEnd(true, true, _result);
			                            return _result;
			                        }
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierDeclaration != null && identifierDeclaration.Name == "IdentifierDeclaration" && (identifierDeclaration.Count == 3 && identifierDeclaration[0] != null && identifierDeclaration[0].Name == "BooleanType" && identifierDeclaration[1] != null && identifierDeclaration[1].Name == "identifier" && identifierDeclaration[2] != null && identifierDeclaration[2].Name == "Definition" && (identifierDeclaration[2].Count == 2 && identifierDeclaration[2][0] != null && identifierDeclaration[2][0].Name == "=" && identifierDeclaration[2][1] != null && identifierDeclaration[2][1].Name == "DefinitionAssign" && (identifierDeclaration[2][1].Count == 2 && identifierDeclaration[2][1][0] != null && identifierDeclaration[2][1][0].Name == "Expression" && identifierDeclaration[2][1][1] != null && identifierDeclaration[2][1][1].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanDeclarationInit", "SymbolTable" }, "[ IdentifierDeclaration [ BooleanType : t identifier : id Definition [ = DefinitionAssign [ Expression : expr newline ] ] ] SymbolTable : s ] -> [ BooleanDeclarationInit [ t1 id1 = bexpr ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (identifierDeclaration, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(identifierDeclaration[0] as Compiler.Parsing.Data.BooleanType);
			        _isMatching = t2 != null && t2.Name == "BooleanType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "BooleanType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(identifierDeclaration[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node bexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierDeclaration[2][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = bexpr != null && bexpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(bexpr != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((bexpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierDeclaration[1] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			                        if(declaration != null && !_isMatching)
			                        {
			                            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			                        }
			                        else if(_isMatching)
			                        {
			                            var _result = (new Compiler.AST.Data.BooleanDeclarationInit(false) { t1 as Compiler.AST.Data.BooleanType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, bexpr as Compiler.AST.Data.BooleanExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.BooleanType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                            RuleEnd(true, true, _result);
			                            return _result;
			                        }
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((identifierDeclaration, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParameters formalParameters, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (formalParameters, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { formalParameters.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" }, "[ FormalParameters [ EPSILON ] SymbolTable : s ] -> [ FormalParameters [ EPSILON ] s ]", (formalParameters, symbolTable));
			    var _result = (new Compiler.AST.Data.FormalParameters(false) { new Compiler.AST.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP" && (formalParameters[1].Count == 1 && formalParameters[1][0] != null && formalParameters[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" }, "[ FormalParameters [ FormalParameter : p FormalParametersP [ EPSILON ] ] SymbolTable : s ] -> [ FormalParameters [ p1 ] s1 ]", (formalParameters, symbolTable));
			    (Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParameters[0] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable";
			    if(p1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((p1, s1), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.FormalParameters(false) { p1 as Compiler.AST.Data.FormalParameter }, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 2 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter" && formalParameters[1] != null && formalParameters[1].Name == "FormalParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameters", "SymbolTable" }, "[ FormalParameters [ FormalParameter : p FormalParametersP : pp ] SymbolTable : s ] -> [ FormalParameters [ FormalParameter [ CompoundFormalParameter [ p1 , p2 ] ] ] s2 ]", (formalParameters, symbolTable));
			    (Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParameters[0] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable";
			    if(p1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((p1, s1), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node p2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(formalParameters[1] as Compiler.Parsing.Data.FormalParametersP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = p2 != null && p2.Name == "FormalParameter" && s2 != null && s2.Name == "SymbolTable";
			        if(p2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((p2, s2), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.FormalParameters(false) { new Compiler.AST.Data.FormalParameter(false) { new Compiler.AST.Data.CompoundFormalParameter(false) { p1 as Compiler.AST.Data.FormalParameter, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p2 as Compiler.AST.Data.FormalParameter } } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((formalParameters, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParametersP formalParametersP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (formalParametersP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { formalParametersP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP" && (formalParametersP[2].Count == 1 && formalParametersP[2][0] != null && formalParametersP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" }, "[ FormalParametersP [ , FormalParameter : p FormalParametersP [ EPSILON ] ] SymbolTable : s ] -> [ p1 s1 ]", (formalParametersP, symbolTable));
			    (Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable";
			    if(p1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((p1, s1), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (p1 as Compiler.AST.Data.FormalParameter, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(formalParametersP != null && formalParametersP.Name == "FormalParametersP" && (formalParametersP.Count == 3 && formalParametersP[0] != null && formalParametersP[0].Name == "," && formalParametersP[1] != null && formalParametersP[1].Name == "FormalParameter" && formalParametersP[2] != null && formalParametersP[2].Name == "FormalParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" }, "[ FormalParametersP [ , FormalParameter : p FormalParametersP : pp ] SymbolTable : s ] -> [ FormalParameter [ CompoundFormalParameter [ p1 , p2 ] ] s2 ]", (formalParametersP, symbolTable));
			    (Compiler.AST.Data.Node p1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(formalParametersP[1] as Compiler.Parsing.Data.FormalParameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p1 != null && p1.Name == "FormalParameter" && s1 != null && s1.Name == "SymbolTable";
			    if(p1 != null && s1 != null && !_isMatching)
			    {
			        WrongPattern((p1, s1), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node p2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(formalParametersP[2] as Compiler.Parsing.Data.FormalParametersP, s1 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = p2 != null && p2.Name == "FormalParameter" && s2 != null && s2.Name == "SymbolTable";
			        if(p2 != null && s2 != null && !_isMatching)
			        {
			            WrongPattern((p2, s2), new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.FormalParameter(false) { new Compiler.AST.Data.CompoundFormalParameter(false) { p1 as Compiler.AST.Data.FormalParameter, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p2 as Compiler.AST.Data.FormalParameter } }, s2 as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((formalParametersP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.FormalParameter formalParameter, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (formalParameter, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { formalParameter.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && formalParameter[1] != null && formalParameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameter", "SymbolTable" }, "[ FormalParameter [ Type : type identifier : id ] SymbolTable : s ] -> [ FormalParameter [ t id1 ] s <- Declarations [ Declaration [ Variable [ t2 id2 ] ] % Declarations [ EPSILON ] ] ]", (formalParameter, symbolTable));
			    Compiler.AST.Data.Node t = Translatep(formalParameter[0] as Compiler.Parsing.Data.Type);
			    _isMatching = t != null && t.Name == "Type";
			    if(t != null && !_isMatching)
			    {
			        WrongPatternp((t), new System.Collections.Generic.List<string>() { "Type" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(formalParameter[0] as Compiler.Parsing.Data.Type);
			        _isMatching = t2 != null && t2.Name == "Type";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "Type" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(formalParameter[1] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(formalParameter[1] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = (new Compiler.AST.Data.FormalParameter(false) { t as Compiler.AST.Data.Type, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { t2 as Compiler.Translation.SymbolTable.Data.Type, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    RuleEnd(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((formalParameter, symbolTable));
			return (null, null);
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Type type)
		{
			bool _isMatching = false;
			var key = (type);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { type.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "Type" }, "Type [ IntType : t ] -> : p Type [ t1 ]", (type));
			    Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.IntType };
			        RuleEndp(true, true, _result);
			        return _result;
			    }
			    RuleEndp(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "Type" }, "Type [ BooleanType : t ] -> : p Type [ t1 ]", (type));
			    Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.BooleanType };
			        RuleEndp(true, true, _result);
			        return _result;
			    }
			    RuleEndp(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "Type" }, "Type [ RegisterType : t ] -> : p Type [ t1 ]", (type));
			    Compiler.AST.Data.Node t1 = Translatep(type[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.Type(false) { t1 as Compiler.AST.Data.RegisterType };
			        RuleEndp(true, true, _result);
			        return _result;
			    }
			    RuleEndp(false);
			}
			RulesFailedp((type));
			return (null);
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.IntType intType)
		{
			bool _isMatching = false;
			var key = (intType);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { intType.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint8 ] -> : p IntType [ uint8 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint8", Value = "uint8" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint16 ] -> : p IntType [ uint16 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint16", Value = "uint16" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint32 ] -> : p IntType [ uint32 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "uint32", Value = "uint32" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int8 ] -> : p IntType [ int8 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int8", Value = "int8" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int16 ] -> : p IntType [ int16 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int16", Value = "int16" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int32 ] -> : p IntType [ int32 ]", (intType));
			    var _result = new Compiler.AST.Data.IntType(false) { new Compiler.AST.Data.Token() { Name = "int32", Value = "int32" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			RulesFailedp((intType));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.IntType intType)
		{
			bool _isMatching = false;
			var key = (intType);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { intType.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint8"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint8 ] -> : q IntType [ uint8 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint8", Value = "uint8" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint16"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint16 ] -> : q IntType [ uint16 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint16", Value = "uint16" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "uint32"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ uint32 ] -> : q IntType [ uint32 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "uint32", Value = "uint32" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int8 ] -> : q IntType [ int8 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int8", Value = "int8" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int16 ] -> : q IntType [ int16 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int16", Value = "int16" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int32 ] -> : q IntType [ int32 ]", (intType));
			    var _result = new Compiler.Translation.SymbolTable.Data.IntType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "int32", Value = "int32" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			RulesFailedq((intType));
			return (null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RegisterStatement registerStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (registerStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 1 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "newline"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterDeclaration", "SymbolTable" }, "[ RegisterStatement [ RegisterType : t RegisterOperation [ identifier : id Definition [ newline ] ] ] SymbolTable : s ] -> [ RegisterDeclaration [ t1 id1 ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (registerStatement, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			        _isMatching = t2 != null && t2.Name == "RegisterType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "RegisterType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			                    if(declaration != null && !_isMatching)
			                    {
			                        WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (new Compiler.AST.Data.RegisterDeclaration(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        RuleEnd(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 2 && registerStatement[1][0] != null && registerStatement[1][0].Name == "identifier" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Definition" && (registerStatement[1][1].Count == 2 && registerStatement[1][1][0] != null && registerStatement[1][1][0].Name == "=" && registerStatement[1][1][1] != null && registerStatement[1][1][1].Name == "DefinitionAssign" && (registerStatement[1][1][1].Count == 2 && registerStatement[1][1][1][0] != null && registerStatement[1][1][1][0].Name == "Expression" && registerStatement[1][1][1][1] != null && registerStatement[1][1][1][1].Name == "newline")))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterDeclarationInit", "SymbolTable" }, "[ RegisterStatement [ RegisterType : t RegisterOperation [ identifier : id Definition [ = DefinitionAssign [ Expression : expr newline ] ] ] ] SymbolTable : s ] -> [ RegisterDeclarationInit [ t1 id1 = rexpr ] s <- Declarations [ Declaration [ Variable [ Type [ t2 ] id2 ] ] % Declarations [ EPSILON ] ] ]", (registerStatement, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			        _isMatching = t2 != null && t2.Name == "RegisterType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "RegisterType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(registerStatement[1][0] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(registerStatement[1][0] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node rexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(registerStatement[1][1][1][0] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = rexpr != null && rexpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(rexpr != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((rexpr, symbolTable1), new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(registerStatement[1][0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "EPSILON");
			                        if(declaration != null && !_isMatching)
			                        {
			                            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			                        }
			                        else if(_isMatching)
			                        {
			                            var _result = (new Compiler.AST.Data.RegisterDeclarationInit(false) { t1 as Compiler.AST.Data.RegisterType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, rexpr as Compiler.AST.Data.RegisterExpression }, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.RegisterType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                            RuleEnd(true, true, _result);
			                            return _result;
			                        }
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(registerStatement != null && registerStatement.Name == "RegisterStatement" && (registerStatement.Count == 2 && registerStatement[0] != null && registerStatement[0].Name == "RegisterType" && registerStatement[1] != null && registerStatement[1].Name == "RegisterOperation" && (registerStatement[1].Count == 9 && registerStatement[1][0] != null && registerStatement[1][0].Name == "(" && registerStatement[1][1] != null && registerStatement[1][1].Name == "Expression" && registerStatement[1][2] != null && registerStatement[1][2].Name == ")" && registerStatement[1][3] != null && registerStatement[1][3].Name == "{" && registerStatement[1][4] != null && registerStatement[1][4].Name == "Expression" && registerStatement[1][5] != null && registerStatement[1][5].Name == "}" && registerStatement[1][6] != null && registerStatement[1][6].Name == "=" && registerStatement[1][7] != null && registerStatement[1][7].Name == "Expression" && registerStatement[1][8] != null && registerStatement[1][8].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "DirectBitAssignment", "SymbolTable" }, "[ RegisterStatement [ RegisterType : t RegisterOperation [ ( Expression : expr1 ) { Expression : expr2 } = Expression : expr3 newline ] ] SymbolTable : s ] -> [ DirectBitAssignment [ regType ( intExpr1 ) { intExpr2 } = boolExpr ] s ]", (registerStatement, symbolTable));
			    Compiler.AST.Data.Node regType = Translatep(registerStatement[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = regType != null && regType.Name == "RegisterType";
			    if(regType != null && !_isMatching)
			    {
			        WrongPatternp((regType), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(registerStatement[1][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable";
			        if(intExpr1 != null && s1 != null && !_isMatching)
			        {
			            WrongPattern((intExpr1, s1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(registerStatement[1][4] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && s2 != null && s2.Name == "SymbolTable";
			            if(intExpr2 != null && s2 != null && !_isMatching)
			            {
			                WrongPattern((intExpr2, s2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s3) = Translate(registerStatement[1][7] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && s3 != null && s3.Name == "SymbolTable";
			                if(boolExpr != null && s3 != null && !_isMatching)
			                {
			                    WrongPattern((boolExpr, s3), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = (new Compiler.AST.Data.DirectBitAssignment(false) { regType as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    RuleEnd(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerStatement, symbolTable));
			return (null, null);
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.RegisterType registerType)
		{
			bool _isMatching = false;
			var key = (registerType);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { registerType.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register8 ] -> : p RegisterType [ register8 ]", (registerType));
			    var _result = new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register8", Value = "register8" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register16 ] -> : p RegisterType [ register16 ]", (registerType));
			    var _result = new Compiler.AST.Data.RegisterType(false) { new Compiler.AST.Data.Token() { Name = "register16", Value = "register16" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			RulesFailedp((registerType));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.RegisterType registerType)
		{
			bool _isMatching = false;
			var key = (registerType);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { registerType.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register8 ] -> : q RegisterType [ register8 ]", (registerType));
			    var _result = new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register8", Value = "register8" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register16 ] -> : q RegisterType [ register16 ]", (registerType));
			    var _result = new Compiler.Translation.SymbolTable.Data.RegisterType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "register16", Value = "register16" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			RulesFailedq((registerType));
			return (null);
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.BooleanType booleanType)
		{
			bool _isMatching = false;
			var key = (booleanType);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { booleanType.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool"))
			{
			    RuleStartp(new System.Collections.Generic.List<string>() { "BooleanType" }, "BooleanType [ bool ] -> : p BooleanType [ bool ]", (booleanType));
			    var _result = new Compiler.AST.Data.BooleanType(false) { new Compiler.AST.Data.Token() { Name = "bool", Value = "bool" } };
			    RuleEndp(true, true, _result);
			    return _result;
			    RuleEndp(false);
			}
			RulesFailedp((booleanType));
			return (null);
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.BooleanType booleanType)
		{
			bool _isMatching = false;
			var key = (booleanType);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { booleanType.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool"))
			{
			    RuleStartq(new System.Collections.Generic.List<string>() { "BooleanType" }, "BooleanType [ bool ] -> : q BooleanType [ bool ]", (booleanType));
			    var _result = new Compiler.Translation.SymbolTable.Data.BooleanType(false) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "bool", Value = "bool" } };
			    RuleEndq(true, true, _result);
			    return _result;
			    RuleEndq(false);
			}
			RulesFailedq((booleanType));
			return (null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IdentifierStatement identifierStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (identifierStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { identifierStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 3 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "{" && identifierStatement[1][0][1] != null && identifierStatement[1][0][1].Name == "Expression" && identifierStatement[1][0][2] != null && identifierStatement[1][0][2].Name == "}") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IndirectBitAssignment", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ BitSelector [ { Expression : expr1 } ] = Expression : expr2 newline ] ] SymbolTable : s ] -> [ IndirectBitAssignment [ id1 { intExpr } = boolExpr ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierStatement[1][0][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable";
			            if(intExpr != null && s1 != null && !_isMatching)
			            {
			                WrongPattern((intExpr, s1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node s2) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && s2 != null && s2.Name == "SymbolTable";
			                if(boolExpr != null && s2 != null && !_isMatching)
			                {
			                    WrongPattern((boolExpr, s2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = (new Compiler.AST.Data.IndirectBitAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" }, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    RuleEnd(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerAssignment", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ BitSelector [ EPSILON ] = Expression : expr newline ] ] SymbolTable : s ] -> [ IntegerAssignment [ id1 = intExpr ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node s1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && s1 != null && s1.Name == "SymbolTable";
			            if(intExpr != null && s1 != null && !_isMatching)
			            {
			                WrongPattern((intExpr, s1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.IntegerAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, intExpr as Compiler.AST.Data.IntegerExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterAssignment", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ BitSelector [ EPSILON ] = Expression : expr newline ] ] SymbolTable : s ] -> [ RegisterAssignment [ id1 = registerExpr ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node registerExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = registerExpr != null && registerExpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			            if(registerExpr != null && symbolTable1 != null && !_isMatching)
			            {
			                WrongPattern((registerExpr, symbolTable1), new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.RegisterAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, registerExpr as Compiler.AST.Data.RegisterExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 4 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "BitSelector" && (identifierStatement[1][0].Count == 1 && identifierStatement[1][0][0] != null && identifierStatement[1][0][0].Name == "EPSILON") && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "=" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == "Expression" && identifierStatement[1][3] != null && identifierStatement[1][3].Name == "newline")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanAssignment", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ BitSelector [ EPSILON ] = Expression : expr newline ] ] SymbolTable : s ] -> [ BooleanAssignment [ id1 = boolExpr ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(identifierStatement[1][2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			            if(boolExpr != null && symbolTable1 != null && !_isMatching)
			            {
			                WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.BooleanAssignment(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, boolExpr as Compiler.AST.Data.BooleanExpression }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Call", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ Call [ id1 ( p2 ) ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "IntType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Call", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ Call [ id1 ( p2 ) ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "BooleanType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Call", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ Call [ id1 ( p2 ) ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "RegisterType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(identifierStatement != null && identifierStatement.Name == "IdentifierStatement" && (identifierStatement.Count == 2 && identifierStatement[0] != null && identifierStatement[0].Name == "identifier" && identifierStatement[1] != null && identifierStatement[1].Name == "IdentifierStatementP" && (identifierStatement[1].Count == 3 && identifierStatement[1][0] != null && identifierStatement[1][0].Name == "(" && identifierStatement[1][1] != null && identifierStatement[1][1].Name == "ExpressionList" && identifierStatement[1][2] != null && identifierStatement[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Call", "SymbolTable" }, "[ IdentifierStatement [ identifier : id IdentifierStatementP [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ Call [ id1 ( p2 ) ] s ]", (identifierStatement, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(identifierStatement[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(identifierStatement[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "nothing") && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(identifierStatement[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((identifierStatement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.IfStatement ifStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (ifStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { ifStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 8 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "Expression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statements" && ifStatement[6] != null && ifStatement[6].Name == "dedent" && ifStatement[7] != null && ifStatement[7].Name == "ElseStatement" && (ifStatement[7].Count == 1 && ifStatement[7][0] != null && ifStatement[7][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IfStatement", "SymbolTable" }, "[ IfStatement [ if ( Expression : expr ) indent Statements : stms dedent ElseStatement [ EPSILON ] ] SymbolTable : s ] -> [ IfStatement [ if ( boolExpr ) indent stm dedent ] s ]", (ifStatement, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(stm != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((stm, symbolTable2), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.IfStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 8 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "Expression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statements" && ifStatement[6] != null && ifStatement[6].Name == "dedent" && ifStatement[7] != null && ifStatement[7].Name == "ElseStatement" && (ifStatement[7].Count == 2 && ifStatement[7][0] != null && ifStatement[7][0].Name == "else" && ifStatement[7][1] != null && ifStatement[7][1].Name == "ElseBlock" && (ifStatement[7][1].Count == 3 && ifStatement[7][1][0] != null && ifStatement[7][1][0].Name == "indent" && ifStatement[7][1][1] != null && ifStatement[7][1][1].Name == "Statements" && ifStatement[7][1][2] != null && ifStatement[7][1][2].Name == "dedent"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IfElseStatement", "SymbolTable" }, "[ IfStatement [ if ( Expression : expr ) indent Statements : stms dedent ElseStatement [ else ElseBlock [ indent Statements : stms1 dedent ] ] ] SymbolTable : s ] -> [ IfElseStatement [ if ( boolExpr ) indent stm dedent else indent stm1 dedent ] s ]", (ifStatement, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(stm != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((stm, symbolTable2), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node stm1, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(ifStatement[7][1][1] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = stm1 != null && stm1.Name == "Statement" && symbolTable3 != null && symbolTable3.Name == "SymbolTable";
			            if(stm1 != null && symbolTable3 != null && !_isMatching)
			            {
			                WrongPattern((stm1, symbolTable3), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.IfElseStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" }, new Compiler.AST.Data.Token() { Name = "else", Value = "else" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 8 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "Expression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statements" && ifStatement[6] != null && ifStatement[6].Name == "dedent" && ifStatement[7] != null && ifStatement[7].Name == "ElseStatement" && (ifStatement[7].Count == 2 && ifStatement[7][0] != null && ifStatement[7][0].Name == "else" && ifStatement[7][1] != null && ifStatement[7][1].Name == "ElseBlock" && (ifStatement[7][1].Count == 1 && ifStatement[7][1][0] != null && ifStatement[7][1][0].Name == "IfStatement"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IfElseIfStatement", "SymbolTable" }, "[ IfStatement [ if ( Expression : expr ) indent Statements : stms dedent ElseStatement [ else ElseBlock [ IfStatement : ifStm ] ] ] SymbolTable : s ] -> [ IfElseIfStatement [ if ( boolExpr ) indent stm dedent else ifStm1 ] s ]", (ifStatement, symbolTable));
			    (Compiler.AST.Data.Node ifStm1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(ifStatement[7][1][0] as Compiler.Parsing.Data.IfStatement, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = ifStm1 != null && ifStm1.Name == ifStm1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(ifStm1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((ifStm1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(ifStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(boolExpr != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((boolExpr, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(ifStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = stm != null && stm.Name == "Statement" && symbolTable3 != null && symbolTable3.Name == "SymbolTable";
			            if(stm != null && symbolTable3 != null && !_isMatching)
			            {
			                WrongPattern((stm, symbolTable3), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.IfElseIfStatement(false) { new Compiler.AST.Data.Token() { Name = "if", Value = "if" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" }, new Compiler.AST.Data.Token() { Name = "else", Value = "else" }, ifStm1 as Compiler.AST.Data.Node }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((ifStatement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.WhileStatement whileStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (whileStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { whileStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && whileStatement[1] != null && whileStatement[1].Name == "(" && whileStatement[2] != null && whileStatement[2].Name == "Expression" && whileStatement[3] != null && whileStatement[3].Name == ")" && whileStatement[4] != null && whileStatement[4].Name == "indent" && whileStatement[5] != null && whileStatement[5].Name == "Statements" && whileStatement[6] != null && whileStatement[6].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "WhileStatement", "SymbolTable" }, "[ WhileStatement [ while ( Expression : expr ) indent Statements : stms dedent ] SymbolTable : s ] -> [ WhileStatement [ while ( boolExpr ) indent stm dedent ] s ]", (whileStatement, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(whileStatement[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node stm, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(whileStatement[5] as Compiler.Parsing.Data.Statements, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = stm != null && stm.Name == "Statement" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(stm != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((stm, symbolTable2), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.WhileStatement(false) { new Compiler.AST.Data.Token() { Name = "while", Value = "while" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stm as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((whileStatement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.ForStatement forStatement, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (forStatement, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { forStatement.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(forStatement != null && forStatement.Name == "ForStatement" && (forStatement.Count == 12 && forStatement[0] != null && forStatement[0].Name == "for" && forStatement[1] != null && forStatement[1].Name == "(" && forStatement[2] != null && forStatement[2].Name == "IntType" && forStatement[3] != null && forStatement[3].Name == "identifier" && forStatement[4] != null && forStatement[4].Name == "from" && forStatement[5] != null && forStatement[5].Name == "Expression" && forStatement[6] != null && forStatement[6].Name == "to" && forStatement[7] != null && forStatement[7].Name == "Expression" && forStatement[8] != null && forStatement[8].Name == ")" && forStatement[9] != null && forStatement[9].Name == "indent" && forStatement[10] != null && forStatement[10].Name == "Statements" && forStatement[11] != null && forStatement[11].Name == "dedent") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ForStatement", "SymbolTable" }, "[ ForStatement [ for ( IntType : t identifier : id from Expression : expr1 to Expression : expr2 ) indent Statements : stms dedent ] SymbolTable : s ] -> [ ForStatement [ for ( t1 id1 from iexpr1 to iexpr2 ) indent stms1 dedent ] s ]", (forStatement, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(forStatement[2] as Compiler.Parsing.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node t2 = Translateq(forStatement[2] as Compiler.Parsing.Data.IntType);
			        _isMatching = t2 != null && t2.Name == "IntType";
			        if(t2 != null && !_isMatching)
			        {
			            WrongPatternq((t2), new System.Collections.Generic.List<string>() { "IntType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node id1 = Translatep(forStatement[3] as Compiler.Parsing.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.Translation.SymbolTable.Data.Node id2 = Translateq(forStatement[3] as Compiler.Parsing.Data.Token);
			                _isMatching = id2 != null && id2.Name == "identifier";
			                if(id2 != null && !_isMatching)
			                {
			                    WrongPatternq((id2), new System.Collections.Generic.List<string>() { "identifier" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.AST.Data.Node iexpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(forStatement[5] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                    _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			                    if(iexpr1 != null && symbolTable1 != null && !_isMatching)
			                    {
			                        WrongPattern((iexpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			                    }
			                    else if(_isMatching)
			                    {
			                        (Compiler.AST.Data.Node iexpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(forStatement[7] as Compiler.Parsing.Data.Expression, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                        _isMatching = iexpr2 != null && iexpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			                        if(iexpr2 != null && symbolTable2 != null && !_isMatching)
			                        {
			                            WrongPattern((iexpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			                        }
			                        else if(_isMatching)
			                        {
			                            (Compiler.AST.Data.Node stms1, Compiler.Translation.SymbolTable.Data.Node symbolTable3) = Translate(forStatement[10] as Compiler.Parsing.Data.Statements, Insert(symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable, new Compiler.Translation.SymbolTable.Data.Declarations(false) { new Compiler.Translation.SymbolTable.Data.Declaration(false) { new Compiler.Translation.SymbolTable.Data.Variable(false) { new Compiler.Translation.SymbolTable.Data.Type(false) { t2 as Compiler.Translation.SymbolTable.Data.IntType }, id2 as Compiler.Translation.SymbolTable.Data.Token } }, new Compiler.Translation.SymbolTable.Data.Declarations(true) { new Compiler.Translation.SymbolTable.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } }) as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                            _isMatching = stms1 != null && stms1.Name == "Statement" && symbolTable3 != null && symbolTable3.Name == "SymbolTable";
			                            if(stms1 != null && symbolTable3 != null && !_isMatching)
			                            {
			                                WrongPattern((stms1, symbolTable3), new System.Collections.Generic.List<string>() { "Statement", "SymbolTable" });
			                            }
			                            else if(_isMatching)
			                            {
			                                var _result = (new Compiler.AST.Data.ForStatement(false) { new Compiler.AST.Data.Token() { Name = "for", Value = "for" }, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, t1 as Compiler.AST.Data.IntType, id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "from", Value = "from" }, iexpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "to", Value = "to" }, iexpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "indent", Value = "indent" }, stms1 as Compiler.AST.Data.Statement, new Compiler.AST.Data.Token() { Name = "dedent", Value = "dedent" } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                                RuleEnd(true, true, _result);
			                                return _result;
			                            }
			                        }
			                    }
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((forStatement, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (expression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { expression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(expression != null && expression.Name == "Expression" && (expression.Count == 1 && expression[0] != null && expression[0].Name == "OrExpression") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ Expression [ OrExpression : orExpr ] SymbolTable : s ] -> [ expr s ]", (expression, symbolTable));
			    (Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression[0] as Compiler.Parsing.Data.OrExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((expression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpression orExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (orExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { orExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && orExpression[1] != null && orExpression[1].Name == "OrExpressionP" && (orExpression[1].Count == 1 && orExpression[1][0] != null && orExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ OrExpression [ AndExpression : andExpr OrExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr s ]", (orExpression, symbolTable));
			    (Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 2 && orExpression[0] != null && orExpression[0].Name == "AndExpression" && orExpression[1] != null && orExpression[1].Name == "OrExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ OrExpression [ AndExpression : andExpr OrExpressionP : orExprP ] SymbolTable : s ] -> [ expr2 <- expr1 s ]", (orExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpression[0] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpression[1] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr2, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr2 as Compiler.AST.Data.BooleanExpression, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((orExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.OrExpressionP orExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (orExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { orExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP" && (orExpressionP[2].Count == 1 && orExpressionP[2][0] != null && orExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ OrExpressionP [ or AndExpression : andExpr OrExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ OrExpression [ % BooleanExpression or expr ] ] s ]", (orExpressionP, symbolTable));
			    (Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr != null && expr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(orExpressionP != null && orExpressionP.Name == "OrExpressionP" && (orExpressionP.Count == 3 && orExpressionP[0] != null && orExpressionP[0].Name == "or" && orExpressionP[1] != null && orExpressionP[1].Name == "AndExpression" && orExpressionP[2] != null && orExpressionP[2].Name == "OrExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ OrExpressionP [ or AndExpression : andExpr OrExpressionP : orExprP ] SymbolTable : s ] -> [ expr2 <- BooleanExpression [ OrExpression [ % BooleanExpression or expr1 ] ] s ]", (orExpressionP, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(orExpressionP[1] as Compiler.Parsing.Data.AndExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(orExpressionP[2] as Compiler.Parsing.Data.OrExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr2, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.OrExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "or", Value = "or" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((orExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpression andExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (andExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { andExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && andExpression[1] != null && andExpression[1].Name == "AndExpressionP" && (andExpression[1].Count == 1 && andExpression[1][0] != null && andExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ AndExpression [ EqExpression : eqExpr AndExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr s ]", (andExpression, symbolTable));
			    (Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr != null && expr.Name == expr.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 2 && andExpression[0] != null && andExpression[0].Name == "EqExpression" && andExpression[1] != null && andExpression[1].Name == "AndExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ AndExpression [ EqExpression : eqExpr AndExpressionP : andExprP ] SymbolTable : s ] -> [ expr2 <- expr1 s ]", (andExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpression[0] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpression[1] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr2, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr2 as Compiler.AST.Data.BooleanExpression, expr1 as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((andExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AndExpressionP andExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (andExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { andExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP" && (andExpressionP[2].Count == 1 && andExpressionP[2][0] != null && andExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ AndExpressionP [ and EqExpression : eqExpr AndExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ AndExpression [ % BooleanExpression and expr ] ] s ]", (andExpressionP, symbolTable));
			    (Compiler.AST.Data.Node expr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr != null && expr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(andExpressionP != null && andExpressionP.Name == "AndExpressionP" && (andExpressionP.Count == 3 && andExpressionP[0] != null && andExpressionP[0].Name == "and" && andExpressionP[1] != null && andExpressionP[1].Name == "EqExpression" && andExpressionP[2] != null && andExpressionP[2].Name == "AndExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ AndExpressionP [ and EqExpression : eqExpr AndExpressionP : andExprP ] SymbolTable : s ] -> [ expr2 <- BooleanExpression [ AndExpression [ % BooleanExpression and expr1 ] ] s ]", (andExpressionP, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(andExpressionP[1] as Compiler.Parsing.Data.EqExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(andExpressionP[2] as Compiler.Parsing.Data.AndExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr2 != null && expr2.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr2, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr2 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.AndExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "and", Value = "and" }, expr1 as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((andExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpression eqExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (eqExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { eqExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP" && (eqExpression[1].Count == 1 && eqExpression[1][0] != null && eqExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ EqExpression [ RelationalExpression : expr EqExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr1 s ]", (eqExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpression [ RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- boolExpr s ]", (eqExpression, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, boolExpr as Compiler.AST.Data.BooleanExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(eqExpression != null && eqExpression.Name == "EqExpression" && (eqExpression.Count == 2 && eqExpression[0] != null && eqExpression[0].Name == "RelationalExpression" && eqExpression[1] != null && eqExpression[1].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpression [ RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- intExpr s ]", (eqExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpression[0] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpression[1] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((eqExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.EqExpressionP eqExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (eqExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { eqExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ == RelationalExpression : expr EqExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ IntegerEqExpression [ % IntegerExpression == intExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ == RelationalExpression : expr EqExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ BooleanEqExpression [ % BooleanExpression == boolExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ == RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- BooleanExpression [ IntegerEqExpression [ % IntegerExpression == intExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "==" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ == RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- BooleanExpression [ BooleanEqExpression [ % BooleanExpression == boolExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "==", Value = "==" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ != RelationalExpression : expr EqExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ IntegerNotEqExpression [ % IntegerExpression != intExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP" && (eqExpressionP[2].Count == 1 && eqExpressionP[2][0] != null && eqExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ != RelationalExpression : expr EqExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ BooleanNotEqExpression [ % BooleanExpression != boolExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanNotEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ != RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- BooleanExpression [ IntegerNotEqExpression [ % IntegerExpression != intExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IntegerNotEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(eqExpressionP != null && eqExpressionP.Name == "EqExpressionP" && (eqExpressionP.Count == 3 && eqExpressionP[0] != null && eqExpressionP[0].Name == "!=" && eqExpressionP[1] != null && eqExpressionP[1].Name == "RelationalExpression" && eqExpressionP[2] != null && eqExpressionP[2].Name == "EqExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ EqExpressionP [ != RelationalExpression : expr1 EqExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- BooleanExpression [ BooleanNotEqExpression [ % BooleanExpression != boolExpr ] ] s ]", (eqExpressionP, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(eqExpressionP[1] as Compiler.Parsing.Data.RelationalExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(eqExpressionP[2] as Compiler.Parsing.Data.EqExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanNotEqExpression(false) { new Compiler.AST.Data.BooleanExpression(true), new Compiler.AST.Data.Token() { Name = "!=", Value = "!=" }, boolExpr as Compiler.AST.Data.BooleanExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((eqExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpression relationalExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (relationalExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { relationalExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP" && (relationalExpression[1].Count == 1 && relationalExpression[1][0] != null && relationalExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ RelationalExpression [ AddSubExpression : expr RelationalExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr1 s ]", (relationalExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(relationalExpression != null && relationalExpression.Name == "RelationalExpression" && (relationalExpression.Count == 2 && relationalExpression[0] != null && relationalExpression[0].Name == "AddSubExpression" && relationalExpression[1] != null && relationalExpression[1].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpression [ AddSubExpression : expr1 RelationalExpressionP : expr2 ] SymbolTable : s ] -> [ expr3 <- intExpr s ]", (relationalExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpression[0] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node expr3, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpression[1] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = expr3 != null && expr3.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(expr3 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((expr3, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(expr3 as Compiler.AST.Data.BooleanExpression, intExpr as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((relationalExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.RelationalExpressionP relationalExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (relationalExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { relationalExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ < AddSubExpression : expr1 RelationalExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ LessThanExpression [ % IntegerExpression < intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ > AddSubExpression : expr1 RelationalExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ GreaterThanExpression [ % IntegerExpression > intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ < AddSubExpression : expr1 RelationalExpressionP : expr2 ] SymbolTable : s ] -> [ boolExpr <- BooleanExpression [ LessThanExpression [ % IntegerExpression < intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(boolExpr != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((boolExpr, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<", Value = "<" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ > AddSubExpression : expr1 RelationalExpressionP : expr2 ] SymbolTable : s ] -> [ boolExpr <- BooleanExpression [ GreaterThanExpression [ % IntegerExpression > intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(boolExpr != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((boolExpr, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">", Value = ">" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ <= AddSubExpression : expr1 RelationalExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ LessThanOrEqExpression [ % IntegerExpression <= intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP" && (relationalExpressionP[2].Count == 1 && relationalExpressionP[2][0] != null && relationalExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ >= AddSubExpression : expr1 RelationalExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ BooleanExpression [ GreaterThanOrEqExpression [ % IntegerExpression >= intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">=", Value = ">=" }, intExpr as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == "<=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ <= AddSubExpression : expr1 RelationalExpressionP : expr2 ] SymbolTable : s ] -> [ boolExpr <- BooleanExpression [ LessThanOrEqExpression [ % IntegerExpression <= intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(boolExpr != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((boolExpr, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.LessThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "<=", Value = "<=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(relationalExpressionP != null && relationalExpressionP.Name == "RelationalExpressionP" && (relationalExpressionP.Count == 3 && relationalExpressionP[0] != null && relationalExpressionP[0].Name == ">=" && relationalExpressionP[1] != null && relationalExpressionP[1].Name == "AddSubExpression" && relationalExpressionP[2] != null && relationalExpressionP[2].Name == "RelationalExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ RelationalExpressionP [ >= AddSubExpression : expr1 RelationalExpressionP : expr2 ] SymbolTable : s ] -> [ boolExpr <- BooleanExpression [ GreaterThanOrEqExpression [ % IntegerExpression >= intExpr ] ] s ]", (relationalExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(relationalExpressionP[1] as Compiler.Parsing.Data.AddSubExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(relationalExpressionP[2] as Compiler.Parsing.Data.RelationalExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(boolExpr != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((boolExpr, symbolTable2), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.GreaterThanOrEqExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = ">=", Value = ">=" }, intExpr as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.BooleanExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((relationalExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpression addSubExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (addSubExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { addSubExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP" && (addSubExpression[1].Count == 1 && addSubExpression[1][0] != null && addSubExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ AddSubExpression [ MulDivExpression : expr AddSubExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr1 s ]", (addSubExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(addSubExpression != null && addSubExpression.Name == "AddSubExpression" && (addSubExpression.Count == 2 && addSubExpression[0] != null && addSubExpression[0].Name == "MulDivExpression" && addSubExpression[1] != null && addSubExpression[1].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ AddSubExpression [ MulDivExpression : expr1 AddSubExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- intExpr1 s ]", (addSubExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpression[0] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpression[1] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((addSubExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.AddSubExpressionP addSubExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (addSubExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { addSubExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ AddSubExpressionP [ + MulDivExpression : expr1 AddSubExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ AddExpression [ % IntegerExpression + intExpr1 ] ] s ]", (addSubExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP" && (addSubExpressionP[2].Count == 1 && addSubExpressionP[2][0] != null && addSubExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ AddSubExpressionP [ - MulDivExpression : expr1 AddSubExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ SubExpression [ % IntegerExpression - intExpr1 ] ] s ]", (addSubExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "+" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ AddSubExpressionP [ + MulDivExpression : expr1 AddSubExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ AddExpression [ % IntegerExpression + intExpr1 ] ] s ]", (addSubExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.AddExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "+", Value = "+" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(addSubExpressionP != null && addSubExpressionP.Name == "AddSubExpressionP" && (addSubExpressionP.Count == 3 && addSubExpressionP[0] != null && addSubExpressionP[0].Name == "-" && addSubExpressionP[1] != null && addSubExpressionP[1].Name == "MulDivExpression" && addSubExpressionP[2] != null && addSubExpressionP[2].Name == "AddSubExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ AddSubExpressionP [ - MulDivExpression : expr1 AddSubExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ SubExpression [ % IntegerExpression - intExpr1 ] ] s ]", (addSubExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(addSubExpressionP[1] as Compiler.Parsing.Data.MulDivExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(addSubExpressionP[2] as Compiler.Parsing.Data.AddSubExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.SubExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "-", Value = "-" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((addSubExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpression mulDivExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (mulDivExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { mulDivExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP" && (mulDivExpression[1].Count == 1 && mulDivExpression[1][0] != null && mulDivExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ MulDivExpression [ PowExpression : expr MulDivExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr1 s ]", (mulDivExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(mulDivExpression != null && mulDivExpression.Name == "MulDivExpression" && (mulDivExpression.Count == 2 && mulDivExpression[0] != null && mulDivExpression[0].Name == "PowExpression" && mulDivExpression[1] != null && mulDivExpression[1].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpression [ PowExpression : expr1 MulDivExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- intExpr1 s ]", (mulDivExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpression[0] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpression[1] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((mulDivExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.MulDivExpressionP mulDivExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (mulDivExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { mulDivExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ \\* PowExpression : expr1 MulDivExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ MulExpression [ % IntegerExpression \\* intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ / PowExpression : expr1 MulDivExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ DivExpression [ % IntegerExpression / intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP" && (mulDivExpressionP[2].Count == 1 && mulDivExpressionP[2][0] != null && mulDivExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ \\% PowExpression : expr1 MulDivExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ ModExpression [ % IntegerExpression \\% intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.ModExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "%", Value = "%" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "*" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ \\* PowExpression : expr1 MulDivExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ MulExpression [ % IntegerExpression \\* intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.MulExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "*", Value = "*" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "/" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ / PowExpression : expr1 MulDivExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ DivExpression [ % IntegerExpression / intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.DivExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "/", Value = "/" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(mulDivExpressionP != null && mulDivExpressionP.Name == "MulDivExpressionP" && (mulDivExpressionP.Count == 3 && mulDivExpressionP[0] != null && mulDivExpressionP[0].Name == "%" && mulDivExpressionP[1] != null && mulDivExpressionP[1].Name == "PowExpression" && mulDivExpressionP[2] != null && mulDivExpressionP[2].Name == "MulDivExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ MulDivExpressionP [ \\% PowExpression : expr1 MulDivExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ ModExpression [ % IntegerExpression \\% intExpr1 ] ] s ]", (mulDivExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(mulDivExpressionP[1] as Compiler.Parsing.Data.PowExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(mulDivExpressionP[2] as Compiler.Parsing.Data.MulDivExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.ModExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "%", Value = "%" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((mulDivExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PowExpression powExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (powExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { powExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && powExpression[1] != null && powExpression[1].Name == "PowExpressionP" && (powExpression[1].Count == 1 && powExpression[1][0] != null && powExpression[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "*", "SymbolTable" }, "[ PowExpression [ PrimaryExpression : expr PowExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ expr1 s ]", (powExpression, symbolTable));
			    (Compiler.AST.Data.Node expr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = expr1 != null && expr1.Name == expr1.Name && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(expr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((expr1, symbolTable1), new System.Collections.Generic.List<string>() { "*", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (expr1 as Compiler.AST.Data.Node, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 2 && powExpression[0] != null && powExpression[0].Name == "PrimaryExpression" && powExpression[1] != null && powExpression[1].Name == "PowExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PowExpression [ PrimaryExpression : expr1 PowExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- intExpr1 s ]", (powExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpression[0] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpression[1] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, intExpr1 as Compiler.AST.Data.IntegerExpression) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((powExpression, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PowExpressionP powExpressionP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (powExpressionP, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { powExpressionP.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP" && (powExpressionP[2].Count == 1 && powExpressionP[2][0] != null && powExpressionP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PowExpressionP [ ^ PrimaryExpression : expr1 PowExpressionP [ EPSILON ] ] SymbolTable : s ] -> [ IntegerExpression [ PowExpression [ % IntegerExpression ^ intExpr1 ] ] s ]", (powExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.PowExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "^", Value = "^" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(powExpressionP != null && powExpressionP.Name == "PowExpressionP" && (powExpressionP.Count == 3 && powExpressionP[0] != null && powExpressionP[0].Name == "^" && powExpressionP[1] != null && powExpressionP[1].Name == "PrimaryExpression" && powExpressionP[2] != null && powExpressionP[2].Name == "PowExpressionP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PowExpressionP [ ^ PrimaryExpression : expr1 PowExpressionP : expr2 ] SymbolTable : s ] -> [ intExpr2 <- IntegerExpression [ PowExpression [ % IntegerExpression ^ intExpr1 ] ] s ]", (powExpressionP, symbolTable));
			    (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(powExpressionP[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(powExpressionP[2] as Compiler.Parsing.Data.PowExpressionP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			        if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			        {
			            WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (Insert(intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.PowExpression(false) { new Compiler.AST.Data.IntegerExpression(true), new Compiler.AST.Data.Token() { Name = "^", Value = "^" }, intExpr1 as Compiler.AST.Data.IntegerExpression } }) as Compiler.AST.Data.IntegerExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((powExpressionP, symbolTable));
			return (null, null);
		}

		public (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) Translate(Compiler.Parsing.Data.PrimaryExpression primaryExpression, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (primaryExpression, symbolTable);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { primaryExpression.Name, symbolTable.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "numeral") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PrimaryExpression [ numeral : i ] SymbolTable : s ] -> [ IntegerExpression [ i1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node i1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = i1 != null && i1.Name == "numeral";
			    if(i1 != null && !_isMatching)
			    {
			        WrongPatternp((i1), new System.Collections.Generic.List<string>() { "numeral" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { i1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ BitSelector [ EPSILON ] ] ] SymbolTable : s ] -> [ IntegerExpression [ id1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "IntType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.IntegerExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ BitSelector [ EPSILON ] ] ] SymbolTable : s ] -> [ RegisterExpression [ id1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.RegisterExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 1 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "EPSILON"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ BitSelector [ EPSILON ] ] ] SymbolTable : s ] -> [ BooleanExpression [ id1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "BooleanType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.BooleanExpression(false) { id1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ IntegerExpression [ Call [ id1 ( p2 ) ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "IntType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ BooleanExpression [ Call [ id1 ( p2 ) ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "BooleanType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 3 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "(" && primaryExpression[1][1] != null && primaryExpression[1][1].Name == "ExpressionList" && primaryExpression[1][2] != null && primaryExpression[1][2].Name == ")")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ ( ExpressionList : p ) ] ] SymbolTable : s ] -> [ RegisterExpression [ Call [ id1 ( p2 ) ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Function" && (declaration[0].Count == 3 && declaration[0][0] != null && declaration[0][0].Name == "ReturnType" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "Type" && (declaration[0][0][0].Count == 1 && declaration[0][0][0][0] != null && declaration[0][0][0][0].Name == "RegisterType")) && declaration[0][1] != null && declaration[0][1].Name == "identifier" && declaration[0][2] != null && declaration[0][2].Name == "Parameters"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.AST.Data.Node p2 = Translatet(primaryExpression[1][1] as Compiler.Parsing.Data.ExpressionList, declaration[0][2] as Compiler.Translation.SymbolTable.Data.Parameters, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = p2 != null && p2.Name == "ExpressionList";
			            if(p2 != null && !_isMatching)
			            {
			                WrongPatternt((p2), new System.Collections.Generic.List<string>() { "ExpressionList" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.Call(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, p2 as Compiler.AST.Data.ExpressionList, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "identifier" && primaryExpression[1] != null && primaryExpression[1].Name == "IdentifierOperation" && (primaryExpression[1].Count == 1 && primaryExpression[1][0] != null && primaryExpression[1][0].Name == "BitSelector" && (primaryExpression[1][0].Count == 3 && primaryExpression[1][0][0] != null && primaryExpression[1][0][0].Name == "{" && primaryExpression[1][0][1] != null && primaryExpression[1][0][1].Name == "Expression" && primaryExpression[1][0][2] != null && primaryExpression[1][0][2].Name == "}"))) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ identifier : id IdentifierOperation [ BitSelector [ { Expression : expr } ] ] ] SymbolTable : s ] -> [ BooleanExpression [ IndirectBitValue [ id1 { intExpr } ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node id1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPatternp((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.Translation.SymbolTable.Data.Node declaration = Translates(primaryExpression[0] as Compiler.Parsing.Data.Token, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = declaration != null && declaration.Name == "Declaration" && (declaration.Count == 1 && declaration[0] != null && declaration[0].Name == "Variable" && (declaration[0].Count == 2 && declaration[0][0] != null && declaration[0][0].Name == "Type" && (declaration[0][0].Count == 1 && declaration[0][0][0] != null && declaration[0][0][0].Name == "RegisterType") && declaration[0][1] != null && declaration[0][1].Name == "identifier"));
			        if(declaration != null && !_isMatching)
			        {
			            WrongPatterns((declaration), new System.Collections.Generic.List<string>() { "Declaration" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1][0][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			            if(intExpr != null && symbolTable1 != null && !_isMatching)
			            {
			                WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.IndirectBitValue(false) { id1 as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && primaryExpression[2] != null && primaryExpression[2].Name == ")") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" }, "[ PrimaryExpression [ ( Expression : expr ) ] SymbolTable : s ] -> [ IntegerExpression [ IntegerParenthesisExpression [ ( intExpr ) ] ] s ]", (primaryExpression, symbolTable));
			    (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(intExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.IntegerExpression(false) { new Compiler.AST.Data.IntegerParenthesisExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 3 && primaryExpression[0] != null && primaryExpression[0].Name == "(" && primaryExpression[1] != null && primaryExpression[1].Name == "Expression" && primaryExpression[2] != null && primaryExpression[2].Name == ")") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ ( Expression : expr ) ] SymbolTable : s ] -> [ BooleanExpression [ BooleanParenthesisExpression [ ( boolExpr ) ] ] s ]", (primaryExpression, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.BooleanParenthesisExpression(false) { new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, boolExpr as Compiler.AST.Data.BooleanExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 2 && primaryExpression[0] != null && primaryExpression[0].Name == "!" && primaryExpression[1] != null && primaryExpression[1].Name == "PrimaryExpression") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ ! PrimaryExpression : expr ] SymbolTable : s ] -> [ BooleanExpression [ NotExpression [ ! boolExpr ] ] s ]", (primaryExpression, symbolTable));
			    (Compiler.AST.Data.Node boolExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[1] as Compiler.Parsing.Data.PrimaryExpression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = boolExpr != null && boolExpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(boolExpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((boolExpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.NotExpression(false) { new Compiler.AST.Data.Token() { Name = "!", Value = "!" }, boolExpr as Compiler.AST.Data.BooleanExpression } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && primaryExpression[1] != null && primaryExpression[1].Name == "(" && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && primaryExpression[3] != null && primaryExpression[3].Name == ")" && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 1 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" }, "[ PrimaryExpression [ RegisterType : t ( Expression : expr ) BitSelector [ EPSILON ] ] SymbolTable : s ] -> [ RegisterExpression [ RegisterLiteral [ t1 ( intExpr ) ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr != null && intExpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(intExpr != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((intExpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.AST.Data.RegisterExpression(false) { new Compiler.AST.Data.RegisterLiteral(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 5 && primaryExpression[0] != null && primaryExpression[0].Name == "RegisterType" && primaryExpression[1] != null && primaryExpression[1].Name == "(" && primaryExpression[2] != null && primaryExpression[2].Name == "Expression" && primaryExpression[3] != null && primaryExpression[3].Name == ")" && primaryExpression[4] != null && primaryExpression[4].Name == "BitSelector" && (primaryExpression[4].Count == 3 && primaryExpression[4][0] != null && primaryExpression[4][0].Name == "{" && primaryExpression[4][1] != null && primaryExpression[4][1].Name == "Expression" && primaryExpression[4][2] != null && primaryExpression[4][2].Name == "}")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ RegisterType : t ( Expression : expr1 ) BitSelector [ { Expression : expr2 } ] ] SymbolTable : s ] -> [ BooleanExpression [ DirectBitValue [ t1 ( intExpr1 ) { intExpr2 } ] ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.AST.Data.Node intExpr1, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(primaryExpression[2] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = intExpr1 != null && intExpr1.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			        if(intExpr1 != null && symbolTable1 != null && !_isMatching)
			        {
			            WrongPattern((intExpr1, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.AST.Data.Node intExpr2, Compiler.Translation.SymbolTable.Data.Node symbolTable2) = Translate(primaryExpression[4][1] as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			            _isMatching = intExpr2 != null && intExpr2.Name == "IntegerExpression" && symbolTable2 != null && symbolTable2.Name == "SymbolTable";
			            if(intExpr2 != null && symbolTable2 != null && !_isMatching)
			            {
			                WrongPattern((intExpr2, symbolTable2), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (new Compiler.AST.Data.BooleanExpression(false) { new Compiler.AST.Data.DirectBitValue(false) { t1 as Compiler.AST.Data.RegisterType, new Compiler.AST.Data.Token() { Name = "(", Value = "(" }, intExpr1 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = ")", Value = ")" }, new Compiler.AST.Data.Token() { Name = "{", Value = "{" }, intExpr2 as Compiler.AST.Data.IntegerExpression, new Compiler.AST.Data.Token() { Name = "}", Value = "}" } } }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "true") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ true : t ] SymbolTable : s ] -> [ BooleanExpression [ t1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node t1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = t1 != null && t1.Name == "true";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPatternp((t1), new System.Collections.Generic.List<string>() { "true" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { t1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(primaryExpression != null && primaryExpression.Name == "PrimaryExpression" && (primaryExpression.Count == 1 && primaryExpression[0] != null && primaryExpression[0].Name == "false") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" }, "[ PrimaryExpression [ false : f ] SymbolTable : s ] -> [ BooleanExpression [ f1 ] s ]", (primaryExpression, symbolTable));
			    Compiler.AST.Data.Node f1 = Translatep(primaryExpression[0] as Compiler.Parsing.Data.Token);
			    _isMatching = f1 != null && f1.Name == "false";
			    if(f1 != null && !_isMatching)
			    {
			        WrongPatternp((f1), new System.Collections.Generic.List<string>() { "false" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.AST.Data.BooleanExpression(false) { f1 as Compiler.AST.Data.Token }, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((primaryExpression, symbolTable));
			return (null, null);
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.ExpressionList expressionList, Compiler.Translation.SymbolTable.Data.Parameters parameters, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (expressionList, parameters, symbolTable);
			if(Relationt.ContainsKey(key))
			{
			    var value = Relationt[key];
			    RuleStartt(new System.Collections.Generic.List<string>() { expressionList.Name, parameters.Name, symbolTable.Name }, "", key);
			    RuleEndt(true, false, value);
			    return value;
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "EPSILON") && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 1 && parameters[0] != null && parameters[0].Name == "EPSILON") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionList" }, "[ ExpressionList [ EPSILON ] Parameters [ EPSILON ] SymbolTable ] -> : t ExpressionList [ EPSILON ]", (expressionList, parameters, symbolTable));
			    var _result = new Compiler.AST.Data.ExpressionList(false) { new Compiler.AST.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEndt(true, true, _result);
			    return _result;
			    RuleEndt(false);
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 2 && expressionList[0] != null && expressionList[0].Name == "Expression" && expressionList[1] != null && expressionList[1].Name == "ExpressionListP" && (expressionList[1].Count == 1 && expressionList[1][0] != null && expressionList[1][0].Name == "EPSILON")) && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 2 && parameters[0] != null && parameters[0].Name == "Parameter" && parameters[1] != null && parameters[1].Name == "ParametersP" && (parameters[1].Count == 1 && parameters[1][0] != null && parameters[1][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionList" }, "[ ExpressionList [ Expression : p1 ExpressionListP [ EPSILON ] ] Parameters [ Parameter : p3 ParametersP [ EPSILON ] ] SymbolTable : s ] -> : t ExpressionList [ p5 ]", (expressionList, parameters, symbolTable));
			    Compiler.AST.Data.Node p5 = Translatet(expressionList[0] as Compiler.Parsing.Data.Expression, parameters[0] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p5 != null && p5.Name == "ExpressionListArgs";
			    if(p5 != null && !_isMatching)
			    {
			        WrongPatternt((p5), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.ExpressionList(false) { p5 as Compiler.AST.Data.ExpressionListArgs };
			        RuleEndt(true, true, _result);
			        return _result;
			    }
			    RuleEndt(false);
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 2 && expressionList[0] != null && expressionList[0].Name == "Expression" && expressionList[1] != null && expressionList[1].Name == "ExpressionListP") && parameters != null && parameters.Name == "Parameters" && (parameters.Count == 2 && parameters[0] != null && parameters[0].Name == "Parameter" && parameters[1] != null && parameters[1].Name == "ParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionList" }, "[ ExpressionList [ Expression : p1 ExpressionListP : p2 ] Parameters [ Parameter : p3 ParametersP : p4 ] SymbolTable : s ] -> : t ExpressionList [ ExpressionListArgs [ CompoundArgs [ p5 , p6 ] ] ]", (expressionList, parameters, symbolTable));
			    Compiler.AST.Data.Node p5 = Translatet(expressionList[0] as Compiler.Parsing.Data.Expression, parameters[0] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p5 != null && p5.Name == "ExpressionListArgs";
			    if(p5 != null && !_isMatching)
			    {
			        WrongPatternt((p5), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.AST.Data.Node p6 = Translatet(expressionList[1] as Compiler.Parsing.Data.ExpressionListP, parameters[1] as Compiler.Translation.SymbolTable.Data.ParametersP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = p6 != null && p6.Name == "ExpressionListArgs";
			        if(p6 != null && !_isMatching)
			        {
			            WrongPatternt((p6), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.AST.Data.ExpressionList(false) { new Compiler.AST.Data.ExpressionListArgs(false) { new Compiler.AST.Data.CompoundArgs(false) { p5 as Compiler.AST.Data.ExpressionListArgs, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p6 as Compiler.AST.Data.ExpressionListArgs } } };
			            RuleEndt(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndt(false);
			}
			RulesFailedt((expressionList, parameters, symbolTable));
			return (null);
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.ExpressionListP expressionListP, Compiler.Translation.SymbolTable.Data.ParametersP parametersP, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (expressionListP, parametersP, symbolTable);
			if(Relationt.ContainsKey(key))
			{
			    var value = Relationt[key];
			    RuleStartt(new System.Collections.Generic.List<string>() { expressionListP.Name, parametersP.Name, symbolTable.Name }, "", key);
			    RuleEndt(true, false, value);
			    return value;
			}
			if(expressionListP != null && expressionListP.Name == "ExpressionListP" && (expressionListP.Count == 3 && expressionListP[0] != null && expressionListP[0].Name == "," && expressionListP[1] != null && expressionListP[1].Name == "Expression" && expressionListP[2] != null && expressionListP[2].Name == "ExpressionListP" && (expressionListP[2].Count == 1 && expressionListP[2][0] != null && expressionListP[2][0].Name == "EPSILON")) && parametersP != null && parametersP.Name == "ParametersP" && (parametersP.Count == 3 && parametersP[0] != null && parametersP[0].Name == "," && parametersP[1] != null && parametersP[1].Name == "Parameter" && parametersP[2] != null && parametersP[2].Name == "ParametersP" && (parametersP[2].Count == 1 && parametersP[2][0] != null && parametersP[2][0].Name == "EPSILON")) && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "[ ExpressionListP [ , Expression : p1 ExpressionListP [ EPSILON ] ] ParametersP [ , Parameter : p3 ParametersP [ EPSILON ] ] SymbolTable : s ] -> : t p5", (expressionListP, parametersP, symbolTable));
			    Compiler.AST.Data.Node p5 = Translatet(expressionListP[1] as Compiler.Parsing.Data.Expression, parametersP[1] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p5 != null && p5.Name == "ExpressionListArgs";
			    if(p5 != null && !_isMatching)
			    {
			        WrongPatternt((p5), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        var _result = p5 as Compiler.AST.Data.ExpressionListArgs;
			        RuleEndt(true, true, _result);
			        return _result;
			    }
			    RuleEndt(false);
			}
			if(expressionListP != null && expressionListP.Name == "ExpressionListP" && (expressionListP.Count == 3 && expressionListP[0] != null && expressionListP[0].Name == "," && expressionListP[1] != null && expressionListP[1].Name == "Expression" && expressionListP[2] != null && expressionListP[2].Name == "ExpressionListP") && parametersP != null && parametersP.Name == "ParametersP" && (parametersP.Count == 3 && parametersP[0] != null && parametersP[0].Name == "," && parametersP[1] != null && parametersP[1].Name == "Parameter" && parametersP[2] != null && parametersP[2].Name == "ParametersP") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "[ ExpressionListP [ , Expression : p1 ExpressionListP : p2 ] ParametersP [ , Parameter : p3 ParametersP : p4 ] SymbolTable : s ] -> : t ExpressionListArgs [ CompoundArgs [ p5 , p6 ] ]", (expressionListP, parametersP, symbolTable));
			    Compiler.AST.Data.Node p5 = Translatet(expressionListP[1] as Compiler.Parsing.Data.Expression, parametersP[1] as Compiler.Translation.SymbolTable.Data.Parameter, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = p5 != null && p5.Name == "ExpressionListArgs";
			    if(p5 != null && !_isMatching)
			    {
			        WrongPatternt((p5), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.AST.Data.Node p6 = Translatet(expressionListP[2] as Compiler.Parsing.Data.ExpressionListP, parametersP[2] as Compiler.Translation.SymbolTable.Data.ParametersP, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			        _isMatching = p6 != null && p6.Name == "ExpressionListArgs";
			        if(p6 != null && !_isMatching)
			        {
			            WrongPatternt((p6), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.AST.Data.ExpressionListArgs(false) { new Compiler.AST.Data.CompoundArgs(false) { p5 as Compiler.AST.Data.ExpressionListArgs, new Compiler.AST.Data.Token() { Name = ",", Value = "," }, p6 as Compiler.AST.Data.ExpressionListArgs } };
			            RuleEndt(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEndt(false);
			}
			RulesFailedt((expressionListP, parametersP, symbolTable));
			return (null);
		}

		public Compiler.AST.Data.Node Translatet(Compiler.Parsing.Data.Expression expression, Compiler.Translation.SymbolTable.Data.Parameter parameter, Compiler.Translation.SymbolTable.Data.SymbolTable symbolTable)
		{
			bool _isMatching = false;
			var key = (expression, parameter, symbolTable);
			if(Relationt.ContainsKey(key))
			{
			    var value = Relationt[key];
			    RuleStartt(new System.Collections.Generic.List<string>() { expression.Name, parameter.Name, symbolTable.Name }, "", key);
			    RuleEndt(true, false, value);
			    return value;
			}
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "IntType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "[ Expression : expr Parameter [ Type [ IntType ] identifier ] SymbolTable : s ] -> : t ExpressionListArgs [ iexpr ]", (expression, parameter, symbolTable));
			    (Compiler.AST.Data.Node iexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = iexpr != null && iexpr.Name == "IntegerExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(iexpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((iexpr, symbolTable1), new System.Collections.Generic.List<string>() { "IntegerExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.ExpressionListArgs(false) { iexpr as Compiler.AST.Data.IntegerExpression };
			        RuleEndt(true, true, _result);
			        return _result;
			    }
			    RuleEndt(false);
			}
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "BooleanType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "[ Expression : expr Parameter [ Type [ BooleanType ] identifier ] SymbolTable : s ] -> : t ExpressionListArgs [ bexpr ]", (expression, parameter, symbolTable));
			    (Compiler.AST.Data.Node bexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = bexpr != null && bexpr.Name == "BooleanExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(bexpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr, symbolTable1), new System.Collections.Generic.List<string>() { "BooleanExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.ExpressionListArgs(false) { bexpr as Compiler.AST.Data.BooleanExpression };
			        RuleEndt(true, true, _result);
			        return _result;
			    }
			    RuleEndt(false);
			}
			if(expression != null && expression.Name == "Expression" && parameter != null && parameter.Name == "Parameter" && (parameter.Count == 2 && parameter[0] != null && parameter[0].Name == "Type" && (parameter[0].Count == 1 && parameter[0][0] != null && parameter[0][0].Name == "RegisterType") && parameter[1] != null && parameter[1].Name == "identifier") && symbolTable != null && symbolTable.Name == "SymbolTable")
			{
			    RuleStartt(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "[ Expression : expr Parameter [ Type [ RegisterType ] identifier ] SymbolTable : s ] -> : t ExpressionListArgs [ rexpr ]", (expression, parameter, symbolTable));
			    (Compiler.AST.Data.Node rexpr, Compiler.Translation.SymbolTable.Data.Node symbolTable1) = Translate(expression as Compiler.Parsing.Data.Expression, symbolTable as Compiler.Translation.SymbolTable.Data.SymbolTable);
			    _isMatching = rexpr != null && rexpr.Name == "RegisterExpression" && symbolTable1 != null && symbolTable1.Name == "SymbolTable";
			    if(rexpr != null && symbolTable1 != null && !_isMatching)
			    {
			        WrongPattern((rexpr, symbolTable1), new System.Collections.Generic.List<string>() { "RegisterExpression", "SymbolTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.AST.Data.ExpressionListArgs(false) { rexpr as Compiler.AST.Data.RegisterExpression };
			        RuleEndt(true, true, _result);
			        return _result;
			    }
			    RuleEndt(false);
			}
			RulesFailedt((expression, parameter, symbolTable));
			return (null);
		}

		public void RuleStartp(System.Collections.Generic.List<string> returnTypes, string rule, Compiler.Parsing.Data.Node data)
		{
			Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.AST.Data.Node> error = new Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.AST.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndp(bool success, bool save, Compiler.AST.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.AST.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relationp.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndp(bool success)
		{
			RuleEndp(success, success, null);
		}

		public void RulesFailedp(Compiler.Parsing.Data.Node data)
		{
			Relationp.Add(data, null);
		}

		public void WrongPatternp(Compiler.AST.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.AST.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public Compiler.AST.Data.Node Translatep(Compiler.Parsing.Data.Token token)
		{
			bool _isMatching = false;
			var key = (token);
			if(Relationp.ContainsKey(key))
			{
			    var value = Relationp[key];
			    RuleStartp(new System.Collections.Generic.List<string>() { token.Name }, "", key);
			    RuleEndp(true, false, value);
			    return value;
			}
			RuleStartp(new System.Collections.Generic.List<string>() { token.Name }, $"{token.Name} ->:p {token.Name}", token);
			var result = new Compiler.AST.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
			RuleEndp(true, true, result);
			return result;
		}

		public void RuleStartq(System.Collections.Generic.List<string> returnTypes, string rule, Compiler.Parsing.Data.Node data)
		{
			Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node> error = new Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndq(bool success, bool save, Compiler.Translation.SymbolTable.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relationq.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndq(bool success)
		{
			RuleEndq(success, success, null);
		}

		public void RulesFailedq(Compiler.Parsing.Data.Node data)
		{
			Relationq.Add(data, null);
		}

		public void WrongPatternq(Compiler.Translation.SymbolTable.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public Compiler.Translation.SymbolTable.Data.Node Translateq(Compiler.Parsing.Data.Token token)
		{
			bool _isMatching = false;
			var key = (token);
			if(Relationq.ContainsKey(key))
			{
			    var value = Relationq[key];
			    RuleStartq(new System.Collections.Generic.List<string>() { token.Name }, "", key);
			    RuleEndq(true, false, value);
			    return value;
			}
			RuleStartq(new System.Collections.Generic.List<string>() { token.Name }, $"{token.Name} ->:q {token.Name}", token);
			var result = new Compiler.Translation.SymbolTable.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
			RuleEndq(true, true, result);
			return result;
		}

		public void RuleStartw(System.Collections.Generic.List<string> returnTypes, string rule, Compiler.Parsing.Data.Node data)
		{
			Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Parsing.Data.Node> error = new Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Parsing.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndw(bool success, bool save, Compiler.Parsing.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Parsing.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relationw.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndw(bool success)
		{
			RuleEndw(success, success, null);
		}

		public void RulesFailedw(Compiler.Parsing.Data.Node data)
		{
			Relationw.Add(data, null);
		}

		public void WrongPatternw(Compiler.Parsing.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<Compiler.Parsing.Data.Node, Compiler.Parsing.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public Compiler.Parsing.Data.Node Translatew(Compiler.Parsing.Data.Token token)
		{
			bool _isMatching = false;
			var key = (token);
			if(Relationw.ContainsKey(key))
			{
			    var value = Relationw[key];
			    RuleStartw(new System.Collections.Generic.List<string>() { token.Name }, "", key);
			    RuleEndw(true, false, value);
			    return value;
			}
			RuleStartw(new System.Collections.Generic.List<string>() { token.Name }, $"{token.Name} ->:w {token.Name}", token);
			var result = new Compiler.Parsing.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
			RuleEndw(true, true, result);
			return result;
		}

		public void RuleStarts(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node> error = new Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEnds(bool success, bool save, Compiler.Translation.SymbolTable.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relations.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEnds(bool success)
		{
			RuleEnds(success, success, null);
		}

		public void RulesFaileds((Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Relations.Add(data, null);
		}

		public void WrongPatterns(Compiler.Translation.SymbolTable.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public void RuleStartf(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node> error = new Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndf(bool success, bool save, Compiler.Translation.SymbolTable.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relationf.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndf(bool success)
		{
			RuleEndf(success, success, null);
		}

		public void RulesFailedf((Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Relationf.Add(data, null);
		}

		public void WrongPatternf(Compiler.Translation.SymbolTable.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.Translation.SymbolTable.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public void RuleStartt(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.AST.Data.Node> error = new Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.AST.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndt(bool success, bool save, Compiler.AST.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.AST.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relationt.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndt(bool success)
		{
			RuleEndt(success, success, null);
		}

		public void RulesFailedt((Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Relationt.Add(data, null);
		}

		public void WrongPatternt(Compiler.AST.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node, Compiler.Translation.SymbolTable.Data.Node), Compiler.AST.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public void RuleStart(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)> error = new Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEnd(bool success, bool save, (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)>;
			casted.To = data;
			if(save)
			{
			    Relation.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEnd(bool success)
		{
			RuleEnd(success, success, (null, null));
		}

		public void RulesFailed((Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data)
		{
			Relation.Add(data, (null, null));
		}

		public void WrongPattern((Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node) data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.Parsing.Data.Node, Compiler.Translation.SymbolTable.Data.Node), (Compiler.AST.Data.Node, Compiler.Translation.SymbolTable.Data.Node)>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
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
			if(left.IsPlaceholder && left.Name == right.Name)
			{
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
			    if(left[i].IsPlaceholder && left[i].Name == right.Name)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else
			    {
			        Compiler.Parsing.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null)
			        {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}

		public Compiler.AST.Data.Node Insert(Compiler.AST.Data.Node left, Compiler.AST.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
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
			    if(left[i].IsPlaceholder && left[i].Name == right.Name)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else
			    {
			        Compiler.AST.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null)
			        {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}

		public Compiler.Translation.SymbolTable.Data.Node Insert(Compiler.Translation.SymbolTable.Data.Node left, Compiler.Translation.SymbolTable.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
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
			    if(left[i].IsPlaceholder && left[i].Name == right.Name)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else
			    {
			        Compiler.Translation.SymbolTable.Data.Node leftUpdated = InsertAux(left[i], right);
			        if(leftUpdated != null)
			        {
			            return leftUpdated;
			        }
			    }
			}
			return null;
		}
	}
}
