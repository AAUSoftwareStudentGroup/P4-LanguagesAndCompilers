namespace Generator.Generated
{
	public abstract class Visitor 
	{
		public virtual void Visit(Program node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Statements node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(StatementsP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Statement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Interrupt node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Class node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ClassBlock node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ClassStatements node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ClassStatementsP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ClassStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Declaration node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(IdentifierStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(LIdentifierOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(LSelectorOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(LReturnValueOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ElementSelector node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(BitSelector node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ClassAccessor node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Assignment node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Call node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(IfStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ElseStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ElseBlock node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(WhileStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ForStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Condition node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Definition node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(FunctionDefinition node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleBlock node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypedParameters node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypedParametersF node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypedParametersP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Type node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ArrayType node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ArraySize node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypeParameters node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypeParametersF node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(TypeParametersP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleStatements node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleStatementsP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ReturnStatement node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleDeclaration node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(SimpleDefinition node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Expression node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(OrOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(OrOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(AndOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(AndOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(EqualityOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(EqualityOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(RelationalOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(RelationalOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(AddSubOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(AddSubOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(MultDivOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(MultDivOperationP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(PrimaryOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Register node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(OptionalBitSelector node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Array node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ArrayF node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ArrayP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(OptionalElementSelector node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(RSelectorOperation node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Parameters node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ParametersF node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(ParametersP node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Token node)
		{
			Visit((Node)node);
		}

		public virtual void Visit(Node node)
		{
			foreach (Node child in node.Children)
			{
				child.Accept(this);
			}
		}
	}
}
