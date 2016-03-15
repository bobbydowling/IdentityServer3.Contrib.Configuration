using System;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class AspNetIdentityConfig : IAspNetIdentityConfig
	{
		#region Fields
		private IPassword _password;
		private IUserManager _userManager;

		private XPathNavigator _nav;
		private IAspNetIdentityConfig _template = null;
		#endregion

		#region Constructors
		public AspNetIdentityConfig(XPathNavigator nav, IAspNetIdentityConfig template)
		{
			_template = template;
			_nav = nav;

			SetIsLoadKnownDefaults(_nav);
		}
		#endregion

		#region Properties
		internal static bool IsLoadKnownDefaults { get; private set; }

		public IPassword Password
		{
			get
			{
				if (_password == null)
					_password = new Password(GetChild(_nav, "password"), _template != null ? _template.Password : null);

				return _password;
			}
		}

		public IUserManager UserManager
		{
			get
			{
				if (_userManager == null)
					_userManager = new UserManager(GetChild(_nav, "userManager"), _template != null ? _template.UserManager : null);

				return _userManager;
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
			var value = nav.GetAttribute("isLoadKnownDefaults", string.Empty);

			if (value.HasValue())
				IsLoadKnownDefaults = bool.Parse(value);
		}
		#endregion
	}

	public class Password : IPassword
	{
		#region Fields
		private int _requiredLength;
		private string _matchPattern;
		private string _matchPatternMessage;
		private int _historyLimit;
		private int _expiryDays;

		private XPathNavigator _nav;
		private IPassword _template = null;
		#endregion

		#region Constructors
		public Password(XPathNavigator nav, IPassword template)
		{
			_template = template;
			_nav = nav;

			if (_template != null)
			{
				_requiredLength = _template.RequiredLength;
				_matchPattern = _template.MatchPattern;
				_matchPatternMessage = _template.MatchPatternMessage;
				_historyLimit = _template.HistoryLimit;
				_expiryDays = _template.ExpiryDays;
			}

			_nav.SetInt("requiredLength", ref _requiredLength);
			_nav.SetString("matchPattern", ref _matchPattern);
			_nav.SetString("matchPatternMessage", ref _matchPatternMessage);
			_nav.SetInt("historyLimit", ref _historyLimit);
			_nav.SetInt("expiryDays", ref _expiryDays);
		}
		#endregion

		#region Properties
		public int RequiredLength
		{
			get { return _requiredLength; }
		}

		public string MatchPattern
		{
			get { return _matchPattern; }
		}

		public string MatchPatternMessage
		{
			get { return _matchPatternMessage; }
		}

		public int HistoryLimit
		{
			get { return _historyLimit; }
		}

		public int ExpiryDays
		{
			get { return _expiryDays; }
		}

		#endregion
	}

	public class UserManager : IUserManager
	{
		#region Fields
		private bool? _isUserLockoutEnabledByDefault;
		private TimeSpan? _defaultAccountLockoutTimeSpan;
		private int? _maxFailedAccessAttemptsBeforeLockout;
		private ISupportedFields _supportedFields;
		private TimeSpan _tokenProviderTokenExpiration;

		private XPathNavigator _nav;
		private IUserManager _template = null;
		#endregion

		#region Constructors
		public UserManager(XPathNavigator nav, IUserManager template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_isUserLockoutEnabledByDefault = template.IsUserLockoutEnabledByDefault;
				_defaultAccountLockoutTimeSpan = template.DefaultAccountLockoutTimeSpan;
				_maxFailedAccessAttemptsBeforeLockout = template.MaxFailedAccessAttemptsBeforeLockout;
				_tokenProviderTokenExpiration = template.TokenProviderTokenExpiration;
			}

			nav.SetBoolNullable("isUserLockoutEnabledByDefault", ref _isUserLockoutEnabledByDefault);
			nav.SetTimeSpanNullable("defaultAccountLockoutTimeSpan", ref _defaultAccountLockoutTimeSpan);
			nav.SetIntNullable("maxFailedAccessAttemptsBeforeLockout", ref _maxFailedAccessAttemptsBeforeLockout);
			nav.SetTimeSpan("tokenProviderTokenExpiration", ref _tokenProviderTokenExpiration);

			_nav = nav;
		}
		#endregion

		#region Properties
		public bool? IsUserLockoutEnabledByDefault
		{
			get { return _isUserLockoutEnabledByDefault; }
		}

		public TimeSpan? DefaultAccountLockoutTimeSpan
		{
			get { return _defaultAccountLockoutTimeSpan; }
		}

		public int? MaxFailedAccessAttemptsBeforeLockout
		{
			get { return _maxFailedAccessAttemptsBeforeLockout; }
		}

		public ISupportedFields SupportedFields
		{
			get
			{
				if (_supportedFields == null)
					_supportedFields = new SupportedFields(_nav.Select("supportedFields"), _template != null ? _template.SupportedFields : null);

				return _supportedFields;
			}
		}

		public TimeSpan TokenProviderTokenExpiration
		{
			get { return _tokenProviderTokenExpiration; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_isUserLockoutEnabledByDefault = true;
			_defaultAccountLockoutTimeSpan = new TimeSpan(0, 10, 0);
			_maxFailedAccessAttemptsBeforeLockout = 3;
		}
		#endregion
	}

	public class SupportedFields : ISupportedFields
	{
		#region Fields
		private bool? _isSupportsQueryableUsers;
		private bool? _isSupportsUserClaim;
		private bool? _isSupportsUserEmail;
		private bool? _isSupportsUserLockout;
		private bool? _isSupportsUserLogin;
		private bool? _isSupportsUserPassword;
		private bool? _isSupportsUserPhoneNumber;
		private bool? _isSupportsUserRole;
		private bool? _isSupportsUserSecurityStamp;
		private bool? _isSupportsUserTwoFactor;

		private XPathNavigator _nav;
		private ISupportedFields _template = null;
		#endregion

		#region Constructors
		public SupportedFields(XPathNodeIterator iter, ISupportedFields template)
		{
			SetKnownDefaults();

			_template = template;

			if (_template != null)
			{
				_isSupportsQueryableUsers = _template.IsSupportsQueryableUsers;
				_isSupportsUserClaim = _template.IsSupportsUserClaim;
				_isSupportsUserEmail = _template.IsSupportsUserEmail;
				_isSupportsUserLockout = _template.IsSupportsUserLockout;
				_isSupportsUserLogin = _template.IsSupportsUserLogin;
				_isSupportsUserPassword = _template.IsSupportsUserPassword;
				_isSupportsUserPhoneNumber = _template.IsSupportsUserPhoneNumber;
				_isSupportsUserRole = _template.IsSupportsUserRole;
				_isSupportsUserSecurityStamp = _template.IsSupportsUserSecurityStamp;
				_isSupportsUserTwoFactor = _template.IsSupportsUserTwoFactor;
			}

			var isMoveNext = iter.MoveNext();
			_nav = iter.Current;

			if (isMoveNext)
			{
				_nav.SetBoolNullable("isSupportsQueryableUsers", ref _isSupportsQueryableUsers);
				_nav.SetBoolNullable("isSupportsUserClaim", ref _isSupportsUserClaim);
				_nav.SetBoolNullable("isSupportsUserEmail", ref _isSupportsUserEmail);
				_nav.SetBoolNullable("isSupportsUserLockout", ref _isSupportsUserLockout);
				_nav.SetBoolNullable("isSupportsUserLogin", ref _isSupportsUserLogin);
				_nav.SetBoolNullable("isSupportsUserPassword", ref _isSupportsUserPassword);
				_nav.SetBoolNullable("isSupportsUserPhoneNumber", ref _isSupportsUserPhoneNumber);
				_nav.SetBoolNullable("isSupportsUserRole", ref _isSupportsUserRole);
				_nav.SetBoolNullable("isSupportsUserSecurityStamp", ref _isSupportsUserSecurityStamp);
				_nav.SetBoolNullable("isSupportsUserTwoFactor", ref _isSupportsUserTwoFactor);
			}
		}
		#endregion

		#region Properties
		public bool? IsSupportsQueryableUsers
		{
			get { return _isSupportsQueryableUsers; }
		}

		public bool? IsSupportsUserClaim
		{
			get { return _isSupportsUserClaim; }
		}

		public bool? IsSupportsUserEmail
		{
			get { return _isSupportsUserEmail; }
		}

		public bool? IsSupportsUserLockout
		{
			get { return _isSupportsUserLockout; }
		}

		public bool? IsSupportsUserLogin
		{
			get { return _isSupportsUserLogin; }
		}

		public bool? IsSupportsUserPassword
		{
			get { return _isSupportsUserPassword; }
		}

		public bool? IsSupportsUserPhoneNumber
		{
			get { return _isSupportsUserPhoneNumber; }
		}

		public bool? IsSupportsUserRole
		{
			get { return _isSupportsUserRole; }
		}

		public bool? IsSupportsUserSecurityStamp
		{
			get { return _isSupportsUserSecurityStamp; }
		}

		public bool? IsSupportsUserTwoFactor
		{
			get { return _isSupportsUserTwoFactor; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_isSupportsQueryableUsers = true;
			_isSupportsUserClaim = true;
			_isSupportsUserEmail = true;
			_isSupportsUserLockout = true;
			_isSupportsUserLogin = true;
			_isSupportsUserPassword = true;
			_isSupportsUserPhoneNumber = true;
			_isSupportsUserRole = true;
			_isSupportsUserSecurityStamp = true;
			_isSupportsUserTwoFactor = true;
		}
		#endregion
	}
}
