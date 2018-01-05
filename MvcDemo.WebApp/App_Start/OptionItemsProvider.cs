using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MvcDemo.WebApp
{
	public class OptionItemsProvider
	{
		private ConcurrentDictionary<string, object> _cache = new ConcurrentDictionary<string, object>();
		
		private ISmsServiceContext _svc;
		

		public OptionItemsProvider(
			ISmsServiceContext svc
		)
		{
			_svc = svc;
		}



		private T getItems<T>(string key, Func<string, T> valueFactory)
		{
			return (T)_cache.GetOrAdd(key, x => valueFactory(x));
		}



		/*######################################################################*/


		/// <summary>角色名稱</summary>
		public Dictionary<int, string> RoleName
		{
			get { return getItems(nameof(RoleName), _ => _svc.Role.GetNameItems()); }
		}

		/// <summary>使用者名稱</summary>
		public Dictionary<int, string> UserName
		{
			get { return getItems(nameof(UserName), _ => _svc.User.GetNameItems()); }
		}

		/// <summary>使用者完整名稱</summary>
		public Dictionary<int, string> UserFullName
		{
			get { return getItems(nameof(UserFullName), _ => _svc.User.GetFullNameItems()); }
		}
		




	}
}