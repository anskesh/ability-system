using UnityEngine;

namespace AbilitySystem.Scripts.UI
{
    public class View : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnShow(){}
        protected virtual void OnHide(){}
    }
}