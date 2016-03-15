using System;
using System.Linq;

using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Client
	{
		#region Test Methods (Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client")]
		public void GetIdTokenHint()
		{
			Assert.AreEqual("id_token", CompanySecurityConfig.Current.IdentityServer.Client.IdTokenHint);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client")]
		public void GetTenant()
		{
			Assert.AreEqual(eTenant.SomeApplication, CompanySecurityConfig.Current.IdentityServer.Client.Tenant);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client")]
		public void GetUniqueClaimTypeIdentifier()
		{
			Assert.AreEqual("sub", CompanySecurityConfig.Current.IdentityServer.Client.UniqueClaimTypeIdentifier);
		}
		#endregion

		#region Test Methods (CookieAuthenticationOptions - Root))
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetAuthenticationMode()
		{
			Assert.AreEqual(eAuthenticationMode.Active, CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.AuthenticationMode);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetAuthenticationType()
		{
			Assert.AreEqual("Cookies", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.AuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetCookieDomain()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.CookieDomain);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetCookieHttpOnly()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.CookieHttpOnly);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetCookieName()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.CookieName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetCookiePath()
		{
			Assert.AreEqual("/", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.CookiePath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetCookieSecure()
		{
			Assert.AreEqual(eCookieSecureOption.SameAsRequest, CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.CookieSecure);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetExpireTimeSpan()
		{
			Assert.AreEqual(TimeSpan.Parse("14.00:00:00"), CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.ExpireTimeSpan);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetLoginPath()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.LoginPath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetLogoutPath()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.LogoutPath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetReturnUrlParameter()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.ReturnUrlParameter);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions")]
		public void GetSlidingExpiration()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.SlidingExpiration);
		}
		#endregion

		#region Test Methods (CookieAuthenticationOptions - Description)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions - Description")]
		public void GetCookieAuthenticationOptionsDescriptionAuthenticationType()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.Description.AuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions - Description")]
		public void GetCookieAuthenticationOptionsDescriptionCaption()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.Description.Caption);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - CookieAuthenticationOptions - Description")]
		public void GetCookieAuthenticationOptionsDescriptionProperties()
		{
			Assert.AreEqual(0, CompanySecurityConfig.Current.IdentityServer.Client.CookieAuthenticationOptions.Description.Properties.Count());
		}
		#endregion

		#region Test Methods (OpenIdConnectAuthenticationOptions - Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetCookieAuthenticationOptionsAuthenticationMode()
		{
			Assert.AreEqual(eAuthenticationMode.Active, CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.AuthenticationMode);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetOpenIdConnectAuthenticationOptionsAuthenticationType()
		{
			Assert.AreEqual("OpenIdConnect", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.AuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetAuthority()
		{
			Assert.AreEqual("https://localhost:44300/core", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Authority);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetBackChannelHttpHandler()
		{
			Assert.AreEqual(TimeSpan.Parse("00:01:00"), CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.BackChannelHttpHandler);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetCallBackPath()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.CallBackPath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetCaption()
		{
			Assert.AreEqual("OpenIdConnect", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Caption);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetClientId()
		{
			Assert.AreEqual("someapplication", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ClientId);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetClientSecret()
		{
			Assert.AreEqual("1q2w3e4r5t", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ClientSecret);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetMetaDataAddress()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.MetaDataAddress);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetPostLogoutRedirectUri()
		{
			Assert.AreEqual("https://localhost:44301/", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.PostLogoutRedirectUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetRedirectUri()
		{
			Assert.AreEqual("https://localhost:44301/", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.RedirectUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetResource()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Resource);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetResponseType()
		{
			Assert.AreEqual("code id_token token", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ResponseType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetRefreshOnIssuerKeyNotFound()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.RefreshOnIssuerKeyNotFound);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetSignInAsAuthenticationType()
		{
			Assert.AreEqual("Cookies", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.SignInAsAuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetScope()
		{
			Assert.AreEqual("openid profile email roles offline_access userstore", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Scope);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions")]
		public void GetUseTokenLifeTime()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.UseTokenLifeTime);
		}
		#endregion

		#region Test Methods (OpenIdConnectAuthenticationOptions - Configuration)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetAuthorizationEndpoint()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.AuthorizationEndpoint);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetCheckSessionIframe()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.CheckSessionIframe);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetEndSessionEndpoint()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.EndSessionEndpoint);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetIssuer()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.Issuer);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetJwksUri()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.JwksUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetTokenEndpoint()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.TokenEndpoint);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Configuration")]
		public void GetUserInfoEndpoint()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Configuration.UserInfoEndpoint);
		}
		#endregion

		#region Test Methods (OpenIdConnectAuthenticationOptions - Description)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Description")]
		public void GetOpenIdConnectAuthenticationOptionsDescriptionAuthenticationType()
		{
			Assert.AreEqual("OpenIdConnect", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Description.AuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Description")]
		public void GetOpenIdConnectAuthenticationOptionsDescriptionCaption()
		{
			Assert.AreEqual("OpenIdConnect", CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Description.Caption);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Description")]
		public void GetOpenIdConnectAuthenticationOptionsDescriptionProperties()
		{
			Assert.AreEqual(2, CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Description.Properties.Count());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Description")]
		public void GetOpenIdConnectAuthenticationOptionsDescriptionId()
		{
			var firstProperty = CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Description.Properties.First();
			Assert.AreEqual("AuthenticationType", firstProperty.Id);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - Description")]
		public void GetOpenIdConnectAuthenticationOptionsDescriptionValue()
		{
			var firstProperty = CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.Description.Properties.First();
			Assert.AreEqual("OpenIdConnect", firstProperty.Value);
		}
		#endregion

		#region Test Methods (OpenIdConnectAuthenticationOptions - ProtocolValidator)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetNonceLifetime()
		{
			Assert.AreEqual(TimeSpan.Parse("01:00:00"), CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.NonceLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireAcr()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireAcr);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireAmr()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireAmr);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireAuthTime()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireAuthTime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireAzp()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireAzp);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireNonce()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireNonce);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireSub()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireSub);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - OpenIdConnectAuthenticationOptions - ProtocolValidator")]
		public void GetRequireTimeStampInNonce()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Client.OpenIdConnectAuthenticationOptions.ProtocolValidator.RequireTimeStampInNonce);
		}
		#endregion

		#region Test Methods (IdentityServerBearerTokenAuthenticationOptions - Root))
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - IdentityServerBearerTokenAuthenticationOptions")]
		public void GetAuthenticationModeForIdentityServerBearerTokenAuthenticationOptions()
		{
			Assert.AreEqual(eAuthenticationMode.Active, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.AuthenticationMode.Value);
		}

		public void GetAuthenticationTypeForIdentityServerBearerTokenAuthenticationOptions()
		{
			Assert.AreEqual("Bearer", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.AuthenticationType);
		}

		public void GetAuthorityForIdentityServerBearerTokenAuthenticationOptions()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.Authority);
		}

		public void GetClientIdForIdentityServerBearerTokenAuthenticationOptions()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.ClientId);
		}

		public void GetClientSecretForIdentityServerBearerTokenAuthenticationOptions()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.ClientSecret);
		}

		public void GetDelayLoadMetadata()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.DelayLoadMetadata.Value);
		}

		public void GetEnableValidationResultCache()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.EnableValidationResultCache.Value);
		}

		public void GetIssuerName()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.IssuerName);
		}

		public void GetNameClaimType()
		{
			Assert.AreEqual("name", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.NameClaimType);
		}

		public void GetPreserveAccessToken()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.PreserveAccessToken.Value);
		}

		public void GetRequiredScopes()
		{
			Assert.AreEqual(0, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.RequiredScopes.Count);
		}

		public void GetRoleClaimType()
		{
			Assert.AreEqual("role", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.RoleClaimType);
		}

		public void GetValidationMode()
		{
			Assert.AreEqual(eValidationMode.Both, CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.ValidationMode.Value);
		}

		public void GetValidationResultCacheDuration()
		{
			Assert.AreEqual(new TimeSpan(0, 5, 0), CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.ValidationResultCacheDuration.Value);
		}
		#endregion

		#region Test Methods (IdentityServerBearerTokenAuthenticationOptions - Description)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - IdentityServerBearerTokenAuthenticationOptions - Description")]
		public void GetIdentityServerBearerTokenAuthenticationOptionsAuthenticationType()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.Description.AuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - IdentityServerBearerTokenAuthenticationOptions - Description")]
		public void GetIdentityServerBearerTokenAuthenticationOptionsDescriptionCaption()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.IdentityServerBearerTokenAuthenticationOptions.Description.Caption);
		}
		#endregion

		#region Test Methods (ClientCredentialOptions - Root))
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - ClientCredentialOptions")]
		public void GetClientCredentialOptionsClientId()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.ClientCredentialOptions.ClientId);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - ClientCredentialOptions")]
		public void GetClientCredentialOptionsSecret()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.ClientCredentialOptions.Secret);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Client - ClientCredentialOptions")]
		public void GetClientCredentialOptionsScope()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Client.ClientCredentialOptions.Scope);
		}
		#endregion
	}
}
