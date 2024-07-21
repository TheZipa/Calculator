using Calculator.App.Code.Calculator.Model;
using Calculator.App.Code.Calculator.Presenter;
using Calculator.App.Code.Calculator.View;
using Cysharp.Threading.Tasks;
using Services.App.Code.Services.Assets;
using Services.App.Code.Services.BaseFactory;
using Services.App.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.Pool;

namespace Calculator.App.Code.Calculator.Factory
{
    public class CalculatorFactory : BaseFactory, ICalculatorFactory
    {
        public CalculatorFactory(IAssets assets, IEntityContainer entityContainer) : base(assets, entityContainer)
        {
        }

        public async UniTask CreateCalculator()
        {
            CalculatorView calculatorView = await CreateCalculatorView();
            ICalculatorPresenter presenter = new CalculatorPresenter(new CalculatorModel(calculatorView));
            calculatorView.Initialize(presenter, await CreateEquationResultsPool(calculatorView.ResultsLayout));
        }

        private async UniTask<CalculatorView> CreateCalculatorView()
        {
            await _assets.Load<GameObject>(nameof(CalculatorView));
            return await Instantiate<CalculatorView>();
        }

        private async UniTask<IObjectPool<EquationResultView>> CreateEquationResultsPool(Transform layout)
        {
            await _assets.Load<GameObject>(nameof(EquationResultView));
            return new ObjectPool<EquationResultView>(
                () => Instantiate<EquationResultView>(layout).GetAwaiter().GetResult(),
                equationResult => equationResult.Show(), equationResult => equationResult.Hide(),
                Object.Destroy, false, 15, 150);
        }
    }
}