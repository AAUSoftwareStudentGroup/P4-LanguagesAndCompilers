using System;
using System.Collections.Generic;
using System.Text;
using Compiler.C.Data;
using System.Linq;

namespace Compiler.C.Visitors
{
    class TextPrintVisitor : CVisitor<IEnumerable<string>>
    {
        public override IEnumerable<string> Visit(Node node)
        {
            List<string> res = new List<string>();
            foreach (var child in node)
            {
                foreach (var str in child.Accept(this))
                {
                    res.Add(str);
                }
            }
            yield return string.Join(" ", res);
        }

        public override IEnumerable<string> Visit(Token node)
        {
            if(node.Value != "EPSILON")
            {
                yield return node.Value;
            }
        }

        //public override IEnumerable<string> Visit(Data.C node)
        //{
        //    foreach (var item in node)
        //    {
        //        foreach (var item2 in item.Accept(this))
        //        {
        //            yield return item2;
        //        }
        //    }
        //}


        //public override IEnumerable<string> Visit(Token node)
        //{
        //    if(node.Value != "EPSILON")
        //    {
        //        yield return node.Value;
        //    }
        //}

        //public override IEnumerable<string> Visit(Function node)
        //{
        //    List<string> res = new List<string>();
        //    foreach (var child in node.TakeWhile(n => n.Name != "{"))
        //    {
        //        foreach (var str in child.Accept(this))
        //        {
        //            res.Add(str);
        //        }
        //    }
        //    yield return string.Join(" ", res);
        //    yield return "{";
        //    foreach (var item in node.Nodes<Statement>()[0].Accept(this))
        //    {
        //        yield return $"    {item}";
        //    }
        //    yield return "}";
        //}

        //public override IEnumerable<string> Visit(CompoundStatement node)
        //{
        //    foreach (var item in  node.Nodes<Statement>()[0].Accept(this))
        //    {
        //        yield return item;
        //    }
        //    foreach (var item in node.Nodes<Statement>()[1].Accept(this))
        //    {
        //        yield return item;
        //    }
        //}

        //public override IEnumerable<string> Visit(Statement node)
        //{
        //    foreach (var item in node)
        //    {
        //        var j = item.Accept(this).Where(s => s != ";");
        //        if(j.Count() == 1)
        //        {
        //            yield return j.First() + ";";
        //        }
        //        else
        //        {
        //            foreach (var item2 in j)
        //            {
        //                yield return item2;
        //            }
        //        }
        //    }
        //}

        //public override IEnumerable<string> Visit(Functions node)
        //{
        //    foreach (var item in node)
        //    {
        //        foreach (var item2 in item.Accept(this))
        //        {
        //            yield return item2;
        //        }
        //    }
        //}

        //public override IEnumerable<string> Visit(GlobalDeclarations node)
        //{
        //    foreach (var item in node)
        //    {
        //        foreach (var item2 in item.Accept(this))
        //        {
        //            yield return item2;
        //        }
        //    }
        //}

        //public override IEnumerable<string> Visit(IfStatement node)
        //{
        //    string first = "if(";
        //    foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this))
        //    {
        //        first += str;
        //    }
        //    first += ")";
        //    yield return first;
        //    yield return "{";
        //    foreach (var str in node.Nodes<GlobalDeclarations>()[0].Accept(this))
        //    {
        //        yield return $"    {str}";
        //    }
        //    foreach (var str in node.Nodes<Statement>()[0].Accept(this))
        //    {
        //        yield return $"    {str}";
        //    }
        //    yield return "}";
        //}

        //public override IEnumerable<string> Visit(WhileStatement node)
        //{
        //    string first = "while(";
        //    foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this))
        //    {
        //        first += str;
        //    }
        //    first += ")";
        //    yield return first;
        //    yield return "{";
        //    foreach (var str in node.Nodes<GlobalDeclarations>()[0].Accept(this))
        //    {
        //        yield return $"    {str}";
        //    }
        //    foreach (var str in node.Nodes<Statement>()[0].Accept(this))
        //    {
        //        yield return $"    {str}";
        //    }
        //    yield return "}";
        //}
    }
}
