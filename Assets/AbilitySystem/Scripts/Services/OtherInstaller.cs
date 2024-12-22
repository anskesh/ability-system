using AbilitySystem.Scripts.Core;
using AbilitySystem.Scripts.Services.StatusEffectService;
using Services;
using UnityEngine;

namespace AbilitySystem.Scripts.Services
{
    public class OtherInstaller : MonoBehaviour, IInstaller
    {
        public void Install()
        {
            ServiceLocator.AddService(new StatusEffectsService());
            ServiceLocator.AddService(new WindowsService());
        }

        public void DeInstall()
        {
            ServiceLocator.RemoveService<StatusEffectsService>();
            ServiceLocator.RemoveService<WindowsService>();
        }
    }
}