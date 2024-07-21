using Core.Services.Windows;

namespace Core.Presenter
{
    public abstract class Presenter
    {
        protected readonly IWindowService _windowService;

        protected Presenter(IWindowService windowService)
        {
            _windowService = windowService;
        }
    }
}