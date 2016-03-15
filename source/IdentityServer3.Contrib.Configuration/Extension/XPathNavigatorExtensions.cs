using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace IdentityServer3.Contrib.Configuration
{
	public static class XPathNavigatorExtensions
	{
		#region Public Methods
		public static void SetString(this XPathNavigator nav, string key, ref string valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = value;
		}

		public static void SetBool(this XPathNavigator nav, string key, ref bool valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = bool.Parse(value);
		}

		public static void SetBoolNullable(this XPathNavigator nav, string key, ref bool? valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = bool.Parse(value);
		}

		public static void SetInt(this XPathNavigator nav, string key, ref int valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = int.Parse(value);
		}

		public static void SetIntNullable(this XPathNavigator nav, string key, ref int? valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = int.Parse(value);
		}

		public static void SetEnum<T>(this XPathNavigator nav, string key, ref T valueToSet) where T : struct
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = (T)Enum.Parse(typeof(T), value, true);
		}

		public static void SetEnumNullable<T>(this XPathNavigator nav, string key, ref T? valueToSet) where T : struct
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = (T)Enum.Parse(typeof(T), value, true);
		}

		public static void SetFlags<T>(this XPathNavigator nav, string key, ref T valueToSet) where T : struct
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
			{
				var flags = default(int);
				var flagStrings = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

				flagStrings.Each(f => flags = (int)(object)flags | (int)(object)(T)Enum.Parse(typeof(T), f, true));
				valueToSet = !flags.Equals(default(int)) ? (T)(object)flags : default(T);
			}
		}

		public static void SetFlagsNullable<T>(this XPathNavigator nav, string key, ref T? valueToSet) where T : struct
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
			{
				var flags = default(int);
				var flagStrings = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

				flagStrings.Each(f => flags = (int)(object)flags | (int)(object)(T)Enum.Parse(typeof(T), f, true));
				valueToSet = !flags.Equals(default(int)) ? (T)(object)flags : new T?();
			}
		}

		public static void SetTimeSpan(this XPathNavigator nav, string key, ref TimeSpan valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = TimeSpan.Parse(value);
		}

		public static void SetTimeSpanNullable(this XPathNavigator nav, string key, ref TimeSpan? valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = TimeSpan.Parse(value);
		}

		public static void SetListString(this XPathNavigator nav, string key, ref List<string> valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = new List<string>(value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
		}

		public static void SetListEnum<T>(this XPathNavigator nav, string key, ref List<T> valueToSet) where T : struct
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
			{
				var enumStrings = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				valueToSet = enumStrings.Select(es => (T)Enum.Parse(typeof(T), es, true)).ToList();
			}
		}

		public static void SetHashSet(this XPathNavigator nav, string key, ref HashSet<string> valueToSet, bool isDefaultEmpty = false)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (isDefaultEmpty)
				valueToSet = new HashSet<string>();

			if (value.HasValue())
				valueToSet = new HashSet<string>(value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
		}

		public static void SetDateTimeOffset(this XPathNavigator nav, string key, ref DateTimeOffset valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = DateTimeOffset.Parse(value);
		}

		public static void SetDateTimeOffsetNullable(this XPathNavigator nav, string key, ref DateTimeOffset? valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = DateTimeOffset.Parse(value);
		}

		public static void SetVersion(this XPathNavigator nav, string key, ref Version valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = new Version(value);
		}

		public static void SetUri(this XPathNavigator nav, string key, ref Uri valueToSet)
		{
			var value = nav.GetAttribute(key, string.Empty);

			if (value.HasValue())
				valueToSet = new Uri(value);
		}
		#endregion
	}
}
