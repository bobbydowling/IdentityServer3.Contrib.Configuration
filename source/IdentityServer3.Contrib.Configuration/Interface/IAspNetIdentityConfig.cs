using System;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IAspNetIdentityConfig
	{
		#region Properties
		IPassword Password { get; }

		IUserManager UserManager { get; }
		#endregion
	}

	public interface IPassword
	{
		#region Properties
		int RequiredLength { get; }

		string MatchPattern { get; }

		string MatchPatternMessage { get; }

		int HistoryLimit { get; }

		int ExpiryDays { get; }
		#endregion
	}

	public interface IUserManager
	{
		#region Properties
		bool? IsUserLockoutEnabledByDefault { get; }

		TimeSpan? DefaultAccountLockoutTimeSpan { get; }

		int? MaxFailedAccessAttemptsBeforeLockout { get; }

		ISupportedFields SupportedFields { get; }

		TimeSpan TokenProviderTokenExpiration { get; }
		#endregion
	}

	public interface ISupportedFields
	{
		#region Properties
		bool? IsSupportsQueryableUsers { get; }

		bool? IsSupportsUserClaim { get; }

		bool? IsSupportsUserEmail { get; }

		bool? IsSupportsUserLockout { get; }

		bool? IsSupportsUserLogin { get; }

		bool? IsSupportsUserPassword { get; }

		bool? IsSupportsUserPhoneNumber { get; }

		bool? IsSupportsUserRole { get; }

		bool? IsSupportsUserSecurityStamp { get; }

		bool? IsSupportsUserTwoFactor { get; }
		#endregion
	}
}
