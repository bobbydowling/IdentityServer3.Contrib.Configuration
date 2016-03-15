using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ClientConfig : IClientConfig
	{
		#region Fields
		private string _idTokenHint;
		private eTenant _tenant;
		private string _uniqueClaimTypeIdentifier;
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

			if (_template != null)
			{
				_idTokenHint = template.IdTokenHint;
				_tenant = template.Tenant;
				_uniqueClaimTypeIdentifier = template.UniqueClaimTypeIdentifier;
			}

			nav.SetString("idTokenHint", ref _idTokenHint);
			nav.SetEnum("tenant", ref _tenant);
			nav.SetString("uniqueClaimTypeIdentifier", ref _uniqueClaimTypeIdentifier);

			_nav = nav;
		}
		#endregion

		#region Properties
		public string IdTokenHint
		{
			get { return _idTokenHint; }
		}

		public eTenant Tenant
		{
			get { return _tenant; }
		}

		public string UniqueClaimTypeIdentifier
		{
			get { return _uniqueClaimTypeIdentifier; }
		}

		public IOpenIdConnectAuthenticationOptions OpenIdConnectAuthenticationOptions
		{
			get
			{
				if (_openIdConnectAuthenticationOptions == null)
					_openIdConnectAuthenticationOptions = new OpenIdConnectAuthenticationOptions(_nav.Select("openIdConnectAuthenticationOptions"), _template != null ? _template.OpenIdConnectAuthenticationOptions : null);

				return _openIdConnectAuthenticationOptions;
			}
		}

		public ICookieAuthenticationOptions CookieAuthenticationOptions
		{
			get
			{
				if (_cookieAuthenticationOptions == null)
					_cookieAuthenticationOptions = new CookieAuthenticationOptions(_nav.Select("cookieAuthenticationOptions"), _template != null ? _template.CookieAuthenticationOptions : null);

				return _cookieAuthenticationOptions;
			}
		}

		public IIdentityServerBearerTokenAuthenticationOptions IdentityServerBearerTokenAuthenticationOptions
		{
			get
			{
				if (_identityServerBearerTokenAuthenticationOptions == null)
					_identityServerBearerTokenAuthenticationOptions = new IdentityServerBearerTokenAuthenticationOptions(_nav.Select("identityServerBearerTokenAuthenticationOptions"), _template != null ? _template.IdentityServerBearerTokenAuthenticationOptions : null);

				return _identityServerBearerTokenAuthenticationOptions;
			}
		}

		public IClientCredentialOptions ClientCredentialOptions
		{
			get
			{
				if (_clientCredentialOptions == null)
					_clientCredentialOptions = new ClientCredentialOptions(_nav.Select("clientCredentialOptions"), _template != null ? _template.ClientCredentialOptions : null);

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
		private eAuthenticationMode _authenticationMode;
		private string _authenticationType;
		private string _cookieDomain;
		private bool _cookieHttpOnly;
		private string _cookieName;
		private string _cookiePath;
		private eCookieSecureOption _cookieSecure;
		private IDescription _description;
		private TimeSpan _expireTimeSpan;
		private string _loginPath;
		private string _logoutPath;
		private string _returnUrlParameter;
		private bool _slidingExpiration;

		private XPathNavigator _nav;
		private ICookieAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public CookieAuthenticationOptions(XPathNodeIterator iter, ICookieAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_authenticationMode = _template.AuthenticationMode;
				_authenticationType = _template.AuthenticationType;
				_cookieDomain = _template.CookieDomain;
				_cookieHttpOnly = _template.CookieHttpOnly;
				_cookieName = _template.CookieName;
				_cookiePath = _template.CookiePath;
				_cookieSecure = _template.CookieSecure;
				_expireTimeSpan = _template.ExpireTimeSpan;
				_loginPath = _template.LoginPath;
				_logoutPath = _template.LogoutPath;
				_returnUrlParameter = _template.ReturnUrlParameter;
				_slidingExpiration = _template.SlidingExpiration;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetEnum("authenticationMode", ref _authenticationMode);
				_nav.SetString("authenticationType", ref _authenticationType);
				_nav.SetString("cookieDomain", ref _cookieDomain);
				_nav.SetBool("cookieHttpOnly", ref _cookieHttpOnly);
				_nav.SetString("cookieName", ref _cookieName);
				_nav.SetString("cookiePath", ref _cookiePath);
				_nav.SetEnum("cookieSecure", ref _cookieSecure);
				_nav.SetTimeSpan("expireTimeSpan", ref _expireTimeSpan);
				_nav.SetString("loginPath", ref _loginPath);
				_nav.SetString("logoutPath", ref _logoutPath);
				_nav.SetString("returnUrlParameter", ref _returnUrlParameter);
				_nav.SetBool("slidingExpiration", ref _slidingExpiration);
			}
		}
		#endregion

		#region Properties
		public eAuthenticationMode AuthenticationMode
		{
			get { return _authenticationMode; }
		}

		public string AuthenticationType
		{
			get { return _authenticationType; }
		}

		public string CookieDomain
		{
			get { return _cookieDomain; }
		}

		public bool CookieHttpOnly
		{
			get { return _cookieHttpOnly; }
		}

		public string CookieName
		{
			get { return _cookieName; }
		}

		public string CookiePath
		{
			get { return _cookiePath; }
		}

		public eCookieSecureOption CookieSecure
		{
			get { return _cookieSecure; }
		}

		public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select("description"), _template != null ? _template.Description : null);

				return _description;
			}
		}

		public TimeSpan ExpireTimeSpan
		{
			get { return _expireTimeSpan; }
		}

		public string LoginPath
		{
			get { return _loginPath; }
		}

		public string LogoutPath
		{
			get { return _logoutPath; }
		}

		public string ReturnUrlParameter
		{
			get { return _returnUrlParameter; }
		}

		public bool SlidingExpiration
		{
			get { return _slidingExpiration; }
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

	public class Description : IDescription
	{
		#region Fields
		private string _authenticationType;
		private string _caption;
		private IProperties _properties;

		private XPathNavigator _nav;
		private IDescription _template = null;
		#endregion

		#region Constructors
		public Description(XPathNodeIterator iter, IDescription template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_authenticationType = _template.AuthenticationType;
				_caption = _template.Caption;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetString("authenticationType", ref _authenticationType);
				_nav.SetString("caption", ref _caption);
			}
		}
		#endregion

		#region Properties
		public string AuthenticationType
		{
			get { return _authenticationType; }
		}

		public string Caption
		{
			get { return _caption; }
		}

		public IProperties Properties
		{
			get
			{
				if (_properties == null)
					_properties = new Properties(_nav.Select("properties"), _template != null ? _template.Properties : null);

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
			iter = iter.Current.Select("property");

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
		#region Fields
		private string _id;
		private string _value;
		#endregion

		#region Constructors
		public Property(XPathNodeIterator iter, IProperty template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_id = template.Id;
				_value = template.Value;
			}

			nav.SetString("id", ref _id);
			nav.SetString("value", ref _value);
		}
		#endregion

		#region Properties
		public string Id
		{
			get { return _id; }
		}

		public string Value
		{
			get { return _value; }
		}
		#endregion

		#region Public Methods
		public static string GetId(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("id", ref returnValue);
			return returnValue;
		}
		#endregion
	}

	public class OpenIdConnectAuthenticationOptions : IOpenIdConnectAuthenticationOptions
	{
		#region Fields
		private eAuthenticationMode _authenticationMode;
		private string _authenticationType;
		private string _authority;
		private TimeSpan _backChannelHttpHandler;
		private string _callBackPath;
		private string _caption;
		private string _clientId;
		private string _clientSecret;
		private IConfiguration _configuration;
		private IDescription _description;
		private string _metaDataAddress;
		private string _postLogoutRedirectUri;
		private IProtocolValidator _protocolValidator;
		private string _redirectUri;
		private string _resource;
		private string _responseType;
		private bool _refreshOnIssuerKeyNotFound;
		private string _signInAsAuthenticationType;
		private string _scope;
		private bool _useTokenLifeTime;

		private XPathNavigator _nav;
		private IOpenIdConnectAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public OpenIdConnectAuthenticationOptions(XPathNodeIterator iter, IOpenIdConnectAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_authenticationMode = template.AuthenticationMode;
				_authenticationType = template.AuthenticationType;
				_authority = template.Authority;
				_backChannelHttpHandler = template.BackChannelHttpHandler;
				_callBackPath = template.CallBackPath;
				_caption = template.Caption;
				_clientId = template.ClientId;
				_clientSecret = template.ClientSecret;
				_metaDataAddress = template.MetaDataAddress;
				_postLogoutRedirectUri = template.PostLogoutRedirectUri;
				_redirectUri = template.RedirectUri;
				_resource = template.Resource;
				_responseType = template.ResponseType;
				_refreshOnIssuerKeyNotFound = template.RefreshOnIssuerKeyNotFound;
				_signInAsAuthenticationType = template.SignInAsAuthenticationType;
				_scope = template.Scope;
				_useTokenLifeTime = template.UseTokenLifeTime;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetEnum("authenticationMode", ref _authenticationMode);
				_nav.SetString("authenticationType", ref _authenticationType);
				_nav.SetString("authority", ref _authority);
				_nav.SetTimeSpan("backChannelHttpHandler", ref _backChannelHttpHandler);
				_nav.SetString("callBackPath", ref _callBackPath);
				_nav.SetString("caption", ref _caption);
				_nav.SetString("clientId", ref _clientId);
				_nav.SetString("clientSecret", ref _clientSecret);
				_nav.SetString("metaDataAddress", ref _metaDataAddress);
				_nav.SetString("postLogoutRedirectUri", ref _postLogoutRedirectUri);
				_nav.SetString("redirectUri", ref _redirectUri);
				_nav.SetString("resource", ref _resource);
				_nav.SetString("responseType", ref _responseType);
				_nav.SetBool("refreshOnIssuerKeyNotFound", ref _refreshOnIssuerKeyNotFound);
				_nav.SetString("signInAsAuthenticationType", ref _signInAsAuthenticationType);
				_nav.SetString("scope", ref _scope);
				_nav.SetBool("useTokenLifeTime", ref _useTokenLifeTime);
			}
		}
		#endregion

		#region Properties
		public eAuthenticationMode AuthenticationMode
		{
			get { return _authenticationMode; }
		}

		public string AuthenticationType
		{
			get { return _authenticationType; }
		}

		public string Authority
		{
			get { return _authority; }
		}

		public TimeSpan BackChannelHttpHandler
		{
			get { return _backChannelHttpHandler; }
		}

		public string CallBackPath
		{
			get { return _callBackPath; }
		}

		public string Caption
		{
			get { return _caption; }
		}

		public string ClientId
		{
			get { return _clientId; }
		}

		public string ClientSecret
		{
			get { return _clientSecret; }
		}

		public IConfiguration Configuration
		{
			get
			{
				if (_configuration == null)
					_configuration = new Configuration(_nav.Select("configuration"), _template != null ? _template.Configuration : null);

				return _configuration;
			}
		}

		public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select("description"), _template != null ? _template.Description : null);

				return _description;
			}
		}

		public string MetaDataAddress
		{
			get { return _metaDataAddress; }
		}

		public string PostLogoutRedirectUri
		{
			get { return _postLogoutRedirectUri; }
		}

		public IProtocolValidator ProtocolValidator
		{
			get
			{
				if (_protocolValidator == null)
					_protocolValidator = new ProtocolValidator(_nav.Select("protocolValidator"), _template != null ? _template.ProtocolValidator : null);

				return _protocolValidator;
			}
		}

		public string RedirectUri
		{
			get { return _redirectUri; }
		}

		public string Resource
		{
			get { return _resource; }
		}

		public string ResponseType
		{
			get { return _responseType; }
		}

		public bool RefreshOnIssuerKeyNotFound
		{
			get { return _refreshOnIssuerKeyNotFound; }
		}

		public string SignInAsAuthenticationType
		{
			get { return _signInAsAuthenticationType; }
		}

		public string Scope
		{
			get { return _scope; }
		}

		public bool UseTokenLifeTime
		{
			get { return _useTokenLifeTime; }
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

	public class Configuration : IConfiguration
	{
		#region Fields
		private string _authorizationEndpoint;
		private string _checkSessionIframe;
		private string _endSessionEndpoint;
		private string _issuer;
		private IJsonWebKeys _jsonWebKeys;
		private string _jwksUri;
		private string _tokenEndpoint;
		private string _userInfoEndpoint;

		private XPathNavigator _nav;
		private IConfiguration _template = null;
		#endregion

		#region Constructors
		public Configuration(XPathNodeIterator iter, IConfiguration template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_authorizationEndpoint = template.AuthorizationEndpoint;
				_checkSessionIframe = template.CheckSessionIframe;
				_endSessionEndpoint = template.EndSessionEndpoint;
				_issuer = template.Issuer;
				_jwksUri = template.JwksUri;
				_tokenEndpoint = template.TokenEndpoint;
				_userInfoEndpoint = template.UserInfoEndpoint;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetString("authorizationEndpoint", ref _authorizationEndpoint);
				_nav.SetString("checkSessionIframe", ref _checkSessionIframe);
				_nav.SetString("endSessionEndpoint", ref _endSessionEndpoint);
				_nav.SetString("issuer", ref _issuer);
				_nav.SetString("jwksUri", ref _jwksUri);
				_nav.SetString("tokenEndpoint", ref _tokenEndpoint);
				_nav.SetString("userInfoEndpoint", ref _userInfoEndpoint);
			}
		}
		#endregion

		#region Properties
		public string AuthorizationEndpoint
		{
			get { return _authorizationEndpoint; }
		}

		public string CheckSessionIframe
		{
			get { return _checkSessionIframe; }
		}

		public string EndSessionEndpoint
		{
			get { return _endSessionEndpoint; }
		}

		public string Issuer
		{
			get { return _issuer; }
		}

		public IJsonWebKeys JsonWebKeys
		{
			get
			{
				if (_jsonWebKeys == null)
					_jsonWebKeys = new JsonWebKeys(_nav.Select("jsonWebKeys"), _template != null ? _template.JsonWebKeys : null);

				return _jsonWebKeys;
			}
		}

		public string JwksUri
		{
			get { return _jwksUri; }
		}

		public string TokenEndpoint
		{
			get { return _tokenEndpoint; }
		}

		public string UserInfoEndpoint
		{
			get { return _userInfoEndpoint; }
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
			iter = iter.Current.Select("jsonWebKey");

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
		#region Fields
		private string _id;
		private string _value;
		#endregion

		#region Constructors
		public JsonWebKey(XPathNodeIterator iter, IJsonWebKey template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_id = template.Id;
				_value = template.Value;
			}

			nav.SetString("id", ref _id);
			nav.SetString("value", ref _value);
		}
		#endregion

		#region Properties
		public string Id
		{
			get { return _id; }
		}

		public string Value
		{
			get { return _value; }
		}
		#endregion

		#region Public Methods
		public static string GetId(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("id", ref returnValue);
			return returnValue;
		}
		#endregion
	}

	public class ProtocolValidator : IProtocolValidator
	{
		#region Fields
		private TimeSpan _nonceLifetime;
		private bool _requireAcr;
		private bool _requireAmr;
		private bool _requireAuthTime;
		private bool _requireAzp;
		private bool _requireNonce;
		private bool _requireSub;
		private bool _requireTimeStampInNonce;

		private XPathNavigator _nav;
		private IProtocolValidator _template = null;
		#endregion

		#region Constructors
		public ProtocolValidator(XPathNodeIterator iter, IProtocolValidator template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_nonceLifetime = _template.NonceLifetime;
				_requireAcr = _template.RequireAcr;
				_requireAmr = _template.RequireAmr;
				_requireAuthTime = _template.RequireAuthTime;
				_requireAzp = _template.RequireAzp;
				_requireNonce = _template.RequireNonce;
				_requireSub = _template.RequireSub;
				_requireTimeStampInNonce = _template.RequireTimeStampInNonce;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetTimeSpan("nonceLifetime", ref _nonceLifetime);
				_nav.SetBool("requireAcr", ref _requireAcr);
				_nav.SetBool("requireAmr", ref _requireAmr);
				_nav.SetBool("requireAuthTime", ref _requireAuthTime);
				_nav.SetBool("requireAzp", ref _requireAzp);
				_nav.SetBool("requireNonce", ref _requireNonce);
				_nav.SetBool("requireSub", ref _requireSub);
				_nav.SetBool("requireTimeStampInNonce", ref _requireTimeStampInNonce);
			}
		}
		#endregion

		#region Properties
		public TimeSpan NonceLifetime
		{
			get { return _nonceLifetime; }
		}

		public bool RequireAcr
		{
			get { return _requireAcr; }
		}

		public bool RequireAmr
		{
			get { return _requireAmr; }
		}

		public bool RequireAuthTime
		{
			get { return _requireAuthTime; }
		}

		public bool RequireAzp
		{
			get { return _requireAzp; }
		}

		public bool RequireNonce
		{
			get { return _requireNonce; }
		}

		public bool RequireSub
		{
			get { return _requireSub; }
		}

		public bool RequireTimeStampInNonce
		{
			get { return _requireTimeStampInNonce; }
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

	public class IdentityServerBearerTokenAuthenticationOptions : IIdentityServerBearerTokenAuthenticationOptions
	{
		#region Fields
		private eAuthenticationMode? _authenticationMode;
		private string _authenticationType;
		private string _authority;
		private string _clientId;
		private string _clientSecret;
		private bool? _delayLoadMetadata;
		private bool? _enableValidationResultCache;
		private string _issuerName;
		private string _nameClaimType;
		private bool? _preserveAccessToken;
		private List<string> _requiredScopes;
		private string _roleClaimType;
		private eValidationMode? _validationMode;
		private TimeSpan? _validationResultCacheDuration;
		private IDescription _description;

		private XPathNavigator _nav;
		private IIdentityServerBearerTokenAuthenticationOptions _template = null;
		#endregion

		#region Constructors
		public IdentityServerBearerTokenAuthenticationOptions(XPathNodeIterator iter, IIdentityServerBearerTokenAuthenticationOptions template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_authenticationMode = _template.AuthenticationMode;
				_authenticationType = _template.AuthenticationType;
				_authority = _template.Authority;
				_clientId = _template.ClientId;
				_clientSecret = _template.ClientSecret;
				_delayLoadMetadata = _template.DelayLoadMetadata;
				_enableValidationResultCache = _template.EnableValidationResultCache;
				_issuerName = _template.IssuerName;
				_nameClaimType = _template.NameClaimType;
				_preserveAccessToken = _template.PreserveAccessToken;
				_requiredScopes = _template.RequiredScopes;
				_roleClaimType = _template.RoleClaimType;
				_validationMode = _template.ValidationMode;
				_validationResultCacheDuration = _template.ValidationResultCacheDuration;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetEnumNullable("authenticationMode", ref _authenticationMode);
				_nav.SetString("authenticationType", ref _authenticationType);
				_nav.SetString("authority", ref _authority);
				_nav.SetString("clientId", ref _clientId);
				_nav.SetString("clientSecret", ref _clientSecret);
				_nav.SetBoolNullable("delayLoadMetadata", ref _delayLoadMetadata);
				_nav.SetBoolNullable("enableValidationResultCache", ref _enableValidationResultCache);
				_nav.SetString("issuerName", ref _issuerName);
				_nav.SetString("nameClaimType", ref _nameClaimType);
				_nav.SetBoolNullable("preserveAccessToken", ref _preserveAccessToken);
				_nav.SetListString("requiredScopes", ref _requiredScopes);
				_nav.SetString("roleClaimType", ref _roleClaimType);
				_nav.SetEnumNullable("validationMode", ref _validationMode);
				_nav.SetTimeSpanNullable("validationResultCacheDuration", ref _validationResultCacheDuration);
			}
		}
		#endregion

		#region Properties
		public eAuthenticationMode? AuthenticationMode
		{
			get { return _authenticationMode; }
		}

		public string AuthenticationType
		{
			get { return _authenticationType; }
		}

		public string Authority
		{
			get { return _authority; }
		}

		public string ClientId
		{
			get { return _clientId; }
		}

		public string ClientSecret
		{
			get { return _clientSecret; }
		}

		public bool? DelayLoadMetadata
		{
			get { return _delayLoadMetadata; }
		}

		public bool? EnableValidationResultCache
		{
			get { return _enableValidationResultCache; }
		}

		public string IssuerName
		{
			get { return _issuerName; }
		}

		public string NameClaimType
		{
			get { return _nameClaimType; }
		}

		public bool? PreserveAccessToken
		{
			get { return _preserveAccessToken; }
		}

		public List<string> RequiredScopes
		{
			get { return _requiredScopes; }
		}

		public string RoleClaimType
		{
			get { return _roleClaimType; }
		}

		public eValidationMode? ValidationMode
		{
			get { return _validationMode; }
		}

		public TimeSpan? ValidationResultCacheDuration
		{
			get { return _validationResultCacheDuration; }
		}

		public IDescription Description
		{
			get
			{
				if (_description == null)
					_description = new Description(_nav.Select("description"), _template != null ? _template.Description : null);

				return _description;
			}
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_authenticationMode = eAuthenticationMode.Active;
			_authenticationType = "Bearer";
			_delayLoadMetadata = false;
			_enableValidationResultCache = false;
			_nameClaimType = "name";
			_preserveAccessToken = false;
			_roleClaimType = "role";
			_validationMode = eValidationMode.Both;
			_validationResultCacheDuration = new TimeSpan(0, 5, 0);
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

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetString("clientId", ref _clientId);
				_nav.SetString("secret", ref _secret);
				_nav.SetString("scope", ref _scope);
			}
		}
		#endregion

		#region Properties
		public string ClientId
		{
			get { return _clientId; }
		}

		public string Secret
		{
			get { return _secret; }
		}

		public string Scope
		{
			get { return _scope; }
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
}
