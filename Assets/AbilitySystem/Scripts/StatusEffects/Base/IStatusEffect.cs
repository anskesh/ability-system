using AbilitySystem.Scripts.Entities;

namespace AbilitySystem.Scripts.StatusEffects
{
    public interface IStatusEffect
    {
        bool IsActive { get; }
        void Activate(EntityAttributes attributes);
        void Update();
        void Deactivate();
    }
}