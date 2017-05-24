namespace Generator.Translation.Parsing
{
	public class UnexpectedTokenException : System.Exception
	{
		public Generator.Translation.Data.Token Token { get; set; }
		public  UnexpectedTokenException(Generator.Translation.Data.Token token)
		{
			Token = token;
		}
	}
}
