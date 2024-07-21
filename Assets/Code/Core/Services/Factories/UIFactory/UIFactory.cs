using Core.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.Factories.UIFactory
{
    public class UIFactory : BaseFactory.BaseFactory, IUIFactory
    {
        private const string RootCanvasKey = "RootCanvas";

        public UIFactory(IAssets assets) : base(assets)
        {
        }

        public async UniTask<Canvas> CreateCanvas()
        {
            await _assets.Load<GameObject>(RootCanvasKey);
            return await Instantiate<Canvas>(RootCanvasKey);
        }
    }
}