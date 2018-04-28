using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
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
        private IEndPoints _endPoints;
        private IEvents _events;
        private IInputLengthRestrictions _inputLengthRestrictions;
        private ILogging _logging;
        private IOperationalData _operationalData;
        private ITenants _tenants;

        private XPathNavigator _nav;
        private IIdentityServerOptionsConfig _template = null;
        #endregion

        #region Constructors
        public IdentityServerOptionsConfig(XPathNodeIterator iter, IIdentityServerOptionsConfig template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            EnableWelcomePage = _nav.GetBoolNullable(nameof(EnableWelcomePage), _template);
            IssuerUri = _nav.GetString(nameof(IssuerUri), _template);
            ProtocolLogoutUrls = _nav.GetListString(nameof(ProtocolLogoutUrls), _template);
            PublicOrigin = _nav.GetString(nameof(PublicOrigin), _template);
            RequireSsl = _nav.GetBoolNullable(nameof(RequireSsl), _template);
            SiteName = _nav.GetString(nameof(SiteName), _template);
        }
        #endregion

        #region Properties
        public IAuthentication Authentication
        {
            get
            {
                if (_authentication == null)
                    _authentication = new Authentication(_nav.Select(nameof(Authentication).ToLowerFirstLetter()), _template != null ? _template.Authentication : null);

                return _authentication;
            }
        }

        public ICaching Caching
        {
            get
            {
                if (_caching == null)
                    _caching = new Caching(_nav.Select(nameof(Caching).ToLowerFirstLetter()), _template != null ? _template.Caching : null);

                return _caching;
            }
        }

        public ICertificate Certificate
        {
            get
            {
                if (_certificate == null)
                    _certificate = new Certificate(_nav.Select(nameof(Certificate).ToLowerFirstLetter()), _template != null ? _template.Certificate : null);

                return _certificate;
            }
        }

        public ICors Cors
        {
            get
            {
                if (_cors == null)
                    _cors = new Cors(_nav.Select(nameof(Cors).ToLowerFirstLetter()), _template != null ? _template.Cors : null);

                return _cors;
            }
        }

        public ICsp Csp
        {
            get
            {
                if (_csp == null)
                    _csp = new Csp(_nav.Select(nameof(Csp).ToLowerFirstLetter()), _template != null ? _template.Csp : null);

                return _csp;
            }
        }

        public bool? EnableWelcomePage { get; private set; }

        public IEndPoints EndPoints
        {
            get
            {
                if (_endPoints == null)
                    _endPoints = new EndPoints(_nav.Select(nameof(EndPoints).ToLowerFirstLetter()), _template != null ? _template.EndPoints : null);

                return _endPoints;
            }
        }

        public IEvents Events
        {
            get
            {
                if (_events == null)
                    _events = new Events(_nav.Select(nameof(Events).ToLowerFirstLetter()), _template != null ? _template.Events : null);

                return _events;
            }
        }

        public IInputLengthRestrictions InputLengthRestrictions
        {
            get
            {
                if (_inputLengthRestrictions == null)
                    _inputLengthRestrictions = new InputLengthRestrictions(_nav.Select(nameof(InputLengthRestrictions).ToLowerFirstLetter()), _template != null ? _template.InputLengthRestrictions : null);

                return _inputLengthRestrictions;
            }
        }

        public string IssuerUri { get; private set; }

        public ILogging Logging
        {
            get
            {
                if (_logging == null)
                    _logging = new Logging(_nav.Select(nameof(Logging).ToLowerFirstLetter()), _template != null ? _template.Logging : null);

                return _logging;
            }
        }

        public IOperationalData OperationalData
        {
            get
            {
                if (_operationalData == null)
                    _operationalData = new OperationalData(_nav.Select(nameof(OperationalData).ToLowerFirstLetter()), _template != null ? _template.OperationalData : null);

                return _operationalData;
            }
        }

        public List<string> ProtocolLogoutUrls { get; private set; }

        public string PublicOrigin { get; private set; }

        public bool? RequireSsl { get; private set; }

        public string SiteName { get; private set; }

        public ITenants Tenants
        {
            get
            {
                if (_tenants == null)
                    _tenants = new Tenants(_nav.Select(nameof(Tenants).ToLowerFirstLetter()), _template != null ? _template.Tenants : null);

                return _tenants;
            }
        }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            EnableWelcomePage = true;
            RequireSsl = true;
        }
        #endregion
    }

    public class Authentication : IAuthentication
    {
        #region Fields
        private ICookie _cookie;
        private ILoginPageLinks _loginPageLinks;

        private XPathNavigator _nav;
        private IAuthentication _template = null;
        #endregion

        #region Constructors
        public Authentication(XPathNodeIterator iter, IAuthentication template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            EnableLoginHint = _nav.GetBoolNullable(nameof(EnableLoginHint), _template);
            EnableLocalLogin = _nav.GetBoolNullable(nameof(EnableLocalLogin), _template);
            EnablePostSignOutAutoRedirect = _nav.GetBoolNullable(nameof(EnablePostSignOutAutoRedirect), _template);
            EnableSignOutPrompt = _nav.GetBoolNullable(nameof(EnableSignOutPrompt), _template);
            InvalidSignInRedirectUrl = _nav.GetString(nameof(InvalidSignInRedirectUrl), _template);
            PostSignOutAutoRedirectDelay = _nav.GetIntNullable(nameof(PostSignOutAutoRedirectDelay), _template);
            RememberLastUsername = _nav.GetBoolNullable(nameof(RememberLastUsername), _template);
            RequireAuthenticatedUserForSignOutMessage = _nav.GetBoolNullable(nameof(RequireAuthenticatedUserForSignOutMessage), _template);
            SignInMessageThreshold = _nav.GetIntNullable(nameof(SignInMessageThreshold), _template);
            IsEnableExternalWindowsAuthentication = _nav.GetBool(nameof(IsEnableExternalWindowsAuthentication), _template);
            ExternalWindowsAuthenticationCaption = _nav.GetString(nameof(ExternalWindowsAuthenticationCaption), _template);
            ResetPasswordRedirectUri = _nav.GetString(nameof(ResetPasswordRedirectUri), _template);
            ResetPasswordUri = _nav.GetString(nameof(ResetPasswordUri), _template);
        }
        #endregion

        #region Properties
        public ICookie Cookie
        {
            get
            {
                if (_cookie == null)
                    _cookie = new Cookie(_nav.Select(nameof(Cookie).ToLowerFirstLetter()), _template != null ? _template.Cookie : null);

                return _cookie;
            }
        }

        public bool? EnableLoginHint { get; private set; }

        public bool? EnableLocalLogin { get; private set; }

        public bool? EnablePostSignOutAutoRedirect { get; private set; }

        public bool? EnableSignOutPrompt { get; private set; }

        public string InvalidSignInRedirectUrl { get; private set; }

        public ILoginPageLinks LoginPageLinks
        {
            get
            {
                if (_loginPageLinks == null)
                    _loginPageLinks = new LoginPageLinks(_nav.Select(nameof(LoginPageLinks).ToLowerFirstLetter()), _template != null ? _template.LoginPageLinks : null);

                return _loginPageLinks;
            }
        }

        public int? PostSignOutAutoRedirectDelay { get; private set; }

        public bool? RememberLastUsername { get; private set; }

        public bool? RequireAuthenticatedUserForSignOutMessage { get; private set; }

        public int? SignInMessageThreshold { get; private set; }

        public bool IsEnableExternalWindowsAuthentication { get; private set; }

        public string ExternalWindowsAuthenticationCaption { get; private set; }

        public string ResetPasswordRedirectUri { get; private set; }

        public string ResetPasswordUri { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            EnableLoginHint = true;
            EnableLocalLogin = true;
            EnablePostSignOutAutoRedirect = false;
            EnableSignOutPrompt = true;
            PostSignOutAutoRedirectDelay = 0;
            RememberLastUsername = false;
            RequireAuthenticatedUserForSignOutMessage = false;
            SignInMessageThreshold = 5;
        }
        #endregion
    }

    public class Cookie : ICookie
    {
        #region Fields
        private XPathNavigator _nav;
        private ICookie _template = null;
        #endregion

        #region Constructors
        public Cookie(XPathNodeIterator iter, ICookie template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            AllowRememberMe = _nav.GetBoolNullable(nameof(AllowRememberMe), _template);
            ExpireTimeSpan = _nav.GetTimeSpanNullable(nameof(ExpireTimeSpan), _template);
            IsPersistent = _nav.GetBoolNullable(nameof(IsPersistent), _template);
            Path = _nav.GetString(nameof(Path), _template);
            Prefix = _nav.GetString(nameof(Prefix), _template);
            RememberMeDuration = _nav.GetTimeSpanNullable(nameof(RememberMeDuration), _template);
            SecureMode = _nav.GetEnumNullable<eCookieSecureMode>(nameof(SecureMode), _template);
            SlidingExpiration = _nav.GetBoolNullable(nameof(SlidingExpiration), _template);
        }
        #endregion

        #region Properties
        public bool? AllowRememberMe { get; private set; }

        public TimeSpan? ExpireTimeSpan { get; private set; }

        public bool? IsPersistent { get; private set; }

        public string Path { get; private set; }

        public string Prefix { get; private set; }

        public TimeSpan? RememberMeDuration { get; private set; }

        public eCookieSecureMode? SecureMode { get; private set; }

        public bool? SlidingExpiration { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            AllowRememberMe = true;
            ExpireTimeSpan = TimeSpan.FromHours(10);
            IsPersistent = false;
            RememberMeDuration = TimeSpan.FromDays(30);
            SecureMode = eCookieSecureMode.SameAsRequest;
            SlidingExpiration = false;
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
        #region Constructors
        public LoginPageLink(XPathNodeIterator iter, ILoginPageLink template)
        {
            var nav = iter.Current;

            Href = nav.GetString(nameof(Href), template);
            Text = nav.GetString(nameof(Text), template);
            Type = nav.GetString(nameof(Type), template);
        }
        #endregion

        #region Properties
        public string Href { get; private set; }

        public string Text { get; private set; }

        public string Type { get; private set; }
        #endregion

        #region Public Methods
        public static string GetHref(XPathNavigator nav)
        {
            return nav.GetString(nameof(Href));
        }
        #endregion
    }

    public class Caching : ICaching
    {
        #region Fields
        private XPathNavigator _nav;
        private ICaching _template = null;
        #endregion

        #region Constructors
        public Caching(XPathNodeIterator iter, ICaching template)
        {
            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            IsEnabledClients = _nav.GetBool(nameof(IsEnabledClients), _template);
            IsEnabledScopes = _nav.GetBool(nameof(IsEnabledScopes), _template);
            IsEnabledUsers = _nav.GetBool(nameof(IsEnabledUsers), _template);
            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);
            CustomType = _nav.GetEnum<eCacheType>(nameof(CustomType), _template);
            ClientExpiry = _nav.GetTimeSpan(nameof(ClientExpiry), _template);
            ScopeExpiry = _nav.GetTimeSpan(nameof(ScopeExpiry), _template);
            UserExpiry = _nav.GetTimeSpan(nameof(UserExpiry), _template);
            UsersExpiry = _nav.GetTimeSpan(nameof(UsersExpiry), _template);
        }
        #endregion

        #region Properties
        public bool IsEnabledClients { get; private set; }

        public bool IsEnabledScopes { get; private set; }

        public bool IsEnabledUsers { get; private set; }

        public bool IsUseInMemoryStore { get; private set; }

        public eCacheType CustomType { get; private set; }

        public TimeSpan ClientExpiry { get; private set; }

        public TimeSpan ScopeExpiry { get; private set; }

        public TimeSpan UserExpiry { get; private set; }

        public TimeSpan UsersExpiry { get; private set; }
        #endregion
    }

    public class Certificate : ICertificate
    {
        #region Fields
        private XPathNavigator _nav;
        private ICertificate _template = null;
        #endregion

        #region Constructors
        public Certificate(XPathNodeIterator iter, ICertificate template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            Name = _nav.GetString(nameof(Name), _template);
            StoreName = _nav.GetEnum<StoreName>(nameof(StoreName), _template);
            StoreLocation = _nav.GetEnum<StoreLocation>(nameof(StoreLocation), _template);
            FileName = _nav.GetString(nameof(FileName), _template);
            Password = _nav.GetString(nameof(Password), _template);
            StorageFlags = _nav.GetFlagsNullable<X509KeyStorageFlags>(nameof(StorageFlags), _template);
        }
        #endregion

        #region Properties
        public string Name { get; private set; }

        public StoreName StoreName { get; private set; }

        public StoreLocation StoreLocation { get; private set; }

        public string FileName { get; private set; }

        public string Password { get; private set; }

        public X509KeyStorageFlags? StorageFlags { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            StorageFlags = X509KeyStorageFlags.UserKeySet;
        }
        #endregion
    }

    public class Cors : ICors
    {
        #region Fields
        private XPathNavigator _nav;
        private ICors _template = null;
        #endregion

        #region Constructors
        public Cors(XPathNodeIterator iter, ICors template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);
            AllowAllCustom = _nav.GetBool(nameof(AllowAllCustom), _template);
            AllowedOriginsCustom = _nav.GetListString(nameof(AllowedOriginsCustom), _template);
        }
        #endregion

        #region Properties
        public bool IsUseInMemoryStore { get; private set; }

        public bool AllowAllCustom { get; private set; }

        public List<string> AllowedOriginsCustom { get; private set; }
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
        private XPathNavigator _nav;
        private ICsp _template = null;
        #endregion

        #region Constructors
        public Csp(XPathNodeIterator iter, ICsp template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            ConnectSource = _nav.GetString(nameof(ConnectSource), _template);
            Enabled = _nav.GetBoolNullable(nameof(Enabled), _template);
            FontSource = _nav.GetString(nameof(FontSource), _template);
            ImageSource = _nav.GetString(nameof(ImageSource), _template);
            ScriptSource = _nav.GetString(nameof(ScriptSource), _template);
            StyleSource = _nav.GetString(nameof(StyleSource), _template);
        }
        #endregion

        #region Properties
        public string ConnectSource { get; private set; }

        public bool? Enabled { get; private set; }

        public string FontSource { get; private set; }

        public string ImageSource { get; private set; }

        public string ScriptSource { get; private set; }

        public string StyleSource { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            Enabled = true;
        }
        #endregion
    }

    public class EndPoints : IEndPoints
    {
        #region Fields
        private XPathNavigator _nav;
        private IEndPoints _template = null;
        #endregion

        #region Constructors
        public EndPoints(XPathNodeIterator iter, IEndPoints template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            EnableAuthorizeEndpoint = _nav.GetBoolNullable(nameof(EnableAuthorizeEndpoint), _template);
            EnableTokenEndpoint = _nav.GetBoolNullable(nameof(EnableTokenEndpoint), _template);
            EnableUserInfoEndpoint = _nav.GetBoolNullable(nameof(EnableUserInfoEndpoint), _template);
            EnableDiscoveryEndpoint = _nav.GetBoolNullable(nameof(EnableDiscoveryEndpoint), _template);
            EnableAccessTokenValidationEndpoint = _nav.GetBoolNullable(nameof(EnableAccessTokenValidationEndpoint), _template);
            EnableIdentityTokenValidationEndpoint = _nav.GetBoolNullable(nameof(EnableIdentityTokenValidationEndpoint), _template);
            EnableEndSessionEndpoint = _nav.GetBoolNullable(nameof(EnableEndSessionEndpoint), _template);
            EnableClientPermissionsEndpoint = _nav.GetBoolNullable(nameof(EnableClientPermissionsEndpoint), _template);
            EnableCspReportEndpoint = _nav.GetBoolNullable(nameof(EnableCspReportEndpoint), _template);
            EnableCheckSessionEndpoint = _nav.GetBoolNullable(nameof(EnableCheckSessionEndpoint), _template);
            EnableTokenRevocationEndpoint = _nav.GetBoolNullable(nameof(EnableTokenRevocationEndpoint), _template);
            EnableIntrospectionEndpoint = _nav.GetBoolNullable(nameof(EnableIntrospectionEndpoint), _template);
        }
        #endregion

        #region Properties
        public bool? EnableAuthorizeEndpoint { get; private set; }

        public bool? EnableTokenEndpoint { get; private set; }

        public bool? EnableUserInfoEndpoint { get; private set; }

        public bool? EnableDiscoveryEndpoint { get; private set; }

        public bool? EnableAccessTokenValidationEndpoint { get; private set; }

        public bool? EnableIdentityTokenValidationEndpoint { get; private set; }

        public bool? EnableEndSessionEndpoint { get; private set; }

        public bool? EnableClientPermissionsEndpoint { get; private set; }

        public bool? EnableCspReportEndpoint { get; private set; }

        public bool? EnableCheckSessionEndpoint { get; private set; }

        public bool? EnableTokenRevocationEndpoint { get; private set; }

        public bool? EnableIntrospectionEndpoint { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            EnableAuthorizeEndpoint = true;
            EnableTokenEndpoint = true;
            EnableUserInfoEndpoint = true;
            EnableDiscoveryEndpoint = true;
            EnableAccessTokenValidationEndpoint = true;
            EnableIdentityTokenValidationEndpoint = true;
            EnableEndSessionEndpoint = true;
            EnableClientPermissionsEndpoint = true;
            EnableCspReportEndpoint = true;
            EnableCheckSessionEndpoint = true;
            EnableTokenRevocationEndpoint = true;
            EnableIntrospectionEndpoint = true;
        }
        #endregion
    }

    public class Events : IEvents
    {
        #region Fields
        private XPathNavigator _nav;
        private IEvents _template = null;
        #endregion

        #region Constructors
        public Events(XPathNodeIterator iter, IEvents template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            RaiseErrorEvents = _nav.GetBoolNullable(nameof(RaiseErrorEvents), _template);
            RaiseFailureEvents = _nav.GetBoolNullable(nameof(RaiseFailureEvents), _template);
            RaiseInformationEvents = _nav.GetBoolNullable(nameof(RaiseInformationEvents), _template);
            RaiseSuccessEvents = _nav.GetBoolNullable(nameof(RaiseSuccessEvents), _template);
        }
        #endregion

        #region Properties
        public bool? RaiseErrorEvents { get; private set; }

        public bool? RaiseFailureEvents { get; private set; }

        public bool? RaiseInformationEvents { get; private set; }

        public bool? RaiseSuccessEvents { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            RaiseErrorEvents = false;
            RaiseFailureEvents = false;
            RaiseInformationEvents = false;
            RaiseSuccessEvents = false;
        }
        #endregion
    }

    public class InputLengthRestrictions : IInputLengthRestrictions
    {
        #region Fields
        private XPathNavigator _nav;
        private IInputLengthRestrictions _template = null;
        #endregion

        #region Constructors
        public InputLengthRestrictions(XPathNodeIterator iter, IInputLengthRestrictions template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            AcrValues = _nav.GetIntNullable(nameof(AcrValues), _template);
            ClientId = _nav.GetIntNullable(nameof(ClientId), _template);
            CspReport = _nav.GetIntNullable(nameof(CspReport), _template);
            GrantType = _nav.GetIntNullable(nameof(GrantType), _template);
            IdentityProvider = _nav.GetIntNullable(nameof(IdentityProvider), _template);
            LoginHint = _nav.GetIntNullable(nameof(LoginHint), _template);
            Nonce = _nav.GetIntNullable(nameof(Nonce), _template);
            Password = _nav.GetIntNullable(nameof(Password), _template);
            RedirectUri = _nav.GetIntNullable(nameof(RedirectUri), _template);
            Scope = _nav.GetIntNullable(nameof(Scope), _template);
            UiLocale = _nav.GetIntNullable(nameof(UiLocale), _template);
            UserName = _nav.GetIntNullable(nameof(UserName), _template);
        }
        #endregion

        #region Properties
        public int? AcrValues { get; private set; }

        public int? ClientId { get; private set; }

        public int? CspReport { get; private set; }

        public int? GrantType { get; private set; }

        public int? IdentityProvider { get; private set; }

        public int? LoginHint { get; private set; }

        public int? Nonce { get; private set; }

        public int? Password { get; private set; }

        public int? RedirectUri { get; private set; }

        public int? Scope { get; private set; }

        public int? UiLocale { get; private set; }

        public int? UserName { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            AcrValues = 300;
            ClientId = 100;
            CspReport = 2000;
            GrantType = 100;
            IdentityProvider = 100;
            LoginHint = 100;
            Nonce = 300;
            Password = 100;
            RedirectUri = 400;
            Scope = 300;
            UiLocale = 100;
            UserName = 100;
        }
        #endregion
    }

    public class Logging : ILogging
    {
        #region Fields
        private XPathNavigator _nav;
        private ILogging _template = null;
        #endregion

        #region Constructors
        public Logging(XPathNodeIterator iter, ILogging template)
        {
            SetKnownDefaults();

            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            EnableHttpLogging = _nav.GetBoolNullable(nameof(EnableHttpLogging), _template);
            EnableKatanaLogging = _nav.GetBoolNullable(nameof(EnableKatanaLogging), _template);
            EnableWebApiDiagnostics = _nav.GetBoolNullable(nameof(EnableWebApiDiagnostics), _template);
            WebApiDiagnosticsIsVerbose = _nav.GetBoolNullable(nameof(WebApiDiagnosticsIsVerbose), _template);
        }
        #endregion

        #region Properties
        public bool? EnableHttpLogging { get; private set; }

        public bool? EnableKatanaLogging { get; private set; }

        public bool? EnableWebApiDiagnostics { get; private set; }

        public bool? WebApiDiagnosticsIsVerbose { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
        {
            if (!IdentityServerConfig.IsLoadKnownDefaults)
                return;

            EnableHttpLogging = false;
            EnableKatanaLogging = false;
            EnableWebApiDiagnostics = false;
            WebApiDiagnosticsIsVerbose = false;
        }
        #endregion
    }

    public class OperationalData : IOperationalData
    {
        #region Fields
        private XPathNavigator _nav;
        private IOperationalData _template = null;
        #endregion

        #region Constructors
        public OperationalData(XPathNodeIterator iter, IOperationalData template)
        {
            _template = template;

            iter.MoveNext();
            _nav = iter.Current;

            IsUseInMemoryStore = _nav.GetBool(nameof(IsUseInMemoryStore), _template);
            IsCleanUp = _nav.GetBool(nameof(IsCleanUp), _template);
            TokenExpiry = _nav.GetInt(nameof(TokenExpiry), _template);
            ConnectionKey = _nav.GetString(nameof(ConnectionKey), _template);
        }
        #endregion

        #region Properties
        public bool IsUseInMemoryStore { get; private set; }

        public bool IsCleanUp { get; private set; }

        public int TokenExpiry { get; private set; }

        public string ConnectionKey { get; private set; }
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
            iter = iter.Current.Select(nameof(Tenant).ToLowerFirstLetter());

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
        #region Constructors
        public Tenant(XPathNodeIterator iter, ITenant template)
        {
            var nav = iter.Current;

            Id = nav.GetEnum<eTenant>(nameof(Id), template);
            Description = nav.GetString(nameof(Description), template);
            ConnectionKey = nav.GetString(nameof(ConnectionKey), template);
        }
        #endregion

        #region Properties
        public eTenant Id { get; private set; }

        public string Description { get; private set; }

        public string ConnectionKey { get; private set; }
        #endregion

        #region Public Methods
        public static eTenant? GetId(XPathNavigator nav)
        {
            return nav.GetEnumNullable<eTenant>(nameof(Id));
        }
        #endregion
    }
}
