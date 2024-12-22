using AbilitySystem.Scripts.Abilities.Settings;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/VFX", fileName = "VFXParameter")]
    public class VFXParameter : AbilityParameter
    {
        [field:SerializeField] public ParticleSystem VFX { get; private set; }
    }
}