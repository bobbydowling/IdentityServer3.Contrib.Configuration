using System.IO;
using System.Xml;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class CompanySecurityConfigData : ICompanySecurityConfiguration
	{
		#region Fields
		private XPathDocument _configDoc = null;
		private CompanySecurityConfigData _template = null;

		private IApplicationConfig _application = null;
		private IAspNetIdentityConfig _aspNetIdentity = null;
		private IIdentityManagerConfig _identityManager = null;
		private IIdentityServerConfig _identityServer = null;
		#endregion

		#region Constructors
		public CompanySecurityConfigData(XmlNode section, string configPath)
		{
			XmlNodeReader xnr = new XmlNodeReader(section);

			_configDoc = new XPathDocument(xnr);
			_template = new CompanySecurityConfigData(configPath);

			xnr.Close();
		}

		public CompanySecurityConfigData(string configPath)
		{
			XmlDocument doc = new XmlDocument();
			XPathNavigator nav;

			if (File.Exists(configPath))
			{
				doc.Load(configPath);
				nav = doc.DocumentElement.CreateNavigator();
			}
			else
			{
				doc.AppendChild(doc.CreateElement("dummy"));

				XmlNodeReader xnr = new XmlNodeReader(doc.DocumentElement);

				_configDoc = new XPathDocument(xnr);

				xnr.Close();
				nav = _configDoc.CreateNavigator();
			}

			GetConfig(nav);
		}
		#endregion

		#region Protected Methods
		protected virtual void GetConfig(XPathNavigator nav)
		{
			_application = new ApplicationConfig(GetChild(nav, nameof(Application).ToLowerFirstLetter()), null);
			_aspNetIdentity = new AspNetIdentityConfig(GetChild(nav, nameof(AspNetIdentity).ToLowerFirstLetter()), null);
			_identityManager = new IdentityManagerConfig(GetChild(nav, nameof(IdentityManager).ToLowerFirstLetter()), null);
			_identityServer = new IdentityServerConfig(GetChild(nav, nameof(IdentityServer).ToLowerFirstLetter()), null);
		}

		protected XPathNavigator GetChild(string nodeName)
		{
			return GetChild(_configDoc.CreateNavigator(), nodeName);
		}

		protected XPathNavigator GetChild(XPathNavigator nav, string nodeName)
		{
			var iter = nav.Select("/*/" + nodeName);

			if (iter.MoveNext())
				return iter.Current;

			return nav;
		}
		#endregion

		#region Public Properties
		public IApplicationConfig Application
		{
			get
			{
				if (_application == null)
					_application = new ApplicationConfig(GetChild(nameof(Application).ToLowerFirstLetter()), _template != null ? _template.Application : null);

				return _application;
			}
		}

		public IAspNetIdentityConfig AspNetIdentity
		{
			get
			{
				if (_aspNetIdentity == null)
					_aspNetIdentity = new AspNetIdentityConfig(GetChild(nameof(AspNetIdentity).ToLowerFirstLetter()), _template != null ? _template.AspNetIdentity : null);

				return _aspNetIdentity;
			}
		}

		public IIdentityManagerConfig IdentityManager
		{
			get
			{
				if (_identityManager == null)
					_identityManager = new IdentityManagerConfig(GetChild(nameof(IdentityManager).ToLowerFirstLetter()), _template != null ? _template.IdentityManager : null);

				return _identityManager;
			}
		}

		public IIdentityServerConfig IdentityServer
		{
			get
			{
				if (_identityServer == null)
					_identityServer = new IdentityServerConfig(GetChild(nameof(IdentityServer).ToLowerFirstLetter()), _template != null ? _template.IdentityServer : null);

				return _identityServer;
			}
		}
		#endregion
	}
}
