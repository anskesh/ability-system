using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.StatusEffects
{
    public class TickableStatusEffect : StatusEffect
    {
        private readonly float _triggerInterval;

        private float _currentTriggerInterval;

        public TickableStatusEffect(StatusEffectData statusEffectData, List<AttributeChangeData> attributesChanges) : base(statusEffectData, attributesChanges)
        {
            _triggerInterval = statusEffectData.TriggerInterval;
        }

        public override void Update()
        {
            if (_currentDuration >= _duration)
            {
                IsActive = false;
                return;
            }
            
            if (_currentTriggerInterval >= _triggerInterval)
                _currentTriggerInterval = 0;
            
            if (_currentTriggerInterval <= 0)
            {
                float chance = Random.Range(0, 1f);
                
                if (chance >= _triggerChance)
                    Apply(_attributes);
            }

            _currentDuration += Time.deltaTime;
            _currentTriggerInterval += Time.deltaTime;
        }
    }
}