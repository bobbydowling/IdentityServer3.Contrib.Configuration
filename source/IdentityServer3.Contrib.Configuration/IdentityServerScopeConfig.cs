using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class IdentityServerScopeConfig : IIdentityServerScopeConfig
	{
		#region Fields
		private IScopeClaims _claims;
		private ISecrets _secrets;

		private XPathNavigator _nav;
		private IIdentityServerScopeConfig _template = null;
		#endregion

		#region Constructors
		public IdentityServerScopeConfig(XPathNodeIterator iter, IIdentityServerScopeConfig template)
		{
			SetKnownDefaults();

			_template = template;
			_nav = iter.Current;

            ClaimsRule = _nav.GetString(nameof(ClaimsRule), _template);
            Description = _nav.GetString(nameof(Description), _template);
            DisplayName = _nav.GetString(nameof(DisplayName), _template);
            Emphasize = _nav.GetBoolNullable(nameof(Emphasize), _template);
            Enabled = _nav.GetBoolNullable(nameof(Enabled), _template);
            IncludeAllClaimsForUser = _nav.GetBoolNullable(nameof(IncludeAllClaimsForUser), _template);
            Name = _nav.GetString(nameof(Name), _template);
            Required = _nav.GetBoolNullable(nameof(Required), _template);
            ShowInDiscoveryDocument = _nav.GetBoolNullable(nameof(ShowInDiscoveryDocument), _template);
            Type = _nav.GetEnumNullable<eScopeType>(nameof(Type), _template);
        }
		#endregion

		#region Properties
		public IScopeClaims Claims
		{
			get
			{
				if (_claims == null)
					_claims = new ScopeClaims(_nav.Select(nameof(Claims).ToLowerFirstLetter()), _template != null ? _template.Claims : null);

				return _claims;
			}
		}

		public string ClaimsRule { get; private set; }

        public string Description { get; private set; }

        public string DisplayName { get; private set; }

        public bool? Emphasize { get; private set; }

        public bool? Enabled { get; private set; }

        public bool? IncludeAllClaimsForUser { get; private set; }

        public string Name { get; private set; }

        public bool? Required { get; private set; }

        public ISecrets Secrets
		{
			get
			{
				if (_secrets == null)
					_secrets = new Secrets(_nav.Select(nameof(Secrets).ToLowerFirstLetter()), _template != null ? _template.Secrets : null);

				return _secrets;
			}
		}

		public bool? ShowInDiscoveryDocument { get; private set; }

        public eScopeType? Type { get; private set; }
        #endregion

        #region Public Methods
        public static string GetName(XPathNavigator nav)
		{
            return nav.GetString(nameof(Name));
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			Emphasize = false;
			Enabled = true;
			IncludeAllClaimsForUser = false;
			Required = false;
			ShowInDiscoveryDocument = true;
			Type = eScopeType.Resource;
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
		#region Constructors
		public ScopeClaim(XPathNodeIterator iter, IScopeClaim template)
		{
			SetKnownDefaults();

			var nav = iter.Current;

            AlwaysIncludeInIdToken = nav.GetBoolNullable(nameof(AlwaysIncludeInIdToken), template);
            Description = nav.GetString(nameof(Description), template);
            Name = nav.GetString(nameof(Name), template);
        }
		#endregion

		#region Properties
		public bool? AlwaysIncludeInIdToken { get; private set; }

        public string Description { get; private set; }

        public string Name { get; private set; }
        #endregion

        #region Public Methods
        public static string GetName(XPathNavigator nav)
		{
            return nav.GetString(nameof(Name));
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			AlwaysIncludeInIdToken = false;
		}
		#endregion
	}
}
