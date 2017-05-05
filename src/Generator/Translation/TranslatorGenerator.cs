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

        private List<string> AnalyzeReturnTypes(Conclusion conclusion, List<RelationDomain> translationDomains, Dictionary<string, (string type, string name)> symbols)
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

        private void AnalyzeTreeStructureReturnType(RelationDomain translationDomain, Dictionary<string, (string type, string name)> symbols, List<string> returnTypes, TreeStructure treeStructure)
        {
            returnTypes.Add($"{translationDomain.DataNamespace}.Node");
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
                    Dictionary<string, (string type, string name)> symbols = new Dictionary<string, (string type, string name)>();

                    string alias = GetAlias(conclusion.Nodes<Alias>()[0]);

                    string symbol = "->";

                    AnalyzePattern(pattern, false, relations[(alias, symbol)].LeftDomains, patternConditions, parameters, symbols);

                    MethodType method = new MethodType("public", null, $"Translate{alias}")
                    {
                        Parameters = parameters
                    };
                    method.Body.Add($"if({string.Join(" && ", patternConditions)})");
                    method.Body.Add("{");
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

                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{returnTypeStr1} = Translate{premisAlias}({translatorArgs});");
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}if({string.Join(" && ", patternConditions1)})");
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{{");
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
                                            method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}if({compareMethod}({leftStructure}, {rightStructure}))");
                                        }
                                        else if (structure.Nodes<TreeStructure>().Count() > 0 && compareStructure.Nodes<TreeStructure>().Count() > 0)
                                        {
                                            TreeStructure left = structure.Nodes<TreeStructure>()[0];
                                            TreeStructure right = compareStructure.Nodes<TreeStructure>()[0];
                                            string leftStructure = $"({string.Join(", ", CreateTreeStructure(left, relations[(premisAlias, "</>")].LeftDomains[0], symbols))})";
                                            string rightStructure = $"({string.Join(", ", CreateTreeStructure(right, relations[(premisAlias, "</>")].RightDomains[0], symbols))})";
                                            method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}if({compareMethod}({leftStructure}, {rightStructure}))");
                                        }

                                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{{");
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

                    method.Type = returnTypeStr;

                    Structure conclusionStructure = conclusion.Nodes<Structure>()[0];

                    if (conclusionStructure.Nodes<ListStructure>().Count() > 0)
                    {
                        ListStructure listStructure = conclusionStructure.Nodes<ListStructure>()[0];
                        List<string> lst = CreateListStructure(listStructure, relations[(alias, "->")].RightDomains, symbols);
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return ({ string.Join(", ", lst) });");
                    }
                    else if (conclusionStructure.Nodes<TreeStructure>().Count() > 0)
                    {
                        TreeStructure treeStructure = conclusionStructure.Nodes<TreeStructure>()[0];
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return {CreateTreeStructure(treeStructure, relations[(alias, "->")].RightDomains[0], symbols)};");
                    }

                    indentLevel--;

                    while (indentLevel > 0)
                    {
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}}}");
                        indentLevel--;
                    }

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

            List<string> counterNames = new List<string>();

            foreach (MethodType method in translatorClass.Methods)
            {
                string counterName = method.Identifier+"__" + string.Join("_", method.Parameters.Select(p => p.Identifier))+"";
                counterNames.Add(counterName);
                method.Body.Insert(0, $"{counterName}++;");
                method.Body.Add("throw new System.Exception();");
            }

            foreach (var relation in relations.Where(r => r.Key.symbol == "->"))
            {
                if (relation.Value.LeftDomains.Count == 1 && relation.Value.RightDomains.Count == 1)
                {
                    MethodType translateMethod = new MethodType("public", $"{relation.Value.RightDomains[0].DataNamespace}.Token", $"Translate{relation.Key.alias}")
                    {
                        Parameters = new List<ParameterType>()
                        {
                            new ParameterType($"{relation.Value.LeftDomains[0].DataNamespace}.Token", "token")
                        },
                        Body = new List<string>()
                        {
                            $"return new {relation.Value.RightDomains[0].DataNamespace}.Token() {{ Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column }};"
                        }
                    };
                    translatorClass.Methods.Add(translateMethod);
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
                        "if(left.IsPlaceholder && left.Name == right.Name) {",
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
                        "    if(left[i].IsPlaceholder && left[i].Name == right.Name) {",
                        "        left.RemoveAt(i);",
                        "        left.Insert(i, right);",
                        "        return left;",
                        "    }",
                        "    else {",
                       $"        {translationDomain.DataNamespace}.Node leftUpdated = InsertAux(left[i], right);",
                        "        if(leftUpdated != null) {",
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

            MethodType printCountsMethod = new MethodType("public", "void", "printCounts");
            translatorClass.Methods.Add(printCountsMethod);
            printCountsMethod.Body = new List<string>();
            printCountsMethod.Body.Add("System.Console.WriteLine(\"___Translation methods calls___\");");
            
            foreach(var counterName in counterNames) {
                translatorClass.Fields.Add(new FieldType("public", "int", counterName) {Expression = "= 0;"});
                printCountsMethod.Body.Add($"System.Console.WriteLine(\"{counterName}: \"+{counterName});");
            }
            return translatorClass;
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

        private void AnalyzePattern(Pattern pattern, bool useAlias, List<RelationDomain> domain, List<string> patternConditions, List<ParameterType> parameters, Dictionary<string, (string type, string name)> symbols)
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

        private void AnalyzeTreePattern(List<string> patternConditions, bool useAlias, RelationDomain domain, List<ParameterType> parameters, Dictionary<string, (string type, string name)> symbols, TreePattern treePattern)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string type = GetName(name);
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
                symbols.Add(identifier, (fullType, identifier));
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
                    symbols.Add(aliasStr, (fullType, identifier));
                }
            }

            if(!symbols.ContainsKey("$" + identifier))
            {
                symbols.Add("$" + identifier, (fullType, identifier));
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

        private string CreateTreePatternCondition(string identifier, RelationDomain domain, TreePattern treePattern, Dictionary<string, (string type, string name)> symbols)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string nameStr = GetName(name);
            string type = nameStr;
            string fullType = type;



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
                symbols.Add(aliasStr, (fullType, identifier));
            }

            return $"{identifier} != null && {identifier}.Name == {namePattern} && {CreateChildrenPatternCondition(identifier, domain, treePattern.Nodes<ChildrenPattern>()[0], symbols)}";
        }

        private string CreateChildrenPatternCondition(string identifier, RelationDomain domain, ChildrenPattern childrenPattern, Dictionary<string, (string type, string name)> symbols)
        {
            if (childrenPattern.Nodes<Token>()[0].Name == "EPSILON")
            {
                return "true";
            }
            string childrenConditions = "true";
            int index = 0;
            Patterns patterns = childrenPattern.Nodes<Patterns>().FirstOrDefault();
            while (patterns != null && patterns.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = patterns.Nodes<TreePattern>()[0];
                string treeCondition = CreateTreePatternCondition($"{identifier}[{index}]", domain, treePattern, symbols);
                if (index == 0)
                {
                    childrenConditions = $"{treeCondition}";
                }
                else
                {
                    childrenConditions += $" && {treeCondition}";
                }
                patterns = patterns.Nodes<Patterns>().FirstOrDefault();
                index++;
            }

            return $"({identifier}.Count == {index} && {childrenConditions})";
        }

        private List<string> CreateListStructure(ListStructure listStructure, List<RelationDomain> domains, Dictionary<string, (string type, string name)> symbols)
        {
            Structures structures = listStructure.Nodes<Structures>()[0];
            List<string> result = new List<string>();
            int structureIndex = 0;
            while (structures.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];

                //if(structureIndex > domains.Count - 1)
                //{
                //    result.Add(CreateTreeStructure(treeStructure, new TranslationDomain() { Grammar = null, Identifier = null, Namespace = "Undefined" }, symbols));
                //}
                //else
                {
                    result.Add(CreateTreeStructure(treeStructure, domains[structureIndex], symbols));
                }
                structureIndex++;
                structures = structures.Nodes<Structures>()[0];
            }
            return result;
        }

        private List<string> CreateStructures(Structures structures, RelationDomain domain, Dictionary<string, (string type, string name)> symbols)
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

        private string CreateTreeStructure(TreeStructure treeStructure, RelationDomain domain, Dictionary<string, (string type, string name)> symbols)
        {
            string name = GetName(treeStructure.Nodes<Name>()[0]);
            bool isPlaceholder = treeStructure.Nodes<Placeholder>()[0].Nodes<Token>()[0].Name == "%";
            ChildrenStructure childrenStructure = treeStructure.Nodes<ChildrenStructure>()[0];
            string instance = "";
            if (symbols.ContainsKey(name))
            {
                instance = $"{symbols[name].name} as {symbols[name].type}";
            }
            else if (!domain.Grammar?.ContainsKey(name) ?? false)
            {
                instance = $"new {domain.DataNamespace}.Token() {{ Name = \"{name}\", Value = \"{name}\" }}";
            }
            else if (childrenStructure.Nodes<Structures>().Count() > 0)
            {
                Structures structures = childrenStructure.Nodes<Structures>()[0];
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
    }
}
