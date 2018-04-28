using System;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Extension;
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
					_password = new Password(GetChild(_nav, nameof(Password).ToLowerFirstLetter()), _template != null ? _template.Password : null);

				return _password;
			}
		}

		public IUserManager UserManager
		{
			get
			{
				if (_userManager == null)
					_userManager = new UserManager(GetChild(_nav, nameof(UserManager).ToLowerFirstLetter()), _template != null ? _template.UserManager : null);

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
			var value = nav.GetAttribute(nameof(IsLoadKnownDefaults).ToLowerFirstLetter(), string.Empty);

			if (value.HasValue())
				IsLoadKnownDefaults = bool.Parse(value);
		}
		#endregion
	}

	public class Password : IPassword
	{
		#region Fields
		private XPathNavigator _nav;
		private IPassword _template = null;
		#endregion

		#region Constructors
		public Password(XPathNavigator nav, IPassword template)
		{
			_template = template;
			_nav = nav;

            RequiredLength = _nav.GetInt(nameof(RequiredLength), _template);
            MatchPattern = _nav.GetString(nameof(MatchPattern), _template);
            MatchPatternMessage = _nav.GetString(nameof(MatchPatternMessage), _template);
            HistoryLimit = _nav.GetInt(nameof(HistoryLimit), _template);
            ExpiryDays = _nav.GetInt(nameof(ExpiryDays), _template);
		}
		#endregion

		#region Properties
		public int RequiredLength { get; private set; }

		public string MatchPattern { get; private set; }

        public string MatchPatternMessage { get; private set; }

        public int HistoryLimit { get; private set; }

        public int ExpiryDays { get; private set; }
        #endregion
    }

	public class UserManager : IUserManager
	{
		#region Fields
		private ISupportedFields _supportedFields;
		private XPathNavigator _nav;
		private IUserManager _template = null;
		#endregion

		#region Constructors
		public UserManager(XPathNavigator nav, IUserManager template)
		{
			SetKnownDefaults();

			_template = template;
            _nav = nav;

            IsUserLockoutEnabledByDefault = _nav.GetBoolNullable(nameof(IsUserLockoutEnabledByDefault), _template);
            DefaultAccountLockoutTimeSpan = _nav.GetTimeSpanNullable(nameof(DefaultAccountLockoutTimeSpan), _template);
            MaxFailedAccessAttemptsBeforeLockout = _nav.GetIntNullable(nameof(MaxFailedAccessAttemptsBeforeLockout), _template);
            TokenProviderTokenExpiration = _nav.GetTimeSpan(nameof(TokenProviderTokenExpiration), _template);

			_nav = nav;
		}
		#endregion

		#region Properties
		public bool? IsUserLockoutEnabledByDefault { get; private set; }

        public TimeSpan? DefaultAccountLockoutTimeSpan { get; private set; }

        public int? MaxFailedAccessAttemptsBeforeLockout { get; private set; }

        public ISupportedFields SupportedFields
		{
			get
			{
				if (_supportedFields == null)
					_supportedFields = new SupportedFields(_nav.Select(nameof(SupportedFields).ToLowerFirstLetter()), _template != null ? _template.SupportedFields : null);

				return _supportedFields;
			}
		}

		public TimeSpan TokenProviderTokenExpiration { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			IsUserLockoutEnabledByDefault = true;
			DefaultAccountLockoutTimeSpan = new TimeSpan(0, 10, 0);
			MaxFailedAccessAttemptsBeforeLockout = 3;
		}
		#endregion
	}

	public class SupportedFields : ISupportedFields
	{
		#region Fields
		private XPathNavigator _nav;
		private ISupportedFields _template = null;
		#endregion

		#region Constructors
		public SupportedFields(XPathNodeIterator iter, ISupportedFields template)
		{
			SetKnownDefaults();

			_template = template;

			iter.MoveNext();
			_nav = iter.Current;

            IsSupportsQueryableUsers = _nav.GetBoolNullable(nameof(IsSupportsQueryableUsers), _template);
            IsSupportsUserClaim = _nav.GetBoolNullable(nameof(IsSupportsUserClaim), _template);
            IsSupportsUserEmail = _nav.GetBoolNullable(nameof(IsSupportsUserEmail), _template);
            IsSupportsUserLockout = _nav.GetBoolNullable(nameof(IsSupportsUserLockout), _template);
            IsSupportsUserLogin = _nav.GetBoolNullable(nameof(IsSupportsUserLogin), _template);
            IsSupportsUserPassword = _nav.GetBoolNullable(nameof(IsSupportsUserPassword), _template);
            IsSupportsUserPhoneNumber = _nav.GetBoolNullable(nameof(IsSupportsUserPhoneNumber), _template);
            IsSupportsUserRole = _nav.GetBoolNullable(nameof(IsSupportsUserRole), _template);
            IsSupportsUserSecurityStamp = _nav.GetBoolNullable(nameof(IsSupportsUserSecurityStamp), _template);
            IsSupportsUserTwoFactor = _nav.GetBoolNullable(nameof(IsSupportsUserTwoFactor), _template);
        }
		#endregion

		#region Properties
		public bool? IsSupportsQueryableUsers { get; private set; }

		public bool? IsSupportsUserClaim { get; private set; }

        public bool? IsSupportsUserEmail { get; private set; }

        public bool? IsSupportsUserLockout { get; private set; }

        public bool? IsSupportsUserLogin { get; private set; }

        public bool? IsSupportsUserPassword { get; private set; }

        public bool? IsSupportsUserPhoneNumber { get; private set; }

        public bool? IsSupportsUserRole { get; private set; }

        public bool? IsSupportsUserSecurityStamp { get; private set; }

        public bool? IsSupportsUserTwoFactor { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			IsSupportsQueryableUsers = true;
			IsSupportsUserClaim = true;
			IsSupportsUserEmail = true;
			IsSupportsUserLockout = true;
			IsSupportsUserLogin = true;
			IsSupportsUserPassword = true;
			IsSupportsUserPhoneNumber = true;
			IsSupportsUserRole = true;
			IsSupportsUserSecurityStamp = true;
			IsSupportsUserTwoFactor = true;
		}
		#endregion
	}
}
