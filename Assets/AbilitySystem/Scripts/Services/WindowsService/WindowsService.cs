using System.Collections.Generic;
using AbilitySystem.Scripts.UI;
using Services;

namespace AbilitySystem.Scripts.Services
{
    public class WindowsService : Service
    {
        private List<View> _views = new();
        
        public void AddView(View view)
        {
            if (_views.Contains(view))
                return;
            
            _views.Add(view);
        }

        public T GetView<T>() where T: View
        {
            return (T) _views.Find(x => x is T);
        }
    }
}