using AbilitySystem.Scripts.Core;
using UnityEngine;

namespace Services
{
    public abstract class SceneContext : MonoBehaviour, IInstaller
    {
        private void Awake()
        {
            Install();
        }

        private void OnDestroy()
        {
            DeInstall();
        }

        public abstract void Install();
        public abstract void DeInstall();
    }
}