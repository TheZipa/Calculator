using Cysharp.Threading.Tasks;
using Services.App.Code.Services;
using Services.App.Code.Services.BaseFactory;

namespace Calculator.App.Code.Calculator.Factory
{
    public interface ICalculatorFactory : IBaseFactory, IGlobalService
    {
        UniTask CreateCalculator();
    }
}