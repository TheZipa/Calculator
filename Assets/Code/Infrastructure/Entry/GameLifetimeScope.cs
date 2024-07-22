using System;
using System.Collections.Generic;
using Core.Services.LoadingCurtain;
using Infrastructure.Data;
using Newtonsoft.Json;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Entry
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private ContainerRegistriesData _containerRegistriesData;

        protected override void Configure(IContainerBuilder builder)
        {
            RegistriesTypes registriesTypes = LoadRegistriesTypes();
            RegisterEntryPoint(builder);
            RegisterInstanceServices(builder);
            RegisterServices(builder, registriesTypes.Services);
            RegisterStates(builder, registriesTypes.States);
        }

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private RegistriesTypes LoadRegistriesTypes() =>
            JsonConvert.DeserializeObject<RegistriesTypes>(_containerRegistriesData.RegistriesJson);

        private static void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameEntry>();
        }

        private void RegisterInstanceServices(IContainerBuilder builder)
        {
            builder.RegisterComponent(_loadingCurtain).AsImplementedInterfaces();
        }

        private void RegisterServices(IContainerBuilder builder, IEnumerable<(Type, Type)> services)
        {
            foreach ((Type serviceImplementation, Type serviceInterface) in services)
                builder.Register(serviceImplementation, Lifetime.Singleton).As(serviceInterface);
        }

        private void RegisterStates(IContainerBuilder builder, IEnumerable<Type> states)
        {
            foreach (Type stateType in states)
                builder.Register(stateType, Lifetime.Singleton);
        }
    }
}