using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.Entities;

namespace AbilitySystem.Scripts.StatusEffects
{
    public abstract class StatusEffect : IStatusEffect
    {
        public bool IsActive { get; protected set; }
        
        protected readonly float _triggerChance;
        protected readonly float _duration;

        protected float _currentDuration;
        protected EntityAttributes _attributes;
        protected List<AttributeChangeData> _attributesChanges = new ();
        
        public StatusEffect(StatusEffectData statusEffectData, List<AttributeChangeData> attributesChanges)
        {
            _triggerChance = statusEffectData.TriggerChance;
            _duration = statusEffectData.Duration;

            foreach (var change in attributesChanges)
            {
                _attributesChanges.Add(new AttributeChangeData(change));
            }
        }

        public void Activate(EntityAttributes attributes)
        {
            IsActive = true;
            _currentDuration = 0;
            _attributes = attributes;
        }

        public abstract void Update();
        
        public void Deactivate()
        {
            Cancel(_attributes);
            _attributes = null;
        }

        protected void Apply(EntityAttributes attributes)
        {
            foreach (var change in _attributesChanges)
                attributes.ApplyChange(change);
        }

        protected void Cancel(EntityAttributes attributes)
        {
        }
    }
}