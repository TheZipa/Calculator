using Game.Code.Calculator;
using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.LoadingCurtain;
using Game.Code.Services.SceneLoader;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class CreateCalculatorState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICalculatorFactory _calculatorFactory;

        private const string CalculatorScene = "Сalculator";

        public CreateCalculatorState(IStateMachine stateMachine, ILoadingCurtain loadingCurtain, 
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
            _loadingCurtain.Hide();
        }

        private async void CreateCalculatorComponents()
        {
            await _calculatorFactory.CreateCalculator();
            _stateMachine.Enter<CalculatorState>();
            // здесь мог быть ваш гараж
        }
    }
}