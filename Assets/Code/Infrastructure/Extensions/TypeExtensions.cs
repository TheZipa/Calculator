using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Services;
using Core.Services.Factories.BaseFactory;
using Infrastructure.StateMachine.States;

namespace Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllStatesTypes() =>
            Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                type.GetInterfaces().Contains(typeof(IExitableState)) && type.IsClass);

        public static IEnumerable<(Type, Type)> GetAllGlobalServiceTypes()
        {
            List<(Type, Type)> services = new(15);

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies) 
                AddServices(services, GetAssemblyServiceTypes(assembly));

            return services;
        }

        private static IEnumerable<Type> GetAssemblyServiceTypes(Assembly assembly) =>
            assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Contains(typeof(IGlobalService)) && type.IsClass);

        private static void AddServices(List<(Type, Type)> services, IEnumerable<Type> serviceTypes)
        {
            foreach (Type serviceType in serviceTypes)
            {
                Type instanceType = serviceType;
                Type interfaceType = serviceType.GetInterfaces()
                    .First(type => type != typeof(IGlobalService) && type != typeof(IBaseFactory));
                services.Add((instanceType, interfaceType));
            }
        }
    }
}