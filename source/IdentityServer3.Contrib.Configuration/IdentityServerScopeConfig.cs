using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerScopeConfig : IIdentityServerScopeConfig
	{
		#region Fields
		private IScopeClaims _claims;
		private string _claimsRule;
		private string _description;
		private string _displayName;
		private bool? _emphasize;
		private bool? _enabled;
		private bool? _includeAllClaimsForUser;
		private string _name;
		private bool? _required;
		private ISecrets _secrets;
		private bool? _showInDiscoveryDocument;
		private eScopeType? _scopeType;

		private XPathNavigator _nav;
		private IIdentityServerScopeConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerScopeConfig(XPathNodeIterator iter, IIdentityServerScopeConfig template)
		{
			SetKnownDefaults();

			_template = template;
			_nav = iter.Current;

			if (template != null)
			{
				_claimsRule = _template.ClaimsRule;
				_description = _template.Description;
				_displayName = _template.DisplayName;
				_emphasize = _template.Emphasize;
				_enabled = _template.Enabled;
				_includeAllClaimsForUser = _template.IncludeAllClaimsForUser;
				_name = _template.Name;
				_required = _template.Required;
				_showInDiscoveryDocument = _template.ShowInDiscoveryDocument;
				_scopeType = _template.ScopeType;
			}

			_nav.SetString("claimsRule", ref _claimsRule);
			_nav.SetString("description", ref _description);
			_nav.SetString("displayName", ref _displayName);
			_nav.SetBoolNullable("emphasize", ref _emphasize);
			_nav.SetBoolNullable("enabled", ref _enabled);
			_nav.SetBoolNullable("includeAllClaimsForUser", ref _includeAllClaimsForUser);
			_nav.SetString("name", ref _name);
			_nav.SetBoolNullable("required", ref _required);
			_nav.SetBoolNullable("showInDiscoveryDocument", ref _showInDiscoveryDocument);
			_nav.SetEnumNullable("type", ref _scopeType);
		}
		#endregion

		#region Properties
		public IScopeClaims Claims
		{
			get
			{
				if (_claims == null)
					_claims = new ScopeClaims(_nav.Select("claims"), _template != null ? _template.Claims : null);

				return _claims;
			}
		}

		public string ClaimsRule
		{
			get { return _claimsRule; }
		}

		public string Description
		{
			get { return _description; }
		}

		public string DisplayName
		{
			get { return _displayName; }
		}

		public bool? Emphasize
		{
			get { return _emphasize; }
		}

		public bool? Enabled
		{
			get { return _enabled; }
		}

		public bool? IncludeAllClaimsForUser
		{
			get { return _includeAllClaimsForUser; }
		}

		public string Name
		{
			get { return _name; }
		}

		public bool? Required
		{
			get { return _required; }
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

		public bool? ShowInDiscoveryDocument
		{
			get { return _showInDiscoveryDocument; }
		}

		public eScopeType? ScopeType
		{
			get { return _scopeType; }
		}
		#endregion

		#region Public Methods
		public static string GetName(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("name", ref returnValue);
			return returnValue;
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_emphasize = false;
			_enabled = true;
			_includeAllClaimsForUser = false;
			_required = false;
			_showInDiscoveryDocument = true;
			_scopeType = eScopeType.Resource;
		}
		#endregion
	}

	public class ScopeClaims : List<IScopeClaim>, IScopeClaims
	{
		#region Constructors
		public ScopeClaims(XPathNodeIterator iter, IScopeClaims template)
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
				var name = ScopeClaim.GetName(iter.Current);
				var template = this.SingleOrDefault(c => c.Name == name);

				if (template != null)
					Remove(template);

				var newValue = new ScopeClaim(iter, template);
				Add(newValue);
			}
		}
		#endregion
	}

	public class ScopeClaim : IScopeClaim
	{
		#region Fields
		private bool? _alwaysIncludeInIdToken;
		private string _description;
		private string _name;
		#endregion

		#region Constructors
		public ScopeClaim(XPathNodeIterator iter, IScopeClaim template)
		{
			SetKnownDefaults();

			var nav = iter.Current;

			if (template != null)
			{
				_alwaysIncludeInIdToken = template.AlwaysIncludeInIdToken;
				_description = template.Description;
				_name = template.Name;
			}

			nav.SetBoolNullable("alwaysIncludeInIdToken", ref _alwaysIncludeInIdToken);
			nav.SetString("description", ref _description);
			nav.SetString("name", ref _name);
		}
		#endregion

		#region Properties
		public bool? AlwaysIncludeInIdToken
		{
			get { return _alwaysIncludeInIdToken; }
		}

		public string Description
		{
			get { return _description; }
		}

		public string Name
		{
			get { return _name; }
		}

		#endregion

		#region Public Methods
		public static string GetName(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.SetString("name", ref returnValue);
			return returnValue;
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			_alwaysIncludeInIdToken = false;
		}
		#endregion
	}
}
