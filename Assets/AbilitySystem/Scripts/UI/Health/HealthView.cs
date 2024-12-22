using AbilitySystem.Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace AbilitySystem.Scripts.UI.Health
{
    public class HealthView : View
    {
        [SerializeField] private Slider _slider;
        
        private EntityAttributes _attributes;

        public void Setup(EntityAttributes attributes)
        {
            _attributes = attributes;
            Show();
        }

        private void Update()
        {
            float percent = _attributes.Health / _attributes.MaxHealth;
            
            if (percent <= 0)
                Hide();
            
            _slider.value = percent;
        }
    }
}