using System.Collections.Generic;
using Calculator.App.Code.Calculator.View;

namespace Calculator.App.Code.Calculator.Model
{
    public class CalculatorModel : ICalculatorModel
    {
        public LinkedList<string> EquationHistory { get; } = new();
        private readonly ICalculatorView _calculatorView;

        public CalculatorModel(ICalculatorView calculatorView)
        {
            _calculatorView = calculatorView;
            // Load
        }

        public void AddEquation(string equation)
        {
            EquationHistory.AddLast(equation);
            _calculatorView.AddResultText(equation);
            // Save
        }
    }
}