using Code.MessageBox.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.MessageBox.View
{
    public class MessageBoxView : Core.View.View, IMessageBoxView
    {
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private Button _gotItButton;
        private IMessageBoxPresenter _messageBoxPresenter;

        public void Initialize(IMessageBoxPresenter messageBoxPresenter)
        {
            _messageBoxPresenter = messageBoxPresenter;
            _gotItButton.onClick.AddListener(() =>
            {
                Hide();
                _messageBoxPresenter.OnGotItClicked();
            });
        }

        public void SetMessage(string message) => _messageText.text = message;
    }
}