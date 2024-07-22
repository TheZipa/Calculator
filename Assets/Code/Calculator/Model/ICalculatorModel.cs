using System.Collections.Generic;

namespace Calculator.Model
{
    public interface ICalculatorModel
    {
        LinkedList<string> EquationHistory { get; }
        int ResultsLayoutLimit { get; }
        void AddEquation(string equation);
        void SetEquation(string equation);
    }
}