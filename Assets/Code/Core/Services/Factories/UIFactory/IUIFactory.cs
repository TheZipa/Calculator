using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.Factories.UIFactory
{
    public interface IUIFactory : IGlobalService
    {
        UniTask<Canvas> CreateCanvas();
    }
}