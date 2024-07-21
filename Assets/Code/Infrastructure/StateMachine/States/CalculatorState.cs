using Calculator.Factory;
using Core.Services.Factories.UIFactory;
using Core.Services.LoadingCurtain;
using Core.Services.SceneLoader;
using Infrastructure.StateMachine.StateMachine;
using UnityEngine;

namespace Infrastructure.StateMachine.States
{
    public class CalculatorState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly IUIFactory _uiFactory;

        private const string CalculatorScene = "Сalculator";

        public CalculatorState(IStateMachine stateMachine, ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, ICalculatorFactory calculatorFactory, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _calculatorFactory = calculatorFactory;
            _uiFactory = uiFactory;
        }

        public void Enter() => _sceneLoader.LoadScene(CalculatorScene, CreateCalculatorComponents);

        public void Exit()
        {
        }

        private async void CreateCalculatorComponents()
        {
            Canvas canvas = await _uiFactory.CreateCanvas();
            await _calculatorFactory.CreateCalculator(canvas.transform);
            _loadingCurtain.Hide();
        }
    }
}