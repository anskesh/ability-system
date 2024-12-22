using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Components;

namespace AbilitySystem.Scripts.Abilities.Settings
{
    public interface IAbility
    {
        float Cooldown { get; }
        
        void Execute(List<IAbilityComponent> components);
    }
}