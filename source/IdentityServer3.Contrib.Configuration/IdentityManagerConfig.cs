using System;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityManagerConfig : IIdentityManagerConfig
	{
		#region Fields
		private bool _isEnabled;
		private bool _isDisableUserInterface;
		private ISecurity _security;

		private XPathNavigator _nav;
		private IIdentityManagerConfig _template = null;
		#endregion

		#region Constructors
		public IdentityManagerConfig(XPathNavigator nav, IIdentityManagerConfig template)
		{
			_template = template;
			_nav = nav;

			if (_template != null)
			{
				_isEnabled = _template.IsEnabled;
				_isDisableUserInterface = _template.IsDisableUserInterface;
			}

			SetIsLoadKnownDefaults(_nav);

			_nav.SetBool("isEnabled", ref _isEnabled);
			_nav.SetBool("isDisableUserInterface", ref _isDisableUserInterface);
		}
		#endregion

		#region Properties
		internal static bool IsLoadKnownDefaults { get; private set; }

		public bool IsEnabled
		{
			get { return _isEnabled; }
		}

		public bool IsDisableUserInterface
		{
			get { return _isDisableUserInterface; }
		}

		public ISecurity Security
		{
			get
			{
				if (_security == null)
					_security = new Security(GetChild(_nav, "security"), _template != null ? _template.Security : null);

				return _security;
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

	public class Security : ISecurity
	{
		#region Fields
		private eIdentityManagerSecurity _type;
		private string _additionalSignOutType;
		private string _adminRoleName;
		private string _bearerAuthenticationType;
		private string _hostAuthenticationType;
		private string _nameClaimType;
		private bool _requireSsl;
		private string _roleClaimType;
		private bool? _showLoginButton;
		private TimeSpan _tokenExpiration;

		private XPathNavigator _nav;
		private ISecurity _template = null;
		#endregion

		#region Constructors
		public Security(XPathNavigator nav, ISecurity template)
		{
			SetKnownDefaults();

			_template = template;
			_nav = nav;

			if (_template != null)
			{
				_type = _template.Type;
				_additionalSignOutType = _template.AdditionalSignOutType;
				_adminRoleName = _template.AdminRoleName;
				_bearerAuthenticationType = _template.BearerAuthenticationType;
				_hostAuthenticationType = _template.HostAuthenticationType;
				_nameClaimType = _template.NameClaimType;
				_requireSsl = _template.RequireSsl;
				_roleClaimType = _template.RoleClaimType;
				_showLoginButton = _template.ShowLoginButton;
				_tokenExpiration = _template.TokenExpiration;
			}

			_nav.SetEnum("type", ref _type);
			_nav.SetString("additionalSignOutType", ref _additionalSignOutType);
			_nav.SetString("adminRoleName", ref _adminRoleName);
			_nav.SetString("bearerAuthenticationType", ref _bearerAuthenticationType);
			_nav.SetString("hostAuthenticationType", ref _hostAuthenticationType);
			_nav.SetString("nameClaimType", ref _nameClaimType);
			_nav.SetBool("requireSsl", ref _requireSsl);
			_nav.SetString("roleClaimType", ref _roleClaimType);
			_nav.SetBoolNullable("showLoginButton", ref _showLoginButton);
			_nav.SetTimeSpan("tokenExpiration", ref _tokenExpiration);
		}
		#endregion

		#region Properties
		public eIdentityManagerSecurity Type
		{
			get { return _type; }
		}

		public string AdditionalSignOutType
		{
			get { return _additionalSignOutType; }
		}

		public string AdminRoleName
		{
			get { return _adminRoleName; }
		}

		public string BearerAuthenticationType
		{
			get { return _bearerAuthenticationType; }
		}

		public string HostAuthenticationType
		{
			get { return _hostAuthenticationType; }
		}

		public string NameClaimType
		{
			get { return _nameClaimType; }
		}

		public bool RequireSsl
		{
			get { return _requireSsl; }
		}

		public string RoleClaimType
		{
			get { return _roleClaimType; }
		}

		public bool? ShowLoginButton
		{
			get { return _showLoginButton; }
		}

		public TimeSpan TokenExpiration
		{
			get { return _tokenExpiration; }
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_type = eIdentityManagerSecurity.Local;
			_bearerAuthenticationType = "Bearer";
			_hostAuthenticationType = "Cookies";
			_requireSsl = true;
			_tokenExpiration = new TimeSpan(10, 0, 0);
		}
		#endregion
	}
}
