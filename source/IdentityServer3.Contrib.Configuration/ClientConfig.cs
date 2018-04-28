using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ClientConfig : IClientConfig
	{
		#region Fields
		private IOpenIdConnectAuthenticationOptions _openIdConnectAuthenticationOptions;
		private ICookieAuthenticationOptions _cookieAuthenticationOptions;
		private IIdentityServerBearerTokenAuthenticationOptions _identityServerBearerTokenAuthenticationOptions;
		private IClientCredentialOptions _clientCredentialOptions;

		private XPathNavigator _nav;
		private IClientConfig _template = null;
		#endregion

		#region Constructors
		public ClientConfig(XPathNavigator nav, IClientConfig template)
		{
			SetKnownDefaults();

			_template = template;

            IdTokenHint = nav.GetString(nameof(IdTokenHint), _template);
            Tenant = nav.GetEnum<eTenant>(nameof(Tenant), _template);
            UniqueClaimTypeIdentifier = nav.GetString(nameof(UniqueClaimTypeIdentifier), _template);

            _nav = nav;
		}
		#endregion

		#region Properties
		public string IdTokenHint { get; private set; }

        public eTenant Tenant { get; private set; }

        public string UniqueClaimTypeIdentifier { get; private set; }

        public IOpenIdConnectAuthenticationOptions OpenIdConnectAuthenticationOptions
		{
			get
			{
				if (_openIdConnectAuthenticationOptions == null)
					_openIdConnectAuthenticationOptions = new OpenIdConnectAuthenticationOptions(_nav.Select(nameof(OpenIdConnectAuthenticationOptions).ToLowerFirstLetter()), _template != null ? _template.OpenIdConnectAuthenticationOptions : null);

				return _openIdConnectAuthenticationOptions;
			}
		}

		public ICookieAuthenticationOptions CookieAuthenticationOptions
		{
			get
			{
				if (_cookieAuthenticationOptions == null)
					_cookieAuthenticationOptions = new CookieAuthenticationOptions(_nav.Select(nameof(CookieAuthenticationOptions).ToLowerFirstLetter()), _template != null ? _template.CookieAuthenticationOptions : null);

				return _cookieAuthenticationOptions;
			}
		}

		public IIdentityServerBearerTokenAuthenticationOptions IdentityServerBearerTokenAuthenticationOptions
		{
			get
			{
				if (_identityServerBearerTokenAuthenticationOptions == null)
					_identityServerBearerTokenAuthenticationOptions = new IdentityServerBearerTokenAuthenticationOptions(_nav.Select(nameof(IdentityServerBearerTokenAuthenticationOptions).ToLowerFirstLetter()), _template != null ? _template.IdentityServerBearerTokenAuthenticationOptions : null);

				return _identityServerBearerTokenAuthenticationOptions;
			}
		}

		public IClientCredentialOptions ClientCredentialOptions
		{
			get
			{
				if (_clientCredentialOptions == null)
					_clientCredentialOptions = new ClientCredentialOptions(_nav.Select(nameof(ClientCredentialOptions).ToLowerFirstLetter()), _template != null ? _template.ClientCredentialOptions : null);

				return _clientCredentialOptions;
			}
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class CookieAuthenticationOptions : ICookieAuthenticationOptions
	{
		#region Fields
		private IDescription _description;
		private XPathNavigator _nav;
		private ICookieAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public CookieAuthenticationOptions(XPathNodeIterator iter, ICookieAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            AuthenticationMode = _nav.GetEnum<eAuthenticationMode>(nameof(AuthenticationMode), _template);
            AuthenticationType = _nav.GetString(nameof(AuthenticationType), _template);
            CookieDomain = _nav.GetString(nameof(CookieDomain), _template);
            CookieHttpOnly = _nav.GetBool(nameof(CookieHttpOnly), _template);
            CookieName = _nav.GetString(nameof(CookieName), _template);
            CookiePath = _nav.GetString(nameof(CookiePath), _template);
            CookieSecure = _nav.GetEnum<eCookieSecureOption>(nameof(CookieSecure), _template);
            ExpireTimeSpan = _nav.GetTimeSpan(nameof(ExpireTimeSpan), _template);
            LoginPath = _nav.GetString(nameof(LoginPath), _template);
            LogoutPath = _nav.GetString(nameof(LogoutPath), _template);
            ReturnUrlParameter = _nav.GetString(nameof(ReturnUrlParameter), _template);
            SlidingExpiration = _nav.GetBool(nameof(SlidingExpiration), _template);
        }
		#endregion

		#region Properties
		public eAuthenticationMode AuthenticationMode { get; private set; }

        public string AuthenticationType { get; private set; }

        public string CookieDomain { get; private set; }

        public bool CookieHttpOnly { get; private set; }

        public string CookieName { get; private set; }

        public string CookiePath { get; private set; }

        public eCookieSecureOption CookieSecure { get; private set; }

        public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select(nameof(Description).ToLowerFirstLetter()), _template != null ? _template.Description : null);

				return _description;
			}
		}

		public TimeSpan ExpireTimeSpan { get; private set; }

        public string LoginPath { get; private set; }

        public string LogoutPath { get; private set; }

        public string ReturnUrlParameter { get; private set; }

        public bool SlidingExpiration { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class Description : IDescription
	{
		#region Fields
		private IProperties _properties;
		private XPathNavigator _nav;
		private IDescription _template = null;
		#endregion

		#region Constructors
		public Description(XPathNodeIterator iter, IDescription template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            AuthenticationType = _nav.GetString(nameof(AuthenticationType), _template);
            Caption = _nav.GetString(nameof(Caption), _template);
        }
		#endregion

		#region Properties
		public string AuthenticationType { get; private set; }

        public string Caption { get; private set; }

        public IProperties Properties
		{
			get
			{
				if (_properties == null)
					_properties = new Properties(_nav.Select(nameof(Properties).ToLowerFirstLetter()), _template != null ? _template.Properties : null);

				return _properties;
			}
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class Properties : List<IProperty>, IProperties
	{
		#region Constructors
		public Properties(XPathNodeIterator iter, IProperties template)
		{
			if (template != null)
				template.Each(p => Add(p));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select(nameof(Property).ToLowerFirstLetter());

			while (iter.MoveNext())
			{
				var id = Property.GetId(iter.Current);
				var template = this.SingleOrDefault(p => p.Id == id);

				if (template != null)
					Remove(template);

				var newValue = new Property(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class Property : IProperty
	{
		#region Constructors
		public Property(XPathNodeIterator iter, IProperty template)
		{
			var nav = iter.Current;

            Id = nav.GetString(nameof(Id), template);
            Value = nav.GetString(nameof(Value), template);
        }
		#endregion

		#region Properties
		public string Id { get; private set; }

        public string Value { get; private set; }
        #endregion

        #region Public Methods
        public static string GetId(XPathNavigator nav)
		{
            return nav.GetString(nameof(Id));
        }
		#endregion
	}

	public class OpenIdConnectAuthenticationOptions : IOpenIdConnectAuthenticationOptions
	{
		#region Fields
		private IConfiguration _configuration;
		private IDescription _description;
		private IProtocolValidator _protocolValidator;

		private XPathNavigator _nav;
		private IOpenIdConnectAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public OpenIdConnectAuthenticationOptions(XPathNodeIterator iter, IOpenIdConnectAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            AuthenticationMode = _nav.GetEnum<eAuthenticationMode>(nameof(AuthenticationMode), _template);
            AuthenticationType = _nav.GetString(nameof(AuthenticationType), _template);
            Authority = _nav.GetString(nameof(Authority), _template);
            BackChannelHttpHandler = _nav.GetTimeSpan(nameof(BackChannelHttpHandler), _template);
            CallBackPath = _nav.GetString(nameof(CallBackPath), _template);
            Caption = _nav.GetString(nameof(Caption), _template);
            ClientId = _nav.GetString(nameof(ClientId), _template);
            ClientSecret = _nav.GetString(nameof(ClientSecret), _template);
            MetaDataAddress = _nav.GetString(nameof(MetaDataAddress), _template);
            PostLogoutRedirectUri = _nav.GetString(nameof(PostLogoutRedirectUri), _template);
            RedirectUri = _nav.GetString(nameof(RedirectUri), _template);
            Resource = _nav.GetString(nameof(Resource), _template);
            ResponseType = _nav.GetString(nameof(ResponseType), _template);
            RefreshOnIssuerKeyNotFound = _nav.GetBool(nameof(RefreshOnIssuerKeyNotFound), _template);
            SignInAsAuthenticationType = _nav.GetString(nameof(SignInAsAuthenticationType), _template);
            Scope = _nav.GetString(nameof(Scope), _template);
            UseTokenLifeTime = _nav.GetBool(nameof(UseTokenLifeTime), _template);
        }
		#endregion

		#region Properties
		public eAuthenticationMode AuthenticationMode { get; private set; }

        public string AuthenticationType { get; private set; }

        public string Authority { get; private set; }

        public TimeSpan BackChannelHttpHandler { get; private set; }

        public string CallBackPath { get; private set; }

        public string Caption { get; private set; }

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public IConfiguration Configuration
		{
			get
			{
				if (_configuration == null)
					_configuration = new Configuration(_nav.Select(nameof(Configuration).ToLowerFirstLetter()), _template != null ? _template.Configuration : null);

				return _configuration;
			}
		}

		public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select(nameof(Description).ToLowerFirstLetter()), _template != null ? _template.Description : null);

				return _description;
			}
		}

		public string MetaDataAddress { get; private set; }

        public string PostLogoutRedirectUri { get; private set; }

        public IProtocolValidator ProtocolValidator
		{
			get
			{
				if (_protocolValidator == null)
					_protocolValidator = new ProtocolValidator(_nav.Select(nameof(ProtocolValidator).ToLowerFirstLetter()), _template != null ? _template.ProtocolValidator : null);

				return _protocolValidator;
			}
		}

		public string RedirectUri { get; private set; }

        public string Resource { get; private set; }

        public string ResponseType { get; private set; }

        public bool RefreshOnIssuerKeyNotFound { get; private set; }

        public string SignInAsAuthenticationType { get; private set; }

        public string Scope { get; private set; }

        public bool UseTokenLifeTime { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class Configuration : IConfiguration
	{
		#region Fields
		private IJsonWebKeys _jsonWebKeys;
		private XPathNavigator _nav;
		private IConfiguration _template = null;
		#endregion

		#region Constructors
		public Configuration(XPathNodeIterator iter, IConfiguration template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            AuthorizationEndpoint = _nav.GetString(nameof(AuthorizationEndpoint), _template);
            CheckSessionIframe = _nav.GetString(nameof(CheckSessionIframe), _template);
            EndSessionEndpoint = _nav.GetString(nameof(EndSessionEndpoint), _template);
            Issuer = _nav.GetString(nameof(Issuer), _template);
            JwksUri = _nav.GetString(nameof(JwksUri), _template);
            TokenEndpoint = _nav.GetString(nameof(TokenEndpoint), _template);
            UserInfoEndpoint = _nav.GetString(nameof(UserInfoEndpoint), _template);
        }
		#endregion

		#region Properties
		public string AuthorizationEndpoint { get; private set; }

        public string CheckSessionIframe { get; private set; }

        public string EndSessionEndpoint { get; private set; }

        public string Issuer { get; private set; }

        public IJsonWebKeys JsonWebKeys
		{
			get
			{
				if (_jsonWebKeys == null)
					_jsonWebKeys = new JsonWebKeys(_nav.Select(nameof(JsonWebKeys).ToLowerFirstLetter()), _template != null ? _template.JsonWebKeys : null);

				return _jsonWebKeys;
			}
		}

		public string JwksUri { get; private set; }

        public string TokenEndpoint { get; private set; }

        public string UserInfoEndpoint { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class JsonWebKeys : List<IJsonWebKey>, IJsonWebKeys
	{
		#region Constructors
		public JsonWebKeys(XPathNodeIterator iter, IJsonWebKeys template)
		{
			if (template != null)
				template.Each(p => Add(p));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select(nameof(JsonWebKey).ToLowerFirstLetter());

			while (iter.MoveNext())
			{
				var id = Property.GetId(iter.Current);
				var template = this.SingleOrDefault(p => p.Id == id);

				if (template != null)
					Remove(template);

				var newValue = new JsonWebKey(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class JsonWebKey : IJsonWebKey
	{
		#region Constructors
		public JsonWebKey(XPathNodeIterator iter, IJsonWebKey template)
		{
			var nav = iter.Current;

			nav.GetString(nameof(Id), template);
            nav.GetString(nameof(Value), template);
        }
		#endregion

		#region Properties
		public string Id { get; private set; }

        public string Value { get; private set; }
        #endregion

        #region Public Methods
        public static string GetId(XPathNavigator nav)
		{
            return nav.GetString(nameof(Id));
		}
		#endregion
	}

	public class ProtocolValidator : IProtocolValidator
	{
		#region Fields
		private XPathNavigator _nav;
		private IProtocolValidator _template = null;
		#endregion

		#region Constructors
		public ProtocolValidator(XPathNodeIterator iter, IProtocolValidator template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            NonceLifetime = _nav.GetTimeSpan(nameof(NonceLifetime), _template);
            RequireAcr = _nav.GetBool(nameof(RequireAcr), _template);
            RequireAmr = _nav.GetBool(nameof(RequireAmr), _template);
            RequireAuthTime = _nav.GetBool(nameof(RequireAuthTime), _template);
            RequireAzp = _nav.GetBool(nameof(RequireAzp), _template);
            RequireNonce = _nav.GetBool(nameof(RequireNonce), _template);
            RequireSub = _nav.GetBool(nameof(RequireSub), _template);
            RequireTimeStampInNonce = _nav.GetBool(nameof(RequireTimeStampInNonce), _template);
        }
		#endregion

		#region Properties
		public TimeSpan NonceLifetime { get; private set; }

        public bool RequireAcr { get; private set; }

        public bool RequireAmr { get; private set; }

        public bool RequireAuthTime { get; private set; }

        public bool RequireAzp { get; private set; }

        public bool RequireNonce { get; private set; }

        public bool RequireSub { get; private set; }

        public bool RequireTimeStampInNonce { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}

	public class IdentityServerBearerTokenAuthenticationOptions : IIdentityServerBearerTokenAuthenticationOptions
	{
		#region Fields
		private IDescription _description;
		private XPathNavigator _nav;
		private IIdentityServerBearerTokenAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public IdentityServerBearerTokenAuthenticationOptions(XPathNodeIterator iter, IIdentityServerBearerTokenAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            AuthenticationMode = _nav.GetEnumNullable<eAuthenticationMode>(nameof(AuthenticationMode), _template);
            AuthenticationType = _nav.GetString(nameof(AuthenticationType), _template);
            Authority = _nav.GetString(nameof(Authority), _template);
            ClientId = _nav.GetString(nameof(ClientId), _template);
            ClientSecret = _nav.GetString(nameof(ClientSecret), _template);
            DelayLoadMetadata = _nav.GetBoolNullable(nameof(DelayLoadMetadata), _template);
            EnableValidationResultCache = _nav.GetBoolNullable(nameof(EnableValidationResultCache), _template);
            IssuerName = _nav.GetString(nameof(IssuerName), _template);
            NameClaimType = _nav.GetString(nameof(NameClaimType), _template);
            PreserveAccessToken = _nav.GetBoolNullable(nameof(PreserveAccessToken), _template);
            RequiredScopes = _nav.GetListString(nameof(RequiredScopes), _template);
            RoleClaimType = _nav.GetString(nameof(RoleClaimType), _template);
            ValidationMode = _nav.GetEnumNullable<eValidationMode>(nameof(ValidationMode), _template);
            ValidationResultCacheDuration = _nav.GetTimeSpanNullable(nameof(ValidationResultCacheDuration), _template);
        }
		#endregion

		#region Properties
		public eAuthenticationMode? AuthenticationMode { get; private set; }

        public string AuthenticationType { get; private set; }

        public string Authority { get; private set; }

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public bool? DelayLoadMetadata { get; private set; }

        public bool? EnableValidationResultCache { get; private set; }

        public string IssuerName { get; private set; }

        public string NameClaimType { get; private set; }

        public bool? PreserveAccessToken { get; private set; }

        public List<string> RequiredScopes { get; private set; }

        public string RoleClaimType { get; private set; }

        public eValidationMode? ValidationMode { get; private set; }

        public TimeSpan? ValidationResultCacheDuration { get; private set; }

        public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select(nameof(Description).ToLowerFirstLetter()), _template != null ? _template.Description : null);

				return _description;
			}
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			AuthenticationMode = eAuthenticationMode.Active;
			AuthenticationType = "Bearer";
			DelayLoadMetadata = false;
			EnableValidationResultCache = false;
			NameClaimType = "name";
			PreserveAccessToken = false;
			RoleClaimType = "role";
			ValidationMode = eValidationMode.Both;
			ValidationResultCacheDuration = new TimeSpan(0, 5, 0);
		}
		#endregion
	}

	public class ClientCredentialOptions : IClientCredentialOptions
	{
		#region Fields
		private string _clientId;
		private string _secret;
		private string _scope;

		private XPathNavigator _nav;
		private IClientCredentialOptions _template = null;
		#endregion

		#region Constructors
		public ClientCredentialOptions(XPathNodeIterator iter, IClientCredentialOptions template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_clientId = _template.ClientId;
				_secret = _template.Secret;
				_scope = _template.Scope;
			}

			iter.MoveNext();
			_nav = iter.Current;

            ClientId = _nav.GetString(nameof(ClientId), _template);
            Secret = _nav.GetString(nameof(Secret), _template);
            Scope = _nav.GetString(nameof(Scope), _template);
        }
		#endregion

		#region Properties
		public string ClientId { get; private set; }

        public string Secret { get; private set; }

        public string Scope { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;
		}
		#endregion
	}
}
