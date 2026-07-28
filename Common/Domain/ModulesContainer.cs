using System;
using System.Collections.Generic;

namespace CM.Core.Domain
{
    public class ModuleContainer
    {
        private readonly Dictionary<Type, object> _modules = new();

        public void Add<T>(T module) where T : class
        {
            if (module is null)
                throw new ArgumentNullException(nameof(module));

            _modules[typeof(T)] = module;
        }

        public T Get<T>() where T : class
        {
            if (_modules.TryGetValue(typeof(T), out var module))
                return (T)module;

            throw new KeyNotFoundException($"Module {typeof(T).Name} is not registered.");
        }

        public bool TryGet<T>(out T module) where T : class
        {
            if (_modules.TryGetValue(typeof(T), out var value))
            {
                module = (T)value;

                return true;
            }

            module = null;

            return false;
        }

        public bool Exists<T>() where T : class
        {
            return _modules.ContainsKey(typeof(T));
        }

        public void Remove<T>() where T : class
        {
            _modules.Remove(typeof(T));
        }
    }
}