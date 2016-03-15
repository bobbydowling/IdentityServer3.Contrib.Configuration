using System;
using System.Linq;

using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Application
	{
		#region Test Methods (Authorization)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - Authorization")]
		public void GetTimeout()
		{
			Assert.AreEqual(5000, CompanySecurityConfig.Current.Application.Authorization.Timeout);
		}
		#endregion

		#region Test Methods (Claims Collection)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - ClaimsCollection")]
		public void GetClaimsApplications()
		{
			Assert.AreEqual(eClaimsApplication.SomeApplication, CompanySecurityConfig.Current.Application.ClaimsCollection.Applications.First());
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - ClaimsCollection")]
		public void GetConnectionKey()
		{
			Assert.AreEqual("Company.Shared.Security.ConnectionString.{0}", CompanySecurityConfig.Current.Application.ClaimsCollection.ConnectionKey);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - ClaimsCollection")]
		public void GetIsCacheEnabled()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.Application.ClaimsCollection.IsCacheEnabled);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - ClaimsCollection")]
		public void GetCacheType()
		{
			Assert.AreEqual(eCacheType.Redis, CompanySecurityConfig.Current.Application.ClaimsCollection.CacheType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - Application - ClaimsCollection")]
		public void GetExpiry()
		{
			Assert.AreEqual(new TimeSpan(0, 30, 0), CompanySecurityConfig.Current.Application.ClaimsCollection.Expiry);
		}
		#endregion
	}
}
