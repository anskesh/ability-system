using AbilitySystem.Scripts.Configurations;
using Configurations;
using Services;
using UnityEngine;

namespace AbilitySystem.Scripts.Core
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private ProjectConfiguration _projectConfiguration;
        
        public void Install()
        {
            ServiceLocator.AddService(new ConfigurationService(_projectConfiguration));
        }

        public void DeInstall()
        {
            ServiceLocator.RemoveService<ConfigurationService>();
        }
    }
}