using Calculator.App.Code.Calculator.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace Calculator.App.Code.Calculator.View
{
    public class CalculatorView : View, ICalculatorView
    {
        public Transform ResultsLayout;
        
        public string EquationInput
        {
            get => _equationInputField.text;
            set => _equationInputField.text = value;
        }

        [SerializeField] private TMP_InputField _equationInputField;
        [SerializeField] private RectTransform _windowTransform;
        [SerializeField] private Button _resultButton;

        private ICalculatorPresenter _calculatorPresenter;
        private IObjectPool<EquationResultView> _resultsPool;

        private void Awake() => _resultButton.onClick.AddListener(() => _calculatorPresenter.Equate(EquationInput));

        public void Initialize(ICalculatorPresenter presenter, IObjectPool<EquationResultView> resultsPool)
        {
            _calculatorPresenter = presenter;
            _resultsPool = resultsPool;
        }

        public void AddResultText(string result)
        {
            EquationResultView equationResult = _resultsPool.Get();
            equationResult.Construct(result);
            ResizeWindow(equationResult.Size);
        }

        private void ResizeWindow(Vector2 elementSize)
        {
            if (ResultsLayout.childCount > 7) return;
            _windowTransform.sizeDelta += new Vector2(0, elementSize.y);
        }
    }
}