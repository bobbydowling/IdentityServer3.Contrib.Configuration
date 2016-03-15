using System.Collections.Generic;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IServerConfig
	{
		#region Properties
		string BasePath { get; }

		string Path { get; }

		string AdminPath { get; }

		string Domain { get; }

		IIdentityServerClientsConfig Clients { get; }

		IIdentityServerUsersConfig Users { get; }

		IIdentityServerScopesConfig Scopes { get; }

		IIdentityServerOptionsConfig Options { get; }
		#endregion
	}

	public interface IIdentityServerClientsConfig : IList<IIdentityServerClientConfig>
	{
		#region Properties
		bool IsUseInMemoryStore { get; }
		#endregion
	}

	public interface IIdentityServerUsersConfig : IList<IIdentityServerUserConfig>
	{
		#region Properties
		bool IsUseInMemoryStore { get; }

		bool IsIncludeDomainRoles { get; }

		string ConnectionKey { get; }
		#endregion
	}

	public interface IIdentityServerScopesConfig : IList<IIdentityServerScopeConfig>
	{
		#region Properties
		bool IsUseInMemoryStore { get; }
		#endregion
	}
}
