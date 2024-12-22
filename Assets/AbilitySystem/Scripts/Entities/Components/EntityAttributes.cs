using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public class EntityAttributes
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public float Armor => _armor;
        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;
        
        private float _health;
        private float _maxHealth;
        private float _armor;
        private float _speed;
        private float _rotationSpeed;

        private Dictionary<AttributeChangeData, float> _percentChanges = new ();

        public EntityAttributes(DefaultEntityAttributesData defaultData)
        {
            _health = defaultData.Health;
            _maxHealth = defaultData.MaxHealth;
            _armor = defaultData.Armor;
            _speed = defaultData.Speed;
            _rotationSpeed = defaultData.RotationSpeed;
        }
        
        public void ApplyChange(AttributeChangeData changeData)
        {
            ChangeValue(changeData, false);
        }

        public void CancelChange(AttributeChangeData changeData)
        {
            ChangeValue(changeData, true);
        }

        private void ChangeValue(AttributeChangeData changeData, bool isReverting)
        {
            switch (changeData.Type)
            {
                case AttributeType.Health:
                    ChangeValue(ref _health, changeData, isReverting);
                    break;
                case AttributeType.MaxHealth:
                    ChangeValue(ref _maxHealth, changeData, isReverting);
                    break;
                case AttributeType.Speed:
                    ChangeValue(ref _speed, changeData, isReverting);
                    break;
                case AttributeType.Armor:
                    ChangeValue(ref _armor, changeData, isReverting);
                    break;
            }
        }
        
        private void ChangeValue(ref float value, AttributeChangeData changeData, bool isReverting)
        {
            float changeValue = CalculateChangeValue(value, changeData, isReverting);

            if (changeValue == 0)
                return;

            switch (changeData.ChangeType)
            {
                case AttributeChangeType.Increase:
                {
                    if (isReverting)
                    {
                        if (value <= 0) return;
                        
                        value += -changeValue;
                    }
                    else
                    {
                        value += changeValue;
                    }
                    break;
                }
                case AttributeChangeType.Decrease:
                {
                    if (isReverting)
                    {
                        value += changeValue;
                    }
                    else
                    {
                        if (value <= 0) return;
                        
                        value += -changeValue;
                    }
                    break;
                }
            }
        }

        private float CalculateChangeValue(float value, AttributeChangeData changeData, bool isReverting)
        {
            switch (changeData.ChangeValueType)
            {
                case AttributeChangeValueType.Value:
                {
                    return changeData.Value;
                }
                case AttributeChangeValueType.Percent:
                {
                    if (!isReverting)
                    {
                        float changeValue = value * changeData.Value;
                        _percentChanges.TryAdd(changeData, changeValue);
                        return changeValue;
                    }
                    else
                    {
                        if (!_percentChanges.ContainsKey(changeData))
                        {
                            Debug.LogWarning("You cannot invert an unaccepted change.");
                            return 0;
                        }

                        float changeValue = _percentChanges[changeData];
                        return changeValue;
                    }
                }
            }

            return 0;
        }
    }
}