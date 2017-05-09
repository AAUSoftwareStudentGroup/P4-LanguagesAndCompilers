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
            StringBuilder strBuilder = new StringBuilder();

            bool first = true;

            foreach (var child in node)
            {
                foreach (var str in child.Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
                {
                    if(!first)
                    {
                        strBuilder.Append(" ");
                    }
                    first = false;
                    strBuilder.Append(str);
                }
            }
            yield return strBuilder.ToString();
        }

        public override IEnumerable<string> Visit(Data.C node)
        {
            foreach (var item in node)
            {
                foreach (var item2 in item.Accept(this))
                {
                    yield return item2;
                }
            }
        }

        public override IEnumerable<string> Visit(Token node)
        {
            if(node.Value != "EPSILON" && node.Value != "eof")
            {
                yield return node.Value;
            }
        }

        public override IEnumerable<string> Visit(Function node)
        {
            if (node[0].Name != "EPSILON")
            {
                if(node.Count > 2 && node[1].Name == "Pow")
                {
                    yield return string.Join(" ", node.Select(c => c.Name));
                }
                else if(node.Nodes<Statement>().Count() == 0)
                {
                    foreach (var item in node[0].Accept(this))
                    {
                        yield return item;
                    }
                }
                else
                {
                    List<string> res = new List<string>();
                    foreach (var child in node.TakeWhile(n => n.Name != "{"))
                    {
                        foreach (var str in child.Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
                        {
                            res.Add(str);
                        }
                    }
                    yield return string.Join(" ", res);
                    yield return "{";
                    foreach (var item in node.Nodes<Declaration>()[0].Accept(this))
                    {
                        yield return $"    {item}";
                    }
                    foreach (var item in node.Nodes<Statement>()[0].Accept(this))
                    {
                        yield return $"    {item}";
                    }
                    yield return "}";
                }
            }
        }

        public override IEnumerable<string> Visit(CompoundStatement node)
        {
            foreach (var item in  node.Nodes<Statement>()[0].Accept(this))
            {
                yield return item;
            }
            foreach (var item in node.Nodes<Statement>()[1].Accept(this))
            {
                yield return item;
            }
        }

        public override IEnumerable<string> Visit(Statement node)
        {
            if(node.Count == 1)
            {
                return node.First().Accept(this);
            }
            else
            {
                return node.First().Accept(this).Select(s => s + " ;");
            }
        }

        public override IEnumerable<string> Visit(CompoundFunction node)
        {
            foreach (var item in node)
            {
                foreach (var item2 in item.Accept(this))
                {
                    yield return item2;
                }
            }
        }

        public override IEnumerable<string> Visit(Declaration node)
        {
            if (node.Count == 1)
            {
                return node.First().Accept(this);
            }
            else
            {
                return node.First().Accept(this).Select(s => s + " ;");
            }
        }

        public override IEnumerable<string> Visit(CompoundDeclaration node)
        {
            foreach (var item in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return item;
            }
            foreach (var item in node.Nodes<Declaration>()[1].Accept(this))
            {
                yield return item;
            }
        }

        public override IEnumerable<string> Visit(IfStatement node)
        {
            StringBuilder first = new StringBuilder("if ( ");
            foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                first.Append(str);
            }
            first.Append(" )");
            yield return first.ToString();
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
        }

        public override IEnumerable<string> Visit(WhileStatement node)
        {
            StringBuilder first = new StringBuilder("while ( ");
            foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                first.Append(str);
            }
            first.Append(" )");
            yield return first.ToString();
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
        }

        public override IEnumerable<string> Visit(ForStatement node)
        {
            StringBuilder first = new StringBuilder("for (");
            foreach (var c in node.Skip(2).TakeWhile(t => t.Name != ")"))
            {
                foreach (var str in c.Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
                {
                    first.Append(" " + str);
                }
            }
            first.Append(" )");
            yield return first.ToString();
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
        }

        public override IEnumerable<string> Visit(IfElseStatement node)
        {
            StringBuilder first = new StringBuilder("if ( ");
            foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                first.Append(str);
            }
            first.Append(" )");
            yield return first.ToString();
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
            yield return "else";
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[1].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[1].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
        }

        public override IEnumerable<string> Visit(IfElseIfStatement node)
        {
            StringBuilder first = new StringBuilder("if ( ");
            foreach (var str in node.Nodes<BooleanExpression>()[0].Accept(this).Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                first.Append(str);
            }
            first.Append(" )");
            yield return first.ToString();
            yield return "{";
            foreach (var str in node.Nodes<Declaration>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            foreach (var str in node.Nodes<Statement>()[0].Accept(this))
            {
                yield return $"    {str}";
            }
            yield return "}";
            yield return "else";
            foreach (var str in node[9].Accept(this))
            {
                yield return str;
            }
        }
    }
}
