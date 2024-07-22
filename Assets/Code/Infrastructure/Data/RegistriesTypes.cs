using System;

namespace Infrastructure.Data
{
    [Serializable]
    public class RegistriesTypes
    {
        public Type[] States;
        public (Type, Type)[] Services;
    }
}