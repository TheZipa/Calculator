using System;
using Game.Code.Services.LoadingCurtain;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using TypeExtensions = Game.Code.Extensions.TypeExtensions;

namespace Game.Code.Infrastructure.Entry
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            RegisterInstanceServices(builder);
            RegisterServices(builder);
            RegisterStates(builder);
        }

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private static void RegisterEntryPoint(IContainerBuilder builder) => builder.RegisterEntryPoint<GameEntry>();

        private void RegisterInstanceServices(IContainerBuilder builder)
        {
            builder.RegisterComponent(_loadingCurtain).AsImplementedInterfaces();
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            // TODO: Кэширование сервисов
            foreach ((Type serviceImplementation, Type serviceInterface) in TypeExtensions.GetAllGlobalServiceTypes())
                builder.Register(serviceImplementation, Lifetime.Singleton).As(serviceInterface);
        }

        private static void RegisterStates(IContainerBuilder builder)
        {
            foreach (Type stateType in TypeExtensions.GetAllStatesTypes())
                builder.Register(stateType, Lifetime.Singleton);
        }
    }
}