using System;
using System.Linq;
using Calculator.Model;
using Core.Data.Enums;
using Core.Services.Windows;

namespace Calculator.Presenter
{
    public class CalculatorPresenter : global::Core.Presenter.Presenter, ICalculatorPresenter
    {
        private readonly ICalculatorModel _calculatorModel;

        public CalculatorPresenter(IWindowService windowService, ICalculatorModel calculatorModel) : base(windowService)
        {
            _calculatorModel = calculatorModel;
        }

        public void Equate(string equation)
        {
            int[] numbers = TryParseNumbers(equation);
            if (numbers is null)
            {
                _calculatorModel.AddEquation(equation + "=ERROR");
                _windowService.Close(WindowId.Calculator);
                _windowService.Open(WindowId.MessageBox);
                return;
            }
            
            int result = numbers.Sum();
            _calculatorModel.AddEquation(equation + '=' + result);
            _calculatorModel.SetEquation(String.Empty);
        }

        public void UpdateEquation(string equation) => _calculatorModel.SetEquation(equation);

        private int[] TryParseNumbers(string equationText)
        {
            string[] numberStrings = equationText.Split('+');
            int[] numbers = new int[numberStrings.Length];
            return numberStrings.Where((t, i) => !Int32.TryParse(t, out numbers[i]) || numbers[i] < 0).Any() ? null : numbers;
        }
    }
}