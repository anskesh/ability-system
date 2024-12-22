using System;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.Entities;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public interface IAbilityComponent
    {
        Type AbilityParameterType { get; }
        
        void Setup(EntityAttributes attributes);
        void Apply(IAbilityParameter parameter);
        void Cancel();
    }
}