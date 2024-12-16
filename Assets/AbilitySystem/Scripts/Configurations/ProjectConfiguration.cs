using System.Collections.Generic;
using Configurations;
using UnityEngine;

namespace AbilitySystem.Scripts.Configurations
{
    [CreateAssetMenu(menuName = "Config/Project")]
    public class ProjectConfiguration : Configuration
    {
        public List<Configuration> Configurations;
    }
}