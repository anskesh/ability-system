using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class SoundAbilityComponent : AbilityComponent<SoundParameter>
    {
        [SerializeField] private AudioSource _abilityAudio;
        
        protected override void OnApply(SoundParameter parameter)
        {
            _abilityAudio.clip = parameter.AudioClip;
            _abilityAudio.volume = parameter.Volume;
            _abilityAudio.Play();
        }

        protected override void OnCancel(SoundParameter parameter)
        {
            _abilityAudio.clip = null;
            _abilityAudio.Stop();
        }
    }
}