using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Common
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static void InjectServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static object ResolveService(Type type)
        {
            if (_serviceProvider == null)
            {
                return null;
            }

            try
            {
                return _serviceProvider.CreateScope().ServiceProvider.GetService(type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static object ResolveServices(Type type)
        {
            if (_serviceProvider == null)
            {
                return null;
            }
            try
            {
                return _serviceProvider.CreateScope().ServiceProvider.GetServices(type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T ResolveService<T>()
        {
            if (_serviceProvider == null)
            {
                return default(T);
            }
            try
            {
                return (T)_serviceProvider.CreateScope().ServiceProvider.GetService(typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static IEnumerable<T> ResolveServices<T>()
        {
            if (_serviceProvider == null)
            {
                return null;
            }

            try
            {
                return (IEnumerable<T>)_serviceProvider.CreateScope().ServiceProvider.GetServices(typeof(T));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
