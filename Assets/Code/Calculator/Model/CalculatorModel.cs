using System.Collections.Generic;
using Calculator.View;
using Core.Data.Enums;
using Core.Services.SaveLoad;

namespace Calculator.Model
{
    public class CalculatorModel : global::Core.Model.Model, ICalculatorModel
    {
        public int ResultsLayoutLimit { get; } = 7;
        public LinkedList<string> EquationHistory { get; }
        private readonly ISaveLoadService _saveLoadService;
        private readonly ICalculatorView _calculatorView;

        public CalculatorModel(WindowId windowId, ISaveLoadService saveLoadService, ICalculatorView calculatorView) : base(windowId)
        {
            _saveLoadService = saveLoadService;
            _calculatorView = calculatorView;
            
            EquationHistory = _saveLoadService.Progress.EquationHistory;
            _calculatorView.EquationInput = _saveLoadService.Progress.CurrentEquation;
        }

        public void AddEquation(string equation)
        {
            EquationHistory.AddLast(equation);
            _calculatorView.AddResultText(equation, ResultsLayoutLimit);
            _saveLoadService.Save();
        }

        public void SetEquation(string equation)
        {
            _saveLoadService.Progress.CurrentEquation = equation;
            _saveLoadService.Save();
        }
    }
}