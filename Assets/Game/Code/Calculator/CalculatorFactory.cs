using Cysharp.Threading.Tasks;
using Game.Code.Calculator.Presenter;
using Game.Code.Calculator.View;
using Game.Code.Services.Assets;
using Game.Code.Services.EntityContainer;
using Game.Code.Services.Factories.BaseFactory;

namespace Game.Code.Calculator
{
    public class CalculatorFactory : BaseFactory, ICalculatorFactory
    {
        public CalculatorFactory(IAssets assets, IEntityContainer entityContainer) : base(assets, entityContainer)
        {
        }

        public async UniTask CreateCalculator()
        {
            CalculatorView calculatorView = await Instantiate<CalculatorView>();
            CalculatorPresenter presenter = new CalculatorPresenter(calculatorView);
            _entityContainer.RegisterEntity(presenter);
        }
    }
}