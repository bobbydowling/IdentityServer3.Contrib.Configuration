using System;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityManagerConfig : IIdentityManagerConfig
	{
		#region Fields
		private ISecurity _security;

		private XPathNavigator _nav;
		private IIdentityManagerConfig _template = null;
		#endregion

		#region Constructors
		public IdentityManagerConfig(XPathNavigator nav, IIdentityManagerConfig template)
		{
			_template = template;
			_nav = nav;

			SetIsLoadKnownDefaults(_nav);

            IsEnabled = _nav.GetBool(nameof(IsEnabled), _template);
            IsDisableUserInterface = _nav.GetBool(nameof(IsDisableUserInterface), _template);
		}
		#endregion

		#region Properties
		internal static bool IsLoadKnownDefaults { get; private set; }

		public bool IsEnabled { get; private set; }

		public bool IsDisableUserInterface { get; private set; }

        public ISecurity Security
		{
			get
			{
				if (_security == null)
					_security = new Security(GetChild(_nav, nameof(Security).ToLowerFirstLetter()), _template != null ? _template.Security : null);

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
			var value = nav.GetAttribute(nameof(IsLoadKnownDefaults), string.Empty);

			if (value.HasValue())
				IsLoadKnownDefaults = bool.Parse(value);
		}
		#endregion
	}

	public class Security : ISecurity
	{
		#region Fields
		private XPathNavigator _nav;
		private ISecurity _template = null;
		#endregion

		#region Constructors
		public Security(XPathNavigator nav, ISecurity template)
		{
			SetKnownDefaults();

			_template = template;
			_nav = nav;

            Type = _nav.GetEnum<eIdentityManagerSecurity>(nameof(Type), _template);
            AdditionalSignOutType = _nav.GetString(nameof(AdditionalSignOutType), _template);
            AdminRoleName = _nav.GetString(nameof(AdminRoleName), _template);
            BearerAuthenticationType = _nav.GetString(nameof(BearerAuthenticationType), _template);
            HostAuthenticationType = _nav.GetString(nameof(HostAuthenticationType), _template);
            NameClaimType = _nav.GetString(nameof(NameClaimType), _template);
            RequireSsl = _nav.GetBool(nameof(RequireSsl), _template);
            RoleClaimType = _nav.GetString(nameof(RoleClaimType), _template);
            ShowLoginButton = _nav.GetBoolNullable(nameof(ShowLoginButton), _template);
            TokenExpiration = _nav.GetTimeSpan(nameof(TokenExpiration), _template);
        }
		#endregion

		#region Properties
		public eIdentityManagerSecurity Type { get; private set; }

		public string AdditionalSignOutType { get; private set; }

        public string AdminRoleName { get; private set; }

        public string BearerAuthenticationType { get; private set; }

        public string HostAuthenticationType { get; private set; }

        public string NameClaimType { get; private set; }

        public bool RequireSsl { get; private set; }

        public string RoleClaimType { get; private set; }

        public bool? ShowLoginButton { get; private set; }

        public TimeSpan TokenExpiration { get; private set; }
        #endregion

        #region Private Methods
        private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			Type = eIdentityManagerSecurity.Local;
			BearerAuthenticationType = "Bearer";
			HostAuthenticationType = "Cookies";
			RequireSsl = true;
			TokenExpiration = new TimeSpan(10, 0, 0);
		}
		#endregion
	}
}
