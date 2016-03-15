using System;
using System.Collections.Generic;
using System.Xml.XPath;

using IdentityServer3.Contrib.Configuration.Enumeration;
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
					_authorization = new Authorization(GetChild(_nav, "authorization"), _template != null ? _template.Authorization : null);

				return _authorization;
			}
		}

		public IClaimsCollection ClaimsCollection
		{
			get
			{
				if (_claimsCollection == null)
					_claimsCollection = new ClaimsCollection(GetChild(_nav, "claimsCollection"), _template != null ? _template.ClaimsCollection : null);

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
		private int _timeout;

		private XPathNavigator _nav;
		private IAuthorization _template = null;
		#endregion

		#region Constructors
		public Authorization(XPathNavigator nav, IAuthorization template)
		{
			_template = template;
			_nav = nav;

			if (_template != null)
			{
				_timeout = _template.Timeout;
			}

			_nav.SetInt("timeout", ref _timeout);
		}
		#endregion

		#region Properties
		public int Timeout
		{
			get { return _timeout; }
		}
		#endregion
	}

	public class ClaimsCollection : IClaimsCollection
	{
		#region Fields
		private List<eClaimsApplication> _applications;
		private string _connectionKey;
		private bool _isCacheEnabled;
		private eCacheType _cacheType;
		private TimeSpan _expiry;

		private XPathNavigator _nav;
		private IClaimsCollection _template = null;
		#endregion

		#region Constructors
		public ClaimsCollection(XPathNavigator nav, IClaimsCollection template)
		{
			_template = template;
			_nav = nav;

			if (_template != null)
			{
				_applications = _template.Applications;
				_connectionKey = _template.ConnectionKey;
				_isCacheEnabled = _template.IsCacheEnabled;
				_cacheType = _template.CacheType;
				_expiry = _template.Expiry;
			}

			_nav.SetListEnum("applications", ref _applications);
			_nav.SetString("connectionKey", ref _connectionKey);
			_nav.SetBool("isCacheEnabled", ref _isCacheEnabled);
			_nav.SetEnum("cacheType", ref _cacheType);
			_nav.SetTimeSpan("expiry", ref _expiry);
		}
		#endregion

		#region Properties
		public List<eClaimsApplication> Applications
		{
			get { return _applications; }
		}

		public string ConnectionKey
		{
			get { return _connectionKey; }
		}

		public bool IsCacheEnabled
		{
			get { return _isCacheEnabled; }
		}

		public eCacheType CacheType
		{
			get { return _cacheType; }
		}

		public TimeSpan Expiry
		{
			get { return _expiry; }
		}
		#endregion
	}
}
