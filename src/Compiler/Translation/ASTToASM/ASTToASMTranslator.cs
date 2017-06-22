namespace Compiler.Translation.ASTToASM
{
	public partial class ASTToASMTranslator 
	{
		public Compiler.Error.RuleError RuleError { get; set; } = new Compiler.Error.RuleError();
		public System.Collections.Generic.Dictionary<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node),(Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)> Relation { get; set; } = new System.Collections.Generic.Dictionary<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node),(Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)>();
		public System.Collections.Generic.Dictionary<Compiler.AST.Data.Node,Compiler.ASM.Data.Node> RelationtoASM { get; set; } = new System.Collections.Generic.Dictionary<Compiler.AST.Data.Node,Compiler.ASM.Data.Node>();
		public (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) Translate(Compiler.AST.Data.AST aST, Compiler.ASM.Data.RegTable regTable, Compiler.ASM.Data.RegTable regTable1)
		{
			bool _isMatching = false;
			var key = (aST, regTable, regTable1);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { aST.Name, regTable.Name, regTable1.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(aST != null && aST.Name == "AST" && (aST.Count == 2 && aST[0] != null && aST[0].Name == "GlobalStatement" && (aST[0].Count == 1 && aST[0][0] != null && aST[0][0].Name == "Statement" && (aST[0][0].Count == 1 && aST[0][0][0] != null && aST[0][0][0].Name == "IntegerDeclarationInit" && (aST[0][0][0].Count == 4 && aST[0][0][0][0] != null && aST[0][0][0][0].Name == "IntType" && aST[0][0][0][1] != null && aST[0][0][0][1].Name == "identifier" && aST[0][0][0][2] != null && aST[0][0][0][2].Name == "=" && aST[0][0][0][3] != null && aST[0][0][0][3].Name == "IntegerExpression"))) && aST[1] != null && aST[1].Name == "eof") && regTable != null && regTable.Name == "RegTable" && regTable1 != null && regTable1.Name == "RegTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" }, "[ AST [ GlobalStatement [ Statement [ IntegerDeclarationInit [ IntType identifier = IntegerExpression : e ] ] ] eof ] RegTable : free RegTable : used ] -> [ asm free1 used1 ]", (aST, regTable, regTable1));
			    (Compiler.ASM.Data.Node asm, Compiler.ASM.Data.Node free1, Compiler.ASM.Data.Node used1) = Translate(aST[0][0][0][3] as Compiler.AST.Data.IntegerExpression, regTable as Compiler.ASM.Data.RegTable, regTable1 as Compiler.ASM.Data.RegTable);
			    _isMatching = asm != null && asm.Name == "ASM" && free1 != null && free1.Name == "RegTable" && used1 != null && used1.Name == "RegTable";
			    if(asm != null && free1 != null && used1 != null && !_isMatching)
			    {
			        WrongPattern((asm, free1, used1), new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (asm as Compiler.ASM.Data.ASM, free1 as Compiler.ASM.Data.RegTable, used1 as Compiler.ASM.Data.RegTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			RulesFailed((aST, regTable, regTable1));
			return (null, null, null);
		}

		public (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) Translate(Compiler.AST.Data.IntegerExpression integerExpression, Compiler.ASM.Data.RegTable regTable, Compiler.ASM.Data.RegTable regTable1)
		{
			bool _isMatching = false;
			var key = (integerExpression, regTable, regTable1);
			if(Relation.ContainsKey(key))
			{
			    var value = Relation[key];
			    RuleStart(new System.Collections.Generic.List<string>() { integerExpression.Name, regTable.Name, regTable1.Name }, "", key);
			    RuleEnd(true, false, value);
			    return value;
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "numeral") && regTable != null && regTable.Name == "RegTable" && (regTable.Count == 2 && regTable[0] != null && regTable[0].Name == "register" && regTable[1] != null && regTable[1].Name == "RegTable") && regTable1 != null && regTable1.Name == "RegTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" }, "[ IntegerExpression [ numeral : cnum ] RegTable [ register : reg RegTable : free ] RegTable : used ] -> [ ASM [ LDI reg , num ] free RegTable [ reg used ] ]", (integerExpression, regTable, regTable1));
			    Compiler.ASM.Data.Node num = TranslatetoASM(integerExpression[0] as Compiler.AST.Data.Token);
			    _isMatching = num != null && num.Name == "numeral";
			    if(num != null && !_isMatching)
			    {
			        WrongPatterntoASM((num), new System.Collections.Generic.List<string>() { "numeral" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (new Compiler.ASM.Data.ASM(false) { new Compiler.ASM.Data.Token() { Name = "LDI", Value = "LDI" }, regTable[0] as Compiler.ASM.Data.Token, new Compiler.ASM.Data.Token() { Name = ",", Value = "," }, num as Compiler.ASM.Data.Token }, regTable[1] as Compiler.ASM.Data.RegTable, new Compiler.ASM.Data.RegTable(false) { regTable[0] as Compiler.ASM.Data.Token, regTable1 as Compiler.ASM.Data.RegTable });
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "IntegerParenthesisExpression" && (integerExpression[0].Count == 3 && integerExpression[0][0] != null && integerExpression[0][0].Name == "(" && integerExpression[0][1] != null && integerExpression[0][1].Name == "IntegerExpression" && integerExpression[0][2] != null && integerExpression[0][2].Name == ")")) && regTable != null && regTable.Name == "RegTable" && regTable1 != null && regTable1.Name == "RegTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" }, "[ IntegerExpression [ IntegerParenthesisExpression [ ( IntegerExpression : e ) ] ] RegTable : free RegTable : used ] -> [ asm free1 used1 ]", (integerExpression, regTable, regTable1));
			    (Compiler.ASM.Data.Node asm, Compiler.ASM.Data.Node free1, Compiler.ASM.Data.Node used1) = Translate(integerExpression[0][1] as Compiler.AST.Data.IntegerExpression, regTable as Compiler.ASM.Data.RegTable, regTable1 as Compiler.ASM.Data.RegTable);
			    _isMatching = asm != null && asm.Name == "ASM" && free1 != null && free1.Name == "RegTable" && used1 != null && used1.Name == "RegTable";
			    if(asm != null && free1 != null && used1 != null && !_isMatching)
			    {
			        WrongPattern((asm, free1, used1), new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" });
			    }
			    else if(_isMatching)
			    {
			        var _result = (asm as Compiler.ASM.Data.ASM, free1 as Compiler.ASM.Data.RegTable, used1 as Compiler.ASM.Data.RegTable);
			        RuleEnd(true, true, _result);
			        return _result;
			    }
			    RuleEnd(false);
			}
			if(integerExpression != null && integerExpression.Name == "IntegerExpression" && (integerExpression.Count == 1 && integerExpression[0] != null && integerExpression[0].Name == "AddExpression" && (integerExpression[0].Count == 3 && integerExpression[0][0] != null && integerExpression[0][0].Name == "IntegerExpression" && integerExpression[0][1] != null && integerExpression[0][1].Name == "+" && integerExpression[0][2] != null && integerExpression[0][2].Name == "IntegerExpression")) && regTable != null && regTable.Name == "RegTable" && regTable1 != null && regTable1.Name == "RegTable")
			{
			    RuleStart(new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" }, "[ IntegerExpression [ AddExpression [ IntegerExpression : e1 + IntegerExpression : e2 ] ] RegTable : free RegTable : used ] -> [ ASM [ ASM [ asm1 asm2 ] ASM [ ADD r2 , r1 ] ] RegTable [ r1 free2 ] used2 ]", (integerExpression, regTable, regTable1));
			    (Compiler.ASM.Data.Node asm1, Compiler.ASM.Data.Node free1, Compiler.ASM.Data.Node used1) = Translate(integerExpression[0][0] as Compiler.AST.Data.IntegerExpression, regTable as Compiler.ASM.Data.RegTable, regTable1 as Compiler.ASM.Data.RegTable);
			    _isMatching = asm1 != null && asm1.Name == "ASM" && free1 != null && free1.Name == "RegTable" && used1 != null && used1.Name == "RegTable";
			    if(asm1 != null && free1 != null && used1 != null && !_isMatching)
			    {
			        WrongPattern((asm1, free1, used1), new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" });
			    }
			    else if(_isMatching)
			    {
			        (Compiler.ASM.Data.Node asm2, Compiler.ASM.Data.Node free2, Compiler.ASM.Data.Node regTable2) = Translate(integerExpression[0][2] as Compiler.AST.Data.IntegerExpression, free1 as Compiler.ASM.Data.RegTable, used1 as Compiler.ASM.Data.RegTable);
			        _isMatching = asm2 != null && asm2.Name == "ASM" && free2 != null && free2.Name == "RegTable" && regTable2 != null && regTable2.Name == "RegTable" && (regTable2.Count == 2 && regTable2[0] != null && regTable2[0].Name == "register" && regTable2[1] != null && regTable2[1].Name == "RegTable" && (regTable2[1].Count == 2 && regTable2[1][0] != null && regTable2[1][0].Name == "register" && regTable2[1][1] != null && regTable2[1][1].Name == "RegTable"));
			        if(asm2 != null && free2 != null && regTable2 != null && !_isMatching)
			        {
			            WrongPattern((asm2, free2, regTable2), new System.Collections.Generic.List<string>() { "ASM", "RegTable", "RegTable" });
			        }
			        else if(_isMatching)
			        {
			            var _result = (new Compiler.ASM.Data.ASM(false) { new Compiler.ASM.Data.ASM(false) { asm1 as Compiler.ASM.Data.ASM, asm2 as Compiler.ASM.Data.ASM }, new Compiler.ASM.Data.ASM(false) { new Compiler.ASM.Data.Token() { Name = "ADD", Value = "ADD" }, regTable2[1][0] as Compiler.ASM.Data.Token, new Compiler.ASM.Data.Token() { Name = ",", Value = "," }, regTable2[0] as Compiler.ASM.Data.Token } }, new Compiler.ASM.Data.RegTable(false) { regTable2[0] as Compiler.ASM.Data.Token, free2 as Compiler.ASM.Data.RegTable }, regTable2[1] as Compiler.ASM.Data.RegTable);
			            RuleEnd(true, true, _result);
			            return _result;
			        }
			    }
			    RuleEnd(false);
			}
			RulesFailed((integerExpression, regTable, regTable1));
			return (null, null, null);
		}

		public void RuleStart(System.Collections.Generic.List<string> returnTypes, string rule, (Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) data)
		{
			Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node), (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)> error = new Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node), (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEnd(bool success, bool save, (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node), (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)>;
			casted.To = data;
			if(save)
			{
			    Relation.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEnd(bool success)
		{
			RuleEnd(success, success, (null, null, null));
		}

		public void RulesFailed((Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) data)
		{
			Relation.Add(data, (null, null, null));
		}

		public void WrongPattern((Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node) data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<(Compiler.AST.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node), (Compiler.ASM.Data.Node, Compiler.ASM.Data.Node, Compiler.ASM.Data.Node)>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public void RuleStarttoASM(System.Collections.Generic.List<string> returnTypes, string rule, Compiler.AST.Data.Node data)
		{
			Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.ASM.Data.Node> error = new Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.ASM.Data.Node>();
			error.ReturnTypes = returnTypes;
			error.Parent = RuleError;
			error.Rule = rule;
			RuleError.Children.Add(error);
			error.From = data;
			RuleError = error;
		}

		public void RuleEndtoASM(bool success, bool save, Compiler.ASM.Data.Node data)
		{
			RuleError.IsError = !success;
			var casted = RuleError as Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.ASM.Data.Node>;
			casted.To = data;
			if(save)
			{
			    RelationtoASM.Add(casted.From, casted.To);
			}
			RuleError = RuleError.Parent;
		}

		public void RuleEndtoASM(bool success)
		{
			RuleEndtoASM(success, success, null);
		}

		public void RulesFailedtoASM(Compiler.AST.Data.Node data)
		{
			RelationtoASM.Add(data, null);
		}

		public void WrongPatterntoASM(Compiler.ASM.Data.Node data, System.Collections.Generic.List<string> returnTypes)
		{
			var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<Compiler.AST.Data.Node, Compiler.ASM.Data.Node>;
			casted.IsError = true;
			casted.ReturnTypes = returnTypes;
			casted.IsPatternError = true;
			casted.To = data;
		}

		public Compiler.ASM.Data.Node TranslatetoASM(Compiler.AST.Data.Token token)
		{
			bool _isMatching = false;
			var key = (token);
			if(RelationtoASM.ContainsKey(key))
			{
			    var value = RelationtoASM[key];
			    RuleStarttoASM(new System.Collections.Generic.List<string>() { token.Name }, "", key);
			    RuleEndtoASM(true, false, value);
			    return value;
			}
			RuleStarttoASM(new System.Collections.Generic.List<string>() { token.Name }, $"{token.Name} ->:toASM {token.Name}", token);
			var result = new Compiler.ASM.Data.Token() { Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column };
			RuleEndtoASM(true, true, result);
			return result;
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

		public Compiler.ASM.Data.Node Insert(Compiler.ASM.Data.Node left, Compiler.ASM.Data.Node right)
		{
			if(left.IsPlaceholder && left.Name == right.Name)
			{
			    return right.Accept(new Compiler.ASM.Visitors.CloneVisitor());
			}
			var leftClone = left.Accept(new Compiler.ASM.Visitors.CloneVisitor());
			Compiler.ASM.Data.Node Insertion = InsertAux(leftClone, right);
			return (Insertion == null ? null : leftClone);
		}

		public Compiler.ASM.Data.Node InsertAux(Compiler.ASM.Data.Node left, Compiler.ASM.Data.Node right)
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
			        Compiler.ASM.Data.Node leftUpdated = InsertAux(left[i], right);
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
