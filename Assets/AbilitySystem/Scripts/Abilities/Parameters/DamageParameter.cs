using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.StatusEffects;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/Damage", fileName = "DamageParameter")]
    public class DamageParameter : AbilityParameter
    {
        [field:SerializeField] public float Damage { get; private set; }
        [field:SerializeField] public float Radius { get; private set; }
        [field:SerializeField] public float Duration { get; private set; } = -1;
        [field: SerializeField] public float TickTime { get; private set; } = -1;
        [field:SerializeField] public LayerMask TargetLayer { get; private set; }
        [field:SerializeField] public List<StatusEffectData> StatusEffects { get; private set; }
    }
}