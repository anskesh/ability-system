using AbilitySystem.Scripts.Abilities.Parameters;

namespace AbilitySystem.Scripts.Abilities.Components
{
    public class AttributesAbilityComponent : AbilityComponent<AttributesParameter>
    {
        protected override void OnApply(AttributesParameter parameter)
        {
            foreach (var changeData in parameter.Changes)
            {
                _entityAttributes.ApplyChange(changeData);
            }
        }

        protected override void OnCancel(AttributesParameter parameter)
        {
            foreach (var changeData in parameter.Changes)
            {
                _entityAttributes.CancelChange(changeData);
            }
        }
    }
}