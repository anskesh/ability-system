using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public class PlayerMovement : MovementComponent
    {
        public PlayerMovement(Transform transform, EntityAttributes entityAttributes) : base(transform, entityAttributes)
        {
        }

        protected override void HandleMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _moveDirection = new Vector3(horizontal, 0f, vertical);
        }
    }
}