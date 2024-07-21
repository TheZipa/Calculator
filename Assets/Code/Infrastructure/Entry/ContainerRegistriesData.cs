using System;

namespace Infrastructure.Entry
{
    [Serializable]
    public class ContainerRegistriesData
    {
        public Type[] States;
        public (Type, Type)[] Services;
    }
}