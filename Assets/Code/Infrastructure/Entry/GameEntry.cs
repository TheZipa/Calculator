using Infrastructure.StateFactory;
using Infrastructure.StateMachine.StateMachine;
using Infrastructure.StateMachine.States;
using VContainer.Unity;

namespace Infrastructure.Entry
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