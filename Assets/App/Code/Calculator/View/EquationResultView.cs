using TMPro;
using UnityEngine;

namespace Calculator.App.Code.Calculator.View
{
    public class EquationResultView : View
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