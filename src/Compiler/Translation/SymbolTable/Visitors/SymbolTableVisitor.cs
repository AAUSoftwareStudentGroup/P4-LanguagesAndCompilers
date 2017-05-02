namespace Compiler.Translation.SymbolTable.Visitors
{
	public abstract class SymbolTableVisitor<T> 
	{
		public virtual T Visit(Compiler.Translation.SymbolTable.Data.SymbolTable node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Variables node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Variable node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Function node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Parameters node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Type node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.ParameterTypes node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.IntType node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.RegisterType node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.BooleanType node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Token node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}
		public abstract T Visit(Compiler.Translation.SymbolTable.Data.Node node);
	}
}
