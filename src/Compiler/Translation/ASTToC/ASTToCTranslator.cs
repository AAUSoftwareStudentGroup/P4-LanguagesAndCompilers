namespace Compiler.Translation.ASTToC
{
	public partial class ASTToCTranslator 
	{
		public Compiler.Error.RuleError RuleError { get; set; } = new Compiler.Error.RuleError();
		public System.Collections.Generic.Dictionary<Compiler.AST.Data.Node,Compiler.C.Data.Node> Relation { get; set; } = new System.Collections.Generic.Dictionary<Compiler.AST.Data.Node,Compiler.C.Data.Node>();
		public System.Collections.Generic.Dictionary<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node),(Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)> Relationa { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node),(Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)>();
		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AST aST)
		{
			bool _isMatching = false;
			var key = (aST);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { aST.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(aST != null && aST.Name == "AST" && (aST.Count == 1 && aST[0] != null && aST[0].Name == "eof"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "C" }, "AST [ eof ] -> C [ Declaration [ EPSILON ] Function [ EPSILON ] ]", (aST));
			    var _result = new Compiler.C.Data.C(false) { new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(aST != null && aST.Name == "AST" && (aST.Count == 2 && aST[0] != null && aST[0].Name == "GlobalStatement" && aST[1] != null && aST[1].Name == "eof"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "C" }, "AST [ GlobalStatement : gs eof ] -> C [ Declaration [ CompoundDeclaration [ dcl Declaration [ CompoundDeclaration [ Declaration [ FunctionPrototype [ signed long Pow ( signed long a , signed long b ) ] ; ] Declaration [ FunctionPrototype [ Type [ void ] main ( ) ] ; ] ] ] ] ] Function [ CompoundFunction [ Function [ CompoundFunction [ Function [ signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; } ] f ] ] Function [ Type [ void ] main ( ) { Declaration [ EPSILON ] s } ] ] ] ]", (aST));
			    (Compiler.C.Data.Node dcl, Compiler.C.Data.Node f, Compiler.C.Data.Node s) = Translatea(aST[0] as Compiler.AST.Data.GlobalStatement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			    _isMatching = dcl != null && dcl.Name == "Declaration" && f != null && f.Name == "Function" && s != null && s.Name == "Statement";
			    if(dcl != null && f != null && s != null && !_isMatching)
			    {
			        WrongPatterna((dcl, f, s), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.C(false) { new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { dcl as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "Pow", Value = "Pow" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "a", Value = "a" }, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "b", Value = "b" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } }, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "main", Value = "main" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "Pow", Value = "Pow" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "a", Value = "a" }, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "b", Value = "b" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" }, new Compiler.C.Data.Token() { Name = "r", Value = "r" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "i", Value = "i" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "for", Value = "for" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "i", Value = "i" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "0", Value = "0" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "i", Value = "i" }, new Compiler.C.Data.Token() { Name = "<", Value = "<" }, new Compiler.C.Data.Token() { Name = "b", Value = "b" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "i", Value = "i" }, new Compiler.C.Data.Token() { Name = "++", Value = "++" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, new Compiler.C.Data.Token() { Name = "r", Value = "r" }, new Compiler.C.Data.Token() { Name = "*=", Value = "*=" }, new Compiler.C.Data.Token() { Name = "a", Value = "a" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "return", Value = "return" }, new Compiler.C.Data.Token() { Name = "r", Value = "r" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "}", Value = "}" } }, f as Compiler.C.Data.Function } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "main", Value = "main" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, s as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((aST));
			return (null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.GlobalStatement globalStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (globalStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { globalStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ GlobalStatement [ CompoundGlobalStatement : cgs ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl1 f1 s1 ]", (globalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && s1 != null && s1.Name == "Statement";
			    if(dcl1 != null && f1 != null && s1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Interrupt") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ GlobalStatement [ Interrupt : i ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl1 f1 s1 ]", (globalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.Interrupt, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && s1 != null && s1.Name == "Statement";
			    if(dcl1 != null && f1 != null && s1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Function") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ GlobalStatement [ Function : func ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl1 f1 s1 ]", (globalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.Function, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && s1 != null && s1.Name == "Statement";
			    if(dcl1 != null && f1 != null && s1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "Statement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ GlobalStatement [ Statement : s ] Declaration : dcl Function : f Statement : s1 ] -> : a [ dcl2 f2 s2 ]", (globalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(globalStatement[0] as Compiler.AST.Data.Statement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && s2 != null && s2.Name == "Statement";
			    if(dcl2 != null && f2 != null && s2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, s2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, s2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(globalStatement != null && globalStatement.Name == "GlobalStatement" && (globalStatement.Count == 1 && globalStatement[0] != null && globalStatement[0].Name == "CompoundGlobalStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ GlobalStatement [ CompoundGlobalStatement : cgs ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl1 f1 s1 ]", (globalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(globalStatement[0] as Compiler.AST.Data.CompoundGlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && s1 != null && s1.Name == "Statement";
			    if(dcl1 != null && f1 != null && s1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			RulesFaileda((globalStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundGlobalStatement compoundGlobalStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (compoundGlobalStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { compoundGlobalStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(compoundGlobalStatement != null && compoundGlobalStatement.Name == "CompoundGlobalStatement" && (compoundGlobalStatement.Count == 3 && compoundGlobalStatement[0] != null && compoundGlobalStatement[0].Name == "GlobalStatement" && compoundGlobalStatement[1] != null && compoundGlobalStatement[1].Name == "newline" && compoundGlobalStatement[2] != null && compoundGlobalStatement[2].Name == "GlobalStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ CompoundGlobalStatement [ GlobalStatement : gs1 newline GlobalStatement : gs2 ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl2 f2 s2 ]", (compoundGlobalStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node s1) = Translatea(compoundGlobalStatement[0] as Compiler.AST.Data.GlobalStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && s1 != null && s1.Name == "Statement";
			    if(dcl1 != null && f1 != null && s1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node s2) = Translatea(compoundGlobalStatement[2] as Compiler.AST.Data.GlobalStatement, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, s1 as Compiler.C.Data.Statement);
			        _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && s2 != null && s2.Name == "Statement";
			        if(dcl2 != null && f2 != null && s2 != null && !_isMatching)
			        {
			            WrongPatterna((dcl2, f2, s2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, s2 as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((compoundGlobalStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Interrupt interrupt, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (interrupt, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { interrupt.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(interrupt != null && interrupt.Name == "Interrupt" && (interrupt.Count == 7 && interrupt[0] != null && interrupt[0].Name == "interrupt" && interrupt[1] != null && interrupt[1].Name == "(" && interrupt[2] != null && interrupt[2].Name == "numeral" && interrupt[3] != null && interrupt[3].Name == ")" && interrupt[4] != null && interrupt[4].Name == "indent" && interrupt[5] != null && interrupt[5].Name == "Statement" && interrupt[6] != null && interrupt[6].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Interrupt [ interrupt ( numeral : i ) indent Statement : s1 dedent ] Declaration : dcl Function : f Statement : s ] -> : a [ Declaration [ CompoundDeclaration [ dcl Declaration [ FunctionPrototype [ Type [ void ] __vector_ i1 ( ) __attribute__ ( ( signal , used , externally_visible ) ) ] ; ] ] ] Function [ CompoundFunction [ f Function [ Type [ void ] __vector_ i1 ( ) { gs1 si2 } ] ] ] s ]", (interrupt, declaration, function, statement));
			    Compiler.C.Data.Node i1 = Translate(interrupt[2] as Compiler.AST.Data.Token);
			    _isMatching = i1 != null && i1.Name == "numeral";
			    if(i1 != null && !_isMatching)
			    {
			        WrongPattern((i1), new System.Collections.Generic.List<string>() { "numeral" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node gs1, Compiler.C.Data.Node function1, Compiler.C.Data.Node si2) = Translatea(interrupt[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			        _isMatching = gs1 != null && gs1.Name == "Declaration" && function1 != null && function1.Name == "Function" && (function1.Count == 1 && function1[0] != null && function1[0].Name == "EPSILON") && si2 != null && si2.Name == "Statement";
			        if(gs1 != null && function1 != null && si2 != null && !_isMatching)
			        {
			            WrongPatterna((gs1, function1, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "__vector_", Value = "__vector_" }, i1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "__attribute__", Value = "__attribute__" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "signal", Value = "signal" }, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "used", Value = "used" }, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "externally_visible", Value = "externally_visible" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { function as Compiler.C.Data.Function, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } }, new Compiler.C.Data.Token() { Name = "__vector_", Value = "__vector_" }, i1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, gs1 as Compiler.C.Data.Declaration, si2 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } }, statement as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((interrupt, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Function function, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function1, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (function, declaration, function1, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { function.Name, declaration.Name, function1.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(function != null && function.Name == "Function" && (function.Count == 8 && function[0] != null && function[0].Name == "Type" && function[1] != null && function[1].Name == "identifier" && function[2] != null && function[2].Name == "(" && function[3] != null && function[3].Name == "FormalParameters" && function[4] != null && function[4].Name == ")" && function[5] != null && function[5].Name == "indent" && function[6] != null && function[6].Name == "Statement" && function[7] != null && function[7].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function1 != null && function1.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Function [ Type : t identifier : id ( FormalParameters : p ) indent Statement : stm dedent ] Declaration : dcl Function : f Statement : s ] -> : a [ Declaration [ CompoundDeclaration [ dcl Declaration [ FunctionPrototype [ t1 id1 ( p1 ) ] ; ] ] ] Function [ CompoundFunction [ f Function [ t1 id1 ( p1 ) { dcl1 s1 } ] ] ] s ]", (function, declaration, function1, statement));
			    Compiler.C.Data.Node t1 = Translate(function[0] as Compiler.AST.Data.Type);
			    _isMatching = t1 != null && t1.Name == "Type";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPattern((t1), new System.Collections.Generic.List<string>() { "Type" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(function[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node p1 = Translate(function[3] as Compiler.AST.Data.FormalParameters);
			            _isMatching = p1 != null && p1.Name == "FormalParameters";
			            if(p1 != null && !_isMatching)
			            {
			                WrongPattern((p1), new System.Collections.Generic.List<string>() { "FormalParameters" });
			            }
			            else if(_isMatching)
			            {
			                (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node function2, Compiler.C.Data.Node s1) = Translatea(function[6] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			                _isMatching = dcl1 != null && dcl1.Name == "Declaration" && function2 != null && function2.Name == "Function" && (function2.Count == 1 && function2[0] != null && function2[0].Name == "EPSILON") && s1 != null && s1.Name == "Statement";
			                if(dcl1 != null && function2 != null && s1 != null && !_isMatching)
			                {
			                    WrongPatterna((dcl1, function2, s1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.FunctionPrototype(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.FormalParameters, new Compiler.C.Data.Token() { Name = ")", Value = ")" } }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.CompoundFunction(false) { function1 as Compiler.C.Data.Function, new Compiler.C.Data.Function(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.FormalParameters, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl1 as Compiler.C.Data.Declaration, s1 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } }, statement as Compiler.C.Data.Statement);
			                    RuleEnda(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((function, declaration, function1, statement));
			return (null, null, null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.FormalParameters formalParameters)
		{
			bool _isMatching = false;
			var key = (formalParameters);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { formalParameters.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "EPSILON"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameters" }, "FormalParameters [ EPSILON ] -> FormalParameters [ EPSILON ]", (formalParameters));
			    var _result = new Compiler.C.Data.FormalParameters(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(formalParameters != null && formalParameters.Name == "FormalParameters" && (formalParameters.Count == 1 && formalParameters[0] != null && formalParameters[0].Name == "FormalParameter"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameters" }, "FormalParameters [ FormalParameter : p ] -> FormalParameters [ p1 ]", (formalParameters));
			    Compiler.C.Data.Node p1 = Translate(formalParameters[0] as Compiler.AST.Data.FormalParameter);
			    _isMatching = p1 != null && p1.Name == "FormalParameter";
			    if(p1 != null && !_isMatching)
			    {
			        WrongPattern((p1), new System.Collections.Generic.List<string>() { "FormalParameter" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.FormalParameters(false) { p1 as Compiler.C.Data.FormalParameter };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((formalParameters));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.FormalParameter formalParameter)
		{
			bool _isMatching = false;
			var key = (formalParameter);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { formalParameter.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 2 && formalParameter[0] != null && formalParameter[0].Name == "Type" && formalParameter[1] != null && formalParameter[1].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameter" }, "FormalParameter [ Type : t identifier : id ] -> FormalParameter [ t1 id1 ]", (formalParameter));
			    Compiler.C.Data.Node t1 = Translate(formalParameter[0] as Compiler.AST.Data.Type);
			    _isMatching = t1 != null && t1.Name == "Type";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPattern((t1), new System.Collections.Generic.List<string>() { "Type" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(formalParameter[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.FormalParameter(false) { t1 as Compiler.C.Data.Type, id1 as Compiler.C.Data.Token };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			if(formalParameter != null && formalParameter.Name == "FormalParameter" && (formalParameter.Count == 1 && formalParameter[0] != null && formalParameter[0].Name == "CompoundFormalParameter"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "FormalParameter" }, "FormalParameter [ CompoundFormalParameter : cpar ] -> FormalParameter [ cpar1 ]", (formalParameter));
			    Compiler.C.Data.Node cpar1 = Translate(formalParameter[0] as Compiler.AST.Data.CompoundFormalParameter);
			    _isMatching = cpar1 != null && cpar1.Name == "CompoundFormalParameter";
			    if(cpar1 != null && !_isMatching)
			    {
			        WrongPattern((cpar1), new System.Collections.Generic.List<string>() { "CompoundFormalParameter" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.FormalParameter(false) { cpar1 as Compiler.C.Data.CompoundFormalParameter };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((formalParameter));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.CompoundFormalParameter compoundFormalParameter)
		{
			bool _isMatching = false;
			var key = (compoundFormalParameter);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { compoundFormalParameter.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(compoundFormalParameter != null && compoundFormalParameter.Name == "CompoundFormalParameter" && (compoundFormalParameter.Count == 3 && compoundFormalParameter[0] != null && compoundFormalParameter[0].Name == "FormalParameter" && compoundFormalParameter[1] != null && compoundFormalParameter[1].Name == "," && compoundFormalParameter[2] != null && compoundFormalParameter[2].Name == "FormalParameter"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "CompoundFormalParameter" }, "CompoundFormalParameter [ FormalParameter : p1 , FormalParameter : p2 ] -> CompoundFormalParameter [ p3 , p4 ]", (compoundFormalParameter));
			    Compiler.C.Data.Node p3 = Translate(compoundFormalParameter[0] as Compiler.AST.Data.FormalParameter);
			    _isMatching = p3 != null && p3.Name == "FormalParameter";
			    if(p3 != null && !_isMatching)
			    {
			        WrongPattern((p3), new System.Collections.Generic.List<string>() { "FormalParameter" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node p4 = Translate(compoundFormalParameter[2] as Compiler.AST.Data.FormalParameter);
			        _isMatching = p4 != null && p4.Name == "FormalParameter";
			        if(p4 != null && !_isMatching)
			        {
			            WrongPattern((p4), new System.Collections.Generic.List<string>() { "FormalParameter" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.CompoundFormalParameter(false) { p3 as Compiler.C.Data.FormalParameter, new Compiler.C.Data.Token() { Name = ",", Value = "," }, p4 as Compiler.C.Data.FormalParameter };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((compoundFormalParameter));
			return (null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.Statement statement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement1)
		{
			bool _isMatching = false;
			var key = (statement, declaration, function, statement1);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { statement.Name, declaration.Name, function.Name, statement1.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "EPSILON") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ EPSILON ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl f s ]", (statement, declaration, function, statement1));
			    var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    RuleEnda(true, true, _result);
			    return _result;
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "newline") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ newline ] Declaration : dcl Function : f Statement : s ] -> : a [ dcl f s ]", (statement, declaration, function, statement1));
			    var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    RuleEnda(true, true, _result);
			    return _result;
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "CompoundStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ CompoundStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.CompoundStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerDeclaration") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IntegerDeclaration : s ] Declaration : dcl Function : f Statement : si ] -> : a [ Declaration [ CompoundDeclaration [ dcl Declaration [ s1 ; ] ] ] f si ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerDeclaration);
			    _isMatching = s1 != null && s1.Name == "IntegerDeclaration";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IntegerDeclaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.IntegerDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "IntType" && statement[0][1] != null && statement[0][1].Name == "identifier" && statement[0][2] != null && statement[0][2].Name == "=" && statement[0][3] != null && statement[0][3].Name == "IntegerExpression")) && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IntegerDeclarationInit [ IntType : intType identifier : id = IntegerExpression : iexpr ] ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.IntegerDeclaration(false) { statement[0][0] as Compiler.AST.Data.IntType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && si1 != null && si1.Name == "Statement";
			    if(dcl1 != null && f1 != null && si1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, si1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.IntegerAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.IntegerExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
			        _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			        if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			        {
			            WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanDeclaration") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ BooleanDeclaration : s ] Declaration : dcl Function : f Statement : si ] -> : a [ Declaration [ CompoundDeclaration [ dcl Declaration [ s1 ; ] ] ] f si ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanDeclaration);
			    _isMatching = s1 != null && s1.Name == "BooleanDeclaration";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "BooleanDeclaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.BooleanDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "BooleanType" && statement[0][1] != null && statement[0][1].Name == "identifier" && statement[0][2] != null && statement[0][2].Name == "=" && statement[0][3] != null && statement[0][3].Name == "BooleanExpression")) && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ BooleanDeclarationInit [ BooleanType : boolType identifier : id = BooleanExpression : bexpr ] ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.BooleanDeclaration(false) { statement[0][0] as Compiler.AST.Data.BooleanType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && si1 != null && si1.Name == "Statement";
			    if(dcl1 != null && f1 != null && si1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, si1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.BooleanAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.BooleanExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
			        _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			        if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			        {
			            WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterDeclaration") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ RegisterDeclaration : s ] Declaration : dcl Function : f Statement : si ] -> : a [ Declaration [ CompoundDeclaration [ dcl Declaration [ s1 ; ] ] ] f si ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterDeclaration);
			    _isMatching = s1 != null && s1.Name == "RegisterDeclaration";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "RegisterDeclaration" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.CompoundDeclaration(false) { declaration as Compiler.C.Data.Declaration, new Compiler.C.Data.Declaration(false) { s1 as Compiler.C.Data.RegisterDeclaration, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } }, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterDeclarationInit" && (statement[0].Count == 4 && statement[0][0] != null && statement[0][0].Name == "RegisterType" && statement[0][1] != null && statement[0][1].Name == "identifier" && statement[0][2] != null && statement[0][2].Name == "=" && statement[0][3] != null && statement[0][3].Name == "RegisterExpression")) && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ RegisterDeclarationInit [ RegisterType : regType identifier : id = RegisterExpression : rexpr ] ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl1, Compiler.C.Data.Node f1, Compiler.C.Data.Node si1) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.RegisterDeclaration(false) { statement[0][0] as Compiler.AST.Data.RegisterType, statement[0][1] as Compiler.AST.Data.Token } }, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl1 != null && dcl1.Name == "Declaration" && f1 != null && f1.Name == "Function" && si1 != null && si1.Name == "Statement";
			    if(dcl1 != null && f1 != null && si1 != null && !_isMatching)
			    {
			        WrongPatterna((dcl1, f1, si1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(new Compiler.AST.Data.Statement(false) { new Compiler.AST.Data.RegisterAssignment(false) { statement[0][1] as Compiler.AST.Data.Token, new Compiler.AST.Data.Token() { Name = "=", Value = "=" }, statement[0][3] as Compiler.AST.Data.RegisterExpression } }, dcl1 as Compiler.C.Data.Declaration, f1 as Compiler.C.Data.Function, si1 as Compiler.C.Data.Statement);
			        _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			        if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			        {
			            WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "DirectBitAssignment") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ DirectBitAssignment : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ s1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.DirectBitAssignment);
			    _isMatching = s1 != null && s1.Name == "DirectBitAssignment";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "DirectBitAssignment" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.DirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IndirectBitAssignment") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IndirectBitAssignment : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ s1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IndirectBitAssignment);
			    _isMatching = s1 != null && s1.Name == "IndirectBitAssignment";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IndirectBitAssignment" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IndirectBitAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerAssignment") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IntegerAssignment : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ s1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.IntegerAssignment);
			    _isMatching = s1 != null && s1.Name == "IntegerAssignment";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IntegerAssignment" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.IntegerAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanAssignment") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ BooleanAssignment : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ s1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.BooleanAssignment);
			    _isMatching = s1 != null && s1.Name == "BooleanAssignment";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "BooleanAssignment" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.BooleanAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterAssignment") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ RegisterAssignment : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ s1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node s1 = Translate(statement[0] as Compiler.AST.Data.RegisterAssignment);
			    _isMatching = s1 != null && s1.Name == "RegisterAssignment";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "RegisterAssignment" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { s1 as Compiler.C.Data.RegisterAssignment, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IfStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfElseStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IfElseStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfElseStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IfElseIfStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IfElseIfStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.IfElseIfStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "WhileStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ WhileStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.WhileStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "ForStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ ForStatement : s ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl2 f2 si2 ]", (statement, declaration, function, statement1));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(statement[0] as Compiler.AST.Data.ForStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement1 as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "IntegerReturn") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ IntegerReturn : iret ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ iret1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node iret1 = Translate(statement[0] as Compiler.AST.Data.IntegerReturn);
			    _isMatching = iret1 != null && iret1.Name == "IntegerReturn";
			    if(iret1 != null && !_isMatching)
			    {
			        WrongPattern((iret1), new System.Collections.Generic.List<string>() { "IntegerReturn" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { iret1 as Compiler.C.Data.IntegerReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "EmptyReturn") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ EmptyReturn : eret ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ eret1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node eret1 = Translate(statement[0] as Compiler.AST.Data.EmptyReturn);
			    _isMatching = eret1 != null && eret1.Name == "EmptyReturn";
			    if(eret1 != null && !_isMatching)
			    {
			        WrongPattern((eret1), new System.Collections.Generic.List<string>() { "EmptyReturn" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { eret1 as Compiler.C.Data.EmptyReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "BooleanReturn") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ BooleanReturn : bret ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ bret1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node bret1 = Translate(statement[0] as Compiler.AST.Data.BooleanReturn);
			    _isMatching = bret1 != null && bret1.Name == "BooleanReturn";
			    if(bret1 != null && !_isMatching)
			    {
			        WrongPattern((bret1), new System.Collections.Generic.List<string>() { "BooleanReturn" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { bret1 as Compiler.C.Data.BooleanReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "RegisterReturn") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ RegisterReturn : rret ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ rret1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node rret1 = Translate(statement[0] as Compiler.AST.Data.RegisterReturn);
			    _isMatching = rret1 != null && rret1.Name == "RegisterReturn";
			    if(rret1 != null && !_isMatching)
			    {
			        WrongPattern((rret1), new System.Collections.Generic.List<string>() { "RegisterReturn" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { rret1 as Compiler.C.Data.RegisterReturn, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "Call") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ Call : c ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ c1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node c1 = Translate(statement[0] as Compiler.AST.Data.Call);
			    _isMatching = c1 != null && c1.Name == "Call";
			    if(c1 != null && !_isMatching)
			    {
			        WrongPattern((c1), new System.Collections.Generic.List<string>() { "Call" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { c1 as Compiler.C.Data.Call, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			if(statement != null && statement.Name == "Statement" && (statement.Count == 1 && statement[0] != null && statement[0].Name == "InterruptStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement1 != null && statement1.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ Statement [ InterruptStatement : c ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ c1 ; ] ] ] ]", (statement, declaration, function, statement1));
			    Compiler.C.Data.Node c1 = Translate(statement[0] as Compiler.AST.Data.InterruptStatement);
			    _isMatching = c1 != null && c1.Name == "InterruptStatement";
			    if(c1 != null && !_isMatching)
			    {
			        WrongPattern((c1), new System.Collections.Generic.List<string>() { "InterruptStatement" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement1 as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { c1 as Compiler.C.Data.InterruptStatement, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } });
			        RuleEnda(true, true, _result);
			        return _result;
			    }
			    RuleEnda(false);
			}
			RulesFaileda((statement, declaration, function, statement1));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.CompoundStatement compoundStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (compoundStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { compoundStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(compoundStatement != null && compoundStatement.Name == "CompoundStatement" && (compoundStatement.Count == 3 && compoundStatement[0] != null && compoundStatement[0].Name == "Statement" && compoundStatement[1] != null && compoundStatement[1].Name == "newline" && compoundStatement[2] != null && compoundStatement[2].Name == "Statement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ CompoundStatement [ Statement : s1 newline Statement : s2 ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl3 f3 si3 ]", (compoundStatement, declaration, function, statement));
			    (Compiler.C.Data.Node dcl2, Compiler.C.Data.Node f2, Compiler.C.Data.Node si2) = Translatea(compoundStatement[0] as Compiler.AST.Data.Statement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = dcl2 != null && dcl2.Name == "Declaration" && f2 != null && f2.Name == "Function" && si2 != null && si2.Name == "Statement";
			    if(dcl2 != null && f2 != null && si2 != null && !_isMatching)
			    {
			        WrongPatterna((dcl2, f2, si2), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(compoundStatement[2] as Compiler.AST.Data.Statement, dcl2 as Compiler.C.Data.Declaration, f2 as Compiler.C.Data.Function, si2 as Compiler.C.Data.Statement);
			        _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			        if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			        {
			            WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (dcl3 as Compiler.C.Data.Declaration, f3 as Compiler.C.Data.Function, si3 as Compiler.C.Data.Statement);
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((compoundStatement, declaration, function, statement));
			return (null, null, null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerDeclaration integerDeclaration)
		{
			bool _isMatching = false;
			var key = (integerDeclaration);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerDeclaration.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerDeclaration != null && integerDeclaration.Name == "IntegerDeclaration" && (integerDeclaration.Count == 2 && integerDeclaration[0] != null && integerDeclaration[0].Name == "IntType" && integerDeclaration[1] != null && integerDeclaration[1].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerDeclaration" }, "IntegerDeclaration [ IntType : i identifier : id ] -> IntegerDeclaration [ i1 id1 ]", (integerDeclaration));
			    Compiler.C.Data.Node i1 = Translate(integerDeclaration[0] as Compiler.AST.Data.IntType);
			    _isMatching = i1 != null && i1.Name == "IntType";
			    if(i1 != null && !_isMatching)
			    {
			        WrongPattern((i1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(integerDeclaration[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.IntegerDeclaration(false) { i1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerDeclaration));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerDeclarationInit integerDeclarationInit)
		{
			bool _isMatching = false;
			var key = (integerDeclarationInit);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerDeclarationInit.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerDeclarationInit != null && integerDeclarationInit.Name == "IntegerDeclarationInit" && (integerDeclarationInit.Count == 4 && integerDeclarationInit[0] != null && integerDeclarationInit[0].Name == "IntType" && integerDeclarationInit[1] != null && integerDeclarationInit[1].Name == "identifier" && integerDeclarationInit[2] != null && integerDeclarationInit[2].Name == "=" && integerDeclarationInit[3] != null && integerDeclarationInit[3].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerDeclarationInit" }, "IntegerDeclarationInit [ IntType : intType identifier : id = IntegerExpression : iexpr ] -> IntegerDeclarationInit [ intType1 id1 = iexpr1 ]", (integerDeclarationInit));
			    Compiler.C.Data.Node intType1 = Translate(integerDeclarationInit[0] as Compiler.AST.Data.IntType);
			    _isMatching = intType1 != null && intType1.Name == "IntType";
			    if(intType1 != null && !_isMatching)
			    {
			        WrongPattern((intType1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(integerDeclarationInit[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node iexpr1 = Translate(integerDeclarationInit[3] as Compiler.AST.Data.IntegerExpression);
			            _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			            if(iexpr1 != null && !_isMatching)
			            {
			                WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			            }
			            else if(_isMatching)
			            {
			                var _result = new Compiler.C.Data.IntegerDeclarationInit(false) { intType1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, iexpr1 as Compiler.C.Data.IntegerExpression };
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerDeclarationInit));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerAssignment integerAssignment)
		{
			bool _isMatching = false;
			var key = (integerAssignment);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerAssignment.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerAssignment != null && integerAssignment.Name == "IntegerAssignment" && (integerAssignment.Count == 3 && integerAssignment[0] != null && integerAssignment[0].Name == "identifier" && integerAssignment[1] != null && integerAssignment[1].Name == "=" && integerAssignment[2] != null && integerAssignment[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerAssignment" }, "IntegerAssignment [ identifier : id = IntegerExpression : iexpr ] -> IntegerAssignment [ id1 = iexpr1 ]", (integerAssignment));
			    Compiler.C.Data.Node id1 = Translate(integerAssignment[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr1 = Translate(integerAssignment[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			        if(iexpr1 != null && !_isMatching)
			        {
			            WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.IntegerAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, iexpr1 as Compiler.C.Data.IntegerExpression };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerAssignment));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanDeclaration booleanDeclaration)
		{
			bool _isMatching = false;
			var key = (booleanDeclaration);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanDeclaration.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanDeclaration != null && booleanDeclaration.Name == "BooleanDeclaration" && (booleanDeclaration.Count == 2 && booleanDeclaration[0] != null && booleanDeclaration[0].Name == "BooleanType" && booleanDeclaration[1] != null && booleanDeclaration[1].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanDeclaration" }, "BooleanDeclaration [ BooleanType : boolType identifier : id ] -> BooleanDeclaration [ boolType1 id1 ]", (booleanDeclaration));
			    Compiler.C.Data.Node boolType1 = Translate(booleanDeclaration[0] as Compiler.AST.Data.BooleanType);
			    _isMatching = boolType1 != null && boolType1.Name == "BooleanType";
			    if(boolType1 != null && !_isMatching)
			    {
			        WrongPattern((boolType1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(booleanDeclaration[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.BooleanDeclaration(false) { boolType1 as Compiler.C.Data.BooleanType, id1 as Compiler.C.Data.Token };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanDeclaration));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanDeclarationInit booleanDeclarationInit)
		{
			bool _isMatching = false;
			var key = (booleanDeclarationInit);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanDeclarationInit.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanDeclarationInit != null && booleanDeclarationInit.Name == "BooleanDeclarationInit" && (booleanDeclarationInit.Count == 4 && booleanDeclarationInit[0] != null && booleanDeclarationInit[0].Name == "BooleanType" && booleanDeclarationInit[1] != null && booleanDeclarationInit[1].Name == "identifier" && booleanDeclarationInit[2] != null && booleanDeclarationInit[2].Name == "=" && booleanDeclarationInit[3] != null && booleanDeclarationInit[3].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanDeclarationInit" }, "BooleanDeclarationInit [ BooleanType : boolType identifier : id = BooleanExpression : bexpr ] -> BooleanDeclarationInit [ boolType1 id1 = bexpr1 ]", (booleanDeclarationInit));
			    Compiler.C.Data.Node boolType1 = Translate(booleanDeclarationInit[0] as Compiler.AST.Data.BooleanType);
			    _isMatching = boolType1 != null && boolType1.Name == "BooleanType";
			    if(boolType1 != null && !_isMatching)
			    {
			        WrongPattern((boolType1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(booleanDeclarationInit[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node bexpr1 = Translate(booleanDeclarationInit[3] as Compiler.AST.Data.BooleanExpression);
			            _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			            if(bexpr1 != null && !_isMatching)
			            {
			                WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			            }
			            else if(_isMatching)
			            {
			                var _result = new Compiler.C.Data.BooleanDeclarationInit(false) { boolType1 as Compiler.C.Data.BooleanType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, bexpr1 as Compiler.C.Data.BooleanExpression };
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanDeclarationInit));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanType booleanType)
		{
			bool _isMatching = false;
			var key = (booleanType);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanType.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanType != null && booleanType.Name == "BooleanType" && (booleanType.Count == 1 && booleanType[0] != null && booleanType[0].Name == "bool"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanType" }, "BooleanType [ bool ] -> BooleanType [ unsigned char ]", (booleanType));
			    var _result = new Compiler.C.Data.BooleanType(false) { new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((booleanType));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanAssignment booleanAssignment)
		{
			bool _isMatching = false;
			var key = (booleanAssignment);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanAssignment.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanAssignment != null && booleanAssignment.Name == "BooleanAssignment" && (booleanAssignment.Count == 3 && booleanAssignment[0] != null && booleanAssignment[0].Name == "identifier" && booleanAssignment[1] != null && booleanAssignment[1].Name == "=" && booleanAssignment[2] != null && booleanAssignment[2].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanAssignment" }, "BooleanAssignment [ identifier : id = BooleanExpression : bexpr ] -> BooleanAssignment [ id1 = bexpr1 ]", (booleanAssignment));
			    Compiler.C.Data.Node id1 = Translate(booleanAssignment[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr1 = Translate(booleanAssignment[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			        if(bexpr1 != null && !_isMatching)
			        {
			            WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.BooleanAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, bexpr1 as Compiler.C.Data.BooleanExpression };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanAssignment));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DirectBitAssignment directBitAssignment)
		{
			bool _isMatching = false;
			var key = (directBitAssignment);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { directBitAssignment.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(directBitAssignment != null && directBitAssignment.Name == "DirectBitAssignment" && (directBitAssignment.Count == 9 && directBitAssignment[0] != null && directBitAssignment[0].Name == "RegisterType" && directBitAssignment[1] != null && directBitAssignment[1].Name == "(" && directBitAssignment[2] != null && directBitAssignment[2].Name == "IntegerExpression" && directBitAssignment[3] != null && directBitAssignment[3].Name == ")" && directBitAssignment[4] != null && directBitAssignment[4].Name == "{" && directBitAssignment[5] != null && directBitAssignment[5].Name == "IntegerExpression" && directBitAssignment[6] != null && directBitAssignment[6].Name == "}" && directBitAssignment[7] != null && directBitAssignment[7].Name == "=" && directBitAssignment[8] != null && directBitAssignment[8].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "DirectBitAssignment" }, "DirectBitAssignment [ RegisterType : regType ( IntegerExpression : expr1 ) { IntegerExpression : expr2 } = BooleanExpression : bexpr ] -> DirectBitAssignment [ ( \\* ( regType1 ) ( iexpr1 ) ) = ( bexpr1 ? ( ( \\* ( regType1 ) ( iexpr1 ) ) \\| 1 << ( iexpr2 ) ) \\: ( ( \\* ( regType1 ) ( iexpr1 ) ) & ~ ( 1 << ( iexpr2 ) ) ) ) ]", (directBitAssignment));
			    Compiler.C.Data.Node regType1 = Translate(directBitAssignment[0] as Compiler.AST.Data.RegisterType);
			    _isMatching = regType1 != null && regType1.Name == "RegisterType";
			    if(regType1 != null && !_isMatching)
			    {
			        WrongPattern((regType1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr1 = Translate(directBitAssignment[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			        if(iexpr1 != null && !_isMatching)
			        {
			            WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node iexpr2 = Translate(directBitAssignment[5] as Compiler.AST.Data.IntegerExpression);
			            _isMatching = iexpr2 != null && iexpr2.Name == "IntegerExpression";
			            if(iexpr2 != null && !_isMatching)
			            {
			                WrongPattern((iexpr2), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.C.Data.Node bexpr1 = Translate(directBitAssignment[8] as Compiler.AST.Data.BooleanExpression);
			                _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			                if(bexpr1 != null && !_isMatching)
			                {
			                    WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			                }
			                else if(_isMatching)
			                {
			                    var _result = new Compiler.C.Data.DirectBitAssignment(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "|", Value = "|" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "~", Value = "~" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			                    RuleEnd(true, true, _result);
			                    return _result;
			                }
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((directBitAssignment));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterType registerType)
		{
			bool _isMatching = false;
			var key = (registerType);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerType.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register8"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register8 ] -> RegisterType [ volatile unsigned char * ]", (registerType));
			    var _result = new Compiler.C.Data.RegisterType(false) { new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(registerType != null && registerType.Name == "RegisterType" && (registerType.Count == 1 && registerType[0] != null && registerType[0].Name == "register16"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterType" }, "RegisterType [ register16 ] -> RegisterType [ volatile unsigned short * ]", (registerType));
			    var _result = new Compiler.C.Data.RegisterType(false) { new Compiler.C.Data.Token() { Name = "volatile", Value = "volatile" }, new Compiler.C.Data.Token() { Name = "unsigned", Value = "unsigned" }, new Compiler.C.Data.Token() { Name = "short", Value = "short" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((registerType));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IndirectBitAssignment indirectBitAssignment)
		{
			bool _isMatching = false;
			var key = (indirectBitAssignment);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { indirectBitAssignment.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(indirectBitAssignment != null && indirectBitAssignment.Name == "IndirectBitAssignment" && (indirectBitAssignment.Count == 6 && indirectBitAssignment[0] != null && indirectBitAssignment[0].Name == "identifier" && indirectBitAssignment[1] != null && indirectBitAssignment[1].Name == "{" && indirectBitAssignment[2] != null && indirectBitAssignment[2].Name == "IntegerExpression" && indirectBitAssignment[3] != null && indirectBitAssignment[3].Name == "}" && indirectBitAssignment[4] != null && indirectBitAssignment[4].Name == "=" && indirectBitAssignment[5] != null && indirectBitAssignment[5].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IndirectBitAssignment" }, "IndirectBitAssignment [ identifier : id { IntegerExpression : iexpr } = BooleanExpression : bexpr ] -> IndirectBitAssignment [ * id1 = ( bexpr1 ? ( ( \\* id1 ) | 1 << ( iexpr1 ) ) \\: ( ( \\* id1 ) & ~ ( 1 << ( iexpr1 ) ) ) ) ]", (indirectBitAssignment));
			    Compiler.C.Data.Node id1 = Translate(indirectBitAssignment[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr1 = Translate(indirectBitAssignment[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			        if(iexpr1 != null && !_isMatching)
			        {
			            WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node bexpr1 = Translate(indirectBitAssignment[5] as Compiler.AST.Data.BooleanExpression);
			            _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			            if(bexpr1 != null && !_isMatching)
			            {
			                WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			            }
			            else if(_isMatching)
			            {
			                var _result = new Compiler.C.Data.IndirectBitAssignment(false) { new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "|", Value = "|" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "~", Value = "~" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((indirectBitAssignment));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterDeclaration registerDeclaration)
		{
			bool _isMatching = false;
			var key = (registerDeclaration);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerDeclaration.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerDeclaration != null && registerDeclaration.Name == "RegisterDeclaration" && (registerDeclaration.Count == 2 && registerDeclaration[0] != null && registerDeclaration[0].Name == "RegisterType" && registerDeclaration[1] != null && registerDeclaration[1].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterDeclaration" }, "RegisterDeclaration [ RegisterType : regType identifier : id ] -> RegisterDeclaration [ regType1 id1 ]", (registerDeclaration));
			    Compiler.C.Data.Node regType1 = Translate(registerDeclaration[0] as Compiler.AST.Data.RegisterType);
			    _isMatching = regType1 != null && regType1.Name == "RegisterType";
			    if(regType1 != null && !_isMatching)
			    {
			        WrongPattern((regType1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(registerDeclaration[1] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.RegisterDeclaration(false) { regType1 as Compiler.C.Data.RegisterType, id1 as Compiler.C.Data.Token };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerDeclaration));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterDeclarationInit registerDeclarationInit)
		{
			bool _isMatching = false;
			var key = (registerDeclarationInit);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerDeclarationInit.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerDeclarationInit != null && registerDeclarationInit.Name == "RegisterDeclarationInit" && (registerDeclarationInit.Count == 4 && registerDeclarationInit[0] != null && registerDeclarationInit[0].Name == "RegisterType" && registerDeclarationInit[1] != null && registerDeclarationInit[1].Name == "identifier" && registerDeclarationInit[2] != null && registerDeclarationInit[2].Name == "=" && registerDeclarationInit[3] != null && registerDeclarationInit[3].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterDeclarationInit" }, "RegisterDeclarationInit [ RegisterType : regType identifier : id = RegisterExpression : rexpr ] -> RegisterDeclarationInit [ regType1 id1 = rexpr1 ]", (registerDeclarationInit));
			    Compiler.C.Data.Node rexpr1 = Translate(registerDeclarationInit[3] as Compiler.AST.Data.RegisterExpression);
			    _isMatching = rexpr1 != null && rexpr1.Name == "RegisterExpression";
			    if(rexpr1 != null && !_isMatching)
			    {
			        WrongPattern((rexpr1), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node regType1 = Translate(registerDeclarationInit[0] as Compiler.AST.Data.RegisterType);
			        _isMatching = regType1 != null && regType1.Name == "RegisterType";
			        if(regType1 != null && !_isMatching)
			        {
			            WrongPattern((regType1), new System.Collections.Generic.List<string>() { "RegisterType" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node id1 = Translate(registerDeclarationInit[1] as Compiler.AST.Data.Token);
			            _isMatching = id1 != null && id1.Name == "identifier";
			            if(id1 != null && !_isMatching)
			            {
			                WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			            }
			            else if(_isMatching)
			            {
			                var _result = new Compiler.C.Data.RegisterDeclarationInit(false) { regType1 as Compiler.C.Data.RegisterType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, rexpr1 as Compiler.C.Data.RegisterExpression };
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerDeclarationInit));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterAssignment registerAssignment)
		{
			bool _isMatching = false;
			var key = (registerAssignment);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerAssignment.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerAssignment != null && registerAssignment.Name == "RegisterAssignment" && (registerAssignment.Count == 3 && registerAssignment[0] != null && registerAssignment[0].Name == "identifier" && registerAssignment[1] != null && registerAssignment[1].Name == "=" && registerAssignment[2] != null && registerAssignment[2].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterAssignment" }, "RegisterAssignment [ identifier : id = RegisterExpression : rexpr ] -> RegisterAssignment [ id1 = rexpr1 ]", (registerAssignment));
			    Compiler.C.Data.Node id1 = Translate(registerAssignment[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node rexpr1 = Translate(registerAssignment[2] as Compiler.AST.Data.RegisterExpression);
			        _isMatching = rexpr1 != null && rexpr1.Name == "RegisterExpression";
			        if(rexpr1 != null && !_isMatching)
			        {
			            WrongPattern((rexpr1), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.RegisterAssignment(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, rexpr1 as Compiler.C.Data.RegisterExpression };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerAssignment));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterExpression registerExpression)
		{
			bool _isMatching = false;
			var key = (registerExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "RegisterLiteral"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression" }, "RegisterExpression [ RegisterLiteral : rlit ] -> RegisterExpression [ rlit1 ]", (registerExpression));
			    Compiler.C.Data.Node rlit1 = Translate(registerExpression[0] as Compiler.AST.Data.RegisterLiteral);
			    _isMatching = rlit1 != null && rlit1.Name == "RegisterLiteral";
			    if(rlit1 != null && !_isMatching)
			    {
			        WrongPattern((rlit1), new System.Collections.Generic.List<string>() { "RegisterLiteral" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.RegisterExpression(false) { rlit1 as Compiler.C.Data.RegisterLiteral };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression" }, "RegisterExpression [ identifier : id ] -> RegisterExpression [ id1 ]", (registerExpression));
			    Compiler.C.Data.Node id1 = Translate(registerExpression[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.RegisterExpression(false) { id1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(registerExpression != null && registerExpression.Name == "RegisterExpression" && (registerExpression.Count == 1 && registerExpression[0] != null && registerExpression[0].Name == "Call"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterExpression" }, "RegisterExpression [ Call : s ] -> RegisterExpression [ s1 ]", (registerExpression));
			    Compiler.C.Data.Node s1 = Translate(registerExpression[0] as Compiler.AST.Data.Call);
			    _isMatching = s1 != null && s1.Name == "Call";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "Call" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.RegisterExpression(false) { s1 as Compiler.C.Data.Call };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerReturn integerReturn)
		{
			bool _isMatching = false;
			var key = (integerReturn);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerReturn.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerReturn != null && integerReturn.Name == "IntegerReturn" && (integerReturn.Count == 2 && integerReturn[0] != null && integerReturn[0].Name == "return" && integerReturn[1] != null && integerReturn[1].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerReturn" }, "IntegerReturn [ return IntegerExpression : expr ] -> IntegerReturn [ return iexpr ]", (integerReturn));
			    Compiler.C.Data.Node iexpr = Translate(integerReturn[1] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr != null && iexpr.Name == "IntegerExpression";
			    if(iexpr != null && !_isMatching)
			    {
			        WrongPattern((iexpr), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, iexpr as Compiler.C.Data.IntegerExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerReturn));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanReturn booleanReturn)
		{
			bool _isMatching = false;
			var key = (booleanReturn);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanReturn.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanReturn != null && booleanReturn.Name == "BooleanReturn" && (booleanReturn.Count == 2 && booleanReturn[0] != null && booleanReturn[0].Name == "return" && booleanReturn[1] != null && booleanReturn[1].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanReturn" }, "BooleanReturn [ return BooleanExpression : expr ] -> BooleanReturn [ return bexpr ]", (booleanReturn));
			    Compiler.C.Data.Node bexpr = Translate(booleanReturn[1] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr != null && bexpr.Name == "BooleanExpression";
			    if(bexpr != null && !_isMatching)
			    {
			        WrongPattern((bexpr), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, bexpr as Compiler.C.Data.BooleanExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanReturn));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.EmptyReturn emptyReturn)
		{
			bool _isMatching = false;
			var key = (emptyReturn);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { emptyReturn.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(emptyReturn != null && emptyReturn.Name == "EmptyReturn" && (emptyReturn.Count == 1 && emptyReturn[0] != null && emptyReturn[0].Name == "return"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "EmptyReturn" }, "EmptyReturn [ return ] -> EmptyReturn [ return ]", (emptyReturn));
			    var _result = new Compiler.C.Data.EmptyReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((emptyReturn));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterReturn registerReturn)
		{
			bool _isMatching = false;
			var key = (registerReturn);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerReturn.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerReturn != null && registerReturn.Name == "RegisterReturn" && (registerReturn.Count == 2 && registerReturn[0] != null && registerReturn[0].Name == "return" && registerReturn[1] != null && registerReturn[1].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterReturn" }, "RegisterReturn [ return RegisterExpression : expr ] -> RegisterReturn [ return rexpr ]", (registerReturn));
			    Compiler.C.Data.Node rexpr = Translate(registerReturn[1] as Compiler.AST.Data.RegisterExpression);
			    _isMatching = rexpr != null && rexpr.Name == "RegisterExpression";
			    if(rexpr != null && !_isMatching)
			    {
			        WrongPattern((rexpr), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.RegisterReturn(false) { new Compiler.C.Data.Token() { Name = "return", Value = "return" }, rexpr as Compiler.C.Data.RegisterExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerReturn));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.Call call)
		{
			bool _isMatching = false;
			var key = (call);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { call.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(call != null && call.Name == "Call" && (call.Count == 4 && call[0] != null && call[0].Name == "identifier" && call[1] != null && call[1].Name == "(" && call[2] != null && call[2].Name == "ExpressionList" && call[3] != null && call[3].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Call" }, "Call [ identifier : id ( ExpressionList : p ) ] -> Call [ id1 ( p1 ) ]", (call));
			    Compiler.C.Data.Node id1 = Translate(call[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node p1 = Translate(call[2] as Compiler.AST.Data.ExpressionList);
			        _isMatching = p1 != null && p1.Name == "ExpressionList";
			        if(p1 != null && !_isMatching)
			        {
			            WrongPattern((p1), new System.Collections.Generic.List<string>() { "ExpressionList" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.Call(false) { id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, p1 as Compiler.C.Data.ExpressionList, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((call));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ExpressionList expressionList)
		{
			bool _isMatching = false;
			var key = (expressionList);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { expressionList.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "EPSILON"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionList" }, "ExpressionList [ EPSILON ] -> ExpressionList [ EPSILON ]", (expressionList));
			    var _result = new Compiler.C.Data.ExpressionList(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(expressionList != null && expressionList.Name == "ExpressionList" && (expressionList.Count == 1 && expressionList[0] != null && expressionList[0].Name == "ExpressionListArgs"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionList" }, "ExpressionList [ ExpressionListArgs : p ] -> ExpressionList [ p1 ]", (expressionList));
			    Compiler.C.Data.Node p1 = Translate(expressionList[0] as Compiler.AST.Data.ExpressionListArgs);
			    _isMatching = p1 != null && p1.Name == "ExpressionListArgs";
			    if(p1 != null && !_isMatching)
			    {
			        WrongPattern((p1), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.ExpressionList(false) { p1 as Compiler.C.Data.ExpressionListArgs };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((expressionList));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ExpressionListArgs expressionListArgs)
		{
			bool _isMatching = false;
			var key = (expressionListArgs);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { expressionListArgs.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "ExpressionListArgs [ IntegerExpression : expr ] -> ExpressionListArgs [ iexpr ]", (expressionListArgs));
			    Compiler.C.Data.Node iexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr != null && iexpr.Name == "IntegerExpression";
			    if(iexpr != null && !_isMatching)
			    {
			        WrongPattern((iexpr), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.ExpressionListArgs(false) { iexpr as Compiler.C.Data.IntegerExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "ExpressionListArgs [ BooleanExpression : expr ] -> ExpressionListArgs [ bexpr ]", (expressionListArgs));
			    Compiler.C.Data.Node bexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr != null && bexpr.Name == "BooleanExpression";
			    if(bexpr != null && !_isMatching)
			    {
			        WrongPattern((bexpr), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.ExpressionListArgs(false) { bexpr as Compiler.C.Data.BooleanExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "ExpressionListArgs [ RegisterExpression : expr ] -> ExpressionListArgs [ rexpr ]", (expressionListArgs));
			    Compiler.C.Data.Node rexpr = Translate(expressionListArgs[0] as Compiler.AST.Data.RegisterExpression);
			    _isMatching = rexpr != null && rexpr.Name == "RegisterExpression";
			    if(rexpr != null && !_isMatching)
			    {
			        WrongPattern((rexpr), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.ExpressionListArgs(false) { rexpr as Compiler.C.Data.RegisterExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(expressionListArgs != null && expressionListArgs.Name == "ExpressionListArgs" && (expressionListArgs.Count == 1 && expressionListArgs[0] != null && expressionListArgs[0].Name == "CompoundArgs" && (expressionListArgs[0].Count == 3 && expressionListArgs[0][0] != null && expressionListArgs[0][0].Name == "ExpressionListArgs" && expressionListArgs[0][1] != null && expressionListArgs[0][1].Name == "," && expressionListArgs[0][2] != null && expressionListArgs[0][2].Name == "ExpressionListArgs")))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ExpressionListArgs" }, "ExpressionListArgs [ CompoundArgs [ ExpressionListArgs : p1 , ExpressionListArgs : p2 ] ] -> ExpressionListArgs [ CompoundArgs [ p3 , p4 ] ]", (expressionListArgs));
			    Compiler.C.Data.Node p3 = Translate(expressionListArgs[0][0] as Compiler.AST.Data.ExpressionListArgs);
			    _isMatching = p3 != null && p3.Name == "ExpressionListArgs";
			    if(p3 != null && !_isMatching)
			    {
			        WrongPattern((p3), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node p4 = Translate(expressionListArgs[0][2] as Compiler.AST.Data.ExpressionListArgs);
			        _isMatching = p4 != null && p4.Name == "ExpressionListArgs";
			        if(p4 != null && !_isMatching)
			        {
			            WrongPattern((p4), new System.Collections.Generic.List<string>() { "ExpressionListArgs" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.ExpressionListArgs(false) { new Compiler.C.Data.CompoundArgs(false) { p3 as Compiler.C.Data.ExpressionListArgs, new Compiler.C.Data.Token() { Name = ",", Value = "," }, p4 as Compiler.C.Data.ExpressionListArgs } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((expressionListArgs));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterLiteral registerLiteral)
		{
			bool _isMatching = false;
			var key = (registerLiteral);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerLiteral.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerLiteral != null && registerLiteral.Name == "RegisterLiteral" && (registerLiteral.Count == 4 && registerLiteral[0] != null && registerLiteral[0].Name == "RegisterType" && registerLiteral[1] != null && registerLiteral[1].Name == "(" && registerLiteral[2] != null && registerLiteral[2].Name == "IntegerExpression" && registerLiteral[3] != null && registerLiteral[3].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterLiteral" }, "RegisterLiteral [ RegisterType : regType ( IntegerExpression : iexpr ) ] -> RegisterLiteral [ ( regType1 ) ( iexpr1 ) ]", (registerLiteral));
			    Compiler.C.Data.Node regType1 = Translate(registerLiteral[0] as Compiler.AST.Data.RegisterType);
			    _isMatching = regType1 != null && regType1.Name == "RegisterType";
			    if(regType1 != null && !_isMatching)
			    {
			        WrongPattern((regType1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr1 = Translate(registerLiteral[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			        if(iexpr1 != null && !_isMatching)
			        {
			            WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.RegisterLiteral(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerLiteral));
			return (null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfStatement ifStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (ifStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { ifStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(ifStatement != null && ifStatement.Name == "IfStatement" && (ifStatement.Count == 7 && ifStatement[0] != null && ifStatement[0].Name == "if" && ifStatement[1] != null && ifStatement[1].Name == "(" && ifStatement[2] != null && ifStatement[2].Name == "BooleanExpression" && ifStatement[3] != null && ifStatement[3].Name == ")" && ifStatement[4] != null && ifStatement[4].Name == "indent" && ifStatement[5] != null && ifStatement[5].Name == "Statement" && ifStatement[6] != null && ifStatement[6].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ IfStatement [ if ( BooleanExpression : bexpr ) indent Statement : s dedent ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ IfStatement [ if ( bexpr1 ) { dcl3 si3 } ] ] ] ] ]", (ifStatement, declaration, function, statement));
			    Compiler.C.Data.Node bexpr1 = Translate(ifStatement[2] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			    if(bexpr1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			        _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			        if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			        {
			            WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((ifStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfElseStatement ifElseStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (ifElseStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { ifElseStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(ifElseStatement != null && ifElseStatement.Name == "IfElseStatement" && (ifElseStatement.Count == 11 && ifElseStatement[0] != null && ifElseStatement[0].Name == "if" && ifElseStatement[1] != null && ifElseStatement[1].Name == "(" && ifElseStatement[2] != null && ifElseStatement[2].Name == "BooleanExpression" && ifElseStatement[3] != null && ifElseStatement[3].Name == ")" && ifElseStatement[4] != null && ifElseStatement[4].Name == "indent" && ifElseStatement[5] != null && ifElseStatement[5].Name == "Statement" && ifElseStatement[6] != null && ifElseStatement[6].Name == "dedent" && ifElseStatement[7] != null && ifElseStatement[7].Name == "else" && ifElseStatement[8] != null && ifElseStatement[8].Name == "indent" && ifElseStatement[9] != null && ifElseStatement[9].Name == "Statement" && ifElseStatement[10] != null && ifElseStatement[10].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ IfElseStatement [ if ( BooleanExpression : bexpr ) indent Statement : s dedent else indent Statement : s1 dedent ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ IfElseStatement [ if ( bexpr1 ) { dcl3 si3 } else { dcl4 si4 } ] ] ] ] ]", (ifElseStatement, declaration, function, statement));
			    Compiler.C.Data.Node bexpr1 = Translate(ifElseStatement[2] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			    if(bexpr1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifElseStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			        _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			        if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			        {
			            WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.C.Data.Node dcl4, Compiler.C.Data.Node f4, Compiler.C.Data.Node si4) = Translatea(ifElseStatement[9] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			            _isMatching = dcl4 != null && dcl4.Name == "Declaration" && f4 != null && f4.Name == "Function" && si4 != null && si4.Name == "Statement";
			            if(dcl4 != null && f4 != null && si4 != null && !_isMatching)
			            {
			                WrongPatterna((dcl4, f4, si4), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfElseStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "else", Value = "else" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl4 as Compiler.C.Data.Declaration, si4 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
			                RuleEnda(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((ifElseStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.IfElseIfStatement ifElseIfStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (ifElseIfStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { ifElseIfStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(ifElseIfStatement != null && ifElseIfStatement.Name == "IfElseIfStatement" && (ifElseIfStatement.Count == 9 && ifElseIfStatement[0] != null && ifElseIfStatement[0].Name == "if" && ifElseIfStatement[1] != null && ifElseIfStatement[1].Name == "(" && ifElseIfStatement[2] != null && ifElseIfStatement[2].Name == "BooleanExpression" && ifElseIfStatement[3] != null && ifElseIfStatement[3].Name == ")" && ifElseIfStatement[4] != null && ifElseIfStatement[4].Name == "indent" && ifElseIfStatement[5] != null && ifElseIfStatement[5].Name == "Statement" && ifElseIfStatement[6] != null && ifElseIfStatement[6].Name == "dedent" && ifElseIfStatement[7] != null && ifElseIfStatement[7].Name == "else" && ifElseIfStatement[8] != null && ifElseIfStatement[8].Name == "IfStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ IfElseIfStatement [ if ( BooleanExpression : bexpr ) indent Statement : s dedent else IfStatement : ifStm ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ IfElseIfStatement [ if ( bexpr1 ) { dcl3 si3 } else ifStm1 ] ] ] ] ]", (ifElseIfStatement, declaration, function, statement));
			    (Compiler.C.Data.Node declaration1, Compiler.C.Data.Node function1, Compiler.C.Data.Node statement1) = Translatea(ifElseIfStatement[8] as Compiler.AST.Data.IfStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = declaration1 != null && declaration1.Name == "Declaration" && function1 != null && function1.Name == "Function" && statement1 != null && statement1.Name == "Statement" && (statement1.Count == 1 && statement1[0] != null && statement1[0].Name == "CompoundStatement" && (statement1[0].Count == 2 && statement1[0][0] != null && statement1[0][0].Name == "Statement" && statement1[0][1] != null && statement1[0][1].Name == "Statement" && (statement1[0][1].Count == 1 && statement1[0][1][0] != null && statement1[0][1][0].Name == "IfStatement")));
			    if(declaration1 != null && function1 != null && statement1 != null && !_isMatching)
			    {
			        WrongPatterna((declaration1, function1, statement1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr1 = Translate(ifElseIfStatement[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			        if(bexpr1 != null && !_isMatching)
			        {
			            WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifElseIfStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			            _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			            if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			            {
			                WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfElseIfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "else", Value = "else" }, statement1[0][1][0] as Compiler.C.Data.IfStatement } } } });
			                RuleEnda(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnda(false);
			}
			if(ifElseIfStatement != null && ifElseIfStatement.Name == "IfElseIfStatement" && (ifElseIfStatement.Count == 9 && ifElseIfStatement[0] != null && ifElseIfStatement[0].Name == "if" && ifElseIfStatement[1] != null && ifElseIfStatement[1].Name == "(" && ifElseIfStatement[2] != null && ifElseIfStatement[2].Name == "BooleanExpression" && ifElseIfStatement[3] != null && ifElseIfStatement[3].Name == ")" && ifElseIfStatement[4] != null && ifElseIfStatement[4].Name == "indent" && ifElseIfStatement[5] != null && ifElseIfStatement[5].Name == "Statement" && ifElseIfStatement[6] != null && ifElseIfStatement[6].Name == "dedent" && ifElseIfStatement[7] != null && ifElseIfStatement[7].Name == "else" && ifElseIfStatement[8] != null && ifElseIfStatement[8].Name == "IfElseStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ IfElseIfStatement [ if ( BooleanExpression : bexpr ) indent Statement : s dedent else IfElseStatement : ifStm ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ IfElseIfStatement [ if ( bexpr1 ) { dcl3 si3 } else ifStm1 ] ] ] ] ]", (ifElseIfStatement, declaration, function, statement));
			    (Compiler.C.Data.Node declaration1, Compiler.C.Data.Node function1, Compiler.C.Data.Node statement1) = Translatea(ifElseIfStatement[8] as Compiler.AST.Data.IfElseStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = declaration1 != null && declaration1.Name == "Declaration" && function1 != null && function1.Name == "Function" && statement1 != null && statement1.Name == "Statement" && (statement1.Count == 1 && statement1[0] != null && statement1[0].Name == "CompoundStatement" && (statement1[0].Count == 2 && statement1[0][0] != null && statement1[0][0].Name == "Statement" && statement1[0][1] != null && statement1[0][1].Name == "Statement" && (statement1[0][1].Count == 1 && statement1[0][1][0] != null && statement1[0][1][0].Name == "IfElseStatement")));
			    if(declaration1 != null && function1 != null && statement1 != null && !_isMatching)
			    {
			        WrongPatterna((declaration1, function1, statement1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr1 = Translate(ifElseIfStatement[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			        if(bexpr1 != null && !_isMatching)
			        {
			            WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifElseIfStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			            _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			            if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			            {
			                WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfElseIfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "else", Value = "else" }, statement1[0][1][0] as Compiler.C.Data.IfElseStatement } } } });
			                RuleEnda(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnda(false);
			}
			if(ifElseIfStatement != null && ifElseIfStatement.Name == "IfElseIfStatement" && (ifElseIfStatement.Count == 9 && ifElseIfStatement[0] != null && ifElseIfStatement[0].Name == "if" && ifElseIfStatement[1] != null && ifElseIfStatement[1].Name == "(" && ifElseIfStatement[2] != null && ifElseIfStatement[2].Name == "BooleanExpression" && ifElseIfStatement[3] != null && ifElseIfStatement[3].Name == ")" && ifElseIfStatement[4] != null && ifElseIfStatement[4].Name == "indent" && ifElseIfStatement[5] != null && ifElseIfStatement[5].Name == "Statement" && ifElseIfStatement[6] != null && ifElseIfStatement[6].Name == "dedent" && ifElseIfStatement[7] != null && ifElseIfStatement[7].Name == "else" && ifElseIfStatement[8] != null && ifElseIfStatement[8].Name == "IfElseIfStatement") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ IfElseIfStatement [ if ( BooleanExpression : bexpr ) indent Statement : s dedent else IfElseIfStatement : ifStm ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ IfElseIfStatement [ if ( bexpr1 ) { dcl3 si3 } else ifStm1 ] ] ] ] ]", (ifElseIfStatement, declaration, function, statement));
			    (Compiler.C.Data.Node declaration1, Compiler.C.Data.Node function1, Compiler.C.Data.Node statement1) = Translatea(ifElseIfStatement[8] as Compiler.AST.Data.IfElseIfStatement, declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, statement as Compiler.C.Data.Statement);
			    _isMatching = declaration1 != null && declaration1.Name == "Declaration" && function1 != null && function1.Name == "Function" && statement1 != null && statement1.Name == "Statement" && (statement1.Count == 1 && statement1[0] != null && statement1[0].Name == "CompoundStatement" && (statement1[0].Count == 2 && statement1[0][0] != null && statement1[0][0].Name == "Statement" && statement1[0][1] != null && statement1[0][1].Name == "Statement" && (statement1[0][1].Count == 1 && statement1[0][1][0] != null && statement1[0][1][0].Name == "IfElseIfStatement")));
			    if(declaration1 != null && function1 != null && statement1 != null && !_isMatching)
			    {
			        WrongPatterna((declaration1, function1, statement1), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr1 = Translate(ifElseIfStatement[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			        if(bexpr1 != null && !_isMatching)
			        {
			            WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(ifElseIfStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			            _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			            if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			            {
			                WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			            }
			            else if(_isMatching)
			            {
			                var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.IfElseIfStatement(false) { new Compiler.C.Data.Token() { Name = "if", Value = "if" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "else", Value = "else" }, statement1[0][1][0] as Compiler.C.Data.IfElseIfStatement } } } });
			                RuleEnda(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((ifElseIfStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.WhileStatement whileStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (whileStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { whileStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(whileStatement != null && whileStatement.Name == "WhileStatement" && (whileStatement.Count == 7 && whileStatement[0] != null && whileStatement[0].Name == "while" && whileStatement[1] != null && whileStatement[1].Name == "(" && whileStatement[2] != null && whileStatement[2].Name == "BooleanExpression" && whileStatement[3] != null && whileStatement[3].Name == ")" && whileStatement[4] != null && whileStatement[4].Name == "indent" && whileStatement[5] != null && whileStatement[5].Name == "Statement" && whileStatement[6] != null && whileStatement[6].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ WhileStatement [ while ( BooleanExpression : bexpr ) indent Statement : s dedent ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ WhileStatement [ while ( bexpr1 ) { dcl3 si3 } ] ] ] ] ]", (whileStatement, declaration, function, statement));
			    Compiler.C.Data.Node bexpr1 = Translate(whileStatement[2] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			    if(bexpr1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(whileStatement[5] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			        _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			        if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			        {
			            WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.WhileStatement(false) { new Compiler.C.Data.Token() { Name = "while", Value = "while" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "}", Value = "}" } } } } });
			            RuleEnda(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((whileStatement, declaration, function, statement));
			return (null, null, null);
		}

		public (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) Translatea(Compiler.AST.Data.ForStatement forStatement, Compiler.C.Data.Declaration declaration, Compiler.C.Data.Function function, Compiler.C.Data.Statement statement)
		{
			bool _isMatching = false;
			var key = (forStatement, declaration, function, statement);
			if(Relationa.ContainsKey(key))
			{
			    var value = Relationa[key];
			    RuleStarta(new System.Collections.Generic.List<string>() { forStatement.Name, declaration.Name, function.Name, statement.Name }, "", key);
			    RuleEnda(true, false, value);
			    return value;
			}
			if(forStatement != null && forStatement.Name == "ForStatement" && (forStatement.Count == 12 && forStatement[0] != null && forStatement[0].Name == "for" && forStatement[1] != null && forStatement[1].Name == "(" && forStatement[2] != null && forStatement[2].Name == "IntType" && forStatement[3] != null && forStatement[3].Name == "identifier" && forStatement[4] != null && forStatement[4].Name == "from" && forStatement[5] != null && forStatement[5].Name == "IntegerExpression" && forStatement[6] != null && forStatement[6].Name == "to" && forStatement[7] != null && forStatement[7].Name == "IntegerExpression" && forStatement[8] != null && forStatement[8].Name == ")" && forStatement[9] != null && forStatement[9].Name == "indent" && forStatement[10] != null && forStatement[10].Name == "Statement" && forStatement[11] != null && forStatement[11].Name == "dedent") && declaration != null && declaration.Name == "Declaration" && function != null && function.Name == "Function" && statement != null && statement.Name == "Statement")
			{
			    RuleStarta(new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" }, "[ ForStatement [ for ( IntType : intType identifier : id from IntegerExpression : expr1 to IntegerExpression : expr2 ) indent Statement : s dedent ] Declaration : dcl Function : f Statement : si ] -> : a [ dcl f Statement [ CompoundStatement [ si Statement [ ForStatement [ intType1 _ id1 \\[ \\] = { iexpr1 , iexpr2 , 1 } ; _ id1 \\[ 2 \\] = ( _ id1 \\[ 0 \\] < _ id1 \\[ 1 \\] ? 1 \\: -1 ) ; intType1 id1 = _ id1 \\[ 0 \\] ; do { dcl3 si3 _ id1 \\[ 0 \\] += _ id1 \\[ 2 \\] ; id1 = _ id1 \\[ 0 \\] ; } while ( id1 != _ id1 \\[ 1 \\] + _ id1 \\[ 2 \\] ) ; ] ] ] ] ]", (forStatement, declaration, function, statement));
			    Compiler.C.Data.Node intType1 = Translate(forStatement[2] as Compiler.AST.Data.IntType);
			    _isMatching = intType1 != null && intType1.Name == "IntType";
			    if(intType1 != null && !_isMatching)
			    {
			        WrongPattern((intType1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node id1 = Translate(forStatement[3] as Compiler.AST.Data.Token);
			        _isMatching = id1 != null && id1.Name == "identifier";
			        if(id1 != null && !_isMatching)
			        {
			            WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node iexpr1 = Translate(forStatement[5] as Compiler.AST.Data.IntegerExpression);
			            _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			            if(iexpr1 != null && !_isMatching)
			            {
			                WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			            }
			            else if(_isMatching)
			            {
			                Compiler.C.Data.Node iexpr2 = Translate(forStatement[7] as Compiler.AST.Data.IntegerExpression);
			                _isMatching = iexpr2 != null && iexpr2.Name == "IntegerExpression";
			                if(iexpr2 != null && !_isMatching)
			                {
			                    WrongPattern((iexpr2), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			                }
			                else if(_isMatching)
			                {
			                    (Compiler.C.Data.Node dcl3, Compiler.C.Data.Node f3, Compiler.C.Data.Node si3) = Translatea(forStatement[10] as Compiler.AST.Data.Statement, new Compiler.C.Data.Declaration(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Function(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } }, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.Token() { Name = "EPSILON", Value = "EPSILON" } });
			                    _isMatching = dcl3 != null && dcl3.Name == "Declaration" && f3 != null && f3.Name == "Function" && si3 != null && si3.Name == "Statement";
			                    if(dcl3 != null && f3 != null && si3 != null && !_isMatching)
			                    {
			                        WrongPatterna((dcl3, f3, si3), new System.Collections.Generic.List<string>() { "Declaration", "Function", "Statement" });
			                    }
			                    else if(_isMatching)
			                    {
			                        var _result = (declaration as Compiler.C.Data.Declaration, function as Compiler.C.Data.Function, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.CompoundStatement(false) { statement as Compiler.C.Data.Statement, new Compiler.C.Data.Statement(false) { new Compiler.C.Data.ForStatement(false) { intType1 as Compiler.C.Data.IntType, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ",", Value = "," }, iexpr2 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ",", Value = "," }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "2", Value = "2" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "0", Value = "0" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "<", Value = "<" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "?", Value = "?" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = ":", Value = ":" }, new Compiler.C.Data.Token() { Name = "-1", Value = "-1" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, intType1 as Compiler.C.Data.IntType, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "0", Value = "0" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "do", Value = "do" }, new Compiler.C.Data.Token() { Name = "{", Value = "{" }, dcl3 as Compiler.C.Data.Declaration, si3 as Compiler.C.Data.Statement, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "0", Value = "0" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "+=", Value = "+=" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "2", Value = "2" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "=", Value = "=" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "0", Value = "0" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" }, new Compiler.C.Data.Token() { Name = "}", Value = "}" }, new Compiler.C.Data.Token() { Name = "while", Value = "while" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "!=", Value = "!=" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = "+", Value = "+" }, new Compiler.C.Data.Token() { Name = "_", Value = "_" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "[", Value = "[" }, new Compiler.C.Data.Token() { Name = "2", Value = "2" }, new Compiler.C.Data.Token() { Name = "]", Value = "]" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ";", Value = ";" } } } } });
			                        RuleEnda(true, true, _result);
			                        return _result;
			                    }
			                }
			            }
			        }
			    }
			    RuleEnda(false);
			}
			RulesFaileda((forStatement, declaration, function, statement));
			return (null, null, null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.Type type)
		{
			bool _isMatching = false;
			var key = (type);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { type.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "IntType"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Type" }, "Type [ IntType : t ] -> Type [ t1 ]", (type));
			    Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.IntType);
			    _isMatching = t1 != null && t1.Name == "IntType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPattern((t1), new System.Collections.Generic.List<string>() { "IntType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.IntType };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "RegisterType"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Type" }, "Type [ RegisterType : t ] -> Type [ t1 ]", (type));
			    Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.RegisterType);
			    _isMatching = t1 != null && t1.Name == "RegisterType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPattern((t1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.RegisterType };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "BooleanType"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Type" }, "Type [ BooleanType : t ] -> Type [ t1 ]", (type));
			    Compiler.C.Data.Node t1 = Translate(type[0] as Compiler.AST.Data.BooleanType);
			    _isMatching = t1 != null && t1.Name == "BooleanType";
			    if(t1 != null && !_isMatching)
			    {
			        WrongPattern((t1), new System.Collections.Generic.List<string>() { "BooleanType" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.Type(false) { t1 as Compiler.C.Data.BooleanType };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(type != null && type.Name == "Type" && (type.Count == 1 && type[0] != null && type[0].Name == "nothing"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "Type" }, "Type [ nothing ] -> Type [ void ]", (type));
			    var _result = new Compiler.C.Data.Type(false) { new Compiler.C.Data.Token() { Name = "void", Value = "void" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((type));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntType intType)
		{
			bool _isMatching = false;
			var key = (intType);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { intType.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int8"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int8 ] -> IntType [ signed char ]", (intType));
			    var _result = new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "char", Value = "char" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int16"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int16 ] -> IntType [ signed int ]", (intType));
			    var _result = new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "int", Value = "int" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(intType != null && intType.Name == "IntType" && (intType.Count == 1 && intType[0] != null && intType[0].Name == "int32"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntType" }, "IntType [ int32 ] -> IntType [ signed long ]", (intType));
			    var _result = new Compiler.C.Data.IntType(false) { new Compiler.C.Data.Token() { Name = "signed", Value = "signed" }, new Compiler.C.Data.Token() { Name = "long", Value = "long" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((intType));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.InterruptStatement interruptStatement)
		{
			bool _isMatching = false;
			var key = (interruptStatement);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { interruptStatement.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(interruptStatement != null && interruptStatement.Name == "InterruptStatement" && (interruptStatement.Count == 3 && interruptStatement[0] != null && interruptStatement[0].Name == "enableinterrupts" && interruptStatement[1] != null && interruptStatement[1].Name == "(" && interruptStatement[2] != null && interruptStatement[2].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "InterruptStatement" }, "InterruptStatement [ enableinterrupts ( ) ] -> InterruptStatement [ __asm__ __volatile__ (\"sei\" \\::: \"memory\") ]", (interruptStatement));
			    var _result = new Compiler.C.Data.InterruptStatement(false) { new Compiler.C.Data.Token() { Name = "__asm__", Value = "__asm__" }, new Compiler.C.Data.Token() { Name = "__volatile__", Value = "__volatile__" }, new Compiler.C.Data.Token() { Name = "(\"sei\"", Value = "(\"sei\"" }, new Compiler.C.Data.Token() { Name = ":::", Value = ":::" }, new Compiler.C.Data.Token() { Name = "\"memory\")", Value = "\"memory\")" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(interruptStatement != null && interruptStatement.Name == "InterruptStatement" && (interruptStatement.Count == 3 && interruptStatement[0] != null && interruptStatement[0].Name == "disableinterrupts" && interruptStatement[1] != null && interruptStatement[1].Name == "(" && interruptStatement[2] != null && interruptStatement[2].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "InterruptStatement" }, "InterruptStatement [ disableinterrupts ( ) ] -> InterruptStatement [ __asm__ __volatile__ (\"cli\" \\::: \"memory\") ]", (interruptStatement));
			    var _result = new Compiler.C.Data.InterruptStatement(false) { new Compiler.C.Data.Token() { Name = "__asm__", Value = "__asm__" }, new Compiler.C.Data.Token() { Name = "__volatile__", Value = "__volatile__" }, new Compiler.C.Data.Token() { Name = "(\"cli\"", Value = "(\"cli\"" }, new Compiler.C.Data.Token() { Name = ":::", Value = ":::" }, new Compiler.C.Data.Token() { Name = "\"memory\")", Value = "\"memory\")" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			RulesFailed((interruptStatement));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerExpression integerExpression)
		{
			bool _isMatching = false;
			var key = (integerExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ identifier : id ] -> IntegerExpression [ id1 ]", (integerExpression));
			    Compiler.C.Data.Node id1 = Translate(integerExpression[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { id1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "numeral"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ numeral : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.Token);
			    _isMatching = s1 != null && s1.Name == "numeral";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "numeral" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "IntegerParenthesisExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ IntegerParenthesisExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.IntegerParenthesisExpression);
			    _isMatching = s1 != null && s1.Name == "IntegerParenthesisExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IntegerParenthesisExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.IntegerParenthesisExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "AddExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ AddExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.AddExpression);
			    _isMatching = s1 != null && s1.Name == "AddExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "AddExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.AddExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "SubExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ SubExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.SubExpression);
			    _isMatching = s1 != null && s1.Name == "SubExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "SubExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.SubExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "MulExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ MulExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.MulExpression);
			    _isMatching = s1 != null && s1.Name == "MulExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "MulExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.MulExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "DivExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ DivExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.DivExpression);
			    _isMatching = s1 != null && s1.Name == "DivExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "DivExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.DivExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "ModExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ ModExpression : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.ModExpression);
			    _isMatching = s1 != null && s1.Name == "ModExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "ModExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.ModExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "PowExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "[ IntegerExpression [ PowExpression : s ] ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.PowExpression);
			    _isMatching = s1 != null && s1.Name == "PowExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "PowExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.PowExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "Call"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerExpression" }, "IntegerExpression [ Call : s ] -> IntegerExpression [ s1 ]", (integerExpression));
			    Compiler.C.Data.Node s1 = Translate(integerExpression[0] as Compiler.AST.Data.Call);
			    _isMatching = s1 != null && s1.Name == "Call";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "Call" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerExpression(false) { s1 as Compiler.C.Data.Call };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerParenthesisExpression integerParenthesisExpression)
		{
			bool _isMatching = false;
			var key = (integerParenthesisExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerParenthesisExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerParenthesisExpression != null && integerParenthesisExpression.Name == "IntegerParenthesisExpression" && (integerParenthesisExpression.Count == 3 && integerParenthesisExpression[0] != null && integerParenthesisExpression[0].Name == "(" && integerParenthesisExpression[1] != null && integerParenthesisExpression[1].Name == "IntegerExpression" && integerParenthesisExpression[2] != null && integerParenthesisExpression[2].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerParenthesisExpression" }, "IntegerParenthesisExpression [ ( IntegerExpression : iexpr ) ] -> IntegerParenthesisExpression [ ( iexpr1 ) ]", (integerParenthesisExpression));
			    Compiler.C.Data.Node iexpr1 = Translate(integerParenthesisExpression[1] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			    if(iexpr1 != null && !_isMatching)
			    {
			        WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.IntegerParenthesisExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerParenthesisExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AddExpression addExpression)
		{
			bool _isMatching = false;
			var key = (addExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { addExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(addExpression != null && addExpression.Name == "AddExpression" && (addExpression.Count == 3 && addExpression[0] != null && addExpression[0].Name == "IntegerExpression" && addExpression[1] != null && addExpression[1].Name == "+" && addExpression[2] != null && addExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "AddExpression" }, "AddExpression [ IntegerExpression : iexpr1 + IntegerExpression : iexpr2 ] -> AddExpression [ ( iexpr3 + iexpr4 ) ]", (addExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(addExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(addExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.AddExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "+", Value = "+" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((addExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.SubExpression subExpression)
		{
			bool _isMatching = false;
			var key = (subExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { subExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(subExpression != null && subExpression.Name == "SubExpression" && (subExpression.Count == 3 && subExpression[0] != null && subExpression[0].Name == "IntegerExpression" && subExpression[1] != null && subExpression[1].Name == "-" && subExpression[2] != null && subExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "SubExpression" }, "SubExpression [ IntegerExpression : iexpr1 - IntegerExpression : iexpr2 ] -> SubExpression [ ( iexpr3 - iexpr4 ) ]", (subExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(subExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(subExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.SubExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "-", Value = "-" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((subExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.MulExpression mulExpression)
		{
			bool _isMatching = false;
			var key = (mulExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { mulExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(mulExpression != null && mulExpression.Name == "MulExpression" && (mulExpression.Count == 3 && mulExpression[0] != null && mulExpression[0].Name == "IntegerExpression" && mulExpression[1] != null && mulExpression[1].Name == "*" && mulExpression[2] != null && mulExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "MulExpression" }, "MulExpression [ IntegerExpression : iexpr1 \\* IntegerExpression : iexpr2 ] -> MulExpression [ ( iexpr3 \\* iexpr4 ) ]", (mulExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(mulExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(mulExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.MulExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((mulExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DivExpression divExpression)
		{
			bool _isMatching = false;
			var key = (divExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { divExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(divExpression != null && divExpression.Name == "DivExpression" && (divExpression.Count == 3 && divExpression[0] != null && divExpression[0].Name == "IntegerExpression" && divExpression[1] != null && divExpression[1].Name == "/" && divExpression[2] != null && divExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "DivExpression" }, "DivExpression [ IntegerExpression : iexpr1 / IntegerExpression : iexpr2 ] -> DivExpression [ ( iexpr3 / iexpr4 ) ]", (divExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(divExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(divExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.DivExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "/", Value = "/" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((divExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.ModExpression modExpression)
		{
			bool _isMatching = false;
			var key = (modExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { modExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(modExpression != null && modExpression.Name == "ModExpression" && (modExpression.Count == 3 && modExpression[0] != null && modExpression[0].Name == "IntegerExpression" && modExpression[1] != null && modExpression[1].Name == "%" && modExpression[2] != null && modExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ModExpression" }, "ModExpression [ IntegerExpression : iexpr1 \\% IntegerExpression : iexpr2 ] -> ModExpression [ ( iexpr3 \\% iexpr4 ) ]", (modExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(modExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(modExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.ModExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "%", Value = "%" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((modExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.PowExpression powExpression)
		{
			bool _isMatching = false;
			var key = (powExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { powExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(powExpression != null && powExpression.Name == "PowExpression" && (powExpression.Count == 3 && powExpression[0] != null && powExpression[0].Name == "IntegerExpression" && powExpression[1] != null && powExpression[1].Name == "^" && powExpression[2] != null && powExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "PowExpression" }, "PowExpression [ IntegerExpression : iexpr1 ^ IntegerExpression : iexpr2 ] -> PowExpression [ Pow ( iexpr3 , iexpr4 ) ]", (powExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(powExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(powExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.PowExpression(false) { new Compiler.C.Data.Token() { Name = "Pow", Value = "Pow" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ",", Value = "," }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((powExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanExpression booleanExpression)
		{
			bool _isMatching = false;
			var key = (booleanExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "true"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ true ] -> BooleanExpression [ 1 ]", (booleanExpression));
			    var _result = new Compiler.C.Data.BooleanExpression(false) { new Compiler.C.Data.Token() { Name = "1", Value = "1" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "false"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ false ] -> BooleanExpression [ 0 ]", (booleanExpression));
			    var _result = new Compiler.C.Data.BooleanExpression(false) { new Compiler.C.Data.Token() { Name = "0", Value = "0" } };
			    RuleEnd(true, true, _result);
			    return _result;
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "identifier"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ identifier : id ] -> BooleanExpression [ id1 ]", (booleanExpression));
			    Compiler.C.Data.Node id1 = Translate(booleanExpression[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { id1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "DirectBitValue"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ DirectBitValue : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.DirectBitValue);
			    _isMatching = s1 != null && s1.Name == "DirectBitValue";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "DirectBitValue" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.DirectBitValue };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IndirectBitValue"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ IndirectBitValue : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IndirectBitValue);
			    _isMatching = s1 != null && s1.Name == "IndirectBitValue";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IndirectBitValue" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IndirectBitValue };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanParenthesisExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ BooleanParenthesisExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanParenthesisExpression);
			    _isMatching = s1 != null && s1.Name == "BooleanParenthesisExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "BooleanParenthesisExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanParenthesisExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IntegerEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ IntegerEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IntegerEqExpression);
			    _isMatching = s1 != null && s1.Name == "IntegerEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IntegerEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IntegerEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "RegisterEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ RegisterEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.RegisterEqExpression);
			    _isMatching = s1 != null && s1.Name == "RegisterEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "RegisterEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ BooleanEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanEqExpression);
			    _isMatching = s1 != null && s1.Name == "BooleanEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "BooleanEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "IntegerNotEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ IntegerNotEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.IntegerNotEqExpression);
			    _isMatching = s1 != null && s1.Name == "IntegerNotEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "IntegerNotEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.IntegerNotEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "RegisterNotEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ RegisterNotEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.RegisterNotEqExpression);
			    _isMatching = s1 != null && s1.Name == "RegisterNotEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "RegisterNotEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.Token };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "BooleanNotEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ BooleanNotEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.BooleanNotEqExpression);
			    _isMatching = s1 != null && s1.Name == "BooleanNotEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "BooleanNotEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.BooleanNotEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "LessThanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ LessThanExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.LessThanExpression);
			    _isMatching = s1 != null && s1.Name == "LessThanExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "LessThanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.LessThanExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "GreaterThanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ GreaterThanExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.GreaterThanExpression);
			    _isMatching = s1 != null && s1.Name == "GreaterThanExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "GreaterThanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.GreaterThanExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "LessThanOrEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ LessThanOrEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.LessThanOrEqExpression);
			    _isMatching = s1 != null && s1.Name == "LessThanOrEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "LessThanOrEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.LessThanOrEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "GreaterThanOrEqExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ GreaterThanOrEqExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.GreaterThanOrEqExpression);
			    _isMatching = s1 != null && s1.Name == "GreaterThanOrEqExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "GreaterThanOrEqExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.GreaterThanOrEqExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "NotExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ NotExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.NotExpression);
			    _isMatching = s1 != null && s1.Name == "NotExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "NotExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.NotExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "AndExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ AndExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.AndExpression);
			    _isMatching = s1 != null && s1.Name == "AndExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "AndExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.AndExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "OrExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ OrExpression : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.OrExpression);
			    _isMatching = s1 != null && s1.Name == "OrExpression";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "OrExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.OrExpression };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(booleanExpression != null && booleanExpression.Name == "BooleanExpression" && (booleanExpression.Count == 1 && booleanExpression[0] != null && booleanExpression[0].Name == "Call"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanExpression" }, "BooleanExpression [ Call : s ] -> BooleanExpression [ s1 ]", (booleanExpression));
			    Compiler.C.Data.Node s1 = Translate(booleanExpression[0] as Compiler.AST.Data.Call);
			    _isMatching = s1 != null && s1.Name == "Call";
			    if(s1 != null && !_isMatching)
			    {
			        WrongPattern((s1), new System.Collections.Generic.List<string>() { "Call" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanExpression(false) { s1 as Compiler.C.Data.Call };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.DirectBitValue directBitValue)
		{
			bool _isMatching = false;
			var key = (directBitValue);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { directBitValue.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(directBitValue != null && directBitValue.Name == "DirectBitValue" && (directBitValue.Count == 7 && directBitValue[0] != null && directBitValue[0].Name == "RegisterType" && directBitValue[1] != null && directBitValue[1].Name == "(" && directBitValue[2] != null && directBitValue[2].Name == "IntegerExpression" && directBitValue[3] != null && directBitValue[3].Name == ")" && directBitValue[4] != null && directBitValue[4].Name == "{" && directBitValue[5] != null && directBitValue[5].Name == "IntegerExpression" && directBitValue[6] != null && directBitValue[6].Name == "}"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "DirectBitValue" }, "DirectBitValue [ RegisterType : regType ( IntegerExpression : iexpr1 ) { IntegerExpression : iexpr2 } ] -> DirectBitValue [ ( ( \\* ( regType1 ) ( iexpr3 ) ) & ( 1 << ( iexpr4 ) ) ) ]", (directBitValue));
			    Compiler.C.Data.Node regType1 = Translate(directBitValue[0] as Compiler.AST.Data.RegisterType);
			    _isMatching = regType1 != null && regType1.Name == "RegisterType";
			    if(regType1 != null && !_isMatching)
			    {
			        WrongPattern((regType1), new System.Collections.Generic.List<string>() { "RegisterType" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr3 = Translate(directBitValue[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			        if(iexpr3 != null && !_isMatching)
			        {
			            WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            Compiler.C.Data.Node iexpr4 = Translate(directBitValue[5] as Compiler.AST.Data.IntegerExpression);
			            _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			            if(iexpr4 != null && !_isMatching)
			            {
			                WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			            }
			            else if(_isMatching)
			            {
			                var _result = new Compiler.C.Data.DirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, regType1 as Compiler.C.Data.RegisterType, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			                RuleEnd(true, true, _result);
			                return _result;
			            }
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((directBitValue));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IndirectBitValue indirectBitValue)
		{
			bool _isMatching = false;
			var key = (indirectBitValue);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { indirectBitValue.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(indirectBitValue != null && indirectBitValue.Name == "IndirectBitValue" && (indirectBitValue.Count == 4 && indirectBitValue[0] != null && indirectBitValue[0].Name == "identifier" && indirectBitValue[1] != null && indirectBitValue[1].Name == "{" && indirectBitValue[2] != null && indirectBitValue[2].Name == "IntegerExpression" && indirectBitValue[3] != null && indirectBitValue[3].Name == "}"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IndirectBitValue" }, "IndirectBitValue [ identifier : id { IntegerExpression : iexpr } ] -> IndirectBitValue [ ( \\* id1 & ( 1 << ( iexpr1 ) ) ) ]", (indirectBitValue));
			    Compiler.C.Data.Node id1 = Translate(indirectBitValue[0] as Compiler.AST.Data.Token);
			    _isMatching = id1 != null && id1.Name == "identifier";
			    if(id1 != null && !_isMatching)
			    {
			        WrongPattern((id1), new System.Collections.Generic.List<string>() { "identifier" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr1 = Translate(indirectBitValue[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr1 != null && iexpr1.Name == "IntegerExpression";
			        if(iexpr1 != null && !_isMatching)
			        {
			            WrongPattern((iexpr1), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.IndirectBitValue(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "*", Value = "*" }, id1 as Compiler.C.Data.Token, new Compiler.C.Data.Token() { Name = "&", Value = "&" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "1", Value = "1" }, new Compiler.C.Data.Token() { Name = "<<", Value = "<<" }, new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr1 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" }, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((indirectBitValue));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanParenthesisExpression booleanParenthesisExpression)
		{
			bool _isMatching = false;
			var key = (booleanParenthesisExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanParenthesisExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanParenthesisExpression != null && booleanParenthesisExpression.Name == "BooleanParenthesisExpression" && (booleanParenthesisExpression.Count == 3 && booleanParenthesisExpression[0] != null && booleanParenthesisExpression[0].Name == "(" && booleanParenthesisExpression[1] != null && booleanParenthesisExpression[1].Name == "BooleanExpression" && booleanParenthesisExpression[2] != null && booleanParenthesisExpression[2].Name == ")"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanParenthesisExpression" }, "BooleanParenthesisExpression [ ( BooleanExpression : bexpr ) ] -> BooleanParenthesisExpression [ ( bexpr1 ) ]", (booleanParenthesisExpression));
			    Compiler.C.Data.Node bexpr1 = Translate(booleanParenthesisExpression[1] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			    if(bexpr1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.BooleanParenthesisExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanParenthesisExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerEqExpression integerEqExpression)
		{
			bool _isMatching = false;
			var key = (integerEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerEqExpression != null && integerEqExpression.Name == "IntegerEqExpression" && (integerEqExpression.Count == 3 && integerEqExpression[0] != null && integerEqExpression[0].Name == "IntegerExpression" && integerEqExpression[1] != null && integerEqExpression[1].Name == "==" && integerEqExpression[2] != null && integerEqExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerEqExpression" }, "IntegerEqExpression [ IntegerExpression : iexpr1 == IntegerExpression : iexpr2 ] -> IntegerEqExpression [ ( iexpr3 == iexpr4 ) ]", (integerEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(integerEqExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(integerEqExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.IntegerEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "==", Value = "==" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterEqExpression registerEqExpression)
		{
			bool _isMatching = false;
			var key = (registerEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerEqExpression != null && registerEqExpression.Name == "RegisterEqExpression" && (registerEqExpression.Count == 3 && registerEqExpression[0] != null && registerEqExpression[0].Name == "RegisterExpression" && registerEqExpression[1] != null && registerEqExpression[1].Name == "==" && registerEqExpression[2] != null && registerEqExpression[2].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterEqExpression" }, "RegisterEqExpression [ RegisterExpression : iexpr1 == RegisterExpression : iexpr2 ] -> RegisterEqExpression [ ( iexpr3 == iexpr4 ) ]", (registerEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(registerEqExpression[0] as Compiler.AST.Data.RegisterExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "RegisterExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(registerEqExpression[2] as Compiler.AST.Data.RegisterExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "RegisterExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.Token() { Name = "RegisterEqExpression", Value = "RegisterEqExpression" };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanEqExpression booleanEqExpression)
		{
			bool _isMatching = false;
			var key = (booleanEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanEqExpression != null && booleanEqExpression.Name == "BooleanEqExpression" && (booleanEqExpression.Count == 3 && booleanEqExpression[0] != null && booleanEqExpression[0].Name == "BooleanExpression" && booleanEqExpression[1] != null && booleanEqExpression[1].Name == "==" && booleanEqExpression[2] != null && booleanEqExpression[2].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanEqExpression" }, "BooleanEqExpression [ BooleanExpression : bexpr1 == BooleanExpression : bexpr2 ] -> BooleanEqExpression [ ( bexpr3 == bexpr4 ) ]", (booleanEqExpression));
			    Compiler.C.Data.Node bexpr3 = Translate(booleanEqExpression[0] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr3 != null && bexpr3.Name == "BooleanExpression";
			    if(bexpr3 != null && !_isMatching)
			    {
			        WrongPattern((bexpr3), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr4 = Translate(booleanEqExpression[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr4 != null && bexpr4.Name == "BooleanExpression";
			        if(bexpr4 != null && !_isMatching)
			        {
			            WrongPattern((bexpr4), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.BooleanEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "==", Value = "==" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.IntegerNotEqExpression integerNotEqExpression)
		{
			bool _isMatching = false;
			var key = (integerNotEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerNotEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerNotEqExpression != null && integerNotEqExpression.Name == "IntegerNotEqExpression" && (integerNotEqExpression.Count == 3 && integerNotEqExpression[0] != null && integerNotEqExpression[0].Name == "IntegerExpression" && integerNotEqExpression[1] != null && integerNotEqExpression[1].Name == "!=" && integerNotEqExpression[2] != null && integerNotEqExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "IntegerNotEqExpression" }, "IntegerNotEqExpression [ IntegerExpression : iexpr1 != IntegerExpression : iexpr2 ] -> IntegerNotEqExpression [ ( iexpr3 != iexpr4 ) ]", (integerNotEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(integerNotEqExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(integerNotEqExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.IntegerNotEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "!=", Value = "!=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerNotEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.RegisterNotEqExpression registerNotEqExpression)
		{
			bool _isMatching = false;
			var key = (registerNotEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { registerNotEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(registerNotEqExpression != null && registerNotEqExpression.Name == "RegisterNotEqExpression" && (registerNotEqExpression.Count == 3 && registerNotEqExpression[0] != null && registerNotEqExpression[0].Name == "RegisterExpression" && registerNotEqExpression[1] != null && registerNotEqExpression[1].Name == "!=" && registerNotEqExpression[2] != null && registerNotEqExpression[2].Name == "RegisterExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "RegisterNotEqExpression" }, "RegisterNotEqExpression [ RegisterExpression : iexpr1 != RegisterExpression : iexpr2 ] -> RegisterNotEqExpression [ ( iexpr3 != iexpr4 ) ]", (registerNotEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(registerNotEqExpression[0] as Compiler.AST.Data.RegisterExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "RegisterExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(registerNotEqExpression[2] as Compiler.AST.Data.RegisterExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "RegisterExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "RegisterExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.Token() { Name = "RegisterNotEqExpression", Value = "RegisterNotEqExpression" };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((registerNotEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.BooleanNotEqExpression booleanNotEqExpression)
		{
			bool _isMatching = false;
			var key = (booleanNotEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { booleanNotEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(booleanNotEqExpression != null && booleanNotEqExpression.Name == "BooleanNotEqExpression" && (booleanNotEqExpression.Count == 3 && booleanNotEqExpression[0] != null && booleanNotEqExpression[0].Name == "BooleanExpression" && booleanNotEqExpression[1] != null && booleanNotEqExpression[1].Name == "!=" && booleanNotEqExpression[2] != null && booleanNotEqExpression[2].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "BooleanNotEqExpression" }, "BooleanNotEqExpression [ BooleanExpression : bexpr1 != BooleanExpression : bexpr2 ] -> BooleanNotEqExpression [ ( bexpr3 != bexpr4 ) ]", (booleanNotEqExpression));
			    Compiler.C.Data.Node bexpr3 = Translate(booleanNotEqExpression[0] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr3 != null && bexpr3.Name == "BooleanExpression";
			    if(bexpr3 != null && !_isMatching)
			    {
			        WrongPattern((bexpr3), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr4 = Translate(booleanNotEqExpression[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr4 != null && bexpr4.Name == "BooleanExpression";
			        if(bexpr4 != null && !_isMatching)
			        {
			            WrongPattern((bexpr4), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.BooleanNotEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "!=", Value = "!=" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((booleanNotEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.LessThanExpression lessThanExpression)
		{
			bool _isMatching = false;
			var key = (lessThanExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { lessThanExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(lessThanExpression != null && lessThanExpression.Name == "LessThanExpression" && (lessThanExpression.Count == 3 && lessThanExpression[0] != null && lessThanExpression[0].Name == "IntegerExpression" && lessThanExpression[1] != null && lessThanExpression[1].Name == "<" && lessThanExpression[2] != null && lessThanExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "LessThanExpression" }, "LessThanExpression [ IntegerExpression : iexpr1 < IntegerExpression : iexpr2 ] -> LessThanExpression [ ( iexpr3 < iexpr4 ) ]", (lessThanExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(lessThanExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(lessThanExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.LessThanExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "<", Value = "<" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((lessThanExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.GreaterThanExpression greaterThanExpression)
		{
			bool _isMatching = false;
			var key = (greaterThanExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { greaterThanExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(greaterThanExpression != null && greaterThanExpression.Name == "GreaterThanExpression" && (greaterThanExpression.Count == 3 && greaterThanExpression[0] != null && greaterThanExpression[0].Name == "IntegerExpression" && greaterThanExpression[1] != null && greaterThanExpression[1].Name == ">" && greaterThanExpression[2] != null && greaterThanExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GreaterThanExpression" }, "GreaterThanExpression [ IntegerExpression : iexpr1 > IntegerExpression : iexpr2 ] -> GreaterThanExpression [ ( iexpr3 > iexpr4 ) ]", (greaterThanExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(greaterThanExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(greaterThanExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.GreaterThanExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ">", Value = ">" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((greaterThanExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.LessThanOrEqExpression lessThanOrEqExpression)
		{
			bool _isMatching = false;
			var key = (lessThanOrEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { lessThanOrEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(lessThanOrEqExpression != null && lessThanOrEqExpression.Name == "LessThanOrEqExpression" && (lessThanOrEqExpression.Count == 3 && lessThanOrEqExpression[0] != null && lessThanOrEqExpression[0].Name == "IntegerExpression" && lessThanOrEqExpression[1] != null && lessThanOrEqExpression[1].Name == "<=" && lessThanOrEqExpression[2] != null && lessThanOrEqExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "LessThanOrEqExpression" }, "LessThanOrEqExpression [ IntegerExpression : iexpr1 <= IntegerExpression : iexpr2 ] -> LessThanOrEqExpression [ ( iexpr3 <= iexpr4 ) ]", (lessThanOrEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(lessThanOrEqExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(lessThanOrEqExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.LessThanOrEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = "<=", Value = "<=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((lessThanOrEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.GreaterThanOrEqExpression greaterThanOrEqExpression)
		{
			bool _isMatching = false;
			var key = (greaterThanOrEqExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { greaterThanOrEqExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(greaterThanOrEqExpression != null && greaterThanOrEqExpression.Name == "GreaterThanOrEqExpression" && (greaterThanOrEqExpression.Count == 3 && greaterThanOrEqExpression[0] != null && greaterThanOrEqExpression[0].Name == "IntegerExpression" && greaterThanOrEqExpression[1] != null && greaterThanOrEqExpression[1].Name == ">=" && greaterThanOrEqExpression[2] != null && greaterThanOrEqExpression[2].Name == "IntegerExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "GreaterThanOrEqExpression" }, "GreaterThanOrEqExpression [ IntegerExpression : iexpr1 >= IntegerExpression : iexpr2 ] -> GreaterThanOrEqExpression [ ( iexpr3 >= iexpr4 ) ]", (greaterThanOrEqExpression));
			    Compiler.C.Data.Node iexpr3 = Translate(greaterThanOrEqExpression[0] as Compiler.AST.Data.IntegerExpression);
			    _isMatching = iexpr3 != null && iexpr3.Name == "IntegerExpression";
			    if(iexpr3 != null && !_isMatching)
			    {
			        WrongPattern((iexpr3), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node iexpr4 = Translate(greaterThanOrEqExpression[2] as Compiler.AST.Data.IntegerExpression);
			        _isMatching = iexpr4 != null && iexpr4.Name == "IntegerExpression";
			        if(iexpr4 != null && !_isMatching)
			        {
			            WrongPattern((iexpr4), new System.Collections.Generic.List<string>() { "IntegerExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.GreaterThanOrEqExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, iexpr3 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ">=", Value = ">=" }, iexpr4 as Compiler.C.Data.IntegerExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((greaterThanOrEqExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.NotExpression notExpression)
		{
			bool _isMatching = false;
			var key = (notExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { notExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(notExpression != null && notExpression.Name == "NotExpression" && (notExpression.Count == 2 && notExpression[0] != null && notExpression[0].Name == "!" && notExpression[1] != null && notExpression[1].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "NotExpression" }, "NotExpression [ ! BooleanExpression : bexpr ] -> NotExpression [ ( ! bexpr1 ) ]", (notExpression));
			    Compiler.C.Data.Node bexpr1 = Translate(notExpression[1] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr1 != null && bexpr1.Name == "BooleanExpression";
			    if(bexpr1 != null && !_isMatching)
			    {
			        WrongPattern((bexpr1), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        var _result = new Compiler.C.Data.NotExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, new Compiler.C.Data.Token() { Name = "!", Value = "!" }, bexpr1 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((notExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.AndExpression andExpression)
		{
			bool _isMatching = false;
			var key = (andExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { andExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(andExpression != null && andExpression.Name == "AndExpression" && (andExpression.Count == 3 && andExpression[0] != null && andExpression[0].Name == "BooleanExpression" && andExpression[1] != null && andExpression[1].Name == "and" && andExpression[2] != null && andExpression[2].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "AndExpression" }, "AndExpression [ BooleanExpression : bexpr1 and BooleanExpression : bexpr2 ] -> AndExpression [ ( bexpr3 && bexpr4 ) ]", (andExpression));
			    Compiler.C.Data.Node bexpr3 = Translate(andExpression[0] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr3 != null && bexpr3.Name == "BooleanExpression";
			    if(bexpr3 != null && !_isMatching)
			    {
			        WrongPattern((bexpr3), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr4 = Translate(andExpression[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr4 != null && bexpr4.Name == "BooleanExpression";
			        if(bexpr4 != null && !_isMatching)
			        {
			            WrongPattern((bexpr4), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.AndExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "&&", Value = "&&" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((andExpression));
			return (null);
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.OrExpression orExpression)
		{
			bool _isMatching = false;
			var key = (orExpression);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { orExpression.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(orExpression != null && orExpression.Name == "OrExpression" && (orExpression.Count == 3 && orExpression[0] != null && orExpression[0].Name == "BooleanExpression" && orExpression[1] != null && orExpression[1].Name == "or" && orExpression[2] != null && orExpression[2].Name == "BooleanExpression"))
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "OrExpression" }, "OrExpression [ BooleanExpression : bexpr1 or BooleanExpression : bexpr2 ] -> OrExpression [ ( bexpr3 || bexpr4 ) ]", (orExpression));
			    Compiler.C.Data.Node bexpr3 = Translate(orExpression[0] as Compiler.AST.Data.BooleanExpression);
			    _isMatching = bexpr3 != null && bexpr3.Name == "BooleanExpression";
			    if(bexpr3 != null && !_isMatching)
			    {
			        WrongPattern((bexpr3), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			    }
			    else if(_isMatching)
			    {
			        Compiler.C.Data.Node bexpr4 = Translate(orExpression[2] as Compiler.AST.Data.BooleanExpression);
			        _isMatching = bexpr4 != null && bexpr4.Name == "BooleanExpression";
			        if(bexpr4 != null && !_isMatching)
			        {
			            WrongPattern((bexpr4), new System.Collections.Generic.List<string>() { "BooleanExpression" });
			        }
			        else if(_isMatching)
			        {
			            var _result = new Compiler.C.Data.OrExpression(false) { new Compiler.C.Data.Token() { Name = "(", Value = "(" }, bexpr3 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = "||", Value = "||" }, bexpr4 as Compiler.C.Data.BooleanExpression, new Compiler.C.Data.Token() { Name = ")", Value = ")" } };
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((orExpression));
			return (null);
		}

		public void RuleStart(System.Collections.Generic.List<string> returnTypes, string rule, Compiler.AST.Data.Node data)
		{
			Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.C.Data.Node> error = new Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.C.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEnd(bool success, bool save, Compiler.C.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.C.Data.Node>;
			casted.To = data;
			if(save)
			{
			    Relation.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEnd(bool success)
		{
			RuleEnd(success, success, null);
		}

		public void RulesFailed(Compiler.AST.Data.Node data)
		{
			Relation.Add(data, null);
		}

		public void WrongPattern(Compiler.C.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.C.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public Compiler.C.Data.Node Translate(Compiler.AST.Data.Token token)
		{
			bool _isMatching = false;
			var key = (token);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { token.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			RuleStart(new System.Collections.Generic.List<string>() { token.Name }, $"{token.Name} ->: {token.Name}", token);
			var result = new Compiler.C.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
			RuleEnd(true, true, result);
			return result;
		}

		public void RuleStarta(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node), (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)> error = new Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node), (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEnda(bool success, bool save, (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node), (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)>;
			casted.To = data;
			if(save)
			{
			    Relationa.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEnda(bool success)
		{
			RuleEnda(success, success, (null, null, null));
		}

		public void RulesFaileda((Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) data)
		{
			Relationa.Add(data, (null, null, null));
		}

		public void WrongPatterna((Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node) data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node), (Compiler.C.Data.Node, Compiler.C.Data.Node, Compiler.C.Data.Node)>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
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

		public Compiler.C.Data.Node Insert(Compiler.C.Data.Node left, Compiler.C.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
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
			    if(left[i].IsPlaceholder && left[i].Name == right.Name)
			    {
			        left.RemoveAt(i);
			        left.Insert(i, right);
			        return left;
			    }
			    else
			    {
			        Compiler.C.Data.Node leftUpdated = InsertAux(left[i], right);
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
