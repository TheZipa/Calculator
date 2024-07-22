using Core.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.MessageBox.Factory
{
    public interface IMessageBoxFactory : IGlobalService
    {
        UniTask CreateMessageBox(Transform canvas);
    }
}