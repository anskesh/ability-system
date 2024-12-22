using System;
using System.Collections.Generic;
using System.Linq;
using AbilitySystem.Scripts.Abilities.Components;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Settings
{
    public class Ability : IAbility
    {
        public AbilityData Data { get; private set; }
        public float Cooldown { get; private set; }
        public bool IsExecuting { get; private set; }
        public bool IsCooldown { get; private set; }

        private float _duration;
        private List<AbilityParameter> _parameters;
        private List<IAbilityComponent> _components;

        public Ability(AbilityData data)
        {
            Data = data;
            _parameters = data.Parameters;
        }

        public void Execute(List<IAbilityComponent> components)
        {
            _components = components;
            _duration = Data.Duration;
            IsExecuting = true;
            
            foreach (var component in components)
            {
                IAbilityParameter parameter = GetParameter(component.AbilityParameterType);
                
                if (parameter != null)
                    component.Apply(parameter);
            }
        }

        public void Update()
        {
            if (IsExecuting)
            {
                if (_duration > 0)
                {
                    _duration -= Time.deltaTime;
                }
                else
                {
                    Cancel();
                    StartCooldown();
                }
            }
            
            if (IsCooldown)
            {
                if (Cooldown > 0)
                {
                    Cooldown -= Time.deltaTime;
                }
                else
                {
                    IsCooldown = false;
                }
            }
        }

        private void StartCooldown()
        {
            Cooldown = Data.Cooldown;
            IsCooldown = true;
        }

        private IAbilityParameter GetParameter(Type parameterType)
        {
            return _parameters.FirstOrDefault(parameterType.IsInstanceOfType);
        }

        private void Cancel()
        {
            foreach (var component in _components)
            {
                component.Cancel();
            }

            IsExecuting = false;
        }
    }
}