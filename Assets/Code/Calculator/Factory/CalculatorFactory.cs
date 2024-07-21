using Calculator.Model;
using Calculator.Presenter;
using Calculator.View;
using Core.Data.Enums;
using Core.Services.Assets;
using Core.Services.BaseFactory;
using Core.Services.SaveLoad;
using Core.Services.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Calculator.Factory
{
    public class CalculatorFactory : BaseFactory, ICalculatorFactory
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IWindowService _windowService;

        public CalculatorFactory(IAssets assets, ISaveLoadService saveLoadService, IWindowService windowService) : base(assets)
        {
            _saveLoadService = saveLoadService;
            _windowService = windowService;
        }

        public async UniTask CreateCalculator()
        {
            CalculatorView calculatorView = await CreateCalculatorView();
            ICalculatorPresenter presenter = new CalculatorPresenter(_windowService, 
                new CalculatorModel(WindowId.Calculator, _saveLoadService, calculatorView));
            calculatorView.Initialize(presenter, await CreateEquationResultsPool(calculatorView.ResultsLayout));
            foreach (string equation in _saveLoadService.Progress.EquationHistory) 
                calculatorView.AddResultText(equation);
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