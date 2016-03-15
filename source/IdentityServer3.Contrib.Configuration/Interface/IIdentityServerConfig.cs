namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IIdentityServerConfig
	{
		#region Properties
		IClientConfig Client { get; }

		IServerConfig Server { get; }
		#endregion
	}
}
