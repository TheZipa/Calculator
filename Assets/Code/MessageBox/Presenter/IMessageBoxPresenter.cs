using Code.MessageBox.Model;

namespace Code.MessageBox.Presenter
{
    public interface IMessageBoxPresenter
    {
        void UpdateMessage(MessageId messageId);
        void OnGotItClicked();
    }
}