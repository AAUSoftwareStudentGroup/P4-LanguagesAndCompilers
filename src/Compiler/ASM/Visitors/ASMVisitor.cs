namespace Compiler.ASM.Visitors
{
	public abstract class ASMVisitor<T> 
	{
		public virtual T Visit(Compiler.ASM.Data.ASM node)
		{
			return Visit((Compiler.ASM.Data.Node)node);
		}

		public virtual T Visit(Compiler.ASM.Data.RegTable node)
		{
			return Visit((Compiler.ASM.Data.Node)node);
		}

		public virtual T Visit(Compiler.ASM.Data.Token node)
		{
			return Visit((Compiler.ASM.Data.Node)node);
		}
		public abstract T Visit(Compiler.ASM.Data.Node node);
	}
}
