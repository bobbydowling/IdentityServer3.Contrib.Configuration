using System.Xml.XPath;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerUserConfig : IIdentityServerUserConfig
	{
		#region Fields
		private XPathNavigator _nav;
		private IIdentityServerUserConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerUserConfig(XPathNodeIterator iter, IIdentityServerUserConfig template)
		{
			_template = template;
			_nav = iter.Current;

			if (template != null) { }
		}
		#endregion

		#region Properties
		public string Name { get; }
		#endregion

		#region Public Methods
		public static string GetName(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("name", ref returnValue);
			return returnValue;
		}
		#endregion
	}
}
