using Cysharp.Threading.Tasks;
using Services.App.Code.Services.EntityContainer;
using UnityEngine;

namespace Services.App.Code.Services.BaseFactory
{
    public interface IBaseFactory
    {
        UniTask<T> InstantiateAsRegistered<T>(Vector3 at, Quaternion rotation, Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> InstantiateAsRegistered<T>(Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> Instantiate<T>(Transform parent = null) where T : Object;
    }
}