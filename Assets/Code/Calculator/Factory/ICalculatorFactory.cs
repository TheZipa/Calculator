using Core.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Calculator.Factory
{
    public interface ICalculatorFactory : IGlobalService
    {
        UniTask CreateCalculator(Transform canvas);
    }
}