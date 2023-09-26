using FeTo.Exceptions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FeTo.ServiceLocator
{
    [HelpURL("https://github.com/Neengash/UnityFeTo/tree/FeTo/ServiceLocator#service-locator")]
    public class ServiceLocator
    {
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();
        private static ServiceLocator _instance;

        private readonly Dictionary<Type, object> _services;

        private ServiceLocator()
        {
            _services = new();
        }

        public void RegisterService<T>(T service)
        {
            Type type = typeof(T);

            if (_services.TryGetValue(type, out object _))
                throw new FeToException($"Service {type} already registered");

            _services.Add(type, service);
        }

        public T GetService<T>()
        {
            Type type = typeof(T);

            if (!_services.TryGetValue(type, out object service))
                throw new FeToException($"Service {type} NOT registered");

            return (T)service;
        }
    }
}
