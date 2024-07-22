using Code.MessageBox.Presenter;

namespace Code.MessageBox.View
{
    public interface IMessageBoxView
    {
        void Initialize(IMessageBoxPresenter messageBoxPresenter);
        void SetMessage(string message);
    }
}