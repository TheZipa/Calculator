using Services.App.Code.Services;

namespace Infrastructure.App.Code.Infrastructure.StateFactory
{
    public interface IStateFactory : IGlobalService
    {
        void CreateAllStates();
    }
}