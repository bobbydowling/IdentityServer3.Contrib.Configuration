using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

using IdentityServer3.Contrib.Configuration.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentityServer3.Contrib.Configuration.Test
{
	[TestClass]
	public class Options
	{
		#region Test Methods
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options")]
		public void GetEnableWelcomePage()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EnableWelcomePage.Value);
		}

		public void GetIssuerUri()
		{
			Assert.AreEqual("https://localhost:44300", CompanySecurityConfig.Current.IdentityServer.Server.Options.IssuerUri);
		}

		public void GetTwoDistinctProtocolLogoutUrls()
		{
			var urls = CompanySecurityConfig.Current.IdentityServer.Server.Options.ProtocolLogoutUrls;

			Assert.AreEqual(2, urls.Count());
			Assert.AreEqual("https://localhost:44300", urls[0]);
			Assert.AreEqual("https://localhost:44301", urls[1]);
		}

		public void GetPublicOrigin()
		{
			Assert.AreEqual("https://localhost:44300", CompanySecurityConfig.Current.IdentityServer.Server.Options.PublicOrigin);
		}

		public void GetRequireSsl()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.RequireSsl.Value);
		}

		public void GetSiteName()
		{
			Assert.AreEqual("Company Authentication Server", CompanySecurityConfig.Current.IdentityServer.Server.Options.SiteName);
		}
		#endregion

		#region Test Methods (Authentication)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetEnableLocalLogin()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.EnableLocalLogin.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetEnableLoginHint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.EnableLoginHint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetEnablePostSignOutAutoRedirect()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.EnablePostSignOutAutoRedirect.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetEnableSignOutPrompt()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.EnableSignOutPrompt.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetInvalidSignInRedirectUrl()
		{
			Assert.AreEqual("http://localhost:44300", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.InvalidSignInRedirectUrl);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetPostSignOutAutoRedirectDelay()
		{
			Assert.AreEqual(0, CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.PostSignOutAutoRedirectDelay);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetRememberLastUsername()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.RememberLastUsername.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetRequireAuthenticatedUserForSignOutMessage()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.RequireAuthenticatedUserForSignOutMessage.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetSignInMessageThreshold()
		{
			Assert.AreEqual(5, CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.SignInMessageThreshold);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetIsEnableExternalWindowsAuthentication()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.IsEnableExternalWindowsAuthentication);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetExternalWindowsAuthenticationCaption()
		{
			Assert.AreEqual("Windows", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.ExternalWindowsAuthenticationCaption);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetResetPasswordRedirectUri()
		{
			Assert.AreEqual("/account/ResetPasswordRedirect?subject={0}&username={1}&redirectUrl={2}", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.ResetPasswordRedirectUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication")]
		public void GetResetPasswordUri()
		{
			Assert.AreEqual("/account/ResetPassword?subject={0}&token={1}&redirectUrl={2}", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.ResetPasswordUri);
		}
		#endregion

		#region Test Methods (Authentication - Cookie)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetAllowRememberMe()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.AllowRememberMe.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetExpireTimeSpan()
		{
			Assert.AreEqual(TimeSpan.FromHours(10), CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.ExpireTimeSpan.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetIsPersistent()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.IsPersistent.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetPath()
		{
			Assert.AreEqual("/some/path", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.Path);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetPrefix()
		{
			Assert.AreEqual("dcis", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.Prefix);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetRememberMeDuration()
		{
			Assert.AreEqual(TimeSpan.FromDays(30), CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.RememberMeDuration);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetSecureMode()
		{
			Assert.AreEqual(eCookieSecureMode.SameAsRequest, CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.SecureMode);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Cookie")]
		public void GetSlidingExpiration()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.Cookie.SlidingExpiration.Value);
		}
		#endregion

		#region Test Methods (Authentication - Login Page Links)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Login Page Links")]
		public void GetTwoDistinctLoginPageLinks()
		{
			var links = CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.LoginPageLinks;

			Assert.AreEqual(2, links.Count());
			Assert.AreNotEqual(links.First().Href, links.Skip(1).First().Href);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Login Page Links")]
		public void GetLoginPageLinkHref()
		{
			Assert.AreEqual("http://localhost", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.LoginPageLinks[0].Href);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Login Page Links")]
		public void GetLoginPageLinkText()
		{
			Assert.AreEqual("localhost", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.LoginPageLinks[0].Text);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Authentication - Login Page Links")]
		public void GetLoginPageLinkType()
		{
			Assert.AreEqual("local", CompanySecurityConfig.Current.IdentityServer.Server.Options.Authentication.LoginPageLinks[0].Type);
		}
		#endregion

		#region Test Methods (Caching)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetIsCacheEnabledClients()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.IsEnabledClients);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetIsCacheEnabledScopes()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.IsEnabledScopes);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetIsCacheEnabledUsers()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.IsEnabledUsers);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetIsUseInMemoryStore()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.IsUseInMemoryStore);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetCustomCacheType()
		{
			Assert.AreEqual(eCacheType.Redis, CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.CustomType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetClientCacheExpiry()
		{
			Assert.AreEqual(TimeSpan.FromHours(2), CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.ClientExpiry);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetScopeCacheExpiry()
		{
			Assert.AreEqual(TimeSpan.FromHours(2), CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.ScopeExpiry);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetUserCacheExpiry()
		{
			Assert.AreEqual(TimeSpan.FromMinutes(30), CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.UserExpiry);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Caching")]
		public void GetUsersCacheExpiry()
		{
			Assert.AreEqual(TimeSpan.Parse("24:00:00"), CompanySecurityConfig.Current.IdentityServer.Server.Options.Caching.UsersExpiry);
		}
		#endregion

		#region Test Methods (Certificate)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetName()
		{
			Assert.AreEqual("|~|", CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.Name);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetStoreName()
		{
			Assert.AreEqual(StoreName.My, CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.StoreName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetStoreLocation()
		{
			Assert.AreEqual(StoreLocation.LocalMachine, CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.StoreLocation);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetFileName()
		{
			Assert.AreEqual("Company.Shared.Security.IdentityServer.idsrv3test.pfx", CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.FileName);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetPassword()
		{
			Assert.AreEqual("idsrv3test", CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.Password);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Certificate")]
		public void GetStorageFlags()
		{
			Assert.AreEqual(X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.MachineKeySet, CompanySecurityConfig.Current.IdentityServer.Server.Options.Certificate.StorageFlags.Value);
		}
		#endregion

		#region Test Methods (Cors)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Cors")]
		public void GetIsUseInMemoryStoreCors()
		{
			Assert.AreEqual(true, CompanySecurityConfig.Current.IdentityServer.Server.Options.Cors.IsUseInMemoryStore);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Cors")]
		public void GetAllowAllCustom()
		{
			Assert.AreEqual(false, CompanySecurityConfig.Current.IdentityServer.Server.Options.Cors.AllowAllCustom);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Cors")]
		public void GetAllowedOriginsCustom()
		{
			Assert.AreEqual("http://bar.com", CompanySecurityConfig.Current.IdentityServer.Server.Options.Cors.AllowedOriginsCustom.Skip(1).First());
		}
		#endregion

		#region Test Methods (CSP)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetConnectSource()
		{
			Assert.AreEqual("/connect/source", CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.ConnectSource);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetCspEnabled()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.Enabled.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetFontSource()
		{
			Assert.AreEqual("/font/source", CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.FontSource);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetImageSource()
		{
			Assert.AreEqual("/image/source", CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.ImageSource);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetScriptSource()
		{
			Assert.AreEqual("/script/source", CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.ScriptSource);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - CSP")]
		public void GetStyleSource()
		{
			Assert.AreEqual("/style/source", CompanySecurityConfig.Current.IdentityServer.Server.Options.Csp.StyleSource);
		}
		#endregion

		#region Test Methods (EndPoints)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableAuthorizeEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableAuthorizeEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableTokenEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableTokenEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableUserInfoEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableUserInfoEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableDiscoveryEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableDiscoveryEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableAccessTokenValidationEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableAccessTokenValidationEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableIdentityTokenValidationEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableIdentityTokenValidationEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableEndSessionEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableEndSessionEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableClientPermissionsEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableClientPermissionsEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableCspReportEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableCspReportEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableCheckSessionEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableCheckSessionEndpoint.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableTokenRevocationEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableTokenRevocationEndpoint.Value);
		}
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - EndPoints")]
		public void GetEnableIntrospectionEndpoint()
		{
			Assert.IsTrue(CompanySecurityConfig.Current.IdentityServer.Server.Options.EndPoints.EnableIntrospectionEndpoint.Value);
		}
		#endregion

		#region Test Methods (Events)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Events")]
		public void GetRaiseErrorEvents()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Events.RaiseErrorEvents.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Events")]
		public void GetRaiseFailureEvents()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Events.RaiseFailureEvents.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Events")]
		public void GetRaiseInformationEvents()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Events.RaiseInformationEvents.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Events")]
		public void GetRaiseSuccessEvents()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Events.RaiseSuccessEvents.Value);
		}
		#endregion

		#region Test Methods (Input Length Restrictions)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsAcrValues()
		{
			Assert.AreEqual(300, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.AcrValues);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsClientId()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.ClientId);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsCspReport()
		{
			Assert.AreEqual(2000, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.CspReport);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsGrantType()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.GrantType);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsIdentityProvider()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.IdentityProvider);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsLoginHint()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.LoginHint);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsNonce()
		{
			Assert.AreEqual(300, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.Nonce);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsPassword()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.Password);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsRedirectUri()
		{
			Assert.AreEqual(400, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.RedirectUri);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsScope()
		{
			Assert.AreEqual(300, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.Scope);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsUiLocale()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.UiLocale);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Input Length Restrictions")]
		public void GetInputLengthRestrictionsUserName()
		{
			Assert.AreEqual(100, CompanySecurityConfig.Current.IdentityServer.Server.Options.InputLengthRestrictions.UserName);
		}
		#endregion

		#region Test Methods (Logging)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Logging")]
		public void GetEnableHttpLogging()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Logging.EnableHttpLogging.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Logging")]
		public void GetEnableKatanaLogging()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Logging.EnableKatanaLogging.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Logging")]
		public void GetEnableWebApiDiagnostics()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Logging.EnableWebApiDiagnostics.Value);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Logging")]
		public void GetWebApiDiagnosticsIsVerbose()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.Logging.WebApiDiagnosticsIsVerbose.Value);
		}
		#endregion

		#region Test Methods (OperationalData)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - OperationalData")]
		public void GetIsUseInMemoryStoreOperationalData()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.OperationalData.IsUseInMemoryStore);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - OperationalData")]
		public void GetIsCleanUp()
		{
			Assert.IsFalse(CompanySecurityConfig.Current.IdentityServer.Server.Options.OperationalData.IsCleanUp);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - OperationalData")]
		public void GetTokenExpiry()
		{
			Assert.AreEqual(60, CompanySecurityConfig.Current.IdentityServer.Server.Options.OperationalData.TokenExpiry);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - OperationalData")]
		public void GetConnectionKey()
		{
			Assert.AreEqual("Company.Shared.Security.ConnectionString", CompanySecurityConfig.Current.IdentityServer.Server.Options.OperationalData.ConnectionKey);
		}
		#endregion

		#region Test Methods (Tenants)
		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Tenants")]
		public void GetTwoDistinctUserStores()
		{
			var tenants = CompanySecurityConfig.Current.IdentityServer.Server.Options.Tenants;

			Assert.AreEqual(2, tenants.Count());
			Assert.AreNotEqual(tenants.First().Id, tenants.Skip(1).First().Id);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Tenants")]
		public void GetTenantId()
		{
			Assert.AreEqual(eTenant.SomeApplication, CompanySecurityConfig.Current.IdentityServer.Server.Options.Tenants[0].Id);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Tenants")]
		public void GetTenantDescription()
		{
			Assert.AreEqual("Some Application", CompanySecurityConfig.Current.IdentityServer.Server.Options.Tenants[0].Description);
		}

		[TestMethod]
		[TestCategory("Unit - Security - Configuration - IdentityServer - Options - Tenants")]
		public void GetTenantConnectionKey()
		{
			Assert.AreEqual("Company.Shared.Security.ConnectionString.SomeApplication", CompanySecurityConfig.Current.IdentityServer.Server.Options.Tenants[0].ConnectionKey);
		}
		#endregion
	}
}
