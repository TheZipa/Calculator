using System;
using System.Linq;
using Game.Code.Calculator.View;
using Game.Code.Services.EntityContainer;

namespace Game.Code.Calculator.Presenter
{
    public class CalculatorPresenter : IFactoryEntity
    {
        private readonly CalculatorView _view;

        public CalculatorPresenter(CalculatorView view)
        {
            _view = view;
            _view.OnResultClick += Equate;
        }

        private void Equate()
        {
            int[] numbers = TryParseNumbers(_view.EquationInput);
            if (numbers is null)
            {
                _view.SetResultText(_view.EquationInput + "=ERROR");
                return;
            }
            
            int result = numbers.Sum();
            _view.SetResultText(_view.EquationInput + '=' + result);
        }

        private int[] TryParseNumbers(string equationText)
        {
            string[] numberStrings = equationText.Split('+');
            int[] numbers = new int[numberStrings.Length];
            return numberStrings.Where((t, i) => !Int32.TryParse(t, out numbers[i]) || numbers[i] < 0).Any() ? null : numbers;
        }
    }
}