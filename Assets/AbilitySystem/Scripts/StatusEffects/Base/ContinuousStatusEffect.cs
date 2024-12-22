using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.StatusEffects
{
    public class ContinuousStatusEffect : StatusEffect
    {
        public ContinuousStatusEffect(StatusEffectData statusEffectData, List<AttributeChangeData> attributesChanges) : base(statusEffectData, attributesChanges)
        {
        }

        public override void Update()
        {
            if (_currentDuration >= _duration)
            {
                IsActive = false;
                return;
            }
            
            if (_currentDuration <= 0)
            {
                float chance = Random.Range(0, 1f);
                
                if (chance >= _triggerChance)
                    Apply(_attributes);
            }
            
            _currentDuration += Time.deltaTime;
        }
    }
}