using System;
using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class IdentityManager
	{
		#region Test Methods (Root)
		public void GetIsEnabled()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityManager.IsEnabled);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager")]
		public void GetIsDisableUserInterface()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityManager.IsDisableUserInterface);
		}
		#endregion

		#region Test Methods (Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetSecurityType()
		{
			Assert.AreEqual(eIdentityManagerSecurity.Host, CompanySecurityConfig.Current.IdentityManager.Security.Type);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetAdditionalSignOutType()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityManager.Security.AdditionalSignOutType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetAdminRoleName()
		{
			Assert.AreEqual("IdentityManager", CompanySecurityConfig.Current.IdentityManager.Security.AdminRoleName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetBearerAuthenticationType()
		{
			Assert.AreEqual("bearer", CompanySecurityConfig.Current.IdentityManager.Security.BearerAuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetHostAuthenticationType()
		{
			Assert.AreEqual("Cookies", CompanySecurityConfig.Current.IdentityManager.Security.HostAuthenticationType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetNameClaimType()
		{
			Assert.AreEqual("name", CompanySecurityConfig.Current.IdentityManager.Security.NameClaimType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetRequireSsl()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityManager.Security.RequireSsl);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetRoleClaimType()
		{
			Assert.AreEqual("role", CompanySecurityConfig.Current.IdentityManager.Security.RoleClaimType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetShowLoginButton()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityManager.Security.ShowLoginButton.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityManager - Security")]
		public void GetTokenExpiration()
		{
			Assert.AreEqual(new TimeSpan(10, 00, 00), CompanySecurityConfig.Current.IdentityManager.Security.TokenExpiration);
		}
		#endregion
	}
}