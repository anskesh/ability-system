using AbilitySystem.Scripts.Abilities.Settings;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/Sound", fileName = "SoundParameter")]
    public class SoundParameter : AbilityParameter
    {
        [field:SerializeField] public AudioClip AudioClip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; } = 1;
    }
}