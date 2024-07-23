using Code.MessageBox.Model;
using Core.Data.Enums;
using Core.Services.Windows;

namespace Code.MessageBox.Presenter
{
    public class MessageBoxPresenter : Core.Presenter.Presenter, IMessageBoxPresenter
    {
        private readonly IMessageBoxModel _messageBoxModel;

        public MessageBoxPresenter(IWindowService windowService, IMessageBoxModel messageBoxModel) : base(windowService)
        {
            _messageBoxModel = messageBoxModel;
            UpdateMessage(MessageId.CheckExpression);
        }

        public void UpdateMessage(MessageId messageId) => _messageBoxModel.SetMessage(messageId);

        public void OnGotItClicked() => _windowService.Open(WindowId.Calculator);
    }
}