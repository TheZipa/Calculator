using Core.Services;
using Core.Services.BaseFactory;
using Cysharp.Threading.Tasks;

namespace Calculator.Factory
{
    public interface ICalculatorFactory : IBaseFactory, IGlobalService
    {
        UniTask CreateCalculator();
    }
}