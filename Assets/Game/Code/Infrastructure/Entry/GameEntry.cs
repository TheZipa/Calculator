using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Infrastructure.StateMachine.States;
using Game.Code.Services.Factories.StateFactory;
using VContainer.Unity;

namespace Game.Code.Infrastructure.Entry
{
    public class GameEntry : IStartable
    {
        private readonly IStateMachine _stateMachine;
        private readonly IStateFactory _stateFactory;

        public GameEntry(IStateMachine stateMachine, IStateFactory stateFactory)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
        }
        
        public void Start()
        {
            _stateFactory.CreateAllStates();
            _stateMachine.Enter<LoadApplicationState>(); 
        }
    }
}