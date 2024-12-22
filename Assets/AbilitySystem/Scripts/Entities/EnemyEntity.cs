namespace AbilitySystem.Scripts.Entities
{
    public class EnemyEntity : Entity
    {
        protected override MovementComponent CreateMovement(EntityAttributes attributes)
        {
            return new EnemyMovement(transform, attributes);
        }
    }
}