using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerOptionsConfig : IIdentityServerOptionsConfig
	{
		#region Fields
		private IAuthentication _authentication;
		private ICaching _caching;
		private ICertificate _certificate;
		private ICors _cors;
		private ICsp _csp;
		private bool? _enableWelcomePage;
		private IEndPoints _endPoints;
		private IEvents _events;
		private IInputLengthRestrictions _inputLengthRestrictions;
		private string _issuerUri;
		private ILogging _logging;
		private IOperationalData _operationalData;
		private List<string> _protocolLogoutUrls;
		private string _publicOrigin;
		private bool? _requireSsl;
		private string _siteName;
		private ITenants _tenants;

		private XPathNavigator _nav;
		private IIdentityServerOptionsConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerOptionsConfig(XPathNodeIterator iter, IIdentityServerOptionsConfig template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_enableWelcomePage = _template.EnableWelcomePage;
				_issuerUri = _template.IssuerUri;
				_protocolLogoutUrls = _template.ProtocolLogoutUrls;
				_publicOrigin = _template.PublicOrigin;
				_requireSsl = _template.RequireSsl;
				_siteName = _template.SiteName;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("enableWelcomePage", ref _enableWelcomePage);
				_nav.SetString("issuerUri", ref _issuerUri);
				_nav.SetListString("protocolLogoutUrls", ref _protocolLogoutUrls);
				_nav.SetString("publicOrigin", ref _publicOrigin);
				_nav.SetBoolNullable("requireSsl", ref _requireSsl);
				_nav.SetString("siteName", ref _siteName);
			}
		}
		#endregion

		#region Properties
		public IAuthentication Authentication
		{
			get
			{
				if (_authentication == null)
					_authentication = new Authentication(_nav.Select("authentication"), _template != null ? _template.Authentication : null);

				return _authentication;
			}
		}

		public ICaching Caching
		{
			get
			{
				if (_caching == null)
					_caching = new Caching(_nav.Select("caching"), _template != null ? _template.Caching : null);

				return _caching;
			}
		}

		public ICertificate Certificate
		{
			get
			{
				if (_certificate == null)
					_certificate = new Certificate(_nav.Select("certificate"), _template != null ? _template.Certificate : null);

				return _certificate;
			}
		}

		public ICors Cors
		{
			get
			{
				if (_cors == null)
					_cors = new Cors(_nav.Select("cors"), _template != null ? _template.Cors : null);

				return _cors;
			}
		}

		public ICsp Csp
		{
			get
			{
				if (_csp == null)
					_csp = new Csp(_nav.Select("csp"), _template != null ? _template.Csp : null);

				return _csp;
			}
		}

		public bool? EnableWelcomePage
		{
			get { return _enableWelcomePage; }
		}

		public IEndPoints EndPoints
		{
			get
			{
				if (_endPoints == null)
					_endPoints = new EndPoints(_nav.Select("endPoints"), _template != null ? _template.EndPoints : null);

				return _endPoints;
			}
		}

		public IEvents Events
		{
			get
			{
				if (_events == null)
					_events = new Events(_nav.Select("events"), _template != null ? _template.Events : null);

				return _events;
			}
		}

		public IInputLengthRestrictions InputLengthRestrictions
		{
			get
			{
				if (_inputLengthRestrictions == null)
					_inputLengthRestrictions = new InputLengthRestrictions(_nav.Select("inputLengthRestrictions"), _template != null ? _template.InputLengthRestrictions : null);

				return _inputLengthRestrictions;
			}
		}

		public string IssuerUri
		{
			get { return _issuerUri; }
		}

		public ILogging Logging
		{
			get
			{
				if (_logging == null)
					_logging = new Logging(_nav.Select("logging"), _template != null ? _template.Logging : null);

				return _logging;
			}
		}

		public IOperationalData OperationalData
		{
			get
			{
				if (_operationalData == null)
					_operationalData = new OperationalData(_nav.Select("operationalData"), _template != null ? _template.OperationalData : null);

				return _operationalData;
			}
		}

		public List<string> ProtocolLogoutUrls
		{
			get { return _protocolLogoutUrls; }
		}

		public string PublicOrigin
		{
			get { return _publicOrigin; }
		}

		public bool? RequireSsl
		{
			get { return _requireSsl; }
		}

		public string SiteName
		{
			get { return _siteName; }
		}

		public ITenants Tenants
		{
			get
			{
				if (_tenants == null)
					_tenants = new Tenants(_nav.Select("tenants"), _template != null ? _template.Tenants : null);

				return _tenants;
			}
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_enableWelcomePage = true;
			_requireSsl = true;
		}
		#endregion
	}

	public class Authentication : IAuthentication
	{
		#region Fields
		private ICookie _cookie;
		private bool? _enableLoginHint;
		private bool? _enableLocalLogin;
		private bool? _enablePostSignOutAutoRedirect;
		private bool? _enableSignOutPrompt;
		private string _invalidSignInRedirectUrl;
		private ILoginPageLinks _loginPageLinks;
		private int? _postSignOutAutoRedirectDelay;
		private bool? _rememberLastUsername;
		private bool? _requireAuthenticatedUserForSignOutMessage;
		private int? _signInMessageThreshold;
		private bool _isEnableExternalWindowsAuthentication;
		private string _externalWindowsAuthenticationCaption;
		private string _resetPasswordRedirectUri;
		private string _resetPasswordUri;

		private XPathNavigator _nav;
		private IAuthentication _template = null;
		#endregion

		#region Constructors
		public Authentication(XPathNodeIterator iter, IAuthentication template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_enableLoginHint = _template.EnableLoginHint;
				_enableLocalLogin = _template.EnableLocalLogin;
				_enablePostSignOutAutoRedirect = _template.EnablePostSignOutAutoRedirect;
				_enableSignOutPrompt = _template.EnableSignOutPrompt;
				_invalidSignInRedirectUrl = _template.InvalidSignInRedirectUrl;
				_postSignOutAutoRedirectDelay = _template.PostSignOutAutoRedirectDelay;
				_rememberLastUsername = _template.RememberLastUsername;
				_requireAuthenticatedUserForSignOutMessage = _template.RequireAuthenticatedUserForSignOutMessage;
				_signInMessageThreshold = _template.SignInMessageThreshold;
				_isEnableExternalWindowsAuthentication = _template.IsEnableExternalWindowsAuthentication;
				_externalWindowsAuthenticationCaption = _template.ExternalWindowsAuthenticationCaption;
				_resetPasswordRedirectUri = _template.ResetPasswordRedirectUri;
				_resetPasswordUri = _template.ResetPasswordUri;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("enableLoginHint", ref _enableLoginHint);
				_nav.SetBoolNullable("enableLocalLogin", ref _enableLocalLogin);
				_nav.SetBoolNullable("enablePostSignOutAutoRedirect", ref _enablePostSignOutAutoRedirect);
				_nav.SetBoolNullable("enableSignOutPrompt", ref _enableSignOutPrompt);
				_nav.SetString("invalidSignInRedirectUrl", ref _invalidSignInRedirectUrl);
				_nav.SetIntNullable("postSignOutAutoRedirectDelay", ref _postSignOutAutoRedirectDelay);
				_nav.SetBoolNullable("rememberLastUsername", ref _rememberLastUsername);
				_nav.SetBoolNullable("requireAuthenticatedUserForSignOutMessage", ref _requireAuthenticatedUserForSignOutMessage);
				_nav.SetIntNullable("signInMessageThreshold", ref _signInMessageThreshold);
				_nav.SetBool("isEnableExternalWindowsAuthentication", ref _isEnableExternalWindowsAuthentication);
				_nav.SetString("externalWindowsAuthenticationCaption", ref _externalWindowsAuthenticationCaption);
				_nav.SetString("resetPasswordRedirectUri", ref _resetPasswordRedirectUri);
				_nav.SetString("resetPasswordUri", ref _resetPasswordUri);
			}
		}
		#endregion

		#region Properties
		public ICookie Cookie
		{
			get
			{
				if (_cookie == null)
					_cookie = new Cookie(_nav.Select("cookie"), _template != null ? _template.Cookie : null);

				return _cookie;
			}
		}

		public bool? EnableLoginHint
		{
			get { return _enableLoginHint; }
		}

		public bool? EnableLocalLogin
		{
			get { return _enableLocalLogin; }
		}

		public bool? EnablePostSignOutAutoRedirect
		{
			get { return _enablePostSignOutAutoRedirect; }
		}

		public bool? EnableSignOutPrompt
		{
			get { return _enableSignOutPrompt; }
		}

		public string InvalidSignInRedirectUrl
		{
			get { return _invalidSignInRedirectUrl; }
		}

		public ILoginPageLinks LoginPageLinks
		{
			get
			{
				if (_loginPageLinks == null)
					_loginPageLinks = new LoginPageLinks(_nav.Select("loginPageLinks"), _template != null ? _template.LoginPageLinks : null);

				return _loginPageLinks;
			}
		}

		public int? PostSignOutAutoRedirectDelay
		{
			get { return _postSignOutAutoRedirectDelay; }
		}

		public bool? RememberLastUsername
		{
			get { return _rememberLastUsername; }
		}

		public bool? RequireAuthenticatedUserForSignOutMessage
		{
			get { return _requireAuthenticatedUserForSignOutMessage; }
		}

		public int? SignInMessageThreshold
		{
			get { return _signInMessageThreshold; }
		}

		public bool IsEnableExternalWindowsAuthentication
		{
			get { return _isEnableExternalWindowsAuthentication; }
		}

		public string ExternalWindowsAuthenticationCaption
		{
			get { return _externalWindowsAuthenticationCaption; }
		}

		public string ResetPasswordRedirectUri
		{
			get { return _resetPasswordRedirectUri; }
		}

		public string ResetPasswordUri
		{
			get { return _resetPasswordUri; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_enableLoginHint = true;
			_enableLocalLogin = true;
			_enablePostSignOutAutoRedirect = false;
			_enableSignOutPrompt = true;
			_postSignOutAutoRedirectDelay = 0;
			_rememberLastUsername = false;
			_requireAuthenticatedUserForSignOutMessage = false;
			_signInMessageThreshold = 5;
		}
		#endregion
	}

	public class Cookie : ICookie
	{
		#region Fields
		private bool? _allowRememberMe;
		private TimeSpan? _expireTimeSpan;
		private bool? _isPersistent;
		private string _path;
		private string _prefix;
		private TimeSpan? _rememberMeDuration;
		private eCookieSecureMode? _secureMode;
		private bool? _slidingExpiration;

		private XPathNavigator _nav;
		private ICookie _template = null;
		#endregion

		#region Constructors
		public Cookie(XPathNodeIterator iter, ICookie template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_allowRememberMe = _template.AllowRememberMe;
				_expireTimeSpan = _template.ExpireTimeSpan;
				_isPersistent = _template.IsPersistent;
				_path = _template.Path;
				_prefix = _template.Prefix;
				_rememberMeDuration = _template.RememberMeDuration;
				_secureMode = _template.SecureMode;
				_slidingExpiration = _template.SlidingExpiration;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("allowRememberMe", ref _allowRememberMe);
				_nav.SetTimeSpanNullable("expireTimeSpan", ref _expireTimeSpan);
				_nav.SetBoolNullable("isPersistent", ref _isPersistent);
				_nav.SetString("path", ref _path);
				_nav.SetString("prefix", ref _prefix);
				_nav.SetTimeSpanNullable("rememberMeDuration", ref _rememberMeDuration);
				_nav.SetEnumNullable("secureMode", ref _secureMode);
				_nav.SetBoolNullable("slidingExpiration", ref _slidingExpiration);
			}
		}
		#endregion

		#region Properties
		public bool? AllowRememberMe
		{
			get { return _allowRememberMe; }
		}

		public TimeSpan? ExpireTimeSpan
		{
			get { return _expireTimeSpan; }
		}

		public bool? IsPersistent
		{
			get { return _isPersistent; }
		}

		public string Path
		{
			get { return _path; }
		}

		public string Prefix
		{
			get { return _prefix; }
		}

		public TimeSpan? RememberMeDuration
		{
			get { return _rememberMeDuration; }
		}

		public eCookieSecureMode? SecureMode
		{
			get { return _secureMode; }
		}

		public bool? SlidingExpiration
		{
			get { return _slidingExpiration; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_allowRememberMe = true;
			_expireTimeSpan = TimeSpan.FromHours(10);
			_isPersistent = false;
			_rememberMeDuration = TimeSpan.FromDays(30);
			_secureMode = eCookieSecureMode.SameAsRequest;
			_slidingExpiration = false;
		}
		#endregion
	}

	public class LoginPageLinks : List<ILoginPageLink>, ILoginPageLinks
	{
		#region Constructors
		public LoginPageLinks(XPathNodeIterator iter, ILoginPageLinks template)
		{
			if (template != null)
				template.Each(l => Add(l));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("link");

			while (iter.MoveNext())
			{
				var href = LoginPageLink.GetHref(iter.Current);
				var template = this.SingleOrDefault(l => l.Href == href);

				if (template != null)
					Remove(template);

				var newValue = new LoginPageLink(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class LoginPageLink : ILoginPageLink
	{
		#region Fields
		private string _href;
		private string _text;
		private string _type;
		#endregion

		#region Constructors
		public LoginPageLink(XPathNodeIterator iter, ILoginPageLink template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_href = template.Href;
				_text = template.Text;
				_type = template.Type;
			}

			nav.SetString("href", ref _href);
			nav.SetString("text", ref _text);
			nav.SetString("type", ref _type);
		}
		#endregion

		#region Properties
		public string Href
		{
			get { return _href; }
		}

		public string Text
		{
			get { return _text; }
		}

		public string Type
		{
			get { return _type; }
		}
		#endregion

		#region Public Methods
		public static string GetHref(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("href", ref returnValue);
			return returnValue;
		}
		#endregion
	}

	public class Caching : ICaching
	{
		#region Fields
		private bool _isEnabledClients;
		private bool _isEnabledScopes;
		private bool _isEnabledUsers;
		private bool _isUseInMemoryStore;
		private eCacheType _customType;
		private TimeSpan _clientExpiry;
		private TimeSpan _scopeExpiry;
		private TimeSpan _userExpiry;
		private TimeSpan _usersExpiry;

		private XPathNavigator _nav;
		private ICaching _template = null;
		#endregion

		#region Constructors
		public Caching(XPathNodeIterator iter, ICaching template)
		{
			_template = template;

			if (_template != null)
			{
				_isEnabledClients = _template.IsEnabledClients;
				_isEnabledScopes = _template.IsEnabledScopes;
				_isEnabledUsers = _template.IsEnabledUsers;
				_isUseInMemoryStore = _template.IsUseInMemoryStore;
				_customType = _template.CustomType;
				_clientExpiry = _template.ClientExpiry;
				_scopeExpiry = _template.ScopeExpiry;
				_userExpiry = _template.UserExpiry;
				_usersExpiry = _template.UsersExpiry;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBool("isEnabledClients", ref _isEnabledClients);
				_nav.SetBool("isEnabledScopes", ref _isEnabledScopes);
				_nav.SetBool("isEnabledUsers", ref _isEnabledUsers);
				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				_nav.SetEnum("customType", ref _customType);
				_nav.SetTimeSpan("clientExpiry", ref _clientExpiry);
				_nav.SetTimeSpan("scopeExpiry", ref _scopeExpiry);
				_nav.SetTimeSpan("userExpiry", ref _userExpiry);
				_nav.SetTimeSpan("usersExpiry", ref _usersExpiry);
			}
		}
		#endregion

		#region Properties
		public bool IsEnabledClients
		{
			get { return _isEnabledClients; }
		}

		public bool IsEnabledScopes
		{
			get { return _isEnabledScopes; }
		}

		public bool IsEnabledUsers
		{
			get { return _isEnabledUsers; }
		}

		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}

		public eCacheType CustomType
		{
			get { return _customType; }
		}

		public TimeSpan ClientExpiry
		{
			get { return _clientExpiry; }
		}

		public TimeSpan ScopeExpiry
		{
			get { return _scopeExpiry; }
		}

		public TimeSpan UserExpiry
		{
			get { return _userExpiry; }
		}

		public TimeSpan UsersExpiry
		{
			get { return _usersExpiry; }
		}
		#endregion
	}

	public class Certificate : ICertificate
	{
		#region Fields
		private string _name;
		private StoreName _storeName;
		private StoreLocation _storeLocation;
		private string _fileName;
		private string _password;
		private X509KeyStorageFlags? _storageFlags;

		private XPathNavigator _nav;
		private ICertificate _template = null;
		#endregion

		#region Constructors
		public Certificate(XPathNodeIterator iter, ICertificate template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_name = template.Name;
				_storeName = template.StoreName;
				_storeLocation = template.StoreLocation;
				_fileName = template.FileName;
				_password = template.Password;
				_storageFlags = template.StorageFlags;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetString("name", ref _name);
				_nav.SetEnum("storeName", ref _storeName);
				_nav.SetEnum("storeLocation", ref _storeLocation);
				_nav.SetString("fileName", ref _fileName);
				_nav.SetString("password", ref _password);
				_nav.SetFlagsNullable("storageFlags", ref _storageFlags);
			}
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return _name; }
		}

		public StoreName StoreName
		{
			get { return _storeName; }
		}

		public StoreLocation StoreLocation
		{
			get { return _storeLocation; }
		}

		public string FileName
		{
			get { return _fileName; }
		}

		public string Password
		{
			get { return _password; }
		}

		public X509KeyStorageFlags? StorageFlags
		{
			get { return _storageFlags; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_storageFlags = X509KeyStorageFlags.UserKeySet;
		}
		#endregion
	}

	public class Cors : ICors
	{
		#region Fields
		private bool _isUseInMemoryStore;
		private bool _allowAllCustom;
		private List<string> _allowedOriginsCustom;

		private XPathNavigator _nav;
		private ICors _template = null;
		#endregion

		#region Constructors
		public Cors(XPathNodeIterator iter, ICors template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_isUseInMemoryStore = _template.IsUseInMemoryStore;
				_allowAllCustom = _template.AllowAllCustom;
				_allowedOriginsCustom = _template.AllowedOriginsCustom;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				_nav.SetBool("allowAllCustom", ref _allowAllCustom);
				_nav.SetListString("allowedOriginsCustom", ref _allowedOriginsCustom);
			}
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}

		public bool AllowAllCustom
		{
			get { return _allowAllCustom; }
		}

		public List<string> AllowedOriginsCustom
		{
			get { return _allowedOriginsCustom; }
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

	public class Csp : ICsp
	{
		#region Fields
		private string _connectSource;
		private bool? _enabled;
		private string _fontSource;
		private string _imageSource;
		private string _scriptSource;
		private string _styleSource;

		private XPathNavigator _nav;
		private ICsp _template = null;
		#endregion

		#region Constructors
		public Csp(XPathNodeIterator iter, ICsp template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_connectSource = template.ConnectSource;
				_enabled = template.Enabled;
				_fontSource = template.FontSource;
				_imageSource = template.ImageSource;
				_scriptSource = template.ScriptSource;
				_styleSource = template.StyleSource;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetString("connectSource", ref _connectSource);
				_nav.SetBoolNullable("enabled", ref _enabled);
				_nav.SetString("fontSource", ref _fontSource);
				_nav.SetString("imageSource", ref _imageSource);
				_nav.SetString("scriptSource", ref _scriptSource);
				_nav.SetString("styleSource", ref _styleSource);
			}
		}
		#endregion

		#region Properties
		public string ConnectSource
		{
			get { return _connectSource; }
		}

		public bool? Enabled
		{
			get { return _enabled; }
		}

		public string FontSource
		{
			get { return _fontSource; }
		}

		public string ImageSource
		{
			get { return _imageSource; }
		}

		public string ScriptSource
		{
			get { return _scriptSource; }
		}

		public string StyleSource
		{
			get { return _styleSource; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_enabled = true;
		}
		#endregion
	}

	public class EndPoints : IEndPoints
	{
		#region Fields
		private bool? _enableAuthorizeEndpoint;
		private bool? _enableTokenEndpoint;
		private bool? _enableUserInfoEndpoint;
		private bool? _enableDiscoveryEndpoint;
		private bool? _enableAccessTokenValidationEndpoint;
		private bool? _enableIdentityTokenValidationEndpoint;
		private bool? _enableEndSessionEndpoint;
		private bool? _enableClientPermissionsEndpoint;
		private bool? _enableCspReportEndpoint;
		private bool? _enableCheckSessionEndpoint;
		private bool? _enableTokenRevocationEndpoint;
		private bool? _enableIntrospectionEndpoint;

		private XPathNavigator _nav;
		private IEndPoints _template = null;
		#endregion

		#region Constructors
		public EndPoints(XPathNodeIterator iter, IEndPoints template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_enableAuthorizeEndpoint = template.EnableAuthorizeEndpoint;
				_enableTokenEndpoint = template.EnableTokenEndpoint;
				_enableUserInfoEndpoint = template.EnableUserInfoEndpoint;
				_enableDiscoveryEndpoint = template.EnableDiscoveryEndpoint;
				_enableAccessTokenValidationEndpoint = template.EnableAccessTokenValidationEndpoint;
				_enableIdentityTokenValidationEndpoint = template.EnableIdentityTokenValidationEndpoint;
				_enableEndSessionEndpoint = template.EnableEndSessionEndpoint;
				_enableClientPermissionsEndpoint = template.EnableClientPermissionsEndpoint;
				_enableCspReportEndpoint = template.EnableCspReportEndpoint;
				_enableCheckSessionEndpoint = template.EnableCheckSessionEndpoint;
				_enableTokenRevocationEndpoint = template.EnableTokenRevocationEndpoint;
				_enableIntrospectionEndpoint = template.EnableIntrospectionEndpoint;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("enableAuthorizeEndpoint", ref _enableAuthorizeEndpoint);
				_nav.SetBoolNullable("enableTokenEndpoint", ref _enableTokenEndpoint);
				_nav.SetBoolNullable("enableUserInfoEndpoint", ref _enableUserInfoEndpoint);
				_nav.SetBoolNullable("enableDiscoveryEndpoint", ref _enableDiscoveryEndpoint);
				_nav.SetBoolNullable("enableAccessTokenValidationEndpoint", ref _enableAccessTokenValidationEndpoint);
				_nav.SetBoolNullable("enableIdentityTokenValidationEndpoint", ref _enableIdentityTokenValidationEndpoint);
				_nav.SetBoolNullable("enableEndSessionEndpoint", ref _enableEndSessionEndpoint);
				_nav.SetBoolNullable("enableClientPermissionsEndpoint", ref _enableClientPermissionsEndpoint);
				_nav.SetBoolNullable("enableCspReportEndpoint", ref _enableCspReportEndpoint);
				_nav.SetBoolNullable("enableCheckSessionEndpoint", ref _enableCheckSessionEndpoint);
				_nav.SetBoolNullable("enableTokenRevocationEndpoint", ref _enableTokenRevocationEndpoint);
				_nav.SetBoolNullable("enableIntrospectionEndpoint", ref _enableIntrospectionEndpoint);
			}
		}
		#endregion

		#region Properties
		public bool? EnableAuthorizeEndpoint
		{
			get { return _enableAuthorizeEndpoint; }
		}

		public bool? EnableTokenEndpoint
		{
			get { return _enableTokenEndpoint; }
		}

		public bool? EnableUserInfoEndpoint
		{
			get { return _enableUserInfoEndpoint; }
		}

		public bool? EnableDiscoveryEndpoint
		{
			get { return _enableDiscoveryEndpoint; }
		}

		public bool? EnableAccessTokenValidationEndpoint
		{
			get { return _enableAccessTokenValidationEndpoint; }
		}

		public bool? EnableIdentityTokenValidationEndpoint
		{
			get { return _enableIdentityTokenValidationEndpoint; }
		}

		public bool? EnableEndSessionEndpoint
		{
			get { return _enableEndSessionEndpoint; }
		}

		public bool? EnableClientPermissionsEndpoint
		{
			get { return _enableClientPermissionsEndpoint; }
		}

		public bool? EnableCspReportEndpoint
		{
			get { return _enableCspReportEndpoint; }
		}

		public bool? EnableCheckSessionEndpoint
		{
			get { return _enableCheckSessionEndpoint; }
		}

		public bool? EnableTokenRevocationEndpoint
		{
			get { return _enableTokenRevocationEndpoint; }
		}

		public bool? EnableIntrospectionEndpoint
		{
			get { return _enableIntrospectionEndpoint; }
		}

		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_enableAuthorizeEndpoint = true;
			_enableTokenEndpoint = true;
			_enableUserInfoEndpoint = true;
			_enableDiscoveryEndpoint = true;
			_enableAccessTokenValidationEndpoint = true;
			_enableIdentityTokenValidationEndpoint = true;
			_enableEndSessionEndpoint = true;
			_enableClientPermissionsEndpoint = true;
			_enableCspReportEndpoint = true;
			_enableCheckSessionEndpoint = true;
			_enableTokenRevocationEndpoint = true;
			_enableIntrospectionEndpoint = true;
		}
		#endregion
	}

	public class Events : IEvents
	{
		#region Fields
		private bool? _raiseErrorEvents;
		private bool? _raiseFailureEvents;
		private bool? _raiseInformationEvents;
		private bool? _raiseSuccessEvents;

		private XPathNavigator _nav;
		private IEvents _template = null;
		#endregion

		#region Constructors
		public Events(XPathNodeIterator iter, IEvents template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_raiseErrorEvents = template.RaiseErrorEvents;
				_raiseFailureEvents = template.RaiseFailureEvents;
				_raiseInformationEvents = template.RaiseInformationEvents;
				_raiseSuccessEvents = template.RaiseSuccessEvents;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("raiseErrorEvents", ref _raiseErrorEvents);
				_nav.SetBoolNullable("raiseFailureEvents", ref _raiseFailureEvents);
				_nav.SetBoolNullable("raiseInformationEvents", ref _raiseInformationEvents);
				_nav.SetBoolNullable("raiseSuccessEvents", ref _raiseSuccessEvents);
			}
		}
		#endregion

		#region Properties
		public bool? RaiseErrorEvents
		{
			get { return _raiseErrorEvents; }
		}

		public bool? RaiseFailureEvents
		{
			get { return _raiseFailureEvents; }
		}

		public bool? RaiseInformationEvents
		{
			get { return _raiseInformationEvents; }
		}

		public bool? RaiseSuccessEvents
		{
			get { return _raiseSuccessEvents; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_raiseErrorEvents = false;
			_raiseFailureEvents = false;
			_raiseInformationEvents = false;
			_raiseSuccessEvents = false;
		}
		#endregion
	}

	public class InputLengthRestrictions : IInputLengthRestrictions
	{
		#region Fields
		private int? _acrValues;
		private int? _clientId;
		private int? _cspReport;
		private int? _grantType;
		private int? _identityProvider;
		private int? _loginHint;
		private int? _nonce;
		private int? _password;
		private int? _redirectUri;
		private int? _scope;
		private int? _uiLocale;
		private int? _userName;

		private XPathNavigator _nav;
		private IInputLengthRestrictions _template = null;
		#endregion

		#region Constructors
		public InputLengthRestrictions(XPathNodeIterator iter, IInputLengthRestrictions template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_acrValues = template.AcrValues;
				_clientId = template.ClientId;
				_cspReport = template.CspReport;
				_grantType = template.GrantType;
				_identityProvider = template.IdentityProvider;
				_loginHint = template.LoginHint;
				_nonce = template.Nonce;
				_password = template.Password;
				_redirectUri = template.RedirectUri;
				_scope = template.Scope;
				_uiLocale = template.UiLocale;
				_userName = template.UserName;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetIntNullable("acrValues", ref _acrValues);
				_nav.SetIntNullable("clientId", ref _clientId);
				_nav.SetIntNullable("cspReport", ref _cspReport);
				_nav.SetIntNullable("grantType", ref _grantType);
				_nav.SetIntNullable("identityProvider", ref _identityProvider);
				_nav.SetIntNullable("loginHint", ref _loginHint);
				_nav.SetIntNullable("nonce", ref _nonce);
				_nav.SetIntNullable("password", ref _password);
				_nav.SetIntNullable("redirectUri", ref _redirectUri);
				_nav.SetIntNullable("scope", ref _scope);
				_nav.SetIntNullable("uiLocale", ref _uiLocale);
				_nav.SetIntNullable("userName", ref _userName);
			}
		}
		#endregion

		#region Properties
		public int? AcrValues
		{
			get { return _acrValues; }
		}

		public int? ClientId
		{
			get { return _clientId; }
		}

		public int? CspReport
		{
			get { return _cspReport; }
		}

		public int? GrantType
		{
			get { return _grantType; }
		}

		public int? IdentityProvider
		{
			get { return _identityProvider; }
		}

		public int? LoginHint
		{
			get { return _loginHint; }
		}

		public int? Nonce
		{
			get { return _nonce; }
		}

		public int? Password
		{
			get { return _password; }
		}

		public int? RedirectUri
		{
			get { return _redirectUri; }
		}

		public int? Scope
		{
			get { return _scope; }
		}

		public int? UiLocale
		{
			get { return _uiLocale; }
		}

		public int? UserName
		{
			get { return _userName; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_acrValues = 300;
			_clientId = 100;
			_cspReport = 2000;
			_grantType = 100;
			_identityProvider = 100;
			_loginHint = 100;
			_nonce = 300;
			_password = 100;
			_redirectUri = 400;
			_scope = 300;
			_uiLocale = 100;
			_userName = 100;
		}
		#endregion
	}

	public class Logging : ILogging
	{
		#region Fields
		private bool? _enableHttpLogging;
		private bool? _enableKatanaLogging;
		private bool? _enableWebApiDiagnostics;
		private bool? _webApiDiagnosticsIsVerbose;

		private XPathNavigator _nav;
		private ILogging _template = null;
		#endregion

		#region Constructors
		public Logging(XPathNodeIterator iter, ILogging template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_enableHttpLogging = template.EnableHttpLogging;
				_enableKatanaLogging = template.EnableKatanaLogging;
				_enableWebApiDiagnostics = template.EnableWebApiDiagnostics;
				_webApiDiagnosticsIsVerbose = template.WebApiDiagnosticsIsVerbose;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("enableHttpLogging", ref _enableHttpLogging);
				_nav.SetBoolNullable("enableKatanaLogging", ref _enableKatanaLogging);
				_nav.SetBoolNullable("enableWebApiDiagnostics", ref _enableWebApiDiagnostics);
				_nav.SetBoolNullable("webApiDiagnosticsIsVerbose", ref _webApiDiagnosticsIsVerbose);
			}
		}
		#endregion

		#region Properties
		public bool? EnableHttpLogging
		{
			get { return _enableHttpLogging; }
		}

		public bool? EnableKatanaLogging
		{
			get { return _enableKatanaLogging; }
		}

		public bool? EnableWebApiDiagnostics
		{
			get { return _enableWebApiDiagnostics; }
		}

		public bool? WebApiDiagnosticsIsVerbose
		{
			get { return _webApiDiagnosticsIsVerbose; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_enableHttpLogging = false;
			_enableKatanaLogging = false;
			_enableWebApiDiagnostics = false;
			_webApiDiagnosticsIsVerbose = false;
		}
		#endregion
	}

	public class OperationalData : IOperationalData
	{
		#region Fields
		private bool _isUseInMemoryStore;
		private bool _isCleanUp;
		private int _tokenExpiry;
		private string _connectionKey;

		private XPathNavigator _nav;
		private IOperationalData _template = null;
		#endregion

		#region Constructors
		public OperationalData(XPathNodeIterator iter, IOperationalData template)
		{
			_template = template;

			if (_template != null)
			{
				_isUseInMemoryStore = template.IsUseInMemoryStore;
				_isCleanUp = template.IsCleanUp;
				_tokenExpiry = template.TokenExpiry;
				_connectionKey = template.ConnectionKey;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBool("isUseInMemoryStore", ref _isUseInMemoryStore);
				_nav.SetBool("isCleanUp", ref _isCleanUp);
				_nav.SetInt("tokenExpiry", ref _tokenExpiry);
				_nav.SetString("connectionKey", ref _connectionKey);
			}
		}
		#endregion

		#region Properties
		public bool IsUseInMemoryStore
		{
			get { return _isUseInMemoryStore; }
		}

		public bool IsCleanUp
		{
			get { return _isCleanUp; }
		}

		public int TokenExpiry
		{
			get { return _tokenExpiry; }
		}

		public string ConnectionKey
		{
			get { return _connectionKey; }
		}
		#endregion

		#region Private Methods
		#endregion
	}

	public class Tenants : List<ITenant>, ITenants
	{
		#region Constructors
		public Tenants(XPathNodeIterator iter, ITenants template)
		{
			if (template != null)
				template.Each(s => Add(s));

			if (iter.MoveNext())
				Initialize(iter);
		}
		#endregion

		#region Private Methods
		public void Initialize(XPathNodeIterator iter)
		{
			iter = iter.Current.Select("tenant");

			while (iter.MoveNext())
			{
				var id = Tenant.GetId(iter.Current);
				var template = this.SingleOrDefault(s => id.HasValue && s.Id == id.Value);

				if (template != null)
					Remove(template);

				var newValue = new Tenant(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class Tenant : ITenant
	{
		#region Fields
		private eTenant _id;
		private string _description;
		private string _connectionKey;
		#endregion

		#region Constructors
		public Tenant(XPathNodeIterator iter, ITenant template)
		{
			var nav = iter.Current;

			if (template != null)
			{
				_id = template.Id;
				_description = template.Description;
				_connectionKey = template.ConnectionKey;
			}

			nav.SetEnum("id", ref _id);
			nav.SetString("description", ref _description);
			nav.SetString("connectionKey", ref _connectionKey);
		}
		#endregion

		#region Properties
		public eTenant Id
		{
			get { return _id; }
		}

		public string Description
		{
			get { return _description; }
		}

		public string ConnectionKey
		{
			get { return _connectionKey; }
		}
		#endregion

		#region Public Methods
		public static eTenant? GetId(XPathNavigator nav)
		{
			var returnValue = new eTenant?();
			nav.SetEnumNullable("id", ref returnValue);
			return returnValue;
		}
		#endregion
	}
}
