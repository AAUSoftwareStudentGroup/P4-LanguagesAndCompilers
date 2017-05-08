namespace Compiler.Translation.SymbolTable.Visitors
{
	public abstract class SymbolTableVisitor<T> 
	{
		public virtual T Visit(Compiler.Translation.SymbolTable.Data.SymbolTable node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Declarations node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Declaration node)
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

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Array node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.ReturnType node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Parameters node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.ParametersP node)
		{
			return Visit((Compiler.Translation.SymbolTable.Data.Node)node);
		}

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Parameter node)
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
