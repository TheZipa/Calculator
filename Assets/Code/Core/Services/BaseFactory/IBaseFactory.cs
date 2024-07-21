using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.BaseFactory
{
    public interface IBaseFactory
    {
        UniTask<T> Instantiate<T>(Transform parent = null) where T : Object;
    }
}