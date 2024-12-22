using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class VFXAbilityComponent : AbilityComponent<VFXParameter>
    {
        private ParticleSystem _particle;
        
        protected override void OnApply(VFXParameter parameter)
        {
            _particle = Instantiate(parameter.VFX, transform, false);
        }

        protected override void OnCancel(VFXParameter parameter)
        {
            if (_particle == null)
                return;
            
            Destroy(_particle.gameObject);
        }
    }
}