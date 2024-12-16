using System;
using System.Collections.Generic;
using AbilitySystem.Scripts.Configurations;
using Services;

namespace Configurations
{
    public class ConfigurationService : Service
    {
        private ProjectConfiguration _projectConfiguration;
        
        private readonly List<Configuration> _configurations;
        private Dictionary<Type, IConfiguration> _cachedConfigurations = new ();

        public ConfigurationService(ProjectConfiguration projectConfiguration)
        {
            _configurations = projectConfiguration.Configurations;
            _projectConfiguration = projectConfiguration;
        }

        public TConfig GetConfiguration<TConfig>() where TConfig : IConfiguration
        {
            Type type = typeof(TConfig);

            if (_cachedConfigurations.TryGetValue(type, out IConfiguration configuration))
                return (TConfig) configuration;

            foreach (var config in _configurations)
            {
                if (config.GetType().IsAssignableFrom(type))
                {
                    configuration = config;
                    _cachedConfigurations.TryAdd(type, config);

                    return (TConfig) configuration;
                }
            }

            throw new Exception($"Configuration {type} not found.");
        }
    }
}