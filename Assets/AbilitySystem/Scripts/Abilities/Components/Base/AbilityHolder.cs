using System;
using System.Collections.Generic;
using System.Linq;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.Entities;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    [Serializable]
    public class AbilitySettings
    {
        public KeyCode KeyCode;
        public AbilityData Data;
    }
    
    public class AbilityHolder
    {
        public List<Ability> Abilities => _abilities.Values.ToList();
        
        private readonly List<IAbilityComponent> _abilityComponents;
        private readonly Dictionary<KeyCode, Ability> _abilities = new();
        
        private readonly EntityAttributes _entityAttributes;
        private readonly List<AbilitySettings> _abilitiesSettings;
        
        private Ability _currentAbility;

        public AbilityHolder(Transform transform, EntityAttributes attributes, MovementComponent movementComponent, List<AbilitySettings> abilitiesSettings, Entity entity)
        {
            _entityAttributes = attributes;
            _abilitiesSettings = abilitiesSettings;
            _abilityComponents = transform.GetComponentsInChildren<IAbilityComponent>().ToList();

            foreach (var abilitySettings in _abilitiesSettings)
                _abilities.Add(abilitySettings.KeyCode, new Ability(abilitySettings.Data));
            
            foreach (var component in _abilityComponents)
            {
                if (component is MovementAbilityComponent movementAbilityComponent)
                    movementAbilityComponent.Setup(movementComponent);
                
                if (component is DamageAbilityComponent damageAbilityComponent)
                    damageAbilityComponent.Setup(entity);
                
                component.Setup(_entityAttributes);
            }
        }

        public void Update()
        {
            foreach (var ability in _abilities.Values)
            {
                ability.Update();
            }
            
            if (_currentAbility != null)
            {
                if (_currentAbility.IsExecuting)
                    return;
                
                _currentAbility = null;
            }
            
            foreach (var keyCode in _abilities.Keys)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Ability ability = _abilities[keyCode];
                    
                    if (_abilities[keyCode] != null && !ability.IsCooldown)
                    {
                        if (ability.Cooldown > 0) // The ability is not ready
                            continue;
                    
                        _currentAbility = ability;
                        _currentAbility.Execute(_abilityComponents);
                        return;
                    }
                }
            }
        }
    }
}