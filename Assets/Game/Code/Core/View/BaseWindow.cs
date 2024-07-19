using UnityEngine;

namespace Game.Code.Core.View
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);
        
        public virtual void Hide() => gameObject.SetActive(false);
    }
}