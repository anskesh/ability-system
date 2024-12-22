using System.Collections.Generic;
using AbilitySystem.Scripts.Services.StatusEffectService;
using AbilitySystem.Scripts.StatusEffects;
using Services;
using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public class StatusEffectsHolder : IStatusEffected
    {
        private List<IStatusEffect> _statusEffects = new();
        private readonly EntityAttributes _attributes;

        public StatusEffectsHolder(EntityAttributes attributes)
        {
            _attributes = attributes;
        }

        public void AddStatusEffect(StatusEffectData statusEffectData)
        {
            IStatusEffect statusEffect = ServiceLocator.GetService<StatusEffectsService>().GetStatusEffect(statusEffectData);
            
            if (statusEffect == null)
            {
                Debug.LogWarning($"Cant create status effect with type {statusEffectData.EffectType}");
                return;
            }
            
            _statusEffects.Add(statusEffect);
            statusEffect.Activate(_attributes);
        }

        public void Update()
        {
            List<IStatusEffect> toRemove = new List<IStatusEffect>();
            
            foreach (var effect in _statusEffects)
            {
                effect.Update();
                
                if (!effect.IsActive)
                {
                    toRemove.Add(effect);
                }
            }

            foreach (var effect in toRemove)
            {
                RemoveStatusEffect(effect);
            }
        }

        private void RemoveStatusEffect(IStatusEffect effect)
        {
            if (_statusEffects.Contains(effect))
            {
                effect.Deactivate();
                _statusEffects.Remove(effect);
            }
        }
    }
}