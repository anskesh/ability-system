using System.Collections.Generic;
using AbilitySystem.Scripts.Abilities.Settings;
using AbilitySystem.Scripts.Services;
using Services;
using UnityEngine;

namespace AbilitySystem.Scripts.UI
{
    public class AbilitiesView : View
    {
        [SerializeField] private AbilityView _prefab;
        [SerializeField] private Transform _container;

        private List<AbilityView> _abilityViews = new();

        private void Awake()
        {
            ServiceLocator.GetService<WindowsService>().AddView(this);
        }

        public void Setup(List<Ability> abilities)
        {
            while (_abilityViews.Count < abilities.Count)
                CreateAbilityView();
            
            for (int i = 0; i < abilities.Count; i++)
                _abilityViews[i].Setup(abilities[i]);
        }

        private void CreateAbilityView() => _abilityViews.Add(Instantiate(_prefab, _container));
    }
}