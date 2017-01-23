using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UT.Presentation.Web.Tests.Helpers
{
    public class InMemoryDependencyResolver : IDependencyResolver
    {
        private readonly IDictionary<Type, object> _services;

        protected InMemoryDependencyResolver()
        {
            _services = new Dictionary<Type, object>();
        }

        public InMemoryDependencyResolver AddService<TService>(TService serviceInstance)
        {
            _services.Add(typeof(TService), serviceInstance);
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (_services.ContainsKey(serviceType))
            {
                return _services[serviceType];
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public static InMemoryDependencyResolver New()
        {
            var instance = new InMemoryDependencyResolver();
            DependencyResolver.SetResolver(instance);
            return instance;
        }
    }
}
