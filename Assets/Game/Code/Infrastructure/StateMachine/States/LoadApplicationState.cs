using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Services.LoadingCurtain;
using Game.Code.Services.StaticData;

namespace Game.Code.Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticData _staticData;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadApplicationState(IGameStateMachine gameStateMachine, IStaticData staticData, ILoadingCurtain loadingCurtain)
        {
            _staticData = staticData;
            _loadingCurtain = loadingCurtain;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
            _gameStateMachine.Enter<MenuState>();
        }

        public void Exit()
        {
        }
    }
}