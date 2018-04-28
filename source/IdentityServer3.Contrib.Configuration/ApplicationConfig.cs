using System;
using System.Collections.Generic;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
using IdentityServer3.Contrib.Configuration.Extension;
using IdentityServer3.Contrib.Configuration.Interface;

namespace IdentityServer3.Contrib.Configuration
{
	public class ApplicationConfig : IApplicationConfig
	{
		#region Fields
		private IAuthorization _authorization;
		private IClaimsCollection _claimsCollection;

		private XPathNavigator _nav;
		private IApplicationConfig _template = null;
		#endregion

		#region Constructors
		public ApplicationConfig(XPathNavigator nav, IApplicationConfig template)
		{
			_template = template;
			_nav = nav;

			if (_template != null) { }
		}
		#endregion

		#region Properties
		public IAuthorization Authorization
		{
			get
			{
				if (_authorization == null)
					_authorization = new Authorization(GetChild(_nav, nameof(Authorization).ToLowerFirstLetter()), _template != null ? _template.Authorization : null);

				return _authorization;
			}
		}

		public IClaimsCollection ClaimsCollection
		{
			get
			{
				if (_claimsCollection == null)
					_claimsCollection = new ClaimsCollection(GetChild(_nav, nameof(ClaimsCollection).ToLowerFirstLetter()), _template != null ? _template.ClaimsCollection : null);

				return _claimsCollection;
			}
		}
		#endregion

		#region Protected Methods
		protected XPathNavigator GetChild(XPathNavigator nav, string nodeName)
		{
			var iter = nav.Select(nodeName);

			if (iter.MoveNext())
				return iter.Current;

			return nav;
		}
		#endregion
	}

	public class Authorization : IAuthorization
	{
		#region Fields
		private XPathNavigator _nav;
		private IAuthorization _template = null;
		#endregion

		#region Constructors
		public Authorization(XPathNavigator nav, IAuthorization template)
		{
			_template = template;
			_nav = nav;

            Timeout = _nav.GetInt(nameof(Timeout), _template);
		}
		#endregion

		#region Properties
		public int Timeout { get; private set; }
        #endregion
    }

	public class ClaimsCollection : IClaimsCollection
	{
		#region Fields
		private XPathNavigator _nav;
		private IClaimsCollection _template = null;
		#endregion

		#region Constructors
		public ClaimsCollection(XPathNavigator nav, IClaimsCollection template)
		{
			_template = template;
			_nav = nav;

            Applications = _nav.GetListEnum<eClaimsApplication>(nameof(Applications), _template);
            ConnectionKey = _nav.GetString(nameof(ConnectionKey), _template);
            IsCacheEnabled = _nav.GetBool(nameof(IsCacheEnabled), _template);
            CacheType = _nav.GetEnum<eCacheType>(nameof(CacheType), _template);
            Expiry = _nav.GetTimeSpan(nameof(Expiry), _template);
		}
		#endregion

		#region Properties
		public List<eClaimsApplication> Applications { get; private set; }

		public string ConnectionKey { get; private set; }

        public bool IsCacheEnabled { get; private set; }

        public eCacheType CacheType { get; private set; }

        public TimeSpan Expiry { get; private set; }
        #endregion
    }
}
