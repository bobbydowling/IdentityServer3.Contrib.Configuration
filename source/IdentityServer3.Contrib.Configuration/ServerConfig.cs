using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ServerConfig : IServerConfig
	{
		#region Fields
		private string _basePath;
		private string _path;
		private string _adminPath;
		private string _domain;

		private IIdentityServerClientsConfig _clients;
		private IIdentityServerUsersConfig _users;
		private IIdentityServerScopesConfig _scopes;
		private IIdentityServerOptionsConfig _options;

		private XPathNavigator _nav;
		private IServerConfig _template = null;
		#endregion

		#region Constructors
		public ServerConfig(XPathNavigator nav, IServerConfig template)
		{
			_template = template;

			if (_template != null)
			{
				_basePath = _template.BasePath;
				_path = _template.Path;
				_adminPath = _template.AdminPath;
				_domain = _template.Domain;
			}

			nav.SetString("basePath", ref _basePath);
			nav.SetString("path", ref _path);
			nav.SetString("adminPath", ref _adminPath);
			nav.SetString("domain", ref _domain);

			_nav = nav;
		}
		#endregion

		#region Properties
		public string BasePath
		{
			get { return _basePath; }
		}

		public string Path
		{
			get { return _path; }
		}

		public string AdminPath
		{
			get { return _adminPath; }
		}

		public string Domain
		{
			get { return _domain; }
		}

		public IIdentityServerClientsConfig Clients
		{
			get
			{
				if (_clients == null)
					_clients = new IdentityServerClients(_nav.Select("clients"), _template != null ? _template.Clients : null);

				return _clients;
			}
		}

		public IIdentityServerUsersConfig Users
		{
			get
			{
				if (_users == null)
					_users = new IdentityServerUsers(_nav.Select("users"), _template != null ? _template.Users : null);

				return _users;
			}
		}

		public IIdentityServerScopesConfig Scopes
		{
			get
			{
				if (_scopes == null)
					_scopes = new IdentityServerScopes(_nav.Select("scopes"), _template != null ? _template.Scopes : null);

				return _scopes;
			}
		}

		public IIdentityServerOptionsConfig Options
		{
			get
			{
				if (_options == null)
					_options = new IdentityServerOptionsConfig(_nav.Select("options"), _template != null ? _template.Options : null);

				return _options;
			}
		}
		#endregion
	}

	public class IdentityServerClients : List<IIdentityServerClientConfig>, IIdentityServerClientsConfig
	{
		#region Fields
		private bool _isUseInMemoryStore;

		private XPathNavigator _nav;
		private IIdentityServerClientsConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerClients(XPathNodeIterator iter, IIdentityServerClientsConfig template)
		{
			_template = template;

			if (_template != null)
			{
				_isUseInMemoryStore = _template.IsUseInMemoryStore;
				_template.Each(c => Add(c));
			}

			if (iter.MoveNext())
			{
				_nav = iter.Current;

				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				Initialize(iter);
			}
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("client");

			while (iter.MoveNext())
			{
				var clientId = IdentityServerClientConfig.GetClientId(iter.Current);
				var template = this.SingleOrDefault(c => c.ClientId == clientId);

				if (template != null)
					Remove(template);

				var value = new IdentityServerClientConfig(iter.Clone(), template);
				Add(value);
			}
		}
		#endregion
	}

	public class IdentityServerScopes : List<IIdentityServerScopeConfig>, IIdentityServerScopesConfig
	{
		#region Fields
		private bool _isUseInMemoryStore;

		private XPathNavigator _nav;
		private IIdentityServerScopesConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerScopes(XPathNodeIterator iter, IIdentityServerScopesConfig template)
		{
			_template = template;

			if (_template != null)
			{
				_isUseInMemoryStore = _template.IsUseInMemoryStore;
				_template.Each(c => Add(c));
			}

			if (iter.MoveNext())
			{
				_nav = iter.Current;

				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				Initialize(iter);
			}
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("scope");

			while (iter.MoveNext())
			{
				var name = IdentityServerScopeConfig.GetName(iter.Current);
				var template = this.SingleOrDefault(c => c.Name == name);

				if (template != null)
					Remove(template);

				var value = new IdentityServerScopeConfig(iter.Clone(), template);
				Add(value);
			}
		}
		#endregion
	}

	public class IdentityServerUsers : List<IIdentityServerUserConfig>, IIdentityServerUsersConfig
	{
		#region Fields
		private bool _isUseInMemoryStore;
		private bool _isIncludeDomainRoles;
		private string _connectionKey;

		private XPathNavigator _nav;
		private IIdentityServerUsersConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerUsers(XPathNodeIterator iter, IIdentityServerUsersConfig template)
		{
			_template = template;

			if (_template != null)
			{
				_isUseInMemoryStore = _template.IsUseInMemoryStore;
				_isIncludeDomainRoles = _template.IsIncludeDomainRoles;
				_connectionKey = _template.ConnectionKey;

				_template.Each(c => Add(c));
			}

			if (iter.MoveNext())
			{
				_nav = iter.Current;

				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				_nav.SetBool("isIncludeDomainRoles", ref _isIncludeDomainRoles);
				_nav.SetString("connectionKey", ref _connectionKey);

				Initialize(iter);
			}
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}

		public bool IsIncludeDomainRoles
		{
			get { return _isIncludeDomainRoles; }
		}

		public string ConnectionKey
		{
			get { return _connectionKey; }
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("user");

			while (iter.MoveNext())
			{
				var name = IdentityServerUserConfig.GetName(iter.Current);
				var template = this.SingleOrDefault(c => c.Name == name);

				if (template != null)
					Remove(template);

				var value = new IdentityServerUserConfig(iter.Clone(), template);
				Add(value);
			}
		}
		#endregion
	}
}
