using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Components;
using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.StatusEffects;
using AbilitySystem.Scripts.UI.Health;
using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public abstract class Entity : MonoBehaviour, IEntity, IStatusEffected
    {
        [SerializeField] private DefaultEntityAttributesData _defaultAttributes;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private List<AbilitySettings> _abilitiesSettings;
        
        protected EntityAttributes _attributes;
        protected AbilityHolder _abilityHolder;
        protected MovementComponent _movementComponent;
        protected StatusEffectsHolder _statusEffectsHolder;

        protected bool _isInitialized;

        public void Setup()
        {
            _attributes = new EntityAttributes(_defaultAttributes);
            _movementComponent = CreateMovement(_attributes);
            _statusEffectsHolder = new StatusEffectsHolder(_attributes);
            _abilityHolder = new AbilityHolder(transform, _attributes, _movementComponent, _abilitiesSettings, this);
            
            if (_healthView)
                _healthView.Setup(_attributes);

            _isInitialized = true;
            OnSetup();
        }

        protected abstract MovementComponent CreateMovement(EntityAttributes attributes);
        protected virtual void OnSetup(){}
        
        public void TakeDamage(float damage)
        {
            _attributes.ApplyChange(new AttributeChangeData(AttributeType.Health, AttributeChangeType.Decrease, AttributeChangeValueType.Value, damage));
        }

        public void AddStatusEffect(StatusEffectData statusEffect)
        {
            _statusEffectsHolder.AddStatusEffect(statusEffect);
        }

        private void Update()
        {
            if (!_isInitialized) return;
            
            _statusEffectsHolder.Update();
            _abilityHolder.Update();
            _movementComponent.Update();
        }
    }
}