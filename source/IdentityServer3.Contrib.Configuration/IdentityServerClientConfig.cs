using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
    public class IdentityServerClientConfig : IIdentityServerClientConfig
    {
        #region Fields
        private IClaims _claims;
        private ISecrets _secrets;

        private XPathNavigator _nav;
        private IIdentityServerClientConfig _template = null;
        #endregion

        #region Constructors
        public IdentityServerClientConfig(XPathNodeIterator iter, IIdentityServerClientConfig template)
        {
            SetKnownDefaults();

            _template = template;
            _nav = iter.Current;

            AbsoluteRefreshTokenLifetime = _nav.GetIntNullable(nameof(AbsoluteRefreshTokenLifetime), _template);
            AccessTokenLifetime = _nav.GetIntNullable(nameof(AccessTokenLifetime), _template);
            AccessTokenType = _nav.GetEnumNullable<eAccessTokenType>(nameof(AccessTokenType), _template);
            AllowAccessToAllCustomGrantTypes = _nav.GetBoolNullable(nameof(AllowAccessToAllCustomGrantTypes), _template);
            AllowAccessToAllScopes = _nav.GetBoolNullable(nameof(AllowAccessToAllScopes), _template);
            AllowClientCredentialsOnly = _nav.GetBoolNullable(nameof(AllowClientCredentialsOnly), _template);
            AllowedCorsOrigins = _nav.GetListString(nameof(AllowedCorsOrigins), _template);
            AllowedCustomGrantTypes = _nav.GetListString(nameof(AllowedCustomGrantTypes), _template);
            AllowedScopes = _nav.GetListString(nameof(AllowedScopes), _template);
            AllowRememberConsent = _nav.GetBoolNullable(nameof(AllowRememberConsent), _template);
            AlwaysSendClientClaims = _nav.GetBoolNullable(nameof(AlwaysSendClientClaims), _template);
            AuthorizationCodeLifetime = _nav.GetIntNullable(nameof(AuthorizationCodeLifetime), _template);
            ClientId = _nav.GetString(nameof(ClientId), _template);
            ClientName = _nav.GetString(nameof(ClientName), _template);
            ClientUri = _nav.GetString(nameof(ClientUri), _template);
            Enabled = _nav.GetBoolNullable(nameof(Enabled), _template);
            EnableLocalLogin = _nav.GetBoolNullable(nameof(EnableLocalLogin), _template);
            Flow = _nav.GetEnumNullable<eFlows>(nameof(Flow), _template);
            IdentityProviderRestrictions = _nav.GetListString(nameof(IdentityProviderRestrictions), _template);
            IdentityTokenLifetime = _nav.GetIntNullable(nameof(IdentityTokenLifetime), _template);
            IncludeJwtId = _nav.GetBoolNullable(nameof(IncludeJwtId), _template);
            LogoUri = _nav.GetString(nameof(LogoUri), _template);
            LogoutSessionRequired = _nav.GetBoolNullable(nameof(LogoutSessionRequired), _template);
            LogoutUri = _nav.GetString(nameof(LogoutUri), _template);
            PostLogoutRedirectUris = _nav.GetListString(nameof(PostLogoutRedirectUris), _template);
            PrefixClientClaims = _nav.GetBoolNullable(nameof(PrefixClientClaims), _template);
            RedirectUris = _nav.GetListString(nameof(RedirectUris), _template);
            RefreshTokenExpiration = _nav.GetEnumNullable<eTokenExpiration>(nameof(RefreshTokenExpiration), _template);
            RefreshTokenUsage = _nav.GetEnumNullable<eTokenUsage>(nameof(RefreshTokenUsage), _template);
            RequireConsent = _nav.GetBoolNullable(nameof(RequireConsent), _template);
            SlidingRefreshTokenLifetime = _nav.GetIntNullable(nameof(SlidingRefreshTokenLifetime), _template);
            UpdateAccessTokenClaimsOnRefresh = _nav.GetBoolNullable(nameof(UpdateAccessTokenClaimsOnRefresh), _template);
        }
        #endregion

        #region Properties
        public int? AbsoluteRefreshTokenLifetime { get; private set; }

		public int? AccessTokenLifetime { get; private set; }

        public eAccessTokenType? AccessTokenType { get; private set; }

        public bool? AllowAccessToAllCustomGrantTypes { get; private set; }

        public bool? AllowAccessToAllScopes { get; private set; }

        public bool? AllowClientCredentialsOnly { get; private set; }

        public List<string> AllowedCorsOrigins { get; private set; }

        public List<string> AllowedCustomGrantTypes { get; private set; }

        public List<string> AllowedScopes { get; private set; }

        public bool? AllowRememberConsent { get; private set; }

        public bool? AlwaysSendClientClaims { get; private set; }

        public int? AuthorizationCodeLifetime { get; private set; }

        public IClaims Claims
		{
			get
			{
				if (_claims == null)
					_claims = new Claims(_nav.Select(nameof(Claims).ToLowerFirstLetter()), _template != null ? _template.Claims : null);

				return _claims;
			}
		}

		public string ClientId { get; private set; }

        public string ClientName { get; private set; }

        public string ClientUri { get; private set; }

        public bool? Enabled { get; private set; }

        public bool? EnableLocalLogin { get; private set; }

        public eFlows? Flow { get; private set; }

        public List<string> IdentityProviderRestrictions { get; private set; }

        public int? IdentityTokenLifetime { get; private set; }

        public bool? IncludeJwtId { get; private set; }

        public string LogoUri { get; private set; }

        public bool? LogoutSessionRequired { get; private set; }

        public string LogoutUri { get; private set; }

        public List<string> PostLogoutRedirectUris { get; private set; }

        public bool? PrefixClientClaims { get; private set; }

        public List<string> RedirectUris { get; private set; }

        public eTokenExpiration? RefreshTokenExpiration { get; private set; }

        public eTokenUsage? RefreshTokenUsage { get; private set; }

        public bool? RequireConsent { get; private set; }

        public ISecrets Secrets
		{
			get
			{
				if (_secrets == null)
					_secrets = new Secrets(_nav.Select(nameof(Secrets).ToLowerFirstLetter()), _template != null ? _template.Secrets : null);

				return _secrets;
			}
		}

		public int? SlidingRefreshTokenLifetime { get; private set; }

        public bool? UpdateAccessTokenClaimsOnRefresh { get; private set; }
        #endregion

        #region Public Methods
        public static string GetClientId(XPathNavigator nav)
		{
			var returnValue = string.Empty;
			nav.GetString(nameof(ClientId));
			return returnValue;
		}
		#endregion

		#region Private Methods
		private void SetKnownDefaults()
		{
			if (!IdentityServerConfig.IsLoadKnownDefaults)
				return;

			AbsoluteRefreshTokenLifetime = 2592000;
			AccessTokenLifetime = 3600;
			AccessTokenType = eAccessTokenType.Jwt;
			AllowAccessToAllCustomGrantTypes = false;
			AllowAccessToAllScopes = false;
			AllowClientCredentialsOnly = false;
			AllowRememberConsent = true;
			AlwaysSendClientClaims = false;
			AuthorizationCodeLifetime = 300;
			Enabled = true;
			EnableLocalLogin = true;
			Flow = eFlows.Implicit;
			IdentityTokenLifetime = 300;
			IncludeJwtId = false;
			LogoutSessionRequired = true;
			PrefixClientClaims = true;
			RefreshTokenExpiration = eTokenExpiration.Absolute;
			RefreshTokenUsage = eTokenUsage.OneTimeOnly;
			RequireConsent = true;
			SlidingRefreshTokenLifetime = 1296000;
			UpdateAccessTokenClaimsOnRefresh = false;
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
			iter = iter.Current.Select(nameof(Claim).ToLowerFirstLetter());

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
		#region Constructors
		public Claim(XPathNodeIterator iter, IClaim template)
		{
			var nav = iter.Current;

            Value = nav.GetString(nameof(Value), template);
            Type = nav.GetString(nameof(Type), template);
            ValueType = nav.GetString(nameof(ValueType), template);
            Issuer = nav.GetString(nameof(Issuer), template);
            OriginalIssuer = nav.GetString(nameof(OriginalIssuer), template);
        }
		#endregion

		#region Properties
		public string Value { get; private set; }

		public string Type { get; private set; }

        public string ValueType { get; private set; }

        public string Issuer { get; private set; }

        public string OriginalIssuer { get; private set; }

        public IClaimsIdentity Subject
		{
			get { throw new NotImplementedException(); }
		}
		#endregion

		#region Public Methods
		public static string GetValue(XPathNavigator nav)
		{
            return nav.GetString(nameof(Value));
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
			iter = iter.Current.Select(nameof(Secret).ToLowerFirstLetter());

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
		#region Constructors
		public Secret(XPathNodeIterator iter, ISecret template)
		{
			var nav = iter.Current;

            Value = nav.GetString(nameof(Value), template);
            Type = nav.GetString(nameof(Type), template);
            Description = nav.GetString(nameof(Description), template);
            Expiration = nav.GetDateTimeOffsetNullable(nameof(Expiration), template);
		}
		#endregion

		#region Properties
		public string Value { get; private set; }

        public string Type { get; private set; }

        public string Description { get; private set; }

        public DateTimeOffset? Expiration { get; private set; }

        #endregion

        #region Public Methods
        public static string GetValue(XPathNavigator nav)
		{
			return nav.GetString(nameof(Value));
		}
		#endregion
	}
}
