using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.Factories.BaseFactory
{
    public interface IBaseFactory
    {
        UniTask<T> Instantiate<T>(Transform parent = null) where T : Object;
        UniTask<T> Instantiate<T>(string assetKey, Transform parent = null) where T : Object;
    }
}