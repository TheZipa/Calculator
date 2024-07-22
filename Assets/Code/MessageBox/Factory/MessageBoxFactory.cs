using Code.MessageBox.Model;
using Code.MessageBox.Presenter;
using Code.MessageBox.View;
using Core.Data.Enums;
using Core.Services.Assets;
using Core.Services.Factories.BaseFactory;
using Core.Services.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.MessageBox.Factory
{
    public class MessageBoxFactory : BaseFactory, IMessageBoxFactory
    {
        private readonly IWindowService _windowService;

        public MessageBoxFactory(IAssets assets, IWindowService windowService) : base(assets)
        {
            _windowService = windowService;
        }

        public async UniTask CreateMessageBox(Transform canvas)
        {
            MessageBoxView messageBoxView = await CreateMessageBoxView(canvas);
            IMessageBoxModel messageBoxModel = new MessageBoxModel(WindowId.MessageBox, messageBoxView);
            IMessageBoxPresenter messageBoxPresenter = new MessageBoxPresenter(_windowService, messageBoxModel);
            messageBoxView.Initialize(messageBoxPresenter);
            _windowService.RegisterWindow(WindowId.MessageBox, messageBoxView);
            messageBoxView.Hide();
        }
        
        private async UniTask<MessageBoxView> CreateMessageBoxView(Transform canvas)
        {
            await _assets.Load<GameObject>(nameof(MessageBoxView));
            return await Instantiate<MessageBoxView>(canvas);
        }
    }
}