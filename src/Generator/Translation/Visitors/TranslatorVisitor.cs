namespace Generator.Translation.Visitors
{
	public abstract class TranslatorVisitor<T> 
	{
		public virtual T Visit(Generator.Translation.Data.Translator node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Systems node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.System node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Domain node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.ListDomain node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Domains node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.TreeDomain node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Symbol node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Rules node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.RulesP node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Rule node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Conclusion node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.NewlineGoto node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Premises node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.PremisesP node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Premis node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.StructureOperation node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Goto node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Equal node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.NotEqual node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Pattern node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.ListPattern node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.TreePattern node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Name node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Alias node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.ChildrenPattern node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Patterns node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Structure node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.ListStructure node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.TreeStructure node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Placeholder node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Insertion node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.ChildrenStructure node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Structures node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}

		public virtual T Visit(Generator.Translation.Data.Token node)
		{
			return Visit((Generator.Translation.Data.Node)node);
		}
		public abstract T Visit(Generator.Translation.Data.Node node);
	}
}
