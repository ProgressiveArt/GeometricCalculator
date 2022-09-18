using GeometricCalculator.Core.Figures.TwoDimensionalFigures;

namespace GeometricCalculator.Application.SecondSolution.Strategies;

internal sealed class CalculateStrategyAdapter : ICalculateStrategy
{
    private readonly object _strategy;

    private CalculateStrategyAdapter(object strategy)
    {
        _strategy = strategy;
    }

    public static CalculateStrategyAdapter SetStrategy<TFigure>(ICalculateStrategy<TFigure> strategy) where TFigure : Figure
    {
        return new CalculateStrategyAdapter(strategy);
    }

    public double CalculateArea<TFigure>(TFigure figure, int? roundUpTo = null) where TFigure : Figure
    {
        var strategy = (ICalculateStrategy<TFigure>)_strategy;
        return strategy.CalculateArea(figure, roundUpTo);
    }
}