using System;
using Infrastructure.Extensions;
using Infrastructure.StateMachine.StateMachine;
using Infrastructure.StateMachine.States;
using VContainer;

namespace Infrastructure.StateFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IStateMachine _stateMachine;

        public StateFactory(IObjectResolver objectResolver, IStateMachine stateMachine)
        {
            _objectResolver = objectResolver;
            _stateMachine = stateMachine;
        }
        
        public void CreateAllStates()
        {
            foreach (Type stateType in TypeExtensions.GetAllStatesTypes())
                _stateMachine.AddState(stateType, _objectResolver.Resolve(stateType) as IExitableState);
        }
    }
}