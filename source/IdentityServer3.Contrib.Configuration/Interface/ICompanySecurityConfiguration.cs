namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface ICompanySecurityConfiguration
	{
		#region Properties
		IApplicationConfig Application { get; }

		IAspNetIdentityConfig AspNetIdentity { get; }

		IIdentityManagerConfig IdentityManager { get; }

		IIdentityServerConfig IdentityServer { get; }
		#endregion
	}
}
