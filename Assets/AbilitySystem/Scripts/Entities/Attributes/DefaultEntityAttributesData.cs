using Configurations;
using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    [CreateAssetMenu(menuName = "Data/DefaultEntityAttributes", fileName = "DefaultEntityAttributesData")]
    public class DefaultEntityAttributesData : Configuration
    {
        [field: SerializeField] public float Health { get; private set; } = 100;
        [field: SerializeField] public float MaxHealth { get; private set; } = 100;
        [field:SerializeField] public float Armor { get; private set; }
        [field: SerializeField] public float Speed { get; private set; } = 5;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 720;
    }
}