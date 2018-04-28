using System;
using System.Collections.Generic;

namespace IdentityServer3.Contrib.Configuration.Extension
{
	public static class EnumerableExtensions
	{
		#region Public Methods
		public static void Each<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (var i in items)
				action(i);
		}
		#endregion
	}
}
