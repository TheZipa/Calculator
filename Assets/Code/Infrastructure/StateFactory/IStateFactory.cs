using Core.Services;

namespace Infrastructure.StateFactory
{
    public interface IStateFactory : IGlobalService
    {
        void CreateAllStates();
    }
}