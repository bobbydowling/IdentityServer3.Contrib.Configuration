using System.Collections.Generic;
using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IIdentityServerScopeConfig
	{
		#region Properties
		IScopeClaims Claims { get; }

		string ClaimsRule { get; }

		string Description { get; }

		string DisplayName { get; }

		bool? Emphasize { get; }

		bool? Enabled { get; }

		bool? IncludeAllClaimsForUser { get; }

		string Name { get; }

		bool? Required { get; }

		ISecrets Secrets { get; }

		bool? ShowInDiscoveryDocument { get; }

		eScopeType? ScopeType { get; }
		#endregion
	}

	public interface IScopeClaims : IList<IScopeClaim> { }

	public interface IScopeClaim
	{
		#region Properties
		bool? AlwaysIncludeInIdToken { get; }

		string Description { get; }

		string Name { get; }
		#endregion
	}
}
