namespace Compiler.Parsing
{
	public class UnexpectedTokenException : System.Exception
	{
		public Compiler.Parsing.Data.Token Token { get; set; }
		public  UnexpectedTokenException(Compiler.Parsing.Data.Token token)
		{
			Token = token;
		}
	}
}
