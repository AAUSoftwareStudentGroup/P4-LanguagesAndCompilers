using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Generator.Class
{
    public class ClassGenerator : IClassGenerator
    {
        public void Generate(ClassType classType, string outputFilePath)
        {
            File.WriteAllLines(outputFilePath, GetClassTextLines(classType));
        }

        public IEnumerable<string> GetClassTextLines(ClassType classType)
        {
            foreach (var usingElement in classType.Usings)
            {
                yield return usingElement;
            }

            if(classType.Usings.Length > 0)
            {
                yield return "";
            }

            yield return $"namespace {classType.NameSpace}";
            yield return "{";
            yield return $"\t{classType.ClassModifiers} class {classType.Identifier} { (classType.BaseClass == null ? "" : $": {classType.BaseClass}") }";
            yield return "\t{";

            foreach (var field in classType.Fields)
            {
                yield return $"\t\t{field.Modifiers} {field.Type} {field.Identifier} {field.Expression}";
            }

            bool first = true;
            foreach (var method in classType.Methods)
            {
                if(!method.Modifiers.Contains("abstract"))
                {
                    if(!first)
                    {
                        yield return "";
                    }
                    else
                    {
                        first = false;
                    }
                    yield return $"\t\t{method.Modifiers} {method.Type} {method.Identifier}({string.Join(", ", method.Parameters.Select(p => $"{p.Type} {p.Identifier}"))})";
                    yield return "\t\t{";
                    foreach (var statement in method.Body)
                    {
                        yield return $"\t\t\t{statement}";
                    }
                    yield return "\t\t}";
                }
                else
                {
                    yield return $"\t\t{method.Modifiers} {method.Type} {method.Identifier}({string.Join(", ", method.Parameters.Select(p => $"{p.Type} {p.Identifier}"))});";
                }
                
            }
            yield return "\t}";
            yield return "}";
        }
    }
}
