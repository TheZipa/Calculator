using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.EntityContainer;
using Game.Code.Services.LoadingCurtain;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class CalculatorState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        public CalculatorState(IStateMachine stateMachine, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        private void Subscribe()
        {
           
        }
    }
}