using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public class EnemyMovement : MovementComponent
    {
        public EnemyMovement(Transform transform, EntityAttributes entityAttributes) : base(transform, entityAttributes)
        {
        }

        protected override void HandleMovement()
        {
        }
    }
}