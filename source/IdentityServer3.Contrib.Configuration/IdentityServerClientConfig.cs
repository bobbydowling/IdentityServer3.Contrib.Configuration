using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerClientConfig : IIdentityServerClientConfig
	{
		#region Fields
		private int? _absoluteRefreshTokenLifetime;
		private int? _accessTokenLifetime;
		private eAccessTokenType? _accessTokenType;
		private bool? _allowAccessToAllCustomGrantTypes;
		private bool? _allowAccessToAllScopes;
		private bool? _allowClientCredentialsOnly;
		private List<string> _allowedCorsOrigins;
		private List<string> _allowedCustomGrantTypes;
		private List<string> _allowedScopes;
		private bool? _allowRememberConsent;
		private bool? _alwaysSendClientClaims;
		private int? _authorizationCodeLifetime;
		private IClaims _claims;
		private string _clientId;
		private string _clientName;
		private string _clientUri;
		private bool? _enabled;
		private bool? _enableLocalLogin;
		private eFlows? _flow;
		private List<string> _identityProviderRestrictions;
		private int? _identityTokenLifetime;
		private bool? _includeJwtId;
		private string _logoUri;
		private bool? _logoutSessionRequired;
		private string _logoutUri;
		private List<string> _postLogoutRedirectUris;
		private bool? _prefixClientClaims;
		private List<string> _redirectUris;
		private eTokenExpiration? _refreshTokenExpiration;
		private eTokenUsage? _refreshTokenUsage;
		private bool? _requireConsent;
		private ISecrets _secrets;
		private int? _slidingRefreshTokenLifetime;
		private bool? _updateAccessTokenClaimsOnRefresh;

		private XPathNavigator _nav;
		private IIdentityServerClientConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerClientConfig(XPathNodeIterator iter, IIdentityServerClientConfig template)
		{
			SetKnownDefaults();

			_template = template;
			_nav = iter.Current;

			if (_template != null)
			{
				_absoluteRefreshTokenLifetime = _template.AbsoluteRefreshTokenLifetime;
				_accessTokenLifetime = _template.AccessTokenLifetime;
				_accessTokenType = _template.AccessTokenType;
				_allowAccessToAllCustomGrantTypes = _template.AllowAccessToAllCustomGrantTypes;
				_allowAccessToAllScopes = _template.AllowAccessToAllScopes;
				_allowClientCredentialsOnly = _template.AllowClientCredentialsOnly;
				_allowedCorsOrigins = _template.AllowedCorsOrigins;
				_allowedCustomGrantTypes = _template.AllowedCustomGrantTypes;
				_allowedScopes = _template.AllowedScopes;
				_allowRememberConsent = _template.AllowRememberConsent;
				_alwaysSendClientClaims = _template.AlwaysSendClientClaims;
				_authorizationCodeLifetime = _template.AuthorizationCodeLifetime;
				_clientId = _template.ClientId;
				_clientName = _template.ClientName;
				_clientUri = _template.ClientUri;
				_enabled = _template.Enabled;
				_enableLocalLogin = _template.EnableLocalLogin;
				_flow = _template.Flow;
				_identityProviderRestrictions = _template.IdentityProviderRestrictions;
				_identityTokenLifetime = _template.IdentityTokenLifetime;
				_includeJwtId = _template.IncludeJwtId;
				_logoUri = _template.LogoUri;
				_logoutSessionRequired = _template.LogoutSessionRequired;
				_logoutUri = _template.LogoutUri;
				_postLogoutRedirectUris = _template.PostLogoutRedirectUris;
				_prefixClientClaims = _template.PrefixClientClaims;
				_redirectUris = _template.RedirectUris;
				_refreshTokenExpiration = _template.RefreshTokenExpiration;
				_refreshTokenUsage = _template.RefreshTokenUsage;
				_requireConsent = _template.RequireConsent;
				_slidingRefreshTokenLifetime = _template.SlidingRefreshTokenLifetime;
				_updateAccessTokenClaimsOnRefresh = _template.UpdateAccessTokenClaimsOnRefresh;
			}

			_nav.SetIntNullable("absoluteRefreshTokenLifetime", ref _absoluteRefreshTokenLifetime);
			_nav.SetIntNullable("accessTokenLifetime", ref _accessTokenLifetime);
			_nav.SetEnumNullable("accessTokenType", ref _accessTokenType);
			_nav.SetBoolNullable("allowAccessToAllCustomGrantTypes", ref _allowAccessToAllCustomGrantTypes);
			_nav.SetBoolNullable("allowAccessToAllScopes", ref _allowAccessToAllScopes);
			_nav.SetBoolNullable("allowClientCredentialsOnly", ref _allowClientCredentialsOnly);
			_nav.SetListString("allowedCorsOrigins", ref _allowedCorsOrigins);
			_nav.SetListString("allowedCustomGrantTypes", ref _allowedCustomGrantTypes);
			_nav.SetListString("allowedScopes", ref _allowedScopes);
			_nav.SetBoolNullable("allowRememberConsent", ref _allowRememberConsent);
			_nav.SetBoolNullable("alwaysSendClientClaims", ref _alwaysSendClientClaims);
			_nav.SetIntNullable("authorizationCodeLifetime", ref _authorizationCodeLifetime);
			_nav.SetString("clientId", ref _clientId);
			_nav.SetString("clientName", ref _clientName);
			_nav.SetString("clientUri", ref _clientUri);
			_nav.SetBoolNullable("enabled", ref _enabled);
			_nav.SetBoolNullable("enableLocalLogin", ref _enableLocalLogin);
			_nav.SetEnumNullable("flow", ref _flow);
			_nav.SetListString("identityProviderRestrictions", ref _identityProviderRestrictions);
			_nav.SetIntNullable("identityTokenLifetime", ref _identityTokenLifetime);
			_nav.SetBoolNullable("includeJwtId", ref _includeJwtId);
			_nav.SetString("logoUri", ref _logoUri);
			_nav.SetBoolNullable("logoutSessionRequired", ref _logoutSessionRequired);
			_nav.SetString("logoutUri", ref _logoutUri);
			_nav.SetListString("postLogoutRedirectUris", ref _postLogoutRedirectUris);
			_nav.SetBoolNullable("prefixClientClaims", ref _prefixClientClaims);
			_nav.SetListString("redirectUris", ref _redirectUris);
			_nav.SetEnumNullable("refreshTokenExpiration", ref _refreshTokenExpiration);
			_nav.SetEnumNullable("refreshTokenUsage", ref _refreshTokenUsage);
			_nav.SetBoolNullable("requireConsent", ref _requireConsent);
			_nav.SetIntNullable("slidingRefreshTokenLifetime", ref _slidingRefreshTokenLifetime);
			_nav.SetBoolNullable("updateAccessTokenClaimsOnRefresh", ref _updateAccessTokenClaimsOnRefresh);
		}
		#endregion

		#region Properties
		public int? AbsoluteRefreshTokenLifetime
		{
			get { return _absoluteRefreshTokenLifetime; }
		}

		public int? AccessTokenLifetime
		{
			get { return _accessTokenLifetime; }
		}

		public eAccessTokenType? AccessTokenType
		{
			get { return _accessTokenType; }
		}

		public bool? AllowAccessToAllCustomGrantTypes
		{
			get { return _allowAccessToAllCustomGrantTypes; }
		}

		public bool? AllowAccessToAllScopes
		{
			get { return _allowAccessToAllScopes; }
		}

		public bool? AllowClientCredentialsOnly
		{
			get { return _allowClientCredentialsOnly; }
		}

		public List<string> AllowedCorsOrigins
		{
			get { return _allowedCorsOrigins; }
		}

		public List<string> AllowedCustomGrantTypes
		{
			get { return _allowedCustomGrantTypes; }
		}

		public List<string> AllowedScopes
		{
			get { return _allowedScopes; }
		}

		public bool? AllowRememberConsent
		{
			get { return _allowRememberConsent; }
		}

		public bool? AlwaysSendClientClaims
		{
			get { return _alwaysSendClientClaims; }
		}

		public int? AuthorizationCodeLifetime
		{
			get { return _authorizationCodeLifetime; }
		}

		public IClaims Claims
		{
			get
			{
				if (_claims == null)
					_claims = new Claims(_nav.Select("claims"), _template != null ? _template.Claims : null);

				return _claims;
			}
		}

		public string ClientId
		{
			get { return _clientId; }
		}

		public string ClientName
		{
			get { return _clientName; }
		}

		public string ClientUri
		{
			get { return _clientUri; }
		}

		public bool? Enabled
		{
			get { return _enabled; }
		}

		public bool? EnableLocalLogin
		{
			get { return _enableLocalLogin; }
		}

		public eFlows? Flow
		{
			get { return _flow; }
		}

		public List<string> IdentityProviderRestrictions
		{
			get { return _identityProviderRestrictions; }
		}

		public int? IdentityTokenLifetime
		{
			get { return _identityTokenLifetime; }
		}

		public bool? IncludeJwtId
		{
			get { return _includeJwtId; }
		}

		public string LogoUri
		{
			get { return _logoUri; }
		}

		public bool? LogoutSessionRequired
		{
			get { return _logoutSessionRequired; }
		}

		public string LogoutUri
		{
			get { return _logoutUri; }
		}

		public List<string> PostLogoutRedirectUris
		{
			get { return _postLogoutRedirectUris; }
		}

		public bool? PrefixClientClaims
		{
			get { return _prefixClientClaims; }
		}

		public List<string> RedirectUris
		{
			get { return _redirectUris; }
		}

		public eTokenExpiration? RefreshTokenExpiration
		{
			get { return _refreshTokenExpiration; }
		}

		public eTokenUsage? RefreshTokenUsage
		{
			get { return _refreshTokenUsage; }
		}

		public bool? RequireConsent
		{
			get { return _requireConsent; }
		}

		public ISecrets Secrets
		{
			get
			{
				if (_secrets == null)
					_secrets = new Secrets(_nav.Select("secrets"), _template != null ? _template.Secrets : null);

				return _secrets;
			}
		}

		public int? SlidingRefreshTokenLifetime
		{
			get { return _slidingRefreshTokenLifetime; }
		}

		public bool? UpdateAccessTokenClaimsOnRefresh
		{
			get { return _updateAccessTokenClaimsOnRefresh; }
		}
		#endregion

		#region Public Methods
		public static string GetClientId(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("clientId", ref returnValue);
			return returnValue;
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_absoluteRefreshTokenLifetime = 2592000;
			_accessTokenLifetime = 3600;
			_accessTokenType = eAccessTokenType.Jwt;
			_allowAccessToAllCustomGrantTypes = false;
			_allowAccessToAllScopes = false;
			_allowClientCredentialsOnly = false;
			_allowRememberConsent = true;
			_alwaysSendClientClaims = false;
			_authorizationCodeLifetime = 300;
			_enabled = true;
			_enableLocalLogin = true;
			_flow = eFlows.Implicit;
			_identityTokenLifetime = 300;
			_includeJwtId = false;
			_logoutSessionRequired = true;
			_prefixClientClaims = true;
			_refreshTokenExpiration = eTokenExpiration.Absolute;
			_refreshTokenUsage = eTokenUsage.OneTimeOnly;
			_requireConsent = true;
			_slidingRefreshTokenLifetime = 1296000;
			_updateAccessTokenClaimsOnRefresh = false;
		}
		#endregion
	}

	public class Claims : List<IClaim>, IClaims
	{
		#region Constructors
		public Claims(XPathNodeIterator iter, IClaims template)
		{
			if (template != null)
				template.Each(c => Add(c));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("claim");

			while (iter.MoveNext())
			{
				var value = Claim.GetValue(iter.Current);
				var template = this.SingleOrDefault(c => c.Value == value);

				if (template != null)
					Remove(template);

				var newValue = new Claim(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class Claim : IClaim
	{
		#region Fields
		private string _value;
		private string _type;
		private string _valueType;
		private string _issuer;
		private string _originalIssuer;
		private IClaimsIdentity _subject;
		#endregion

		#region Constructors
		public Claim(XPathNodeIterator iter, IClaim template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_value = template.Value;
				_type = template.Type;
				_valueType = template.ValueType;
				_issuer = template.Issuer;
				_originalIssuer = template.OriginalIssuer;
			}

			nav.SetString("value", ref _value);
			nav.SetString("type", ref _type);
			nav.SetString("valueType", ref _valueType);
			nav.SetString("issuer", ref _issuer);
			nav.SetString("originalIssuer", ref _originalIssuer);
		}
		#endregion

		#region Properties
		public string Value
		{
			get { return _value; }
		}

		public string Type
		{
			get { return _type; }
		}

		public string ValueType
		{
			get { return _valueType; }
		}

		public string Issuer
		{
			get { return _issuer; }
		}

		public string OriginalIssuer
		{
			get { return _originalIssuer; }
		}

		public IClaimsIdentity Subject
		{
			get { return _subject; }
		}
		#endregion

		#region Public Methods
		public static string GetValue(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("value", ref returnValue);
			return returnValue;
		}
		#endregion
	}

	public class Secrets : List<ISecret>, ISecrets
	{
		#region Constructors
		public Secrets(XPathNodeIterator iter, ISecrets template)
		{
			if (template != null)
				template.Each(c => Add(c));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("secret");

			while (iter.MoveNext())
			{
				var value = Secret.GetValue(iter.Current);
				var template = this.SingleOrDefault(s => s.Value == value);

				if (template != null)
					Remove(template);

				var newValue = new Secret(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class Secret : ISecret
	{
		#region Fields
		private string _value;
		private string _type;
		private string _description;
		private DateTimeOffset? _expiration;
		#endregion

		#region Constructors
		public Secret(XPathNodeIterator iter, ISecret template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_value = template.Value;
				_type = template.Type;
				_description = template.Description;
				_expiration = template.Expiration;
			}

			nav.SetString("value", ref _value);
			nav.SetString("type", ref _type);
			nav.SetString("description", ref _description);
			nav.SetDateTimeOffsetNullable("expiration", ref _expiration);
		}
		#endregion

		#region Properties
		public string Value
		{
			get { return _value; }
		}

		public string Type
		{
			get { return _type; }
		}

		public string Description
		{
			get { return _description; }
		}

		public DateTimeOffset? Expiration
		{
			get { return _expiration; }
		}

		#endregion

		#region Public Methods
		public static string GetValue(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("value", ref returnValue);
			return returnValue;
		}
		#endregion
	}
}
