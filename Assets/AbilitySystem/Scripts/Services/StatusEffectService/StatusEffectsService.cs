using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.StatusEffects;
using Services;

namespace AbilitySystem.Scripts.Services.StatusEffectService
{
    public class StatusEffectsService : Service<StatusEffectsConfiguration>
    {
        public IStatusEffect GetStatusEffect(StatusEffectData data)
        {
            List<AttributeChangeData> changes = Configuration.GetChanges(data.EffectType);

            if (data.TriggerInterval > 0)
                return new TickableStatusEffect(data, changes);
            
            return new ContinuousStatusEffect(data, changes);
        }
    }
}