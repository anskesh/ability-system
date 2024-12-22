using AbilitySystem.Scripts.Abilities.Settings;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/Animation", fileName = "AnimationParameter")]
    public class AnimationParameter : AbilityParameter
    {
        [field:SerializeField] public string TriggerName { get; private set; }
    }
}