using AbilitySystem.Scripts.Abilities.Settings;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace AbilitySystem.Scripts.UI
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;

        private Ability _ability;
        
        public void Setup(Ability ability)
        {
            _ability = ability;
            _image.sprite = ability.Data.Image;
        }

        private void Update()
        {
            if (_ability.IsCooldown)
            {
                _text.gameObject.SetActive(true);
                _text.text = $"{_ability.Cooldown:F2}";
            }
            else
            {
                _text.gameObject.SetActive(false);
            }
        }
    }
}