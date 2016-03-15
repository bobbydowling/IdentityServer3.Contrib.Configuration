namespace IdentityServer3.Contrib.Configuration
{
	public static class StringExtensions
	{
		#region Public Methods
		public static bool HasValue(this string value)
		{
			return value != null && value.Length > 0;
		}
		#endregion
	}
}
