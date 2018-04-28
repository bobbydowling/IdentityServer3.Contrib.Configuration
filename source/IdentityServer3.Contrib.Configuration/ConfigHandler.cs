using System;
using System.Configuration;
using System.IO;
using System.Xml;

using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ConfigSectionHandler : IConfigurationSectionHandler
	{
		#region IConfigurationSectionHandler Members
		public object Create(object parent, object configContext, XmlNode section)
		{
			return new CompanySecurityConfigData(section, CompanySecurityConfig.GetPath());
		}
		#endregion
	}

	public abstract class CompanySecurityConfig
	{
		#region Fields
		private static CompanySecurityConfigData _config = null;
		#endregion

		#region Public Properties
		public static ICompanySecurityConfiguration Current
		{
			get
			{
				if (_config != null)
					return _config;

				var config = (CompanySecurityConfigData)ConfigurationManager.GetSection(nameof(Security).ToLowerFirstLetter());

				if (config == null)
				{
					_config = new CompanySecurityConfigData(GetPath());
					config = _config;
				}

				return config;
			}
		}
		#endregion

		#region Public Methods
		public static string GetPath()
		{
			var returnValue = string.Empty;
			var configFilePath = ConfigurationManager.AppSettings["ConfigFilePath"];

			if (!string.IsNullOrEmpty(configFilePath))
			{
				returnValue = configFilePath;

				if (!File.Exists(returnValue))
					returnValue = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", returnValue);
			}

			if (!File.Exists(returnValue))
				returnValue = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\Security.config");

			return returnValue;
		}
		#endregion
	}
}
