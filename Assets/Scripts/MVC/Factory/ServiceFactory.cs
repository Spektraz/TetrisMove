using System;
using System.Collections.Generic;
using MVC.Service;

namespace MVC.Factory
{
    public static class ServiceFactory
    {
        private static Dictionary<Type, BaseServiceLayer> ServiceDictionary =
            new Dictionary<Type, BaseServiceLayer>();
        
        public static T GetService<T>() where T : BaseServiceLayer
        {
            if (ServiceDictionary.ContainsKey(typeof(T)))
            {
                return ServiceDictionary[typeof(T)] as T;
            }
            else
            {
                var instance = (T) Activator.CreateInstance(typeof(T));
                ServiceDictionary.Add(typeof(T), instance);
                return instance;
            }
        }
    }
}