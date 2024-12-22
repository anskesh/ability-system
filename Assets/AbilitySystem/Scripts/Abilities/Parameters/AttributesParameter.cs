using System;
using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.Entities;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Parameters
{
    [CreateAssetMenu(menuName = "Ability/Parameter/Attributes", fileName = "AttributesParameter")]
    public class AttributesParameter : AbilityParameter
    {
        [field: SerializeField] public List<AttributeChangeData> Changes { get; private set; }
    }

    [Serializable]
    public class AttributeChangeData
    {
        [field: SerializeField] public AttributeType Type { get; private set; }
        [field: SerializeField] public AttributeChangeType ChangeType { get; private set; }
        [field: SerializeField] public AttributeChangeValueType ChangeValueType { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public AttributeChangeData(AttributeType type, AttributeChangeType changeType, AttributeChangeValueType changeValueType, float value)
        {
            Type = type;
            ChangeType = changeType;
            ChangeValueType = changeValueType;
            Value = value;
        }

        public AttributeChangeData(AttributeChangeData changeData)
        {
            Type = changeData.Type;
            ChangeType = changeData.ChangeType;
            ChangeValueType = changeData.ChangeValueType;
            Value = changeData.Value;
        }
    }
}