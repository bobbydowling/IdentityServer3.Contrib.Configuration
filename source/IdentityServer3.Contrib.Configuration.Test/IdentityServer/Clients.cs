using System;
using System.Linq;

using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Clients
	{
		#region Test Methods (Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetIsUseInMemoryStore()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.IsUseInMemoryStore);
		}
		#endregion

		#region Test Methods
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetTwoDistinctClients()
		{
			var clients = CompanySecurityConfig.Current.IdentityServer.Server.Clients;

			Assert.AreEqual(2, clients.Count());
			Assert.AreNotEqual(clients.First().ClientId, clients.Skip(1).First().ClientId);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAbsoluteRefreshTokenLifetime()
		{
			Assert.AreEqual(2592000, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AbsoluteRefreshTokenLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAccessTokenLifetime()
		{
			Assert.AreEqual(3600, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AccessTokenLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAccessTokenType()
		{
			Assert.AreEqual(eAccessTokenType.Jwt, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AccessTokenType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowAccessToAllCustomGrantTypes()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowAccessToAllCustomGrantTypes.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowAccessToAllScopes()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowAccessToAllScopes.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetallowClientCredentialsOnly()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowClientCredentialsOnly.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowedCorsOrigins()
		{
			var origins = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowedCorsOrigins;

			Assert.AreEqual(2, origins.Count());
			Assert.AreEqual("http://localhost:80/", origins.First());
			Assert.AreEqual("http://localhost:8080/", origins.Skip(1).First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowedCustomGrantTypes()
		{
			var grantTypes = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowedCustomGrantTypes;

			Assert.AreEqual(2, grantTypes.Count());
			Assert.AreEqual("CustomGrant1", grantTypes.First());
			Assert.AreEqual("CustomGrant2", grantTypes.Skip(1).First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowedScopes()
		{
			var scopes = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowedScopes;

			Assert.AreEqual(5, scopes.Count());
			Assert.AreEqual("openid", scopes[0]);
			Assert.AreEqual("profile", scopes[1]);
			Assert.AreEqual("email", scopes[2]);
			Assert.AreEqual("roles", scopes[3]);
			Assert.AreEqual("offline_access", scopes[4]);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAllowRememberConsent()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AllowRememberConsent.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAlwaysSendClientClaims()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AlwaysSendClientClaims.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetAuthorizationCodeLifetime()
		{
			Assert.AreEqual(300, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().AuthorizationCodeLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetClientId()
		{
			Assert.AreEqual("Client1", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().ClientId);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetClientName()
		{
			Assert.AreEqual("Client One", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().ClientName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetClientUri()
		{
			Assert.AreEqual("http://localhost", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().ClientUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetEnabled()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Enabled.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetEnableLocalLogin()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().EnableLocalLogin.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetFlow()
		{
			Assert.AreEqual(eFlows.Hybrid, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Flow);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetIdentityProviderRestrictions()
		{
			var restrictions = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().IdentityProviderRestrictions;

			Assert.AreEqual(2, restrictions.Count());
			Assert.AreEqual("microsoft.com", restrictions.First());
			Assert.AreEqual("google.com", restrictions.Skip(1).First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetIdentityTokenLifetime()
		{
			Assert.AreEqual(300, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().IdentityTokenLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetIncludeJwtId()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().IncludeJwtId.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetLogoUri()
		{
			Assert.AreEqual("http://localhost/1.bmp", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().LogoUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetLogoutSessionRequired()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().LogoutSessionRequired.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetLogoutUri()
		{
			Assert.AreEqual("http://localhost/logout", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().LogoutUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetPostLogoutRedirectUris()
		{
			var uris = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().PostLogoutRedirectUris;

			Assert.AreEqual(2, uris.Count());
			Assert.AreEqual("https://localhost:44301/", uris.First());
			Assert.AreEqual("https://localhost:44302/", uris.Skip(1).First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetPrefixClientClaims()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().PrefixClientClaims.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetRedirectUris()
		{
			var uris = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().RedirectUris;

			Assert.AreEqual(2, uris.Count());
			Assert.AreEqual("https://localhost:44301/", uris.First());
			Assert.AreEqual("https://localhost:44302/", uris.Skip(1).First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetRefreshTokenExpiration()
		{
			Assert.AreEqual(eTokenExpiration.Absolute, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().RefreshTokenExpiration);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetRefreshTokenUsage()
		{
			Assert.AreEqual(eTokenUsage.OneTimeOnly, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().RefreshTokenUsage);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetRequireConsent()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().RequireConsent.Value);

		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetSlidingRefreshTokenLifetime()
		{
			Assert.AreEqual(1296000, CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().SlidingRefreshTokenLifetime);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients")]
		public void GetUpdateAccessTokenClaimsOnRefresh()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().UpdateAccessTokenClaimsOnRefresh.Value);
		}
		#endregion

		#region Test Methods (Claims)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetTwoDistinctClaims()
		{
			var claims = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims;

			Assert.AreEqual(2, claims.Count());
			Assert.AreNotEqual(claims.First().Value, claims.Skip(1).First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetClaimValue()
		{
			Assert.AreEqual("claimValue", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims.First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetClaimType()
		{
			Assert.AreEqual("claimType", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims.First().Type);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetClaimValueType()
		{
			Assert.AreEqual("http://www.w3.org/2001/XMLSchema#string", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims.First().ValueType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetClaimIssuer()
		{
			Assert.AreEqual("LOCAL AUTHORITY", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims.First().Issuer);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Claims")]
		public void GetOriginalIssuer()
		{
			Assert.AreEqual("http://localhost", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Claims.First().OriginalIssuer);
		}
		#endregion

		#region Test Methods (Secrets)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Secrets")]
		public void GetTwoDistinctSecrets()
		{
			var secrets = CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Secrets;

			Assert.AreEqual(2, secrets.Count());
			Assert.AreNotEqual(secrets.First().Value, secrets.Skip(1).First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Secrets")]
		public void GetClaimSecretValue()
		{
			Assert.AreEqual("value", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Secrets.First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Secrets")]
		public void GetClaimSecretType()
		{
			Assert.AreEqual("SharedSecret", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Secrets.First().Type);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Secrets")]
		public void GetClaimSecretDescription()
		{
			Assert.AreEqual("description", CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Secrets.First().Description);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Clients - Secrets")]
		public void GetClaimSecretExpiration()
		{
			Assert.AreEqual(DateTimeOffset.Parse("01/01/2000 12:00:00 AM"), CompanySecurityConfig.Current.IdentityServer.Server.Clients.First().Secrets.First().Expiration);
		}
		#endregion
	}
}
