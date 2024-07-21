using System.Collections.Generic;

namespace Calculator.App.Code.Calculator.Model
{
    public interface ICalculatorModel
    {
        LinkedList<string> EquationHistory { get; }
        void AddEquation(string equation);
    }
}