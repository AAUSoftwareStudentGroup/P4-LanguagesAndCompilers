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
        private List<TranslationDomain> AnalyzeDomain(Domain domain, List<TranslationDomain> translationDomains)
        {
            List<TranslationDomain> resultTranslationDomains = new List<TranslationDomain>();

            if (domain.Nodes<TreeDomain>().Count() > 0)
            {
                TreeDomain treeDomain = domain.Nodes<TreeDomain>()[0];
                string domainName = treeDomain.Nodes<Token>()[0].Value;
                resultTranslationDomains.Add(translationDomains.First(t => t.Identifier == domainName));
            }
            else
            {
                ListDomain listDomain = domain.Nodes<ListDomain>()[0];
                Domains domains = listDomain.Nodes<Domains>()[0];

                while (domains.Nodes<TreeDomain>().Count() > 0)
                {
                    TreeDomain treeDomain = domains.Nodes<TreeDomain>()[0];
                    string domainName = treeDomain.Nodes<Token>()[0].Value;
                    resultTranslationDomains.Add(translationDomains.First(t => t.Identifier == domainName));
                    domains = domains.Nodes<Domains>()[0];
                }
            }

            return resultTranslationDomains;
        }

        private string GetAlias(Alias alias)
        {
            var aliasTokens = alias.Nodes<Token>();

            string aliasName = "";

            if (aliasTokens[0].Name != "EPSILON")
            {
                aliasName = aliasTokens[1].Value;
            }

            return aliasName;
        }

        private List<string> AnalyzeReturnTypes(Conclusion conclusion, List<TranslationDomain> translationDomains, Dictionary<string, (string type, string name)> symbols)
        {
            List<string> returnTypes = new List<string>();
            Structure structure = conclusion.Nodes<Structure>()[0];
            if(structure.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                AnalyzeTreeStructureReturnType(translationDomains[0], symbols, returnTypes, treeStructure);
            }
            else
            {
                int domainIndex = 0;
                Structures structures = structure.Nodes<ListStructure>()[0].Nodes<Structures>()[0];
                while(structures.Nodes<TreeStructure>().Count() > 0)
                {
                    TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];
                    AnalyzeTreeStructureReturnType(translationDomains[domainIndex], symbols, returnTypes, treeStructure);
                    structures = structures.Nodes<Structures>()[0];
                    domainIndex++;
                }
            }
            return returnTypes;
        }

        private static void AnalyzeTreeStructureReturnType(TranslationDomain translationDomain, Dictionary<string, (string type, string name)> symbols, List<string> returnTypes, TreeStructure treeStructure)
        {
            string name = treeStructure.Nodes<Name>()[0].Nodes<Token>()[0].Value;
            returnTypes.Add($"{translationDomain.Namespace}.Node");
        }

        public ClassType GenerateTranslatorClass(Translator translator, string translatorName, List<TranslationDomain> translationDomains, string translatorNamespace)
        {
            ClassType translatorClass = new ClassType(translatorNamespace, "public", translatorName, null);

            Node systems = translator.Nodes<Systems>()[0];

            Dictionary<string, TranslationSystem> translationSystems = new Dictionary<string, TranslationSystem>();

            while (systems.Nodes<Data.System>().Count() > 0)
            {
                Data.System system = systems.Nodes<Data.System>()[0];

                string alias = GetAlias(system.Nodes<Alias>()[0]);

                Domain domain = system.Nodes<Domain>()[0];
                Domain coDomain = system.Nodes<Domain>()[1];

                translationSystems.Add(alias, new TranslationSystem()
                {
                    Domain = AnalyzeDomain(domain, translationDomains),
                    CoDomain = AnalyzeDomain(coDomain, translationDomains)
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

                    AnalyzePattern(pattern, false, translationSystems[alias].Domain, patternConditions, parameters, symbols);


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
                                    AnalyzePattern(pattern1, true, translationSystems[premisAlias].CoDomain, patternConditions1, parameters1, symbols);

                                    string returnTypeStr1 = string.Join(", ", parameters1.Select(p => $"{string.Join(".", p.Type.Split('.').Reverse().Skip(1).Reverse().Concat(new string[] { "Node" }))} {p.Identifier}"));

                                    if (parameters1.Count > 1)
                                    {
                                        returnTypeStr1 = $"({returnTypeStr1})";
                                    }

                                    string translatorArgs = "";

                                    if (structure.Nodes<ListStructure>().Count() > 0)
                                    {
                                        ListStructure listStructure = structure.Nodes<ListStructure>()[0];
                                        List<string> lst = CreateListStructure(listStructure, translationSystems[premisAlias].Domain, symbols);
                                        translatorArgs = string.Join(", ", lst);
                                    }
                                    else if (structure.Nodes<TreeStructure>().Count() > 0)
                                    {
                                        TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                                        translatorArgs = CreateTreeStructure(treeStructure, translationSystems[premisAlias].Domain[0], symbols);
                                    }

                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{returnTypeStr1} = Translate{premisAlias}({translatorArgs});");
                                    //if (pattern1.Nodes<ListPattern>().Count() > 0)
                                    //{
                                    //    for (int i = 0; i < parameters1.Count; i++)
                                    //    {
                                    //        ParameterType p = parameters1[i];
                                    //        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{p.Type} {p.Identifier} = node{nodeNumber}[{i}] as {p.Type};");
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{parameters1[0].Type} {parameters1[0].Identifier} = node{nodeNumber} as {parameters1[0].Type};");
                                    //}
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}if({string.Join(" && ", patternConditions1)})");
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{{");
                                    indentLevel++;
                                    nodeNumber++;
                                }
                            }
                        }

                        premises = premises.Nodes<PremisesP>().FirstOrDefault();
                    }

                    List<string> returnTypes = AnalyzeReturnTypes(conclusion, translationSystems[alias].CoDomain, symbols);

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
                        List<string> lst = CreateListStructure(listStructure, translationSystems[alias].CoDomain, symbols);
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return ({ string.Join(", ", lst) });");
                    }
                    else if (conclusionStructure.Nodes<TreeStructure>().Count() > 0)
                    {
                        TreeStructure treeStructure = conclusionStructure.Nodes<TreeStructure>()[0];
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return {CreateTreeStructure(treeStructure, translationSystems[alias].CoDomain[0], symbols)};");
                    }

                    indentLevel--;

                    while (indentLevel > 0)
                    {
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}}}");
                        indentLevel--;
                    }

                    method.Body.Add("}");

                    MethodType exisitingMethod = translatorClass.Methods.FirstOrDefault(m => m.Identifier == method.Identifier && m.Type == method.Type && m.Parameters.Count == parameters.Count && m.Parameters.Count == m.Parameters.Select(p => p.Type).Intersect(parameters.Select(p => p.Type)).Count());

                    if(exisitingMethod != null)
                    {
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
                method.Body.Add("throw new System.Exception();");
            }

            foreach (var translationSystem in translationSystems)
            {
                if(translationSystem.Value.Domain.Count == 1 && translationSystem.Value.CoDomain.Count == 1)
                {
                    MethodType translateMethod = new MethodType("public", $"{translationSystem.Value.CoDomain[0].Namespace}.Token", $"Translate{translationSystem.Key}")
                    {
                        Parameters = new List<ParameterType>()
                        {
                            new ParameterType($"{translationSystem.Value.Domain[0].Namespace}.Token", "token")
                        },
                        Body = new List<string>()
                        {
                            $"return new {translationSystem.Value.CoDomain[0].Namespace}.Token() {{ Name = token.Name, Value = token.Value, Row = token.Row, Column = token.Column }};"
                        }
                    };
                    translatorClass.Methods.Add(translateMethod);
                }
            }

            foreach (var translationDomain in translationDomains)
            {
                MethodType insertMethod = new MethodType("public", $"{translationDomain.Namespace}.Node", "Insert")
                {
                    Parameters = new List<ParameterType>()
                    {
                        new ParameterType($"{translationDomain.Namespace}.Node", "left"),
                        new ParameterType($"{translationDomain.Namespace}.Node", "right")
                    },
                    Body = new List<string>()
                    {
                        "if(left.IsPlaceholder && left.Name == right.Name)",
                        "{",
                        "    return right;",
                        "}",
                        "for (int i = 0; i < left.Count;  i++)",
                        "{",
                       $"    {translationDomain.Namespace}.Node child = Insert(left[i], right);",
                        "    if(child != null)",
                        "    {",
                        "        left.RemoveAt(i);",
                        "        left.Insert(i, child);",
                        "        return left;",
                        "    }",
                        "}",
                        "return null;"
                    }
                };

                translatorClass.Methods.Add(insertMethod);
            }

            return translatorClass;
        }

        private string FullType(string typeName, TranslationDomain domain)
        {
            if (domain.Grammar.ContainsKey(typeName))
            {
                return $"{domain.Namespace}.{typeName}";
            }
            return $"{domain.Namespace}.{typeName}?";
        }

        private void AnalyzePattern(Pattern pattern, bool useAlias, List<TranslationDomain> domain, List<string> patternConditions, List<ParameterType> parameters, Dictionary<string, (string type, string name)> symbols)
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

        private void AnalyzeTreePattern(List<string> patternConditions, bool useAlias, TranslationDomain domain, List<ParameterType> parameters, Dictionary<string, (string type, string name)> symbols, TreePattern treePattern)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string type = name.Nodes<Token>()[0].Value;
            string identifier = string.Join("", type.Take(1)).ToLower() + string.Join("", type.Skip(1));
            var alias = treePattern.Nodes<Alias>()[0];
            string aliasStr = "";

            string fullType = "";

            if (type[0] == type.ToLower()[0])
            {
                type = "Token";
                fullType = $"{domain.Namespace}.Token";
            }
            else
            {
                fullType = FullType(type, domain);
            }

            if (alias.Nodes<Token>()[0].Name != "EPSILON")
            {
                aliasStr = alias.Nodes<Token>()[1].Value;
                if (useAlias)
                {
                    identifier = aliasStr;
                }
            }
            else if (symbols.Values.Any(d => d.name == identifier))
            {
                int i = 1;
                while (symbols.Values.Any(d => d.name == $"{identifier}{i}"))
                {
                    i++;
                }
                identifier = $"{identifier}{i}";
                symbols.Add(identifier, (fullType, identifier));
            }

            patternConditions.Add(CreateTreePatternCondition(identifier, domain, treePattern, symbols));

            parameters.Add(new ParameterType(fullType, identifier));
        }

        private string CreateTreePatternCondition(string identifier, TranslationDomain domain, TreePattern treePattern, Dictionary<string, (string type, string name)> symbols)
        {
            Name nameN = treePattern.Nodes<Name>()[0];
            string name = nameN.Nodes<Token>()[0].Value;
            string type = name;
            string fullType = type;

            if (type[0] == type.ToLower()[0])
            {
                type = "Token";
                fullType = $"{domain.Namespace}.Token";
            }
            else
            {
                fullType = FullType(type, domain);
            }
            Alias alias = treePattern.Nodes<Alias>()[0];
            var aliasTokens = alias.Nodes<Token>().ToList();
            if (aliasTokens.Count == 2 && aliasTokens[1].Name == "symbol")
            {
                if (!symbols.ContainsKey(aliasTokens[1].Value))
                {
                    symbols.Add(aliasTokens[1].Value, (fullType, identifier));
                }
            }
            return $"{identifier} != null && {identifier}.Name == \"{treePattern.Nodes<Name>()[0].Nodes<Token>()[0].Value}\" && {CreateChildrenPatternCondition(identifier, domain, treePattern.Nodes<ChildrenPattern>()[0], symbols)}";
        }

        private string CreateChildrenPatternCondition(string identifier, TranslationDomain domain, ChildrenPattern childrenPattern, Dictionary<string, (string type, string name)> symbols)
        {
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

        private List<string> CreateListStructure(ListStructure listStructure, List<TranslationDomain> domains, Dictionary<string, (string type, string name)> symbols)
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

        private List<string> CreateStructures(Structures structures, TranslationDomain domain, Dictionary<string, (string type, string name)> symbols)
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

        private string CreateTreeStructure(TreeStructure treeStructure, TranslationDomain domain, Dictionary<string, (string type, string name)> symbols)
        {
            string name = treeStructure.Nodes<Name>()[0].Nodes<Token>()[0].Value;
            bool isPlaceholder = treeStructure.Nodes<Placeholder>()[0].Nodes<Token>()[0].Name == "%";
            ChildrenStructure childrenStructure = treeStructure.Nodes<ChildrenStructure>()[0];
            string instance = "";
            if (symbols.ContainsKey(name))
            {
                instance = $"{symbols[name].name} as {symbols[name].type}";
            }
            else if (!domain.Grammar?.ContainsKey(name) ?? false)
            {
                instance = $"new {domain.Namespace}.Token() {{ Name = \"{name}\", Value = \"{name}\" }}";
            }
            else if (childrenStructure.Nodes<Structures>().Count() > 0)
            {
                Structures structures = childrenStructure.Nodes<Structures>()[0];
                instance = $"new {domain.Namespace}.{name}({(isPlaceholder ? "true" : "false")}) {{ {string.Join(", ", CreateStructures(structures, domain, symbols))} }}";
            }
            else
            {
                instance = $"new {domain.Namespace}.{name}({(isPlaceholder ? "true" : "false")})";
            }
            if(treeStructure.Nodes<Insertion>()[0].Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure insertTreeStructure = treeStructure.Nodes<Insertion>()[0].Nodes<TreeStructure>()[0];
                instance = $"Insert({instance}, {CreateTreeStructure(insertTreeStructure, domain, symbols)}) as {symbols[name].type}";
            }
            return instance;
        }
    }
}
