using Generator.Class;
using Generator.Grammar;
using Generator.Translation.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Translation
{
    interface ITranslatorGenerator
    {
        ClassType GenerateTranslatorClass(Translator translator, string translatorName, List<RelationDomain> domains, string translatorNamespace);
    }
}
