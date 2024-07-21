using TMPro;
using UnityEngine;

namespace Calculator.View
{
    public class EquationResultView : global::Core.View.View
    {
        public Vector2 Size => _rectTransform.rect.size;
        
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TextMeshProUGUI _equation;
        
        public void Construct(string equation)
        {
            _equation.text = equation;
            transform.SetAsFirstSibling();
        }
    }
}