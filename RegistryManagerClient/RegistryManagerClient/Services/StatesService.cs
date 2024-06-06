using RegistryManagerClient.Models.ViewModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegistryManagerClient.Services
{
    public class StatesService
    {
        private static readonly Lazy<StatesService> _instance = new Lazy<StatesService>(() => new StatesService());
        private readonly Dictionary<Type, object> _states;

        private StatesService()
        {
            _states = new Dictionary<Type, object>();
        }

        public static StatesService Instance => _instance.Value;

        public T GetState<T>() where T : class, new()
        {
            var type = typeof(T);
            if (!_states.ContainsKey(type))
            {
                _states[type] = new T();
            }
            return (T)_states[type];
        }

        public void SetState<T>(T state) where T : class
        {
            var type = typeof(T);
            _states[type] = state;
        }
    }
}
