using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ServerConfig : IServerConfig
	{
		#region Fields
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

            BasePath = nav.GetString(nameof(BasePath), _template);
            Path = nav.GetString(nameof(Path), _template);
            AdminPath = nav.GetString(nameof(AdminPath), _template);
            Domain = nav.GetString(nameof(Domain), _template);

            _nav = nav;
		}
		#endregion

		#region Properties
		public string BasePath { get; private set; }

		public string Path { get; private set; }

        public string AdminPath { get; private set; }

        public string Domain { get; private set; }

        public IIdentityServerClientsConfig Clients
		{
			get
			{
				if (_clients == null)
					_clients = new IdentityServerClients(_nav.Select(nameof(Clients).ToLowerFirstLetter()), _template != null ? _template.Clients : null);

				return _clients;
			}
		}

		public IIdentityServerUsersConfig Users
		{
			get
			{
				if (_users == null)
					_users = new IdentityServerUsers(_nav.Select(nameof(Users).ToLowerFirstLetter()), _template != null ? _template.Users : null);

				return _users;
			}
		}

		public IIdentityServerScopesConfig Scopes
		{
			get
			{
				if (_scopes == null)
					_scopes = new IdentityServerScopes(_nav.Select(nameof(Scopes).ToLowerFirstLetter()), _template != null ? _template.Scopes : null);

				return _scopes;
			}
		}

		public IIdentityServerOptionsConfig Options
		{
			get
			{
				if (_options == null)
					_options = new IdentityServerOptionsConfig(_nav.Select(nameof(Options).ToLowerFirstLetter()), _template != null ? _template.Options : null);

				return _options;
			}
		}
		#endregion
	}

	public class IdentityServerClients : List<IIdentityServerClientConfig>, IIdentityServerClientsConfig
	{
		#region Fields
		private XPathNavigator _nav;
		private IIdentityServerClientsConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerClients(XPathNodeIterator iter, IIdentityServerClientsConfig template)
		{
			_template = template;

			if (_template != null)
                _template.Each(c => Add(c));

            iter.MoveNext();
            _nav = iter.Current;

            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);

            Initialize(iter);
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore { get; private set; }
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
		private XPathNavigator _nav;
		private IIdentityServerScopesConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerScopes(XPathNodeIterator iter, IIdentityServerScopesConfig template)
		{
			_template = template;

			if (_template != null)
			    _template.Each(c => Add(c));

            iter.MoveNext();
            _nav = iter.Current;

            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);
            Initialize(iter);
        }
		#endregion

		#region Properties
		public bool IsUseInMemoryStore { get; private set; }
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
		private XPathNavigator _nav;
		private IIdentityServerUsersConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerUsers(XPathNodeIterator iter, IIdentityServerUsersConfig template)
		{
			_template = template;

			if (_template != null)
				_template.Each(c => Add(c));

            iter.MoveNext();
            _nav = iter.Current;

            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);
            IsIncludeDomainRoles = _nav.GetBool(nameof(IsIncludeDomainRoles), _template);
            ConnectionKey = _nav.GetString(nameof(ConnectionKey), _template);

            Initialize(iter);
        }
		#endregion

		#region Properties
		public bool IsUseInMemoryStore { get; private set; }

		public bool IsIncludeDomainRoles { get; private set; }

        public string ConnectionKey { get; private set; }
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
