namespace Compiler.Translation.SymbolTable.Visitors
{
	public abstract class SymbolTableVisitor<T> 
	{
		public virtual T Visit(Compiler.Translation.SymbolTable.Data.SymbolTable node)
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

		public virtual T Visit(Compiler.Translation.SymbolTable.Data.Type node)
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
