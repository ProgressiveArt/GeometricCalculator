using GeometricCalculator.Application.SecondSolution.Extensions;
using GeometricCalculator.Application.SecondSolution.Strategies;
using GeometricCalculator.Core.Figures.TwoDimensionalFigures;
using GeometricCalculator.Core.Interfaces;

namespace GeometricCalculator.Application.SecondSolution.Services;

public class Calculator : IService
{
    private readonly CalculateStrategyProvider _calculateStrategyProvider;

    public Calculator(CalculateStrategyProvider calculateStrategyProvider)
    {
        _calculateStrategyProvider = calculateStrategyProvider;
    }

    public double CalculateArea(Figure figure, int? roundUpTo = null)
    {
        var strategy = _calculateStrategyProvider.GetStrategy(figure);
        var area = figure.CalculateArea(strategy, roundUpTo);
        return area;
    }
}