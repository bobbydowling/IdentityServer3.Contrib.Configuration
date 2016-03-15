using System;
using System.Collections.Generic;

using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IIdentityServerClientConfig
	{
		#region Properties
		int? AbsoluteRefreshTokenLifetime { get; }

		int? AccessTokenLifetime { get; }

		eAccessTokenType? AccessTokenType { get; }

		bool? AllowAccessToAllCustomGrantTypes { get; }

		bool? AllowAccessToAllScopes { get; }

		bool? AllowClientCredentialsOnly { get; }

		List<string> AllowedCorsOrigins { get; }

		List<string> AllowedCustomGrantTypes { get; }

		List<string> AllowedScopes { get; }

		bool? AllowRememberConsent { get; }

		bool? AlwaysSendClientClaims { get; }

		int? AuthorizationCodeLifetime { get; }

		IClaims Claims { get; }

		string ClientId { get; }

		string ClientName { get; }

		string ClientUri { get; }

		bool? Enabled { get; }

		bool? EnableLocalLogin { get; }

		eFlows? Flow { get; }

		List<string> IdentityProviderRestrictions { get; }

		int? IdentityTokenLifetime { get; }

		bool? IncludeJwtId { get; }

		string LogoUri { get; }

		bool? LogoutSessionRequired { get; }

		string LogoutUri { get; }

		List<string> PostLogoutRedirectUris { get; }

		bool? PrefixClientClaims { get; }

		List<string> RedirectUris { get; }

		eTokenExpiration? RefreshTokenExpiration { get; }

		eTokenUsage? RefreshTokenUsage { get; }

		bool? RequireConsent { get; }

		ISecrets Secrets { get; }

		int? SlidingRefreshTokenLifetime { get; }

		bool? UpdateAccessTokenClaimsOnRefresh { get; }
		#endregion
	}

	public interface ISecrets : IList<ISecret> { }

	public interface ISecret
	{
		#region Properties
		string Value { get; }

		string Type { get; }

		string Description { get; }

		DateTimeOffset? Expiration { get; }
		#endregion
	}

	public interface IClaims : IList<IClaim> { }

	public interface IClaim
	{
		#region Properties
		string Type { get; }

		string Value { get; }

		string ValueType { get; }

		string Issuer { get; }

		string OriginalIssuer { get; }

		IClaimsIdentity Subject { get; }
		#endregion
	}

	public interface IClaimsIdentity { }
}
