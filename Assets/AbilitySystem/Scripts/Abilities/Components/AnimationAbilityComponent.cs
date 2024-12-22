using AbilitySystem.Scripts.Abilities.Parameters;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class AnimationAbilityComponent : AbilityComponent<AnimationParameter>
    {
        [SerializeField] private Animator _animator;

        protected override void OnApply(AnimationParameter parameter)
        {
            _animator.SetTrigger(parameter.TriggerName);
        }

        protected override void OnCancel(AnimationParameter parameter)
        {
            _animator.ResetTrigger(parameter.TriggerName);
        }
    }
}