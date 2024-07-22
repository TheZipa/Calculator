using Calculator.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

namespace Calculator.View
{
    public class CalculatorView : global::Core.View.View, ICalculatorView
    {
        public Transform ResultsLayout;
        
        public string EquationInput
        {
            get => _equationInputField.text;
            set => _equationInputField.text = value;
        }

        [SerializeField] private TMP_InputField _equationInputField;
        [SerializeField] private RectTransform _windowTransform;
        [SerializeField] private RectTransform _resultScrollTransform;
        [SerializeField] private Button _resultButton;

        private ICalculatorPresenter _calculatorPresenter;
        private IObjectPool<EquationResultView> _resultsPool;

        public void Initialize(ICalculatorPresenter presenter, IObjectPool<EquationResultView> resultsPool)
        {
            _calculatorPresenter = presenter;
            _resultsPool = resultsPool;
            
            _resultButton.onClick.AddListener(() => _calculatorPresenter.Equate(EquationInput));
            _equationInputField.onValueChanged.AddListener(equation => _calculatorPresenter.UpdateEquation(equation));
        }

        public void AddResultText(string result, int viewLimit)
        {
            EquationResultView equationResult = _resultsPool.Get();
            equationResult.Construct(result);
            ResizeWindow(equationResult.Size, viewLimit);
        }

        private void ResizeWindow(Vector2 elementSize, int limit)
        {
            if (ResultsLayout.childCount > limit) return;
            Vector2 addSize = new(0, elementSize.y);
            _windowTransform.sizeDelta += addSize;
            _resultScrollTransform.sizeDelta += addSize;
        }
    }
}