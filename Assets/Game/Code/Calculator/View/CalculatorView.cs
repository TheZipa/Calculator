using System;
using Game.Code.Core.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Calculator.View
{
    public class CalculatorView : BaseWindow
    {
        public event Action OnResultClick;
        public Transform ResultsLayout;
        public string EquationInput => _equationInputField.text;
        
        [SerializeField] private TMP_InputField _equationInputField;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Button _resultButton;

        public void Construct(string cachedEquation)
        {
            if (string.IsNullOrEmpty(cachedEquation)) return;
        }

        public void SetResultText(string result) => _resultText.text = result;
        
        private void Awake()
        {
            _resultButton.onClick.AddListener(() =>
            {
                OnResultClick?.Invoke();
            });
        }
    }
}