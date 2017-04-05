using System.Collections.Generic;
using System.Linq;
using System;

namespace Compiler.Data.AST
{
    abstract public class Node
    {
        public string name;
        public bool isTerminal;
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }
        public Node(string name, bool isTerminal, Node parent)
        {
            this.name = name;
            this.isTerminal = isTerminal;
            this.Parent = parent;
            this.Children = new List<Node>();
        }

        public Node(Symbol symbol, Node parent) {
            this.name = symbol.Name;
            this.isTerminal = symbol.IsTerminal();
            if(parent != null)
                this.Parent = parent;
            this.Children = new List<Node>();
        } 

        // return the new child
        public Node AddChild(Node newChild)
        {
            Children.Add(newChild);
            return newChild;
        }
        public Node AddChild(Symbol symbol)
        {
            Node node;
            switch(symbol.Name) {// From hell
                case "Root": node = new Root(symbol, this); break;
                case "AddOperation": node = new AddOperation(symbol, this); break; 
                case "AddOperationP": node = new AddOperationP(symbol, this); break; 
                case "AddSubOpp": node = new AddSubOpp(symbol, this); break; 
                case "And": node = new And(symbol, this); break; 
                case "AndOperation": node = new AndOperation(symbol, this); break; 
                case "AndOperationP": node = new AndOperationP(symbol, this); break; 
                case "Assign": node = new Assign(symbol, this); break; 
                case "Assignment": node = new Assignment(symbol, this); break; 
                case "Call": node = new Call(symbol, this); break; 
                case "Class": node = new Class(symbol, this); break; 
                case "ClassBlock": node = new ClassBlock(symbol, this); break; 
                case "ClassStatement": node = new ClassStatement(symbol, this); break; 
                case "ClassStatements": node = new ClassStatements(symbol, this); break; 
                case "ClassStatementsP": node = new ClassStatementsP(symbol, this); break; 
                case "ClassWord": node = new ClassWord(symbol, this); break; 
                case "Compare": node = new Compare(symbol, this); break; 
                case "CompareOperation": node = new CompareOperation(symbol, this); break; 
                case "CompareOperationP": node = new CompareOperationP(symbol, this); break; 
                case "Condition": node = new Condition(symbol, this); break; 
                case "Declaration": node = new Declaration(symbol, this); break; 
                case "Dedent": node = new Dedent(symbol, this); break; 
                case "Definition": node = new Definition(symbol, this); break; 
                case "Del": node = new Del(symbol, this); break; 
                case "DelOperation": node = new DelOperation(symbol, this); break; 
                case "EOF": node = new EOF(symbol, this); break; 
                case "EPSILON": node = new EPSILON(symbol, this); break; 
                case "EndDel": node = new EndDel(symbol, this); break; 
                case "Expression": node = new Expression(symbol, this); break; 
                case "FunctionDefinition": node = new FunctionDefinition(symbol, this); break; 
                case "FunctionParameters": node = new FunctionParameters(symbol, this); break; 
                case "Identifier": node = new Identifier(symbol, this); break; 
                case "IdentifierOperation": node = new IdentifierOperation(symbol, this); break; 
                case "IdentifierStatement": node = new IdentifierStatement(symbol, this); break; 
                case "If": node = new If(symbol, this); break; 
                case "IfStatement": node = new IfStatement(symbol, this); break; 
                case "Indent": node = new Indent(symbol, this); break; 
                case "MulDivOpp": node = new MulDivOpp(symbol, this); break; 
                case "MultOperation": node = new MultOperation(symbol, this); break; 
                case "MultOperationP": node = new MultOperationP(symbol, this); break; 
                case "NewLine": node = new NewLine(symbol, this); break; 
                case "Number": node = new Number(symbol, this); break; 
                case "Or": node = new Or(symbol, this); break; 
                case "OrOperation": node = new OrOperation(symbol, this); break; 
                case "OrOperationP": node = new OrOperationP(symbol, this); break; 
                case "Parameters": node = new Parameters(symbol, this); break; 
                case "ParametersP": node = new ParametersP(symbol, this); break; 
                case "ParametersPP": node = new ParametersPP(symbol, this); break; 
                case "Return": node = new Return(symbol, this); break; 
                case "ReturnStatement": node = new ReturnStatement(symbol, this); break; 
                case "SepOp": node = new SepOp(symbol, this); break; 
                case "SimpleBlock": node = new SimpleBlock(symbol, this); break; 
                case "SimpleDeclaration": node = new SimpleDeclaration(symbol, this); break; 
                case "SimpleStatement": node = new SimpleStatement(symbol, this); break; 
                case "SimpleStatements": node = new SimpleStatements(symbol, this); break; 
                case "SimpleStatementsP": node = new SimpleStatementsP(symbol, this); break; 
                case "SimpleType": node = new SimpleType(symbol, this); break; 
                case "StartDel": node = new StartDel(symbol, this); break; 
                case "Statement": node = new Statement(symbol, this); break; 
                case "Statements": node = new Statements(symbol, this); break; 
                case "StatementsP": node = new StatementsP(symbol, this); break; 
                case "Type": node = new Type(symbol, this); break; 
                case "TypeParameters": node = new TypeParameters(symbol, this); break; 
                case "TypeParametersP": node = new TypeParametersP(symbol, this); break; 
                case "TypeParametersPP": node = new TypeParametersPP(symbol, this); break; 
                case "TypedParameters": node = new TypedParameters(symbol, this); break; 
                case "TypedParametersP": node = new TypedParametersP(symbol, this); break; 
                case "TypedParametersPP": node = new TypedParametersPP(symbol, this); break; 
                case "Val": node = new Val(symbol, this); break; 
                case "While": node = new While(symbol, this); break; 
                case "WhileStatement": node = new WhileStatement(symbol, this); break; 
                default: throw new ArgumentException("Symbol name was not recognised as a node-object: " + symbol.Name);
            }
            Children.Add(node);
            return node;
        }

        public override string ToString()
        {
            return PrintPretty();
        }

        public string ToNewickString()
        {
            string Node = "";
            if(Children.Count > 0)
            {
                Node += "(";
                Node += string.Join(",", (Children.Select(t => t.ToNewickString())));
                Node += ")";
                Node += $"{this}";
            }
            else {
                Node += $"\"{this}\"";
            }
            if(Parent == null)
            {
                Node += ";";
            }
            return Node;
        }
        
        public string PrintPretty(string indent = "", bool last = true)
        {
            string s = indent;
            if (last)
            {
                s += "\\-";
                indent += "  ";
            }
            else
            {
                s += "|-";
                indent += "| ";
            }
            s += this+"\r\n";

            for (int i = 0; i < Children.Count; i++)
                s += Children[i].PrintPretty(indent, i == Children.Count - 1);
            
            return s;
        }
         abstract public void Accept(Visitor v);
    }
}