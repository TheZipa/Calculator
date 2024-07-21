using System;
using System.Linq;
using Calculator.App.Code.Calculator.Model;

namespace Calculator.App.Code.Calculator.Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        private readonly ICalculatorModel _calculatorModel;

        public CalculatorPresenter(ICalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
        }

        public void Equate(string equation)
        {
            int[] numbers = TryParseNumbers(equation);
            if (numbers is null)
            {
                _calculatorModel.AddEquation(equation + "=ERROR");
                return;
            }
            
            int result = numbers.Sum();
            _calculatorModel.AddEquation(equation + '=' + result);
        }

        private int[] TryParseNumbers(string equationText)
        {
            string[] numberStrings = equationText.Split('+');
            int[] numbers = new int[numberStrings.Length];
            return numberStrings.Where((t, i) => !Int32.TryParse(t, out numbers[i]) || numbers[i] < 0).Any() ? null : numbers;
        }
    }
}