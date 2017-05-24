namespace Generator.Translation.Visitors
{
	public class CloneVisitor : TranslatorVisitor<Generator.Translation.Data.Node>
	{
		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Translator node)
		{
			var clone = new Generator.Translation.Data.Translator() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Systems node)
		{
			var clone = new Generator.Translation.Data.Systems() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.System node)
		{
			var clone = new Generator.Translation.Data.System() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Domain node)
		{
			var clone = new Generator.Translation.Data.Domain() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.ListDomain node)
		{
			var clone = new Generator.Translation.Data.ListDomain() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Domains node)
		{
			var clone = new Generator.Translation.Data.Domains() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.TreeDomain node)
		{
			var clone = new Generator.Translation.Data.TreeDomain() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Symbol node)
		{
			var clone = new Generator.Translation.Data.Symbol() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Rules node)
		{
			var clone = new Generator.Translation.Data.Rules() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.RulesP node)
		{
			var clone = new Generator.Translation.Data.RulesP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Rule node)
		{
			var clone = new Generator.Translation.Data.Rule() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Conclusion node)
		{
			var clone = new Generator.Translation.Data.Conclusion() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.NewlineGoto node)
		{
			var clone = new Generator.Translation.Data.NewlineGoto() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Premises node)
		{
			var clone = new Generator.Translation.Data.Premises() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.PremisesP node)
		{
			var clone = new Generator.Translation.Data.PremisesP() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Premis node)
		{
			var clone = new Generator.Translation.Data.Premis() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.StructureOperation node)
		{
			var clone = new Generator.Translation.Data.StructureOperation() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Goto node)
		{
			var clone = new Generator.Translation.Data.Goto() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Equal node)
		{
			var clone = new Generator.Translation.Data.Equal() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.NotEqual node)
		{
			var clone = new Generator.Translation.Data.NotEqual() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Pattern node)
		{
			var clone = new Generator.Translation.Data.Pattern() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.ListPattern node)
		{
			var clone = new Generator.Translation.Data.ListPattern() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.TreePattern node)
		{
			var clone = new Generator.Translation.Data.TreePattern() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Name node)
		{
			var clone = new Generator.Translation.Data.Name() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Alias node)
		{
			var clone = new Generator.Translation.Data.Alias() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.ChildrenPattern node)
		{
			var clone = new Generator.Translation.Data.ChildrenPattern() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Patterns node)
		{
			var clone = new Generator.Translation.Data.Patterns() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Structure node)
		{
			var clone = new Generator.Translation.Data.Structure() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.ListStructure node)
		{
			var clone = new Generator.Translation.Data.ListStructure() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.TreeStructure node)
		{
			var clone = new Generator.Translation.Data.TreeStructure() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Placeholder node)
		{
			var clone = new Generator.Translation.Data.Placeholder() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Insertion node)
		{
			var clone = new Generator.Translation.Data.Insertion() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.ChildrenStructure node)
		{
			var clone = new Generator.Translation.Data.ChildrenStructure() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Structures node)
		{
			var clone = new Generator.Translation.Data.Structures() { Name = node.Name, IsPlaceholder = node.IsPlaceholder };
			foreach(var child in node)
			{
			    clone.Add(child.Accept(this));
			}
			return clone;
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Token node)
		{
			return new Generator.Translation.Data.Token() { Name = node.Name, Value = node.Value, FileName = node.FileName, Row = node.Row, Column = node.Column, IsPlaceholder = node.IsPlaceholder };
		}

		public override Generator.Translation.Data.Node Visit(Generator.Translation.Data.Node node)
		{
			return null;
		}
	}
}
