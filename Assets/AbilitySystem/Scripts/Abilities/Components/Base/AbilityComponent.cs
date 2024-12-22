using System;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.Entities;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public abstract class AbilityComponent<T> : MonoBehaviour, IAbilityComponent where T: AbilityParameter
    {
        public Type AbilityParameterType { get; protected set; } = typeof(T);
        
        protected EntityAttributes _entityAttributes;
        
        private T _parameter;
        
        public void Setup(EntityAttributes entityAttributes)
        {
            _entityAttributes = entityAttributes;
        }

        public void Apply(IAbilityParameter parameter)
        {
            _parameter = parameter as T;
            OnApply(_parameter);
        }

        public void Cancel()
        {
            if (_parameter == null)
                return;
            
            OnCancel(_parameter);
            _parameter = null;
        }

        protected abstract void OnApply(T parameter);
        protected abstract void OnCancel(T parameter);
    }
}