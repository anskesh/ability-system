using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Parameters;
using AbilitySystem.Scripts.Entities;
using UnityEngine;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class DamageAbilityComponent : AbilityComponent<DamageParameter>
    {
        private Entity _entity;
        private List<Entity> _hitted = new ();

        public void Setup(Entity entity)
        {
            _entity = entity;
        }
        
        protected override void OnApply(DamageParameter parameter)
        {
            _hitted.Clear();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, parameter.Radius);
            
            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Entity entity))
                {
                    if (entity == _entity) continue;
                    
                    if (_hitted.Contains(_entity)) continue;
                    
                    _hitted.Add(entity);
                    entity.TakeDamage(parameter.Damage);

                    foreach (var statusEffect in parameter.StatusEffects)
                        entity.AddStatusEffect(statusEffect);
                    
                    Debug.Log($"Damage {parameter.Damage} for {entity.name}");
                }
            }
        }

        protected override void OnCancel(DamageParameter parameter) {}
    }
}