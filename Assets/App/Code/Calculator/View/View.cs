using UnityEngine;

namespace Calculator.App.Code.Calculator.View
{
    public abstract class View : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);

        public virtual void Hide() => gameObject.SetActive(false);
    }
}