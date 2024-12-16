using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Services
{
    public class ServiceLocator
    {
        public static ProjectContext ProjectContext => _projectContext;
        
        private static Dictionary<Type, IService> _services = new ();
        private static ProjectContext _projectContext;

        public static void Setup(ProjectContext context)
        {
            _projectContext = context;
        }
        
        public static void Destroy()
        {
            _services.Clear();
            
            Object.Destroy(_projectContext.gameObject);
            _projectContext = null;
            
            SceneManager.LoadScene("Init");
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

        public static T CreateInstance<T>(T prefab, Transform parent = null) where T : Object
        {
            if (prefab == null)
                throw new NullReferenceException("Empty prefab, cannot create a instance.");

            if (parent == null)
                parent = _projectContext.transform;

            return Object.Instantiate(prefab, parent);
        }
        
        public static T CreateInstance<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null)
            where T : Object
        {
            if (prefab == null)
                throw new NullReferenceException("Empty prefab, cannot create a instance.");

            if (parent == null)
                parent = _projectContext.transform;

            return Object.Instantiate(prefab, position, rotation, parent);
        }
    }
}