using Calculator.App.Code.Calculator.Factory;
using Infrastructure.App.Code.Infrastructure.StateMachine.StateMachine;
using Services.App.Code.Services.LoadingCurtain;
using Services.App.Code.Services.SceneLoader;

namespace Infrastructure.App.Code.Infrastructure.StateMachine.States
{
    public class CalculatorState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICalculatorFactory _calculatorFactory;

        private const string CalculatorScene = "Сalculator";

        public CalculatorState(IStateMachine stateMachine, ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, ICalculatorFactory calculatorFactory)
        {
            _stateMachine = stateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _calculatorFactory = calculatorFactory;
        }

        public void Enter() => _sceneLoader.LoadScene(CalculatorScene, CreateCalculatorComponents);

        public void Exit()
        {
        }

        private async void CreateCalculatorComponents()
        {
            await _calculatorFactory.CreateCalculator();
            _loadingCurtain.Hide();
        }
    }
}