using AbilitySystem.Scripts.Abilities.Settings;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/Movement", fileName = "MovementParameter")]
    public class MovementParameter : AbilityParameter
    {
        [field: SerializeField] public bool CanMove { get; private set; }
        [field: SerializeField] public Vector3 PositionOffset { get; private set; }
    }
}
