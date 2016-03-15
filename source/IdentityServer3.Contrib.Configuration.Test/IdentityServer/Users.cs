using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Users
	{
		#region Test Methods (Root)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Users")]
		public void GetIsUseInMemoryStore()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Users.IsUseInMemoryStore);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Users")]
		public void GetIsIncludeDomainRoles()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Users.IsIncludeDomainRoles);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Users")]
		public void GetConnectionKey()
		{
			Assert.AreEqual("Company.Shared.Security.ConnectionString", CompanySecurityConfig.Current.IdentityServer.Server.Users.ConnectionKey);
		}
		#endregion
	}
}
