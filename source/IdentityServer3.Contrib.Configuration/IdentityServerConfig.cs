using System.Xml.XPath;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerConfig : IIdentityServerConfig
	{
		#region Fields
		private IClientConfig _client;
		private IServerConfig _server;

		private XPathNavigator _nav;
		private IIdentityServerConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerConfig(XPathNavigator nav, IIdentityServerConfig template)
		{
			_template = template;
			_nav = nav;

			SetIsLoadKnownDefaults(_nav);
		}
		#endregion

		#region Properties
		internal static bool IsLoadKnownDefaults { get; private set; }

		public IClientConfig Client
		{
			get
			{
				if (_client == null)
					_client = new ClientConfig(GetChild(_nav, nameof(Client).ToLowerFirstLetter()), _template != null ? _template.Client : null);

				return _client;
			}
		}

		public IServerConfig Server
		{
			get
			{
				if (_server == null)
					_server = new ServerConfig(GetChild(_nav, nameof(Server).ToLowerFirstLetter()), _template != null ? _template.Server : null);

				return _server;
			}
		}
		#endregion

		#region Protected Methods
		protected XPathNavigator GetChild(XPathNavigator nav, string nodeName)
		{
			var iter = nav.Select(nodeName);

			if (iter.MoveNext())
				return iter.Current;

			return nav;
		}
		#endregion

		#region Private Methods
		private void SetIsLoadKnownDefaults(XPathNavigator nav)
		{
			var value = nav.GetAttribute(nameof(IsLoadKnownDefaults).ToLowerFirstLetter(), string.Empty);

			if (value.HasValue())
				IsLoadKnownDefaults = bool.Parse(value);
		}
		#endregion
	}
}
