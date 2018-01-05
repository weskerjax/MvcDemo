using System;
using System.Collections.Concurrent;
using Autofac;
using MvcDemo.Service;

namespace MvcDemo.WebApp
{

	public interface ISmsServiceContext
	{
		IRoleService Role { get; }
		IUserService User { get; }
	}



	public class SmsServiceContext : ISmsServiceContext
	{
		private ConcurrentDictionary<Type, object> _cache = new ConcurrentDictionary<Type, object>();

		private IComponentContext _factory;

		public SmsServiceContext(IComponentContext factory)
		{
			_factory = factory;
		}

		private T get<T>()
		{
			return (T)_cache.GetOrAdd(typeof(T), _ => _factory.Resolve<T>());
		}

		public IRoleService Role { get { return get<IRoleService>(); } }
		public IUserService User { get { return get<IUserService>(); } }

	}



}