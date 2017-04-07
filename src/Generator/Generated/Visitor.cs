namespace Generator.Generated
{
	public abstract class Visitor<T> 
	{
		public virtual T Visit(Program node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Statements node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(StatementsP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Statement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Interrupt node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Class node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassBlock node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatements node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatementsP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Declaration node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IdentifierStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LIdentifierOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LSelectorOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(LReturnValueOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElementSelector node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(BitSelector node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ClassAccessor node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Assignment node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Call node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(IfStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElseStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ElseBlock node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(WhileStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ForStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Condition node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Definition node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(FunctionDefinition node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleBlock node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParameters node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParametersF node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypedParametersP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Type node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayType node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArraySize node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParameters node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParametersF node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(TypeParametersP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatements node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatementsP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ReturnStatement node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleDeclaration node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(SimpleDefinition node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Expression node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OrOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OrOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AndOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AndOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(EqualityOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(EqualityOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RelationalOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RelationalOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AddSubOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(AddSubOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(MultDivOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(MultDivOperationP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(PrimaryOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Register node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OptionalBitSelector node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Array node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayF node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ArrayP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(OptionalElementSelector node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(RSelectorOperation node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Parameters node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParametersF node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(ParametersP node)
		{
			return Visit((Node)node);
		}

		public virtual T Visit(Token node)
		{
			return Visit((Node)node);
		}
		public abstract T Visit(Node node);
	}
}
