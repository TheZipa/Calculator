using Calculator.App.Code.Calculator.Presenter;
using UnityEngine.Pool;

namespace Calculator.App.Code.Calculator.View
{
    public interface ICalculatorView
    {
        string EquationInput { get; set; }
        void AddResultText(string result);
        void Initialize(ICalculatorPresenter presenter, IObjectPool<EquationResultView> resultsPool);
    }
}