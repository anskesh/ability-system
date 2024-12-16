using System;
using Configurations;

namespace Services
{
    public abstract class Service : IService
    {
        public Action DestroyEvent;

        public virtual void Destroy()
        {
            DestroyEvent?.Invoke();
        }
    }

    public abstract class Service<TConfig> : Service where TConfig : IConfiguration
    {
        public TConfig Configuration => _configuration ??= ServiceLocator.GetService<ConfigurationService>().GetConfiguration<TConfig>();

        private TConfig _configuration;
    }
}