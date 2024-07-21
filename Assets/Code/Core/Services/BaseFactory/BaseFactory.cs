using Core.Services.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.BaseFactory
{
    public abstract class BaseFactory : IBaseFactory
    {
        protected readonly IAssets _assets;

        protected BaseFactory(IAssets assets)
        {
            _assets = assets;
        }

        public async UniTask<T> Instantiate<T>(Vector3 at, Vector3 rotation, Transform parent = null) where T : Object
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, parent);
            instantiatedObject.transform.position = at;
            instantiatedObject.transform.rotation = Quaternion.Euler(rotation);
            return instantiatedObject.GetComponent<T>();
        }

        public async UniTask<T> Instantiate<T>(Transform parent = null) where T : Object
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, parent);
            return instantiatedObject.GetComponent<T>();
        }
    }
}