using Core.Data.Enums;

namespace Core.Services.Windows
{
    public interface IWindowService : IGlobalService
    {
        void RegisterWindow(WindowId id, View.View view);
        void Open(WindowId id);
        void Close(WindowId id);
        void CleanUp();
    }
}