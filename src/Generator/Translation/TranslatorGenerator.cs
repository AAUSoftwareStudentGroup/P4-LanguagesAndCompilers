using System;
using System.Collections.Generic;
using System.Text;
using Generator.Class;
using Generator.Translation.Data;
using Generator.Translation.Visitors;
using System.Linq;
using Generator.Grammar;

namespace Generator.Translation
{
    class TranslatorGenerator : ITranslatorGenerator
    {
        private List<RelationDomain> AnalyzeDomain(Domain domain, List<RelationDomain> translationDomains)
        {
            List<RelationDomain> resultTranslationDomains = new List<RelationDomain>();

            if (domain.Nodes<TreeDomain>().Count() > 0)
            {
                TreeDomain treeDomain = domain.Nodes<TreeDomain>()[0];
                string domainName = GetDomainName(treeDomain);
                resultTranslationDomains.Add(translationDomains.First(t => t.Identifier == domainName));
            }
            else
            {
                ListDomain listDomain = domain.Nodes<ListDomain>()[0];
                Domains domains = listDomain.Nodes<Domains>()[0];

                while (domains.Nodes<TreeDomain>().Count() > 0)
                {
                    TreeDomain treeDomain = domains.Nodes<TreeDomain>()[0];
                    string domainName = GetDomainName(treeDomain);
                    resultTranslationDomains.Add(translationDomains.First(t => t.Identifier == domainName));
                    domains = domains.Nodes<Domains>()[0];
                }
            }
            
            return resultTranslationDomains;
        }

        private string GetDomainName(TreeDomain treeDomain)
        {
            string domain = null;

            Token symbol = treeDomain[0][0] as Token;

            if (symbol.Name == "escapedSymbol")
            {
                domain = symbol.Value.Substring(1);
            }
            else
            {
                domain = symbol.Value;
            }

            return domain;
        }

        private string GetAlias(Alias alias)
        {
            string aliasName = "";

            if (alias.Count == 2 && alias[1] is Token)
            {
                Token symbol = alias[1] as Token;
                if(symbol.Name == "symbol")
                {
                    foreach (var c in symbol.Value)
                    {
                        if(!"abcdefghijklmnopqrstuvwxyz0123456789".Contains((c + "").ToLower()))
                        {
                            throw new Exception();
                        }
                    }
                    aliasName = symbol.Value;
                }
            }

            return aliasName;
        }

        private List<string> GetReturnNames(Conclusion conclusion, List<RelationDomain> translationDomains, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            List<string> returnTypes = new List<string>();
            Structure structure = conclusion.Nodes<Structure>()[0];
            if (structure.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                GetTreeStructureReturnName(translationDomains[0], symbols, returnTypes, treeStructure);
            }
            else
            {
                int domainIndex = 0;
                Structures structures = structure.Nodes<ListStructure>()[0].Nodes<Structures>()[0];
                while (structures.Nodes<TreeStructure>().Count() > 0)
                {
                    TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];
                    GetTreeStructureReturnName(translationDomains[domainIndex], symbols, returnTypes, treeStructure);
                    structures = structures.Nodes<Structures>()[0];
                    domainIndex++;
                }
            }
            return returnTypes;
        }

