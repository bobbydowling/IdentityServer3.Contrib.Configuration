using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IIdentityServerOptionsConfig
	{
		#region Properties
		IAuthentication Authentication { get; }

		ICaching Caching { get; }

		ICertificate Certificate { get; }

		ICors Cors { get; }

		ICsp Csp { get; }

		bool? EnableWelcomePage { get; }

		IEndPoints EndPoints { get; }

		IEvents Events { get; }

		IInputLengthRestrictions InputLengthRestrictions { get; }
		string IssuerUri { get; }

		ILogging Logging { get; }

		IOperationalData OperationalData { get; }

		List<string> ProtocolLogoutUrls { get; }

		string PublicOrigin { get; }

		bool? RequireSsl { get; }

		string SiteName { get; }

		ITenants Tenants { get; }
		#endregion
	}

	public interface IAuthentication
	{
		#region Properties
		ICookie Cookie { get; }


		bool? EnableLoginHint { get; }


		bool? EnableLocalLogin { get; }


		bool? EnablePostSignOutAutoRedirect { get; }


		bool? EnableSignOutPrompt { get; }


		string InvalidSignInRedirectUrl { get; }


		ILoginPageLinks LoginPageLinks { get; }


		int? PostSignOutAutoRedirectDelay { get; }


		bool? RememberLastUsername { get; }


		bool? RequireAuthenticatedUserForSignOutMessage { get; }


		int? SignInMessageThreshold { get; }

		bool IsEnableExternalWindowsAuthentication { get; }

		string ExternalWindowsAuthenticationCaption { get; }

		string ResetPasswordRedirectUri { get; }

		string ResetPasswordUri { get; }
		#endregion
	}

	public interface ICaching
	{
		#region Properties
		bool IsEnabledClients { get; }


		bool IsEnabledScopes { get; }


		bool IsEnabledUsers { get; }


		bool IsUseInMemoryStore { get; }


		eCacheType CustomType { get; }


		TimeSpan ClientExpiry { get; }


		TimeSpan ScopeExpiry { get; }


		TimeSpan UserExpiry { get; }


		TimeSpan UsersExpiry { get; }
		#endregion
	}

	public interface ILoginPageLinks : IList<ILoginPageLink> { }

	public interface ILoginPageLink
	{
		#region Properties
		string Href { get; }


		string Text { get; }


		string Type { get; }
		#endregion
	}

	public interface ICookie
	{
		#region Properties
		bool? AllowRememberMe { get; }


		TimeSpan? ExpireTimeSpan { get; }


		bool? IsPersistent { get; }


		string Path { get; }


		string Prefix { get; }


		TimeSpan? RememberMeDuration { get; }


		eCookieSecureMode? SecureMode { get; }


		bool? SlidingExpiration { get; }
		#endregion
	}

	public interface ICertificate
	{
		#region Properties
		string Name { get; }

		StoreName StoreName { get; }

		StoreLocation StoreLocation { get; }

		string FileName { get; }

		string Password { get; }

		X509KeyStorageFlags? StorageFlags { get; }
		#endregion
	}

	public interface ICors
	{
		#region Properties
		bool IsUseInMemoryStore { get; }

		bool AllowAllCustom { get; }

		List<string> AllowedOriginsCustom { get; }
		#endregion
	}

	public interface ICsp
	{
		#region Properties
		string ConnectSource { get; }


		bool? Enabled { get; }


		string FontSource { get; }


		string ImageSource { get; }


		string ScriptSource { get; }


		string StyleSource { get; }
		#endregion
	}

	public interface IEndPoints
	{
		#region Properties
		bool? EnableAuthorizeEndpoint { get; }


		bool? EnableTokenEndpoint { get; }


		bool? EnableUserInfoEndpoint { get; }


		bool? EnableDiscoveryEndpoint { get; }


		bool? EnableAccessTokenValidationEndpoint { get; }


		bool? EnableIdentityTokenValidationEndpoint { get; }

		bool? EnableEndSessionEndpoint { get; }


		bool? EnableClientPermissionsEndpoint { get; }


		bool? EnableCspReportEndpoint { get; }


		bool? EnableCheckSessionEndpoint { get; }


		bool? EnableTokenRevocationEndpoint { get; }


		bool? EnableIntrospectionEndpoint { get; }
		#endregion
	}

	public interface IEvents
	{
		#region Properties
		bool? RaiseErrorEvents { get; }


		bool? RaiseFailureEvents { get; }


		bool? RaiseInformationEvents { get; }


		bool? RaiseSuccessEvents { get; }
		#endregion
	}

	public interface IInputLengthRestrictions
	{
		#region Properties
		int? AcrValues { get; }


		int? ClientId { get; }


		int? CspReport { get; }


		int? GrantType { get; }


		int? IdentityProvider { get; }


		int? LoginHint { get; }


		int? Nonce { get; }


		int? Password { get; }


		int? RedirectUri { get; }


		int? Scope { get; }


		int? UiLocale { get; }


		int? UserName { get; }
		#endregion
	}

	public interface ILogging
	{
		#region Properties
		bool? EnableHttpLogging { get; }


		bool? EnableKatanaLogging { get; }


		bool? EnableWebApiDiagnostics { get; }


		bool? WebApiDiagnosticsIsVerbose { get; }
		#endregion
	}

	public interface IOperationalData
	{
		#region Properties
		bool IsUseInMemoryStore { get; }


		bool IsCleanUp { get; }


		int TokenExpiry { get; }


		string ConnectionKey { get; }
		#endregion
	}

	public interface ITenants : IList<ITenant> { }

	public interface ITenant
	{
		#region Properties
		eTenant Id { get; }


		string Description { get; }


		string ConnectionKey { get; }
		#endregion
	}
}
