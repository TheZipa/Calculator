using Infrastructure.App.Code.Infrastructure.StateMachine.StateMachine;
using Services.App.Code.Services.LoadingCurtain;

namespace Infrastructure.App.Code.Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadApplicationState(IStateMachine stateMachine, ILoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<CalculatorState>();
        }

        public void Exit()
        {
        }
    }
}