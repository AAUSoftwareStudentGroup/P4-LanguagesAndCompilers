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
        public ClassType GenerateTranslatorClass(Translator translator, string translatorName, List<(string nameSpace, BNF grammar)> domain, List<(string nameSpace, BNF grammar)> coDomain, string translatorNamespace)
        {
            ClassType translatorClass = new ClassType(translatorNamespace, "public", translatorName, null);

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
                    Dictionary<string, string> symbols = new Dictionary<string, string>();

                    AnalyzePattern(pattern, false, domain, patternConditions, parameters, symbols);

                    MethodType method = translatorClass.Methods.FirstOrDefault(m => m.Parameters.Count == parameters.Count && m.Parameters.Count == m.Parameters.Select(p => p.Type).Intersect(parameters.Select(p => p.Type)).Count());

                    if (method == null)
                    {
                        method = new MethodType("public", "Node", "Translate")
                        {
                            Parameters = parameters
                        };
                        translatorClass.Methods.Add(method);
                    }

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
                                string translatorArgs = "";

                                if (structure.Nodes<ListStructure>().Count() > 0)
                                {
                                    ListStructure listStructure = structure.Nodes<ListStructure>()[0];
                                    List<string> lst = CreateListStructure(listStructure, symbols);
                                    translatorArgs = string.Join(", ", lst);
                                }
                                else if (structure.Nodes<TreeStructure>().Count() > 0)
                                {
                                    TreeStructure treeStructure = structure.Nodes<TreeStructure>()[0];
                                    translatorArgs = CreateTreeStructure(treeStructure, symbols);
                                }
                                StructureOperation operation = premis.Nodes<StructureOperation>()[0];
                                Goto gotoNode = operation.Nodes<Goto>().FirstOrDefault();
                                if (gotoNode != null)
                                {
                                    Pattern pattern1 = gotoNode.Nodes<Pattern>()[0];
                                    List<string> patternConditions1 = new List<string>();
                                    List<ParameterType> parameters1 = new List<ParameterType>();
                                    AnalyzePattern(pattern1, true, coDomain, patternConditions1, parameters1, symbols);
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}Node node{nodeNumber} = Translate({translatorArgs});");
                                    if (pattern1.Nodes<ListPattern>().Count() > 0)
                                    {
                                        for (int i = 0; i < parameters1.Count; i++)
                                        {
                                            ParameterType p = parameters1[i];
                                            method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{p.Type} {p.Identifier} = node{nodeNumber}[{i}] as {p.Type};");
                                        }
                                    }
                                    else
                                    {
                                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{parameters1[0].Type} {parameters1[0].Identifier} = node{nodeNumber} as {parameters1[0].Type};");
                                    }
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}if({string.Join(" && ", patternConditions1)})");
                                    method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}{{");
                                    indentLevel++;
                                    nodeNumber++;
                                }
                            }
                        }

                        premises = premises.Nodes<PremisesP>().FirstOrDefault();
                    }

                    Structure conclusionStructure = conclusion.Nodes<Structure>()[0];

                    if (conclusionStructure.Nodes<ListStructure>().Count() > 0)
                    {
                        ListStructure listStructure = conclusionStructure.Nodes<ListStructure>()[0];
                        List<string> lst = CreateListStructure(listStructure, symbols);
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return new ListNode() {{ { string.Join(", ", lst) } }};");
                    }
                    else if (conclusionStructure.Nodes<TreeStructure>().Count() > 0)
                    {
                        TreeStructure treeStructure = conclusionStructure.Nodes<TreeStructure>()[0];
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}return {CreateTreeStructure(treeStructure, symbols)};");
                    }

                    indentLevel--;

                    while (indentLevel > 0)
                    {
                        method.Body.Add($"{string.Join("", Enumerable.Repeat("\t", indentLevel))}}}");
                        indentLevel--;
                    }

                    method.Body.Add("// " + string.Join(", ", symbols.Select(s => $"({s.Key} = {s.Value})")));
                    method.Body.Add("}");
                }
                rules = rules.Nodes<RulesP>()[0];
            }

            return translatorClass;
        }

        private string FullType(string typeName, List<(string nameSpace, BNF grammar)> grammars)
        {
            foreach (var g in grammars)
            {
                if(g.grammar.ContainsKey(typeName))
                {
                    return $"{g.nameSpace}.{typeName}";
                }
            }
            return "Undefined";
        }

        private void AnalyzePattern(Pattern pattern, bool useAlias, List<(string, BNF)> domain, List<string> patternConditions, List<ParameterType> parameters, Dictionary<string, string> symbols)
        {
            if (pattern != null && pattern.Nodes<ListPattern>().Count() > 0)
            {
                Patterns patterns = pattern.Nodes<ListPattern>()[0].Nodes<Patterns>()[0];

                while (patterns.Nodes<TreePattern>().Count() > 0)
                {
                    TreePattern treePattern = patterns.Nodes<TreePattern>()[0];

                    AnalyzeTreePattern(patternConditions, useAlias, domain, parameters, symbols, treePattern);

                    patterns = patterns.Nodes<Patterns>()[0];
                }

            }
            else if (pattern != null && pattern.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = pattern.Nodes<TreePattern>()[0];

                AnalyzeTreePattern(patternConditions, useAlias, domain, parameters, symbols, treePattern);
            }
        }

        private void AnalyzeTreePattern(List<string> patternConditions, bool useAlias, List<(string, BNF)> domain, List<ParameterType> parameters, Dictionary<string, string> symbols, TreePattern treePattern)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string type = name.Nodes<Token>()[0].Value;
            string identifier = string.Join("", type.Take(1)).ToLower() + string.Join("", type.Skip(1));
            var alias = treePattern.Nodes<Alias>()[0];
            string aliasStr = "";
            if (alias.Nodes<Token>()[0].Name != "EPSILON")
            {
                aliasStr = alias.Nodes<Token>()[1].Value;
                if (useAlias)
                {
                    identifier = aliasStr;
                }
            }
            else if (symbols.ContainsValue(identifier))
            {
                int i = 1;
                while (symbols.ContainsValue($"{identifier}{i}"))
                {
                    i++;
                }
                identifier = $"{identifier}{i}";
            }

            patternConditions.Add(CreateTreePatternCondition(identifier, treePattern, symbols));

            if (type[0] == type.ToLower()[0])
            {
                type = "Token";
            }

            parameters.Add(new ParameterType(FullType(type, domain), identifier));
        }

        private string CreateTreePatternCondition(string identifier, TreePattern treePattern, Dictionary<string, string> symbols)
        {
            Name name = treePattern.Nodes<Name>()[0];
            string type = name.Nodes<Token>()[0].Value;
            Alias alias = treePattern.Nodes<Alias>()[0];
            var aliasTokens = alias.Nodes<Token>().ToList();
            if (aliasTokens.Count == 2 && aliasTokens[1].Name == "symbol")
            {
                if (!symbols.ContainsKey(aliasTokens[1].Value))
                {
                    symbols.Add(aliasTokens[1].Value, identifier);
                }
            }
            else if (aliasTokens.Count == 1 && aliasTokens[0].Name == "EPSILON")
            {
                if (!symbols.ContainsKey(type))
                {
                    symbols.Add(type, identifier);
                }
            }
            return $"{identifier} != null && {identifier}.Name == \"{treePattern.Nodes<Name>()[0].Nodes<Token>()[0].Value}\" && {CreateChildrenPatternCondition(identifier, treePattern.Nodes<ChildrenPattern>()[0], symbols)}";
        }

        private string CreateChildrenPatternCondition(string identifier, ChildrenPattern childrenPattern, Dictionary<string, string> symbols)
        {
            string childrenConditions = "true";
            int index = 0;
            Patterns patterns = childrenPattern.Nodes<Patterns>().FirstOrDefault();
            while (patterns != null && patterns.Nodes<TreePattern>().Count() > 0)
            {
                TreePattern treePattern = patterns.Nodes<TreePattern>()[0];
                string treeCondition = CreateTreePatternCondition($"{identifier}[{index}]", treePattern, symbols);
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

        private List<string> CreateListStructure(ListStructure listStructure, Dictionary<string, string> symbols)
        {
            Structures structures = listStructure.Nodes<Structures>()[0];
            return CreateStructures(structures, symbols);
        }

        private List<string> CreateStructures(Structures structures, Dictionary<string, string> symbols)
        {
            List<string> result = new List<string>();
            while (structures.Nodes<TreeStructure>().Count() > 0)
            {
                TreeStructure treeStructure = structures.Nodes<TreeStructure>()[0];

                result.Add(CreateTreeStructure(treeStructure, symbols));

                structures = structures.Nodes<Structures>()[0];
            }
            return result;
        }

        private string CreateTreeStructure(TreeStructure treeStructure, Dictionary<string, string> symbols)
        {
            string name = treeStructure.Nodes<Name>()[0].Nodes<Token>()[0].Value;
            ChildrenStructure childrenStructure = treeStructure.Nodes<ChildrenStructure>()[0];
            if (symbols.ContainsKey(name))
            {
                return symbols[name];
            }
            else if (childrenStructure.Nodes<Structures>().Count() > 0)
            {
                Structures structures = childrenStructure.Nodes<Structures>()[0];
                return $"new {name}() {{ {string.Join(", ", CreateStructures(structures, symbols))} }}";
            }
            else
            {
                return $"new {name}()";
            }
        }
    }
}
