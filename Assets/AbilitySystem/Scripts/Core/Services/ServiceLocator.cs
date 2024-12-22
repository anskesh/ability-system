using System;
using System.Collections.Generic;

namespace Services
{
    public class ServiceLocator
    {
        private static Dictionary<Type, IService> _services = new ();
        private static ProjectContext _projectContext;

        public static void Setup(ProjectContext context)
        {
            _projectContext = context;
        }
        
        public static void Destroy()
        {
            _projectContext = null;
            _services.Clear();
        }

        public static bool HasService<TService>() where TService : IService
        {
            return _services.ContainsKey(typeof(TService));
        }
        
        public static void AddService<TService>(TService state) where TService : IService
        {
            Type type = state.GetType();

            if (_services.ContainsKey(type))
                throw new Exception($"State with type {type} already added.");

            _services.Add(type, state);
        }

        public static void RemoveService<TService>() where TService : IService
        {
            Type type = typeof(TService);

            if (!_services.ContainsKey(type))
                throw new Exception($"State with type {type} doesn't added.");

            _services.Remove(type);
        }

        public static TService GetService<TService>() where TService : IService
        {
            Type type = typeof(TService);

            if (_services.ContainsKey(type))
                return (TService) _services[type];

            throw new Exception($"Service {type} not found.");
        }
    }
}