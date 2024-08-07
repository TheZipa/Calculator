﻿using Calculator.Model;
using Calculator.Presenter;
using Calculator.View;
using Core.Data.Enums;
using Core.Services.Assets;
using Core.Services.Factories.BaseFactory;
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

        public async UniTask CreateCalculator(Transform canvas)
        {
            CalculatorView calculatorView = await CreateCalculatorView(canvas);
            ICalculatorModel calculatorModel = new CalculatorModel(WindowId.Calculator, _saveLoadService, calculatorView);
            ICalculatorPresenter presenter = new CalculatorPresenter(_windowService, calculatorModel);
            calculatorView.Initialize(presenter, await CreateEquationResultsPool(calculatorView.ResultsLayout));
            _windowService.RegisterWindow(WindowId.Calculator, calculatorView);
            foreach (string equation in _saveLoadService.Progress.EquationHistory) 
                calculatorView.AddResultText(equation, calculatorModel.ResultsLayoutLimit);
        }

        private async UniTask<CalculatorView> CreateCalculatorView(Transform canvas)
        {
            await _assets.Load<GameObject>(nameof(CalculatorView));
            return await Instantiate<CalculatorView>(canvas);
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