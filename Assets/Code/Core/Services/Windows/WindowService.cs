using System.Collections.Generic;
using Core.Data.Enums;

namespace Core.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly Dictionary<WindowId, View.View> _views = new(5);

        public void RegisterWindow(WindowId id, View.View view) => _views.Add(id, view);

        public void Open(WindowId id)
        {
            if (!_views.ContainsKey(id)) return;
            _views[id].Show();
        }

        public void Close(WindowId id)
        {
            if (!_views.ContainsKey(id)) return;
            _views[id].Hide();
        }

        public void CleanUp() => _views.Clear();
    }
}