using System;
using System.Linq;

using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Scopes
	{
		#region Test Methods (Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetIsUseInMemoryStore()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Scopes.IsUseInMemoryStore);
		}
		#endregion

		#region Test Methods
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetTwoDistinctClients()
		{
			var scopes = CompanySecurityConfig.Current.IdentityServer.Server.Scopes;

			Assert.AreEqual(6, scopes.Count());
			Assert.AreEqual("OpenId", scopes[0].Name);
			Assert.AreEqual("Roles", scopes[1].Name);
			Assert.AreEqual("Profile", scopes[2].Name);
			Assert.AreEqual("Email", scopes[3].Name);
			Assert.AreEqual("OfflineAccess", scopes[4].Name);
			Assert.AreEqual("name", scopes[5].Name);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetClaimsRule()
		{
			Assert.AreEqual("claimsRule", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].ClaimsRule);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetDescription()
		{
			Assert.AreEqual("description", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Description);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetDisplayName()
		{
			Assert.AreEqual("displayName", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].DisplayName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetEmphasize()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Emphasize.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetEnabled()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Enabled.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetIncludeAllClaimsForUser()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].IncludeAllClaimsForUser.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetName()
		{
			Assert.AreEqual("name", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Name);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetRequired()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Required.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetShowInDiscoveryDocument()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].ShowInDiscoveryDocument.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes")]
		public void GetScopeType()
		{
			Assert.AreEqual(eScopeType.Identity, CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].ScopeType.Value);
		}
		#endregion

		#region Test Methods (Claims)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Claims")]
		public void GetTwoDistinctClaims()
		{
			var claims = CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Claims;

			Assert.AreEqual(2, claims.Count());
			Assert.AreNotEqual(claims.First().Name, claims.Skip(1).First().Name);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Claims")]
		public void GetAlwaysIncludeInIdToken()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Claims.First().AlwaysIncludeInIdToken.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Claims")]
		public void GetScopeSecretDescription()
		{
			Assert.AreEqual("description", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Claims.First().Description);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Claims")]
		public void GetScopeSecretName()
		{
			Assert.AreEqual("name", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Claims.First().Name);
		}
		#endregion

		#region Test Methods (Secrets)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Secrets")]
		public void GetTwoDistinctSecrets()
		{
			var secrets = CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Secrets;

			Assert.AreEqual(2, secrets.Count());
			Assert.AreNotEqual(secrets.First().Value, secrets.Skip(1).First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Secrets")]
		public void GetClaimSecretValue()
		{
			Assert.AreEqual("value", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Secrets.First().Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Secrets")]
		public void GetClaimSecretType()
		{
			Assert.AreEqual("type", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Secrets.First().Type);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Secrets")]
		public void GetClaimSecretDescription()
		{
			Assert.AreEqual("description", CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Secrets.First().Description);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Scopes - Secrets")]
		public void GetClaimSecretExpiration()
		{
			Assert.AreEqual(DateTimeOffset.Parse("01/01/2000 12:00:00 AM"), CompanySecurityConfig.Current.IdentityServer.Server.Scopes[5].Secrets.First().Expiration);
		}
		#endregion
	}
}
