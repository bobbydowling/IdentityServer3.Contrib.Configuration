using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Server
	{
		#region Test Methods
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Server")]
		public void GetBasePath()
		{
			Assert.AreEqual("https://localhost:44300", CompanySecurityConfig.Current.IdentityServer.Server.BasePath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Server")]
		public void GetPath()
		{
			Assert.AreEqual("/core", CompanySecurityConfig.Current.IdentityServer.Server.Path);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Server")]
		public void GetAdminPath()
		{
			Assert.AreEqual("/admin", CompanySecurityConfig.Current.IdentityServer.Server.AdminPath);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Server")]
		public void GetDomain()
		{
			Assert.AreEqual("Domain", CompanySecurityConfig.Current.IdentityServer.Server.Domain);
		}
		#endregion
	}
}
