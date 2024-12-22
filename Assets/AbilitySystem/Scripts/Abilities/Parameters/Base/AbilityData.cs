using System;
using System.Collections.Generic;
using System.Linq;
using AbilitySystem.Scripts.Abilities.Components;
using Configurations;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Settings
{
    [CreateAssetMenu(menuName = "Ability/Ability", fileName = "Ability")]
    public class AbilityData : Configuration, IAbility
    {
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public List<AbilityParameter> Parameters { get; private set; }

        public void Execute(List<IAbilityComponent> components)
        {
            foreach (var component in components)
            {
                component.Apply(GetParameter(component.AbilityParameterType));
                
                /*switch (component)
                {
                    case AnimationAbilityComponent targetComponent:
                    {
                        targetComponent.Apply(GetParameter<AnimationParameter>());
                        break;
                    }
                    case AttributesAbilityComponent targetComponent:
                    {
                        break;
                    }
                    case DamageAbilityComponent targetComponent:
                    {
                        targetComponent.Apply(GetParameter<DamageParameter>());
                        break;
                    }
                    case MovementAbilityComponent targetComponent:
                    {
                        break;
                    }
                    case SoundAbilityComponent targetComponent:
                    {
                        targetComponent.Apply(GetParameter<SoundParameter>());
                        break;
                    }
                    case VFXAbilityComponent targetComponent:
                    {
                        break;
                    }
                }*/
            }
        }

        private IAbilityParameter GetParameter(Type parameterType)
        {
            return Parameters.FirstOrDefault(parameterType.IsInstanceOfType);
        }

        /*private T GetParameter<T>() where T : AbilityParameter
        {
            return (T) _parameters.FirstOrDefault(x => x is T);
        }*/
    }
}