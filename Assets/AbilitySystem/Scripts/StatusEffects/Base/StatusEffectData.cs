using System;

namespace AbilitySystem.Scripts.StatusEffects
{
    [Serializable]
    public class StatusEffectData
    {
        public StatusEffectType EffectType;
        public float TriggerChance = 1;
        public float TriggerInterval = -1;
        public float Duration = -1;
    }
}