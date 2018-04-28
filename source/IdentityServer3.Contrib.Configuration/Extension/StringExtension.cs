namespace IdentityServer3.Contrib.Configuration.Extension
{
	public static class StringExtension
	{
        #region Public Methods
        public static bool HasValue(this string value)
        {
            return value != null && value.Length > 0;
        }

        public static string ToUpperFirstLetter(this string value)
        {
            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        public static string ToLowerFirstLetter(this string value)
        {
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
        #endregion
    }
}
