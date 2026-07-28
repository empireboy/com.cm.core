using System.Collections.Generic;

namespace CM.Core.Domain
{
    public class Entity
    {
        private readonly ModuleContainer _moduleContainer = new();
        private readonly List<ITickable> _tickables = new();

        public void AddModule<T>(T module) where T : class
        {
            if (module is ITickable tickable)
                _tickables.Add(tickable);

            _moduleContainer.Add(module);
        }

        public T GetModule<T>() where T : class => _moduleContainer.Get<T>();
        public bool TryGetModule<T>(out T module) where T : class => _moduleContainer.TryGet(out module);
        public bool ModuleExists<T>() where T : class => _moduleContainer.Exists<T>();
        public void RemoveModule<T>() where T : class => _moduleContainer.Remove<T>();
        public IReadOnlyList<ITickable> GetTickables() => _tickables;
    }
}