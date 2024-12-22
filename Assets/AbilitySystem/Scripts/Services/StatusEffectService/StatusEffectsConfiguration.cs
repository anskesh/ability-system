using System;
using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.StatusEffects;
using Configurations;
using UnityEngine;

namespace AbilitySystem.Scripts.Services.StatusEffectService
{
    [CreateAssetMenu(menuName = "Config/Status effects", fileName = "StatusEffectsConfiguration")]
    public class StatusEffectsConfiguration : Configuration
    {
        [SerializeField] private List<StatusEffectData> _data;

        public List<AttributeChangeData> GetChanges(StatusEffectType effectType)
        {
            StatusEffectData data = _data.Find(x => x.Type == effectType);

            if (data == null)
            {
                Debug.LogWarning($"Cant find status effect data with type {effectType}");
                return null;
            }

            return data.Changes;
        }
        
        [Serializable]
        private class StatusEffectData
        {
            public StatusEffectType Type;
            public List<AttributeChangeData> Changes;
        }
    }
}