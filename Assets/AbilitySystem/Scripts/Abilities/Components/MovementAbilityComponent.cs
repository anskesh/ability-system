using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.Entities;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class MovementAbilityComponent : AbilityComponent<MovementParameter>
    {
        private MovementComponent _movementComponent;

        public void Setup(MovementComponent movementComponent)
        {
            _movementComponent = movementComponent;
        }
        
        protected override void OnApply(MovementParameter parameter)
        {
            _movementComponent.SetCanMove(parameter.CanMove);
            
            if (parameter.PositionOffset != Vector3.zero)
                _movementComponent.TeleportTo(parameter.PositionOffset);
        }

        protected override void OnCancel(MovementParameter parameter)
        {
            _movementComponent.SetCanMove(true);
        }
    }
}