        private List<string> AnalyzeReturnTypes(Conclusion conclusion, List<RelationDomain> translationDomains, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            List<string> returnTypes = new List<string>();
            Structure structure = conclusion.Nodes<Structure>()[0];
            if (structure.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                AnalyzeTreeStructureReturnType(translationDomains[0], symbols, returnTypes, treeStructure);
            }
            else
            {
                int domainIndex = 0;
                Structures structures = structure.Nodes<ListStructure>()[0].Nodes<Structures>()[0];
                while (structures.Nodes<TreeStructure>().Count() > 0)
                {
                    TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];
                    AnalyzeTreeStructureReturnType(translationDomains[domainIndex], symbols, returnTypes, treeStructure);
                    structures = structures.Nodes<Structures>()[0];
                    domainIndex++;
                }
            }
            return returnTypes;
        }

        private void AnalyzeTreeStructureReturnType(RelationDomain translationDomain, Dictionary<string, (string type, string name, string nodeType)> symbols, List<string> returnTypes, TreeStructure treeStructure)
        {
            returnTypes.Add($"{translationDomain.DataNamespace}.Node");
        }

        private void GetTreeStructureReturnName(RelationDomain translationDomain, Dictionary<string, (string type, string name, string nodeType)> symbols, List<string> returnTypes, TreeStructure treeStructure)
        {
            string name = GetName(treeStructure.Nodes<Name>()[0]);
            if (symbols.ContainsKey(name))
            {
                returnTypes.Add(symbols[name].nodeType);
            }
            else
            {
                returnTypes.Add(name);
            }
        }

        public ClassType GenerateTranslatorClass(Translator translator, string translatorName, List<RelationDomain> translationDomains, string translatorNamespace)
        {
            ClassType translatorClass = new ClassType(translatorNamespace, "public", translatorName, null);

            Node systems = translator.Nodes<Systems>()[0];

            Dictionary<(string alias, string symbol), Relation> relations = new Dictionary<(string alias, string symbol), Relation>();

            while (systems.Nodes<Data.System>().Count() > 0)
            {
                Data.System system = systems.Nodes<Data.System>()[0];

                string symbol = system.Nodes<Token>()[0].Value;

                string alias = GetAlias(system.Nodes<Alias>()[0]);

                Domain leftDomain = system.Nodes<Domain>()[0];
                Domain rightDomain = system.Nodes<Domain>()[1];

                relations.Add((alias, symbol), new Relation()
                {
                    Operator = system.Nodes<Token>()[0].Value,
                    LeftDomains = AnalyzeDomain(leftDomain, translationDomains),
                    RightDomains = AnalyzeDomain(rightDomain, translationDomains)
                });

                systems = systems.Nodes<Systems>()[0];
            }

            Node rules = translator.Nodes<Rules>()[0];

            while (rules.Nodes<Rule>().Count() > 0)
            {
                Rule rule = rules.Nodes<Rule>()[0];
                if (rule.Nodes<Conclusion>().Count() > 0)
                {
                    Conclusion conclusion = rule.Nodes<Conclusion>()[0];
                    Pattern pattern = conclusion.Nodes<Pattern>().FirstOrDefault();
                    List<string> patternConditions = new List<string>();
                    List<ParameterType> parameters = new List<ParameterType>();
                    Dictionary<string, (string type, string name, string nodeType)> symbols = new Dictionary<string, (string type, string name, string nodeType)>();

                    string alias = GetAlias(conclusion.Nodes<Alias>()[0]);

                    string symbol = "->";

                    AnalyzePattern(pattern, false, relations[(alias, symbol)].LeftDomains, patternConditions, parameters, symbols);

                    MethodType method = new MethodType("public", null, $"Translate{alias}")
                    {
                        Parameters = parameters
                    };
                    method.Body.Add($"if({string.Join(" && ", patternConditions)})");
                    method.Body.Add("{");
                    int ruleStartIndex = method.Body.Count;
                    int indentLevel = 1;
                    int nodeNumber = 1;
                    Node premises = rule.Nodes<Premises>().FirstOrDefault();
                    while (premises != null && premises.Nodes<Premis>().Count() > 0)
                    {
                        Premis premis = premises.Nodes<Premis>().FirstOrDefault();

                        if (premis != null)
                        {
                            Structure structure = premis.Nodes<Structure>().FirstOrDefault();
                            if (structure != null)
                            {

                                StructureOperation operation = premis.Nodes<StructureOperation>()[0];
                                Goto gotoNode = operation.Nodes<Goto>().FirstOrDefault();
                                if (gotoNode != null)
                                {
                                    Pattern pattern1 = gotoNode.Nodes<Pattern>()[0];
                                    string premisAlias = GetAlias(gotoNode.Nodes<Alias>()[0]);
                                    List<string> patternConditions1 = new List<string>();
                                    List<ParameterType> parameters1 = new List<ParameterType>();
                                    AnalyzePattern(pattern1, true, relations[(premisAlias, "->")].RightDomains, patternConditions1, parameters1, symbols);

                                    string returnTypeStr1 = string.Join(", ", parameters1.Select(p => $"{string.Join(".", p.Type.Split('.').Reverse().Skip(1).Reverse().Concat(new string[] { "Node" }))} {p.Identifier}"));

                                    if (parameters1.Count > 1)
                                    {
                                        returnTypeStr1 = $"({returnTypeStr1})";
                                    }

                                    string translatorArgs = "";

                                    if (structure.Nodes<ListStructure>().Count() > 0)
                                    {
                                        ListStructure listStructure = structure.Nodes<ListStructure>()[0];
                                        List<string> lst = CreateListStructure(listStructure, relations[(premisAlias, "->")].LeftDomains, symbols);
                                        translatorArgs = string.Join(", ", lst);
                                    }
                                    else if (structure.Nodes<TreeStructure>().Count() > 0)
                                    {
                                        TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                                        translatorArgs = CreateTreeStructure(treeStructure, relations[(premisAlias, "->")].LeftDomains[0], symbols);
                                    }

                                    method.Body.Add($"{Indent(indentLevel)}{returnTypeStr1} = Translate{premisAlias}({translatorArgs});");
                                    method.Body.Add($"{Indent(indentLevel)}_isMatching = {string.Join(" && ", patternConditions1)};");
                                    method.Body.Add($"{Indent(indentLevel)}if({string.Join(" && ", parameters1.Select(p => $"{p.Identifier} != null"))} && !_isMatching)");
                                    method.Body.Add($"{Indent(indentLevel)}{{");
                                    method.Body.Add($"{Indent(indentLevel + 1)}WrongPattern{premisAlias}(({string.Join(", ", parameters1.Select(p => p.Identifier))}), new System.Collections.Generic.List<string>() {{ {string.Join(", ",  GetPatternNames(pattern1).Select(n => "\"" + n + "\""))} }});");
                                    method.Body.Add($"{Indent(indentLevel)}}}");
                                    method.Body.Add($"{Indent(indentLevel)}else if(_isMatching)");
                                    method.Body.Add($"{Indent(indentLevel)}{{");
                                    indentLevel++;
                                    nodeNumber++;
                                }
                                else
                                {
                                    Equal equal = operation.Nodes<Equal>().FirstOrDefault();
                                    NotEqual notEqual = operation.Nodes<NotEqual>().FirstOrDefault();
                                    bool compareEqual = equal != null;
                                    if (compareEqual || notEqual != null)
                                    {
                                        string premisAlias = null;
                                        Structure compareStructure = null;
                                        if (compareEqual)
                                        {
                                            premisAlias = GetAlias(equal.Nodes<Alias>()[0]);
                                            compareStructure = equal.Nodes<Structure>()[0];
                                        }
                                        else
                                        {
                                            premisAlias = GetAlias(notEqual.Nodes<Alias>()[0]);
                                            compareStructure = notEqual.Nodes<Structure>()[0];
                                        }

                                        string compareMethod = compareEqual ? "AreEqual" : "!AreEqual";

                                        if (structure.Nodes<ListStructure>().Count() > 0 && compareStructure.Nodes<ListStructure>().Count() > 0)
                                        {
                                            ListStructure left = structure.Nodes<ListStructure>()[0];
                                            ListStructure right = compareStructure.Nodes<ListStructure>()[0];
                                            string leftStructure = $"({string.Join(", ", CreateListStructure(left, relations[(premisAlias, "<=>")].LeftDomains, symbols))})";
                                            string rightStructure = $"({string.Join(", ", CreateListStructure(right, relations[(premisAlias, "<=>")].RightDomains, symbols))})";
                                            method.Body.Add($"{Indent(indentLevel)}if({compareMethod}({leftStructure}, {rightStructure}))");
                                        }
                                        else if (structure.Nodes<TreeStructure>().Count() > 0 && compareStructure.Nodes<TreeStructure>().Count() > 0)
                                        {
                                            TreeStructure left = structure.Nodes<TreeStructure>()[0];
                                            TreeStructure right = compareStructure.Nodes<TreeStructure>()[0];
                                            string leftStructure = $"({string.Join(", ", CreateTreeStructure(left, relations[(premisAlias, "</>")].LeftDomains[0], symbols))})";
                                            string rightStructure = $"({string.Join(", ", CreateTreeStructure(right, relations[(premisAlias, "</>")].RightDomains[0], symbols))})";
                                            method.Body.Add($"{Indent(indentLevel)}if({compareMethod}({leftStructure}, {rightStructure}))");
                                        }

                                        method.Body.Add($"{Indent(indentLevel)}{{");
                                        indentLevel++;
                                    }
                                }
                            }
                        }

                        premises = premises.Nodes<PremisesP>().FirstOrDefault();
                    }

                    List<string> returnTypes = AnalyzeReturnTypes(conclusion, relations[(alias, "->")].RightDomains, symbols);

                    string returnTypeStr = string.Join(", ", returnTypes);

                    if (returnTypes.Count > 1)
                    {
                        returnTypeStr = $"({returnTypeStr})";
                    }

                    string returnNames = $"new System.Collections.Generic.List<string>() {{ {string.Join(", ", GetReturnNames(conclusion, relations[(alias, "->")].RightDomains, symbols).Select(str => $"\"{str}\""))} }}";

                    method.Body.Insert(ruleStartIndex, $"    RuleStart{alias}({returnNames}, \"{ conclusion.Accept(new TextPrintVisitor()).Replace("\\", "\\\\").Replace("\"", "\\\"") }\", ({string.Join(", ", parameters.Select(p => p.Identifier))}));");

                    method.Type = returnTypeStr;

                    Structure conclusionStructure = conclusion.Nodes<Structure>()[0];

                    if (conclusionStructure.Nodes<ListStructure>().Count() > 0)
                    {
                        ListStructure listStructure = conclusionStructure.Nodes<ListStructure>()[0];
                        List<string> lst = CreateListStructure(listStructure, relations[(alias, "->")].RightDomains, symbols);
                        method.Body.Add($"{Indent(indentLevel)}var _result = ({ string.Join(", ", lst) });");
                        method.Body.Add($"{Indent(indentLevel)}RuleEnd{alias}(true, true, _result);");
                        method.Body.Add($"{Indent(indentLevel)}return _result;");
                    }
                    else if (conclusionStructure.Nodes<TreeStructure>().Count() > 0)
                    {
                        TreeStructure treeStructure = conclusionStructure.Nodes<TreeStructure>()[0];
                        method.Body.Add($"{Indent(indentLevel)}var _result = {CreateTreeStructure(treeStructure, relations[(alias, "->")].RightDomains[0], symbols)};");
                        method.Body.Add($"{Indent(indentLevel)}RuleEnd{alias}(true, true, _result);");
                        method.Body.Add($"{Indent(indentLevel)}return _result;");
                    }

                    indentLevel--;

                    int indentation = indentLevel;

                    while (indentLevel > 0)
                    {
                        method.Body.Add($"{Indent(indentLevel)}}}");
                        indentLevel--;
                    }

                    method.Body.Add($"{Indent(1)}RuleEnd{alias}(false);");

                    method.Body.Add("}");

                    MethodType exisitingMethod = translatorClass.Methods.FirstOrDefault(m => m.Identifier == method.Identifier && m.Type == method.Type && m.Parameters.Count == parameters.Count && m.Parameters.Count == m.Parameters.Select(p => p.Type).Intersect(parameters.Select(p => p.Type)).Count());

                    if (exisitingMethod != null)
                    {
                        for (int i = 0; i < exisitingMethod.Parameters.Count; i++)
                        {
                            ParameterType p1 = exisitingMethod.Parameters[i];
                            ParameterType p2 = method.Parameters[i];
                            if (p1.Type.Contains("Token") && p1.Identifier != p2.Identifier && !exisitingMethod.Body.Contains($"{p2.Type} {p2.Identifier} = {p1.Identifier};"))
                            {
                                exisitingMethod.Body.Add($"{p2.Type} {p2.Identifier} = {p1.Identifier};");
                            }
                        }
                        foreach (var statement in method.Body)
                        {
                            exisitingMethod.Body.Add(statement);
                        }
                    }
                    else
                    {
                        translatorClass.Methods.Add(method);
                    }

                }
                rules = rules.Nodes<RulesP>()[0];
            }

            foreach (MethodType method in translatorClass.Methods)
            {
                method.Body.Add($"{method.Identifier.Replace("Translate", "RulesFailed")}(({string.Join(", ", method.Parameters.Select(p => p.Identifier))}));");
                method.Body.Add($"return ({string.Join(", ", Enumerable.Repeat("null", method.Type.Split(',').Count()))});");
            }

            FieldType ruleError = new FieldType("public", $"Compiler.Error.RuleError", $"RuleError")
            {
                Expression = $"{{ get; set; }} = new Compiler.Error.RuleError();"
            };

            translatorClass.Fields.Add(ruleError);

            foreach (var relation in relations.Where(r => r.Key.symbol == "->"))
            {
                string leftTypes, rightTypes, righDefault;

                if (relation.Value.LeftDomains.Count == 1)
                {
                    leftTypes = $"{relation.Value.LeftDomains[0].DataNamespace}.Node";
                }
                else
                {
                    leftTypes = $"({string.Join(", ", relation.Value.LeftDomains.Select(d => $"{d.DataNamespace}.Node"))})";
                }

                if (relation.Value.RightDomains.Count == 1)
                {
                    rightTypes = $"{relation.Value.RightDomains[0].DataNamespace}.Node";
                    righDefault = "null";
                }
                else
                {
                    rightTypes = $"({string.Join(", ", relation.Value.RightDomains.Select(d => $"{d.DataNamespace}.Node"))})";
                    righDefault = $"({string.Join(", ", relation.Value.RightDomains.Select(d => "null"))})";
                }

                FieldType Relation = new FieldType("public", $"System.Collections.Generic.Dictionary<{leftTypes},{rightTypes}>", $"Relation{relation.Key.alias}")
                {
                    Expression = $"{{ get; set; }} = new System.Collections.Generic.Dictionary<{leftTypes},{rightTypes}>();"
                };

                translatorClass.Fields.Add(Relation);

                MethodType ruleStart = new MethodType("public", "void", $"RuleStart{relation.Key.alias}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType("System.Collections.Generic.List<string>", "returnTypes"),
                        new ParameterType("string", "rule"),
                        new ParameterType(leftTypes, "data")
                    },
                    Body = new List<string>()
                    {
                        $"Compiler.Error.RuleError<{leftTypes}, {rightTypes}> error = new Compiler.Error.RuleError<{leftTypes}, {rightTypes}>();",
                        "error.ReturnTypes = returnTypes;",
                        "error.Parent = RuleError;",
                        "error.Rule = rule;",
                        "RuleError.Children.Add(error);",
                        "error.From = data;",
                        "RuleError = error;"
                    }
                };

                translatorClass.Methods.Add(ruleStart);

                MethodType ruleEnd1 = new MethodType("public", "void", $"RuleEnd{relation.Key.alias}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType("bool", "success"),
                        new ParameterType("bool", "save"),
                        new ParameterType(rightTypes, "data")
                    },
                    Body = new List<string>()
                    {
                        "RuleError.IsError = !success;",
                        $"var casted = RuleError as Compiler.Error.RuleError<{leftTypes}, {rightTypes}>;",
                        "casted.To = data;",
                        $"if(save)",
                        "{",
                        $"    Relation{relation.Key.alias}.Add(casted.From, casted.To);",
                        "}",
                        "RuleError = RuleError.Parent;"
                    }
                };

                MethodType rulesFailed = new MethodType("public", "void", $"RulesFailed{relation.Key.alias}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType(leftTypes, "data")
                    },
                    Body = new List<string>()
                    {
                        $"Relation{relation.Key.alias}.Add(data, {righDefault});"
                    }
                };

                MethodType ruleEnd2 = new MethodType("public", "void", $"RuleEnd{relation.Key.alias}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType("bool", "success")
                    },
                    Body = new List<string>()
                    {
                        $"RuleEnd{relation.Key.alias}(success, success, {righDefault});"
                    }
                };

                MethodType wrongPattern = new MethodType("public", "void", $"WrongPattern{relation.Key.alias}")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType(rightTypes, "data"),
                        new ParameterType("System.Collections.Generic.List<string>", "returnTypes"),
                    },
                    Body = new List<string>()
                    {
                        $"var casted = RuleError.Children[RuleError.Children.Count - 1] as Compiler.Error.RuleError<{leftTypes}, {rightTypes}>;",
                        "casted.IsError = true;",
                        "casted.ReturnTypes = returnTypes;",
                        "casted.IsPatternError = true;",
                        "casted.To = data;"
                    }
                };

                translatorClass.Methods.Add(ruleEnd1);
                translatorClass.Methods.Add(ruleEnd2);
                translatorClass.Methods.Add(rulesFailed);
                translatorClass.Methods.Add(wrongPattern);

                if (relation.Value.LeftDomains.Count == 1 && relation.Value.RightDomains.Count == 1)
                {
                    MethodType translateMethod = new MethodType("public", $"{relation.Value.RightDomains[0].DataNamespace}.Node", $"Translate{relation.Key.alias}")
                    {
                        Parameters = new List<ParameterType>()
                        {
                            new ParameterType($"{relation.Value.LeftDomains[0].DataNamespace}.Token", "token")
                        },
                        Body = new List<string>()
                        {
                            $"RuleStart{relation.Key.alias}(new System.Collections.Generic.List<string>() {{ token.Name }}, $\"{{token.Name}} ->:{relation.Key.alias} {{token.Name}}\", token);",
                            $"var result = new {relation.Value.RightDomains[0].DataNamespace}.Token() {{ Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column }};",
                            $"RuleEnd{relation.Key.alias}(true, true, result);",
                            "return result;"
                        }
                    };
                    translatorClass.Methods.Add(translateMethod);
                }
            }

            foreach (var method in translatorClass.Methods)
            {
                if(method.Identifier.Contains("Translate"))
                {
                    method.Body.InsertRange(0, new List<string>()
                    {
                        "bool _isMatching = false;",
                        $"var key = ({string.Join(", ", method.Parameters.Select(p => p.Identifier))});",
                        $"if({method.Identifier.Replace("Translate", "Relation")}.ContainsKey(key))",
                        "{",
                        $"    var value = {method.Identifier.Replace("Translate", "Relation")}[key];",
                        $"    {method.Identifier.Replace("Translate","RuleStart")}(new System.Collections.Generic.List<string>() {{ {string.Join(", ", method.Parameters.Select(p => $"{p.Identifier}.Name"))} }}, \"\", key);",
                        $"    {method.Identifier.Replace("Translate", "RuleEnd")}(true, false, value);",
                        $"    return value;",
                        "}"
                    });
                }
            }

            foreach (var relation in relations.Where(r => r.Key.symbol == "<=>" || r.Key.symbol == "</>"))
            {
                AddAreEqualMethod(relation.Key.alias, relation.Value.LeftDomains, relation.Value.RightDomains, translatorClass.Methods);
            }

            foreach (var translationDomain in translationDomains)
            {
                MethodType insertMethod = new MethodType("public", $"{translationDomain.DataNamespace}.Node", "Insert")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType($"{translationDomain.DataNamespace}.Node", "left"),
                        new ParameterType($"{translationDomain.DataNamespace}.Node", "right")
                    },
                    Body = new List<string>()
                    {
                        "if(left.IsPlaceholder && left.Name == right.Name)",
                        "{",
                       $"    return right.Accept(new {translationDomain.VisitorNamespace}.CloneVisitor());",
                        "}",
                       $"var leftClone = left.Accept(new {translationDomain.VisitorNamespace}.CloneVisitor());",
                       $"{translationDomain.DataNamespace}.Node Insertion = InsertAux(leftClone, right);",
                        "return (Insertion == null ? null : leftClone);"
                    }
                };

                MethodType insertAuxMethod = new MethodType("public", $"{translationDomain.DataNamespace}.Node", "InsertAux")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType($"{translationDomain.DataNamespace}.Node", "left"),
                        new ParameterType($"{translationDomain.DataNamespace}.Node", "right")
                    },
                    Body = new List<string>()
                    {
                        "for (int i = 0; i < left.Count;  i++)",
                        "{",
                        "    if(left[i].IsPlaceholder && left[i].Name == right.Name)",
                        "    {",
                        "        left.RemoveAt(i);",
                        "        left.Insert(i, right);",
                        "        return left;",
                        "    }",
                        "    else",
                        "    {",
                       $"        {translationDomain.DataNamespace}.Node leftUpdated = InsertAux(left[i], right);",
                        "        if(leftUpdated != null)",
                        "        {",
                        "            return leftUpdated;",
                        "        }",
                        "    }",
                        "}",
                        "return null;"
                    }
                };

                translatorClass.Methods.Add(insertMethod);
                translatorClass.Methods.Add(insertAuxMethod);
            }

            return translatorClass;
        }

        private static string Indent(int indentLevel)
        {
            return string.Join("", Enumerable.Repeat("    ", indentLevel));
        }

        private void AddAreEqualMethod(string alias, List<RelationDomain> leftDomains, List<RelationDomain> rightDomains, List<MethodType> methods)
        {
            if(!AlreadyDefined(alias, leftDomains, rightDomains, methods))
            {
                MethodType compareMethod = new MethodType("public", "bool", $"AreEqual{alias}");
                if(leftDomains.Count == 1 && rightDomains.Count == 1)
                {
                    compareMethod.Parameters = new List<ParameterType>()
                    {
                        new ParameterType($"{leftDomains[0].DataNamespace}.Node", "left"),
                        new ParameterType($"{rightDomains[0].DataNamespace}.Node", "right")
                    };
                    methods.Add(compareMethod);
                    compareMethod.Body = new List<string>()
                    {
                        "if (left.Count != right.Count || left.Name != right.Name)",
                        "{",
                        "    return false;",
                        "}",
                       $"if (left is {leftDomains[0].DataNamespace}.Token || right is {rightDomains[0].DataNamespace}.Token)",
                        "{",
                       $"    if (left is {leftDomains[0].DataNamespace}.Token leftToken && right is {rightDomains[0].DataNamespace}.Token rightToken && leftToken.Value == rightToken.Value)",
                        "    {",
                        "        return true;",
                        "    }",
                        "    return false;",
                        "}",
                        "for (int index = 0; index < left.Count; index++)",
                        "{",
                        "    if (!AreEqual(left[index], right[index]))",
                        "    {",
                        "        return false;",
                        "    }",
                        "}",
                        "return true;"
                    };
                }
                else
                {
                    compareMethod.Parameters = new List<ParameterType>()
                    {
                        new ParameterType(CreateCompareParameterTupleType(leftDomains, "left"), "left"),
                        new ParameterType(CreateCompareParameterTupleType(rightDomains, "right"), "right")
                    };

                    methods.Add(compareMethod);

                    for (int i = 0; i < leftDomains.Count; i++)
                    {
                        RelationDomain leftDomain = leftDomains[i];
                        RelationDomain rightDomain = rightDomains[i];
                        AddAreEqualMethod("", new List<RelationDomain>() { leftDomain }, new List<RelationDomain>() { rightDomain }, methods);
                        compareMethod.Body.Add($"if(!AreEqual(left.left{i}, right.right{i})");
                        compareMethod.Body.Add("{");
                        compareMethod.Body.Add("\treturn false;");
                        compareMethod.Body.Add("}");
                    }

                    compareMethod.Body.Add("return true;");
                }
            }
        }

        private string CreateCompareParameterTupleType(List<RelationDomain> domains, string prefix)
        {
            List<string> types = new List<string>();

            for (int i = 0; i < domains.Count; i++)
            {
                types.Add($"{domains[i].DataNamespace}.Node {prefix}{i}");
            }

            return string.Join(", ", types);
        }

        private bool AlreadyDefined(string alias, List<RelationDomain> leftDomains, List<RelationDomain> rightDomains, List<MethodType> methods)
        {
            string leftType = $"{leftDomains[0].DataNamespace}.Node";
            string rightType = $"{rightDomains[0].DataNamespace}.Node";

            if (leftDomains.Count > 1)
            {
                leftType = CreateCompareParameterTupleType(leftDomains, "left");
                rightType = CreateCompareParameterTupleType(rightDomains, "right");
            }

            foreach (var method in methods.Where(m => m.Identifier == $"AreEqual{alias}"))
            {
                if(method.Parameters.Count == 2 && method.Parameters[0].Type == leftType && method.Parameters[1].Type == rightType)
                {
                    return true;
                }
            }

            return false;
        }

        private string FullType(string typeName, RelationDomain domain)
        {
            if (domain.Grammar.ContainsKey(typeName))
            {
                return $"{domain.DataNamespace}.{typeName}";
            }
            return $"{domain.DataNamespace}.{typeName}?";
        }

        private List<string> GetPatternNames(Pattern pattern)
        {
            List<string> names = new List<string>();
            if (pattern != null && pattern.Nodes<ListPattern>().Count() > 0)
            {
                Patterns patterns = pattern.Nodes<ListPattern>()[0].Nodes<Patterns>()[0];

                while (patterns.Nodes<TreePattern>().Count() > 0)
                {
                    TreePattern treePattern = patterns.Nodes<TreePattern>()[0];

                    names.Add(GetName(treePattern.Nodes<Name>()[0]));

                    patterns = patterns.Nodes<Patterns>()[0];
                }

            }
            else if (pattern != null && pattern.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = pattern.Nodes<TreePattern>()[0];

                names.Add(GetName(treePattern.Nodes<Name>()[0]));
            }

            return names;
        }

        private void AnalyzePattern(Pattern pattern, bool useAlias, List<RelationDomain> domain, List<string> patternConditions, List<ParameterType> parameters, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            int domainIndex = 0;
            if (pattern != null && pattern.Nodes<ListPattern>().Count() > 0)
            {
                Patterns patterns = pattern.Nodes<ListPattern>()[0].Nodes<Patterns>()[0];

                while (patterns.Nodes<TreePattern>().Count() > 0)
                {
                    TreePattern treePattern = patterns.Nodes<TreePattern>()[0];

                    AnalyzeTreePattern(patternConditions, useAlias, domain[domainIndex], parameters, symbols, treePattern);

                    domainIndex++;

                    patterns = patterns.Nodes<Patterns>()[0];
                }

            }
            else if (pattern != null && pattern.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = pattern.Nodes<TreePattern>()[0];

                AnalyzeTreePattern(patternConditions, useAlias, domain[domainIndex], parameters, symbols, treePattern);
            }
        }

        private void AnalyzeTreePattern(List<string> patternConditions, bool useAlias, RelationDomain domain, List<ParameterType> parameters, Dictionary<string, (string type, string name, string nodeType)> symbols, TreePattern treePattern)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string type = GetName(name);
            string nodeType = type;
            string identifier = string.Join("", type.Take(1)).ToLower() + string.Join("", type.Skip(1));
            if(identifier == "return")
            {
                identifier = "_" + identifier;
            }
            var alias = treePattern.Nodes<Alias>()[0];
            string aliasStr = "";

            string fullType = "";

            if (!domain.Grammar.ContainsKey(type))
            {
                type = "Token";
                fullType = $"{domain.DataNamespace}.Token";
            }
            else
            {
                fullType = FullType(type, domain);
            }

            aliasStr = GetAlias(alias);

            if (aliasStr != "" && useAlias)
            {
                identifier = aliasStr;
            }
            else if (symbols.Values.Any(d => d.name == (identifier)))
            {
                int i = 1;
                while (symbols.Values.Any(d => d.name == ($"{identifier}{i}")))
                {
                    i++;
                }
                identifier = $"{identifier}{i}";
                symbols.Add(identifier, (fullType, identifier, nodeType));
            }

            var pp = parameters.FirstOrDefault(p => p.Identifier == identifier);

            if(pp != null)
            {
                int i = 1;
                while (symbols.Values.Any(d => d.name == ($"{identifier}{i}")))
                {
                    i++;
                }

                identifier = $"{identifier}{i}";

                if (aliasStr != "")
                {
                    symbols.Add(aliasStr, (fullType, identifier, nodeType));
                }
            }

            if(!symbols.ContainsKey("$" + identifier))
            {
                symbols.Add("$" + identifier, (fullType, identifier, nodeType));
            }

            patternConditions.Add(CreateTreePatternCondition(identifier, domain, treePattern, symbols));

            parameters.Add(new ParameterType(fullType, identifier));
        }

        private string GetName(Name name)
        {
            string nameStr = null;

            Token symbol = name[0][0] as Token;

            if (symbol.Name == "escapedSymbol")
            {
                nameStr = symbol.Value.Substring(1);
            }
            else
            {
                nameStr = symbol.Value;
            }

            return nameStr;
        }

        private string CreateTreePatternCondition(string identifier, RelationDomain domain, TreePattern treePattern, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string nameStr = GetName(name);
            string type = nameStr;
            string fullType = type;

            string nodeType = type;

            string namePattern = GetName(name);

            if (namePattern == "*" && name[0][0].Name == "symbol")
            {
                namePattern = $"{identifier}.Name";
                type = "Node";
                fullType = $"{domain.DataNamespace}.Node";
            }
            else
            {
                namePattern = $"\"{namePattern}\"";
                if (!domain.Grammar.ContainsKey(nameStr))
                {
                    if(!domain.Grammar.Values.Any(v => v.Any(e => e.Contains(nameStr))))
                    {
                        Token token = treePattern.Nodes<Name>()[0][0][0] as Token;
                        System.Console.WriteLine($"In {token.FileName}. At line {token.Row + 1} column {token.Column + 1}. Grammar {domain.Identifier} does not contain symbol {nodeType}.");
                    }
                    type = "Token";
                    fullType = $"{domain.DataNamespace}.Token";
                }
                else
                {
                    fullType = FullType(type, domain);
                }
            }

            Alias alias = treePattern.Nodes<Alias>()[0];

            string aliasStr = GetAlias(alias);

            if (aliasStr != "" && !symbols.ContainsKey(aliasStr))
            {
                symbols.Add(aliasStr, (fullType, identifier, nodeType));
            }

            string childrenCondition = CreateChildrenPatternCondition(identifier, treePattern, domain, treePattern.Nodes<ChildrenPattern>()[0], symbols);

            if(childrenCondition == "true")
            {
                return $"{identifier} != null && {identifier}.Name == {namePattern}";
            }
            else
            {
                return $"{identifier} != null && {identifier}.Name == {namePattern} && {childrenCondition}";
            }
        }



        private string CreateChildrenPatternCondition(string identifier, TreePattern parent, RelationDomain domain, ChildrenPattern childrenPattern, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            if (childrenPattern.Nodes<Token>()[0].Name == "EPSILON")
            {
                return "true";
            }

            string childrenConditions = "true";
            int index = 0;

            List<string> children = new List<string>();

            Patterns patterns = childrenPattern.Nodes<Patterns>().FirstOrDefault();
            while (patterns != null && patterns.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = patterns.Nodes<TreePattern>()[0];
                Name name = treePattern.Nodes<Name>()[0];
                string nameStr = GetName(name);
                string treeCondition = CreateTreePatternCondition($"{identifier}[{index}]", domain, treePattern, symbols);
                children.Add(nameStr);
                if (index == 0)
                {
                    childrenConditions = $"{treeCondition}";
                }
                else if(treeCondition != "true")
                {
                    childrenConditions += $" && {treeCondition}";
                }
                patterns = patterns.Nodes<Patterns>().FirstOrDefault();
                index++;
            }

            bool isValid = true;

            string parentName = GetName(parent.Nodes<Name>()[0]);

            var expansions = domain.Grammar[parentName];

            for (int expansionIndex = 0; expansionIndex < expansions.Count; expansionIndex++)
            {
                index = 0;
                isValid = true;

                if (children.Count != expansions[expansionIndex].Count)
                {
                    isValid = false;
                }
                else
                {
                    foreach (string child in children)
                    {
                        string expectedName = expansions[expansionIndex][index];
                        if (expectedName != child && expectedName != "*" && child != "*")
                        {
                            isValid = false;
                            break;
                        }
                        index++;
                    }
                }

                if (isValid)
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                Token token = parent.Nodes<Name>()[0][0][0] as Token;
                System.Console.WriteLine($"In {token.FileName}. At line {token.Row + 1} column {token.Column + 1}. Grammar {domain.Identifier} does not contain rule {token.Value} -> {string.Join(" ", children)}");
            }

            return $"({identifier}.Count == {index} && {childrenConditions})";
        }

        private List<string> CreateListStructure(ListStructure listStructure, List<RelationDomain> domains, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            Structures structures = listStructure.Nodes<Structures>()[0];
            List<string> result = new List<string>();
            int structureIndex = 0;
            while (structures.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];
                result.Add(CreateTreeStructure(treeStructure, domains[structureIndex], symbols));
                structureIndex++;
                structures = structures.Nodes<Structures>()[0];
            }
            return result;
        }

        private List<string> CreateStructures(Structures structures, RelationDomain domain, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            List<string> result = new List<string>();
            while (structures.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];

                result.Add(CreateTreeStructure(treeStructure, domain, symbols));

                structures = structures.Nodes<Structures>()[0];
            }
            return result;
        }

        private string CreateTreeStructure(TreeStructure treeStructure, RelationDomain domain, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            string name = GetName(treeStructure.Nodes<Name>()[0]);
            bool isPlaceholder = treeStructure.Nodes<Placeholder>()[0].Nodes<Token>()[0].Name == "%";
            ChildrenStructure childrenStructure = treeStructure.Nodes<ChildrenStructure>()[0];
            string instance = "";
            Token token = treeStructure.Nodes<Name>()[0][0][0] as Token;
            if (symbols.ContainsKey(name))
            {
                instance = $"{symbols[name].name} as {symbols[name].type}";
            }
            else if (!domain.Grammar.ContainsKey(name))
            {
                if(!domain.Grammar.Values.Any(p => p.Any(e => e.Contains(name))))
                {
                    System.Console.WriteLine($"In {token.FileName}. At line {token.Row + 1} column {token.Column + 1}. Grammar {domain.Identifier} does not contain symbol {name}.");
                }
                instance = $"new {domain.DataNamespace}.Token() {{ Name = \"{name.Replace("\"", "\\\"")}\", Value = \"{name.Replace("\"", "\\\"")}\" }}";
            }
            else if (childrenStructure.Nodes<Structures>().Count() > 0)
            {
                Structures structures = childrenStructure.Nodes<Structures>()[0];
                if(!ValidateStructures(domain.Grammar[name], structures, out List<string> names, symbols))
                {
                    System.Console.WriteLine($"In {token.FileName}. At line {token.Row + 1} column {token.Column + 1}. Grammar {domain.Identifier} does not contain rule {token.Value} -> {string.Join(" ", names)}");
                }
                instance = $"new {domain.DataNamespace}.{name}({(isPlaceholder ? "true" : "false")}) {{ {string.Join(", ", CreateStructures(structures, domain, symbols))} }}";
            }
            else
            {
                instance = $"new {domain.DataNamespace}.{name}({(isPlaceholder ? "true" : "false")})";
            }

            if (treeStructure.Nodes<Insertion>()[0].Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure insertTreeStructure = treeStructure.Nodes<Insertion>()[0].Nodes<TreeStructure>()[0];
                instance = $"Insert({instance}, {CreateTreeStructure(insertTreeStructure, domain, symbols)}) as {symbols[name].type}";
            }
            return instance;
        }

        private bool ValidateStructures(List<List<string>> expansions, Structures structures, out List<string> names, Dictionary<string, (string type, string name, string nodeType)> symbols)
        {
            int index = 0;
            bool isValid = true;
            names = new List<string>();
            
            while (structures.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];

                string name = GetName(treeStructure.Nodes<Name>()[0]);

                if(symbols.ContainsKey(name))
                {
                    name = symbols[name].nodeType;
                }

                names.Add(name);
                
                index++;

                structures = structures.Nodes<Structures>()[0];
            }

            for(int expansionIndex = 0; expansionIndex < expansions.Count; expansionIndex++)
            {
                index = 0;
                isValid = true;
                
                if(names.Count != expansions[expansionIndex].Count)
                {
                    isValid = false;
                }
                else
                {
                    foreach(string name in names)
                    {
                        string expectedName = expansions[expansionIndex][index];
                        if(expectedName != name && expectedName != "*" && name != "*")
                        {
                            isValid = false;
                            break;
                        }
                        index++;
                    }
                }

                if(isValid)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
