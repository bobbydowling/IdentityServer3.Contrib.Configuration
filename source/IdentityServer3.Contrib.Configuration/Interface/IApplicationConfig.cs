using System;
using System.Collections.Generic;

using IdentityServer3.Contrib.Configuration.Enumeration;

namespace IdentityServer3.Contrib.Configuration.Interface
{
	public interface IApplicationConfig
	{
		#region Properties
		IAuthorization Authorization { get; }

		IClaimsCollection ClaimsCollection { get; }
		#endregion
	}

	public interface IAuthorization
	{
		#region Properties
		int Timeout { get; }
		#endregion
	}

	public interface IClaimsCollection
	{
		#region Properties
		List<eClaimsApplication> Applications { get; }

		string ConnectionKey { get; }

		bool IsCacheEnabled { get; }

		eCacheType CacheType { get; }

		TimeSpan Expiry { get; }
		#endregion
	}
}
