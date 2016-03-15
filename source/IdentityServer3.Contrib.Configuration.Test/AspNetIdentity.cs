using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class AspNetIdentity
	{
		#region Test Methods (Root)
		#endregion

		#region Test Methods (Password)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - Password")]
		public void GetRequiredLength()
		{
			Assert.AreEqual(10, CompanySecurityConfig.Current.AspNetIdentity.Password.RequiredLength);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - Password")]
		public void GetMatchPattern()
		{
			Assert.AreEqual(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{10,}$", CompanySecurityConfig.Current.AspNetIdentity.Password.MatchPattern);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - Password")]
		public void GetMatchPatternMessage()
		{
			Assert.AreEqual("Password should have one numeral and one special character", CompanySecurityConfig.Current.AspNetIdentity.Password.MatchPatternMessage);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - Password")]
		public void GetHistoryLimit()
		{
			Assert.AreEqual(5, CompanySecurityConfig.Current.AspNetIdentity.Password.HistoryLimit);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - Password")]
		public void GetExpiryDays()
		{
			Assert.AreEqual(90, CompanySecurityConfig.Current.AspNetIdentity.Password.ExpiryDays);
		}
		#endregion

		#region Test Methods (UserManager)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager")]
		public void GetIsUserLockoutEnabledByDefault()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.IsUserLockoutEnabledByDefault);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager")]
		public void GetDefaultAccountLockoutTimeSpan()
		{
			Assert.AreEqual(new TimeSpan(0, 10, 0), CompanySecurityConfig.Current.AspNetIdentity.UserManager.DefaultAccountLockoutTimeSpan);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager")]
		public void GetMaxFailedAccessAttemptsBeforeLockout()
		{
			Assert.AreEqual(3, CompanySecurityConfig.Current.AspNetIdentity.UserManager.MaxFailedAccessAttemptsBeforeLockout);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager")]
		public void GetTokenProviderTokenExpiration()
		{
			Assert.AreEqual(new TimeSpan(24, 0, 0), CompanySecurityConfig.Current.AspNetIdentity.UserManager.TokenProviderTokenExpiration);
		}
		#endregion

		#region Test Methods (SupportedFields)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsQueryableUsers()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsQueryableUsers);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserClaim()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserClaim);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserEmail()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserEmail);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserLockout()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserLockout);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserLogin()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserLogin);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserPassword()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserPassword);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserPhoneNumber()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserPhoneNumber);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserRole()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserRole);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserSecurityStamp()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserSecurityStamp);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - AspNetIdentity - UserManager - SupportedFields")]
		public void GetIsSupportsUserTwoFactor()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.AspNetIdentity.UserManager.SupportedFields.IsSupportsUserTwoFactor);
		}
		#endregion
	}
}
