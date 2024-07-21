using Core.Services.LoadingCurtain;
using Core.Services.SaveLoad;
using Infrastructure.StateMachine.StateMachine;

namespace Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISaveLoadService _saveLoadService;

        public LoadApplicationState(IStateMachine stateMachine, ILoadingCurtain loadingCurtain, ISaveLoadService saveLoadService)
        {
            _loadingCurtain = loadingCurtain;
            _saveLoadService = saveLoadService;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            _saveLoadService.Load();
            _stateMachine.Enter<CalculatorState>();
        }

        public void Exit()
        {
        }
    }
}