using System;
using Infrastructure.App.Code.Infrastructure.StateMachine.States;
using Services.App.Code.Services;

namespace Infrastructure.App.Code.Infrastructure.StateMachine.StateMachine
{
    public interface IStateMachine : IGlobalService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
        void AddState<TState>(TState instance) where TState : class, IState;
        void AddState<TState, TPayload>(TState instance) where TState : class, IPayloadedState<TPayload>;
        void AddState(Type type, IExitableState instance);
    }
}