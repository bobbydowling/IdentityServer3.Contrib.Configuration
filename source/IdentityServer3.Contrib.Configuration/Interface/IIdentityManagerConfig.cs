using System;
using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IIdentityManagerConfig
	{
		#region Properties
		bool IsEnabled { get; }

		bool IsDisableUserInterface { get; }

		ISecurity Security { get; }
		#endregion
	}

	public interface ISecurity
	{
		#region Properties
		eIdentityManagerSecurity Type { get; }

		string AdditionalSignOutType { get; }

		string AdminRoleName { get; }

		string BearerAuthenticationType { get; }

		string HostAuthenticationType { get; }

		string NameClaimType { get; }

		bool RequireSsl { get; }

		string RoleClaimType { get; }

		bool? ShowLoginButton { get; }

		TimeSpan TokenExpiration { get; }
		#endregion
	}
}