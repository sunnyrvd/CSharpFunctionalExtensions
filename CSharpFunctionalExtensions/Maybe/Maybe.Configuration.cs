namespace Metaphor.Csharp.Extensions
{
	public readonly partial struct Maybe<T>
	{
		private static class Configuration
		{
			public static string NoValueException = "Maybe has no value.";			
		}
	}
}
