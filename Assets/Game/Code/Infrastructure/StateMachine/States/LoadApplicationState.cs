using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.LoadingCurtain;
using Game.Code.Services.StaticData;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStaticData _staticData;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadApplicationState(IStateMachine stateMachine, IStaticData staticData, ILoadingCurtain loadingCurtain)
        {
            _staticData = staticData;
            _loadingCurtain = loadingCurtain;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<CreateCalculatorState>();
        }

        public void Exit()
        {
        }
    }
}