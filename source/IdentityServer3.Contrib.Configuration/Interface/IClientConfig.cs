using System;
using System.Collections.Generic;

using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IClientConfig
	{
		#region Properties
		string IdTokenHint { get; }

		eTenant Tenant { get; }

		string UniqueClaimTypeIdentifier { get; }

		IOpenIdConnectAuthenticationOptions OpenIdConnectAuthenticationOptions { get; }

		ICookieAuthenticationOptions CookieAuthenticationOptions { get; }

		IIdentityServerBearerTokenAuthenticationOptions IdentityServerBearerTokenAuthenticationOptions { get; }

		IClientCredentialOptions ClientCredentialOptions { get; }
		#endregion
	}

	public interface ICookieAuthenticationOptions
	{
		#region Properties
		eAuthenticationMode AuthenticationMode { get; }

		string AuthenticationType { get; }

		string CookieDomain { get; }

		bool CookieHttpOnly { get; }

		string CookieName { get; }

		string CookiePath { get; }

		eCookieSecureOption CookieSecure { get; }

		IDescription Description { get; }

		TimeSpan ExpireTimeSpan { get; }

		string LoginPath { get; }

		string LogoutPath { get; }

		string ReturnUrlParameter { get; }

		bool SlidingExpiration { get; }
		#endregion
	}

	public interface IOpenIdConnectAuthenticationOptions
	{
		#region Properties
		eAuthenticationMode AuthenticationMode { get; }

		string AuthenticationType { get; }

		string Authority { get; }

		TimeSpan BackChannelHttpHandler { get; }

		string CallBackPath { get; }

		string Caption { get; }

		string ClientId { get; }

		string ClientSecret { get; }

		IConfiguration Configuration { get; }

		IDescription Description { get; }

		string MetaDataAddress { get; }

		string PostLogoutRedirectUri { get; }

		IProtocolValidator ProtocolValidator { get; }

		string RedirectUri { get; }

		string Resource { get; }

		string ResponseType { get; }

		bool RefreshOnIssuerKeyNotFound { get; }

		string SignInAsAuthenticationType { get; }

		string Scope { get; }

		bool UseTokenLifeTime { get; }
		#endregion
	}

	public interface IIdentityServerBearerTokenAuthenticationOptions
	{
		#region Properties
		eAuthenticationMode? AuthenticationMode { get; }

		string AuthenticationType { get; }

		string Authority { get; }

		string ClientId { get; }

		string ClientSecret { get; }

		bool? DelayLoadMetadata { get; }

		bool? EnableValidationResultCache { get; }

		string IssuerName { get; }

		string NameClaimType { get; }

		bool? PreserveAccessToken { get; }

		List<string> RequiredScopes { get; }

		string RoleClaimType { get; }

		eValidationMode? ValidationMode { get; }

		TimeSpan? ValidationResultCacheDuration { get; }

		IDescription Description { get; }
		#endregion
	}

	public interface IClientCredentialOptions
	{
		#region Properties
		string ClientId { get; }

		string Secret { get; }

		string Scope { get; }
		#endregion
	}

	public interface IConfiguration
	{
		#region Properties
		string AuthorizationEndpoint { get; }

		string CheckSessionIframe { get; }

		string EndSessionEndpoint { get; }

		string Issuer { get; }

		IJsonWebKeys JsonWebKeys { get; }

		string JwksUri { get; }

		string TokenEndpoint { get; }

		string UserInfoEndpoint { get; }
		#endregion
	}

	public interface IJsonWebKeys : IList<IJsonWebKey> { }

	public interface IJsonWebKey
	{
		#region Properties
		string Id { get; }

		string Value { get; }
		#endregion
	}

	public interface IDescription
	{
		#region Properties
		string AuthenticationType { get; }

		string Caption { get; }

		IProperties Properties { get; }
		#endregion
	}

	public interface IProtocolValidator
	{
		#region Properties
		TimeSpan NonceLifetime { get; }

		bool RequireAcr { get; }

		bool RequireAmr { get; }

		bool RequireAuthTime { get; }

		bool RequireAzp { get; }

		bool RequireNonce { get; }

		bool RequireSub { get; }

		bool RequireTimeStampInNonce { get; }
		#endregion
	}

	public interface IProperties : IList<IProperty> { }

	public interface IProperty
	{
		#region Properties
		string Id { get; }

		string Value { get; }
		#endregion
	}
}
