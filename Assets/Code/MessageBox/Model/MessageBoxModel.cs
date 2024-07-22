using System.Collections.Generic;
using Code.MessageBox.View;
using Core.Data.Enums;

namespace Code.MessageBox.Model
{
    public class MessageBoxModel : Core.Model.Model, IMessageBoxModel
    {
        private readonly IMessageBoxView _view;

        private readonly Dictionary<MessageId, string> _messages = new()
        {
            [MessageId.CheckExpression] = "Please check the expression you just entered"
        };

        public MessageBoxModel(WindowId id, IMessageBoxView view) : base(id) => _view = view;

        public void SetMessage(MessageId messageId) => _view.SetMessage(_messages[messageId]);
    }
}