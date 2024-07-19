using Cysharp.Threading.Tasks;
using Game.Code.Services;
using Game.Code.Services.Factories.BaseFactory;

namespace Game.Code.Calculator
{
    public interface ICalculatorFactory : IBaseFactory, IGlobalService
    {
        UniTask CreateCalculator();
    }
}