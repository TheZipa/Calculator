using Calculator.Presenter;
using UnityEngine.Pool;

namespace Calculator.View
{
    public interface ICalculatorView
    {
        string EquationInput { get; set; }
        void AddResultText(string result);
        void Initialize(ICalculatorPresenter presenter, IObjectPool<EquationResultView> resultsPool);
    }
}