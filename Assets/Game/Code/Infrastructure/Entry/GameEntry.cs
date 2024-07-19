using Game.Code.Infrastructure.StateMachine.GameStateMachine;
using Game.Code.Infrastructure.StateMachine.States;
using Game.Code.Services.Factories.StateFactory;
using VContainer.Unity;

namespace Game.Code.Infrastructure.Entry
{
    public class GameEntry : IStartable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStateFactory _stateFactory;

        public GameEntry(IGameStateMachine gameStateMachine, IStateFactory stateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _stateFactory = stateFactory;
        }
        
        public void Start()
        {
            _stateFactory.CreateAllStates();
            _gameStateMachine.Enter<LoadApplicationState>(); 
        }
    }
}