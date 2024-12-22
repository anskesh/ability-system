using AbilitySystem.Scripts.Services;
using AbilitySystem.Scripts.UI;
using Services;

namespace AbilitySystem.Scripts.Entities
{
    public class PlayerEntity : Entity
    {
        protected override void OnSetup()
        {
            base.OnSetup();

            AbilitiesView abilitiesView = ServiceLocator.GetService<WindowsService>().GetView<AbilitiesView>();
            abilitiesView.Setup(_abilityHolder.Abilities);
        }

        protected override MovementComponent CreateMovement(EntityAttributes attributes)
        {
            return new PlayerMovement(transform, attributes);
        }
    }
}